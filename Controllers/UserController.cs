using System.Threading.Tasks;
using System.Collections.Generic;
using scrubcardshopAPI.Models;
using scrubcardshopAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace scrubcardshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUserService _service;

        public UserController (IUserService userService)
        {
            _service = userService;
        }

        [HttpGet]
        public async Task <IActionResult> Get()
        {
            var userlist = await _service.GetUsers();
            return Ok(userlist);

        }

        [HttpGet("{id:length(24)}", Name="GetUser")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user =  await _service.GetUser(id);
            
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task <IActionResult> Create(CreateUserRequest user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var User = await _service.CreateUser(user);
            var location = string.Format("/api/users/{0}",User.Id);
            return Created(location,User);
        }

        [HttpPut("{id:length(24)}")]
        public async Task <IActionResult>  Update(string id, CreateUserRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await  _service.UpdateUser(id,updateRequest);

            return NoContent();
        }
        
        [HttpDelete("{id:length(24)}")]
        public async Task <IActionResult> Delete(string id)
        {
            await _service.RemoveUser(id);
            return NoContent();
     
        }       
    }
}