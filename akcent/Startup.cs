using akcent.Db;
using akcent.Repositories;

namespace akcent
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.Configure<DbSettings>(Configuration.GetSection("DatabaseSettings"));
            services.AddTransient<DbConnection>();
            services.AddTransient(provider =>
                provider.GetRequiredService<DbConnection>().CreateConnection());

            services.AddScoped<IWorkerRepository, WorkerRepository>();
        }

        public void ConfigureServices(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
