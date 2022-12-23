using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyEmployeeApplication.IService;
using MyEmployeeApplication.Model;
using MyEmployeeApplication.Service;

namespace MyEmployeeApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        private IConfiguration _config;

        public JWTController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]

        public string JWTToken(Employee employee)
        {
            var jwt = new JwtServices(_config);
            var token = jwt.GenerateSecurityToken(employee.Email);
            return token;
        }

    }
}
