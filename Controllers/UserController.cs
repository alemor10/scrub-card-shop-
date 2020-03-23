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

        public UserController (UserService userService)
        {
            _service = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            var userlist = await _service.Get();
            return Ok(userlist);

        }

        [HttpGet("{id:length(24)}", Name="GetUser")]
        public ActionResult<User> Get(string id)
        {
            var user =  _userservice.Get(id);
            
            if(user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _userservice.Create(user);
            return CreatedAtRoute("GetUser",new {id =user.Id.ToString()} ,user);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User userIn)
        {
            var user = _userservice.Get(id);

            if (user == null)
            {
                return NotFound();
            }
            _userservice.Update(id,userIn);

            return NoContent();
        }
        
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = _userservice.Get(id);
            
            if (user == null)
            {
                return NotFound();
            }
            
            _userservice.Delete(user.Id);

            return NoContent();
     
        }       
    }
}