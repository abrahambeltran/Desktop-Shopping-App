using Library.TaskManagement.Models;
using Microsoft.AspNetCore.Mvc;
using TaskApplication.API.Database;

namespace TaskApplication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController:ControllerBase
    {
        private readonly ILogger<AppointmentController> _logger;

        public AppointmentController(ILogger<AppointmentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Appointment> Get()
        {
            return FakeDatabase.Appointments;
        }
    }
}
