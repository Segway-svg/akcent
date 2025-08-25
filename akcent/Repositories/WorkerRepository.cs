using akcent.Models.Worker;
using Dapper;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace akcent.Repositories
{
    public class WorkerRepository : IWorkerRepository, IDisposable
    {
        private readonly SqlConnection _connection;
        private bool _disposed;
        public WorkerRepository(SqlConnection connection)
        {
            _connection = connection;
        }
        public async Task<bool> ValidateFilterAsync(PersonFilter filter)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(filter);

            if (!Validator.TryValidateObject(filter, validationContext, validationResults, true))
            {
                throw new ValidationException("Ошибка валидации фильтра: " +
                    string.Join("; ", validationResults.Select(v => v.ErrorMessage)));
            }

            if (filter.StatusId.HasValue)
            {
                var statuses = await GetStatusesAsync();
                if (!statuses.Any(s => s.Id == filter.StatusId))
                    throw new ValidationException("Указанный статус не существует");
            }

            if (filter.DepartmentId.HasValue)
            {
                var deps = await GetDepartmentsAsync();
                if (!deps.Any(d => d.Id == filter.DepartmentId))
                    throw new ValidationException("Указанный отдел не существует");
            }

            if (filter.PostId.HasValue)
            {
                var posts = await GetPostsAsync();
                if (!posts.Any(p => p.Id == filter.PostId))
                    throw new ValidationException("Указанная должность не существует");
            }

            return true;
        }

        public async Task<List<Person>> GetEmployeesAsync(PersonFilter filter)
        {
            await ValidateFilterAsync(filter);

            using var connection = new SqlConnection(_connection.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@StatusId", filter.StatusId);
            parameters.Add("@DepartmentId", filter.DepartmentId);
            parameters.Add("@PostId", filter.PostId);
            parameters.Add("@LastNamePart", filter.LastNamePart);
            parameters.Add("@SortBy", filter.SortBy);
            parameters.Add("@SortAscending", filter.SortAscending);

            var employees = await connection.QueryAsync<Person>(
                "sp_GetEmployees",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return employees.ToList();
        }

        public async Task<List<Status>> GetStatusesAsync()
        {
            using var connection = new SqlConnection(_connection.ConnectionString);
            return (await connection.QueryAsync<Status>(
                "sp_GetStatuses",
                commandType: CommandType.StoredProcedure
            )).ToList();
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            using var connection = new SqlConnection(_connection.ConnectionString);
            return (await connection.QueryAsync<Department>(
                "sp_GetDepartments",
                commandType: CommandType.StoredProcedure
            )).ToList();
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            using var connection = new SqlConnection(_connection.ConnectionString);
            return (await connection.QueryAsync<Post>(
                "sp_GetPosts",
                commandType: CommandType.StoredProcedure
            )).ToList();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_connection != null)
                    {
                        _connection.Close();
                        _connection.Dispose();
                    }
                }

                _disposed = true;
            }
        }
    }
}