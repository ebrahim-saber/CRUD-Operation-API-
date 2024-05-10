using AutoMapper;
using Frist_API_Project.Data;
using Frist_API_Project.Models;
using Frist_API_Project.Models.DatatTransfareObject;
using Frist_API_Project.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Frist_API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepository _db;
        private readonly IMapper mapper;
        public APIResponce _responce;

        public EmployeeController(IEmployeeRepository db ,IMapper mapper )
        {
          
            this._db = db;
            this.mapper = mapper;
            _responce = new();
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponce>> GetEmployees()
        {
            var employees = await _db.GetAll();
            _responce.Result = mapper.Map<List<EmployeeDto>>(employees);
            _responce.StatusCode = HttpStatusCode.OK;
            return Ok(_responce);
        }


        [HttpGet("{id}", Name = "GetEmployee")]
        public async Task<ActionResult<APIResponce>> GetEmployeeById(int id)
        {
            if (id == 0)
            {
                _responce.StatusCode= HttpStatusCode.BadRequest;
                _responce.ErrorMessage = new() { "Id = 0" };
                _responce.IsSuccess = false;
                return BadRequest(_responce);
            }
            Employee myemb =  await _db.Get(x => x.Id == id);
            if (myemb == null)
            {
                _responce.StatusCode = HttpStatusCode.NotFound;
                _responce.ErrorMessage = new() { "Id = Null please Enter Id" };
                _responce.IsSuccess = false;
                return BadRequest(_responce);
            }
            else
            {
                _responce.Result = mapper.Map<List<EmployeeDto>>(myemb);
                _responce.StatusCode = HttpStatusCode.OK;
                return Ok(myemb);
            }
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto employee)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Employee myemp =  mapper.Map<Employee>(employee);
            //Employee myemp = new()
            //{
            //    Name = employee.Name,
            //    departmentId = employee.departmentId,
            //    City = employee.City,
            //    street = employee.street,
            //};
            await _db.Add(myemp);

            return Ok(employee);
        }



        // id his name is route for value.


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateEmployee(int id, [FromBody] UpdateEmployeeDto obj)
        {
            if (id == 0)
            {
                ModelState.AddModelError("", " id is = 0 ");
            }
            if (ModelState.IsValid)
            {
                var employee =  _db.Get(x => x.Id == id,tracking:true);
                if (employee != null)
                {
                  _db.Update(mapper.Map<Employee>(obj));
                   
                }
                return Ok(obj);
            }
            return BadRequest();

        }


        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (id == 0)
            {
                ModelState.AddModelError("", " Id is = 0");
            }

            Employee emp = await _db.Get(x => x.Id == id);
            if (emp != null)
            {
                _db.Delete(emp);
                return Ok();
            }
            return BadRequest();
        }
    }
}
