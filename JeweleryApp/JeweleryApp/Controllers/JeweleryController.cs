using System;
using System.Threading.Tasks;
using JeweleryApp.Models;
using JeweleryApp.Repositories;
using JeweleryApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JeweleryApp.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [ApiController]
    [Route("[controller]")]
    public class JeweleryController : ControllerBase
    {
        private readonly IJeweleryRepository repository;
        private readonly IJeweleryService loginService;

        public JeweleryController(IJeweleryRepository repository, IJeweleryService loginService)
        {
            this.repository = repository;
            this.loginService = loginService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(UserModel user)
        {
            if (await repository.IsUserValid(user.UserId, user.Password))
                return Ok(loginService.GenerateToken(user.UserId));
            else
                return NotFound("Invalid Login Credentials !!!");
        }


        [HttpGet("{title}")]
        [Authorize]
        public async Task<IActionResult> DiscountCalculator(decimal price, int weight, decimal? discount)
        {
            try
            {
                return Ok(await loginService.DiscountCalculator(price,weight,discount??0));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Some error occurred, please try again later !!");
            }
        }

    }
}
