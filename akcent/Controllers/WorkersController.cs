using akcent.Models.Worker;
using akcent.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace akcent.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkersController : ControllerBase
    {

        private readonly ILogger<WorkersController> _logger;
        private IWorkerRepository _workerRepository;

        public WorkersController(ILogger<WorkersController> logger, IWorkerRepository workerRepository)
        {
            _logger = logger;
            _workerRepository = workerRepository;
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetEmployees([FromBody] PersonFilter filter)
        {
            try
            {
                if (filter == null)
                    return BadRequest("Фильтр не может быть пустым");

                var employees = await _workerRepository.GetEmployeesAsync(filter);
                return Ok(employees);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка сервера: {ex.Message}");
            }
        }

        [HttpGet("statuses")]
        public async Task<IActionResult> GetStatuses()
        {
            try
            {
                var statuses = await _workerRepository.GetStatusesAsync();
                return Ok(statuses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка сервера: {ex.Message}");
            }
        }

        [HttpGet("departments")]
        public async Task<IActionResult> GetDepartments()
        {
            try
            {
                var departments = await _workerRepository.GetDepartmentsAsync();
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка сервера: {ex.Message}");
            }
        }

        [HttpGet("posts")]
        public async Task<IActionResult> GetPosts()
        {
            try
            {
                var posts = await _workerRepository.GetPostsAsync();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка сервера: {ex.Message}");
            }
        }
    }
}