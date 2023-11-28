using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService) {
            _employeeService= employeeService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _employeeService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _employeeService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] EmployeeModel model)
        {
            var result = _employeeService.Insert(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] EmployeeModel model)
        {
            var result = _employeeService.Update(id, model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _employeeService.Delete(id);
            return Ok(result);
        }
    }
}
