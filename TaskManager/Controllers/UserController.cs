using Domain.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using System.Web.Http;
using System.Web.Mvc;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace TaskManager.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/users
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllUsers()
        {
            try
            {
                var users = _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/users/{id}
        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUserById(int id)
        {
            try
            {
                var user = _userService.GetAllUsers().FirstOrDefault(u => u.UserID == id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/users
        [HttpPost]
        [Route("")]
        public IHttpActionResult PostUser([FromBody] Users user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _userService.CreateUser(user);
                var responseUri = new Uri(Request.RequestUri, $"/api/users/{user.UserID}");
                return Created(responseUri.ToString(), user);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/users/login
        [HttpPost]
        [Route("login")]
        [ResponseType(typeof(Users))]
        public IHttpActionResult Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = _userService.GetUserByEmailAndPassword(request.EmailOrUsername, request.Password);
                if (user == null)
                {
                    return Unauthorized();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/users/username-exists/{username}
        [HttpGet]
        [Route("username-exists/{username}")]
        public IHttpActionResult IsUsernameExist(string username)
        {
            try
            {
                var exists = _userService.IsUsernameExist(username);
                return Ok(exists);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/users/email-exists/{email}
        [HttpGet]
        [Route("email-exists/{email}")]
        public IHttpActionResult IsEmailExist(string email)
        {
            try
            {
                var exists = _userService.IsEmailExist(email);
                return Ok(exists);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }

    // A simple request model for login
    public class LoginRequest
    {
        public string EmailOrUsername { get; set; }
        public string Password { get; set; }
    }
}
