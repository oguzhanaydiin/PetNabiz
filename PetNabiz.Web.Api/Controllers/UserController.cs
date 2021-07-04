using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetNabiz.DAL;
using PetNabiz.Domain.Models;
using PetNabiz.Domain.RequestModels;
using PetNabiz.Domain.ResponseModels;
using PetNabiz.Web.Services.Abstract;
using PetNabiz.Web.Services.Concrete;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace PetNabiz.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UnitOfWork _UnitOfWork { get; set; }
        private UserService _userService { get; set; }

        public UserController()
        {
            _UnitOfWork = new UnitOfWork(new DatabaseContext());
            _userService = new UserService();
        }

        /// <summary>
        ///     Get all users
        /// </summary>
        /// <returns>
        ///     {
        ///     "items":[User],
        ///     "status",
        ///     "errormessage"
        ///     }
        /// </returns>
        // GET: api/<UserController>
        [HttpGet("getAllUsers")]
        public IActionResult Get()
        {
            var users = _UnitOfWork.UserRepository.GetAll();
            if (!users.Any())
            {
                return Ok(new CommonResponseModel<IEnumerable<User>>(users, "204", "Eleman yok"));
            }
            else
            {
                return Ok(new CommonResponseModel<IEnumerable<User>>(users, "200", "Basarili"));
            }


        }
        /// <summary>
        ///     get the user from db if id valid
        /// </summary>
        /// <param>  int id</param>
        /// <returns>
        ///     {
        ///     "items":User,
        ///     "status",
        ///     "errormessage"
        ///     }
        /// </returns>
        // GET api/<UserController>/5
        [HttpGet("getUserById")]
        public IActionResult Get(int id)
        {
            var user = _UnitOfWork.UserRepository.GetById(id);
            if (user == null)
            {
                return Ok(new CommonResponseModel<User>(null, "204", "Eleman yok"));
            }
            else
            {
                return Ok(new CommonResponseModel<User>(user, "200", "Basarili"));
            }
        }

        // POST api/<UserController>/
        [HttpPost("addUser")]
        public IActionResult Post([FromBody] UserRequestModel userReq)
        {
            var found = _UnitOfWork.UserRepository.GetAll().FirstOrDefault(item => item.MailAddress == userReq.MailAddress);
            if (found== null)
            {
                var user = new User()
                {
                    BirthDate = "16-08-1999",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    IsActive = true,
                    MailAddress = userReq.MailAddress,
                    Name = userReq.Name,
                    VetName = userReq.VetName,
                    Password = userReq.Password,
                    PhoneNumber = userReq.PhoneNumber,
                    UserType = "vet"

                };

                _UnitOfWork.UserRepository.Add(user);
                _UnitOfWork.Complete();

                return Ok(new CommonResponseModel<User>(user, "200", "Basariyla eklendi"));

            }
            else
            {
                return BadRequest(new CommonResponseModel<User>(null, "406", "Bu mail numarasıyla kullanıcı var!"));
            }


        }

        // POST api/<UserController>/
        [HttpDelete("deleteById")]
        public IActionResult Delete(int id)
        {
            _UnitOfWork.UserRepository.Remove(id);
            _UnitOfWork.Complete();

            return Ok();
        }


        // GET api/<UserController>/5
        [HttpPost("decodeToken")]
        public IActionResult DecodeToken ([FromBody] TokenRequestModel tokenReq) 
        {
            var token = tokenReq.Token;
            var handler = new JwtSecurityTokenHandler();
            var response = handler.ReadJwtToken(token);

            var jsonResponse = JsonConvert.SerializeObject(new { items = response });
            return Ok(jsonResponse);
        }

        // POST api/<UserController>/
        [HttpPost("auth")]
        public IActionResult Auth([FromBody] UserRequestModel userReq)
        {
            var user = _userService.Authenticate(userReq.MailAddress, userReq.Password);
            if (user == null)
            {
                return BadRequest(new { message = "kullanici adi veya sifre hatali!" });
            }
            else
            {
                return Ok(user);
            }
        }


    }

    

    
}
