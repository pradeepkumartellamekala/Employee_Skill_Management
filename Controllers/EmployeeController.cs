using Employee_Skill_Management.DAL;
using Employee_Skill_Management.Security;
using Employee_Skill_Management.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Skill_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeDAL empDal;

        public EmployeeController(IConfiguration config) 
        { 
            empDal = new EmployeeDAL(config);
        }
        [HttpPost]
        [Route("/login")]
        public IActionResult Login(Login_User loginData)
        {
            LoggedInEmployeeData loggedInEmployeeData = null;
            var isValid = empDal.ValidateUser(loginData);
            if (isValid)
            {
                loggedInEmployeeData = empDal.GetLoggedUserData(loginData.loginId);
                return Ok(loggedInEmployeeData);
            }
            else
            {
                return BadRequest(new { status=0, message = "invalid user"});
            }
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            return Ok(empDal.GetAllEmps());
        }
        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee(Employee emp)
        {

            var result = empDal.AddNewEmployee(emp);
            return result.ToLower() == "success" ? Ok(emp) : BadRequest(result);
        }

        [HttpPost]
        [Route("/hash")]
        public IActionResult HashedPassword(string pwd)
        {
            string password = pwd;
            byte[] salt = PasswordHasher.GenerateSalt();
            string hashedPassword = PasswordHasher.HashPassword(password, salt);
            return Ok(hashedPassword);
        }
    }
}
