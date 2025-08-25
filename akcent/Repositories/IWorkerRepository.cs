using akcent.Models.Worker;

namespace akcent.Repositories
{
    public interface IWorkerRepository
    {
        Task<List<Person>> GetEmployeesAsync(PersonFilter filter);
        Task<List<Status>> GetStatusesAsync();
        Task<List<Department>> GetDepartmentsAsync();
        Task<List<Post>> GetPostsAsync();
        Task<bool> ValidateFilterAsync(PersonFilter filter);
    }
}
