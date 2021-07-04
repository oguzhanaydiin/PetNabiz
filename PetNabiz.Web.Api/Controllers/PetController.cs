using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetNabiz.DAL;
using PetNabiz.Domain.Models;
using PetNabiz.Domain.RequestModels;
using PetNabiz.Domain.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetNabiz.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private UnitOfWork _UnitOfWork { get; set; }

        public PetController()
        {
            _UnitOfWork = new UnitOfWork(new DatabaseContext());
        }

        /// <summary>
        /// Get All Pets
        /// </summary>
        /// <returns>
        ///     {
        ///     "items":[Pet],
        ///     "status",
        ///     "errormessage"
        ///     }
        /// </returns>
        // GET: api/<PetController>
        [HttpGet("getAllPets")]
        public IActionResult Get()
        {
            var pets = _UnitOfWork.PetRepository.GetAll();
            if (!pets.Any())
            {
                return Ok(new CommonResponseModel<IEnumerable<Pet>>(pets, "204", "Eleman yok"));
            }
            else
            {
                return Ok(new CommonResponseModel<IEnumerable<Pet>>(pets, "200", "Basarili"));
            }

        }


        /// <summary>
        /// Get Pet By Id
        /// </summary>
        /// <returns>
        ///     {
        ///     "items":Pet,
        ///     "status",
        ///     "errormessage"
        ///     }
        /// </returns>
        // GET api/<PetController>/5
        [HttpGet("getPetById")]
        public IActionResult Get(int id)
        {
            var pet = _UnitOfWork.PetRepository.GetById(id);

            if (pet == null)
            {
                return Ok(new CommonResponseModel<Pet>(null, "204", "Eleman yok"));
            }
            else
            {
                return Ok(new CommonResponseModel<Pet>(pet, "200", "Basarili"));
            }
        }

        /// <summary>
        /// If the given request's passport number is cant found by Pet table
        /// Then add the given request as a pet
        /// </summary>
        /// <returns>
        ///     {
        ///     "items":Pet,
        ///     "status",
        ///     "errormessage"
        ///     }
        /// </returns>
        // POST api/<PetController>/
        [HttpPost("addPet")]
        public IActionResult Post([FromBody] PetRequestModel petReq)
        {
            var found = _UnitOfWork.PetRepository.GetAll().FirstOrDefault(item => item.PassportNumber== petReq.PassportNumber);
            if (found == null)
            {
                var pet = new Pet()
                {
                    Name = petReq.Name,
                    AnimalType = petReq.AnimalType,
                    IsActive = true,
                    NeutoringState = petReq.NeutoringState,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    PassportNumber = petReq.PassportNumber
                };
                _UnitOfWork.PetRepository.Add(pet);
                _UnitOfWork.Complete();

                return Ok(new CommonResponseModel<Pet>(pet, "200", "Basariyla eklendi"));
            }
            else
            {
                var pet = new Pet();
                return BadRequest(new CommonResponseModel<Pet>(pet,"406", "ayni passport numarali hayvan var"));
            }
            
        }
        /// <summary>
        /// if given id can found by database, delete the record from Pet table
        /// </summary>
        /// <returns>
        ///     {
        ///     "items":Pet,
        ///     "status",
        ///     "errormessage"
        ///     }
        /// </returns>
        // POST api/<PetController>/
        [HttpDelete("deleteById")]
        public IActionResult Delete(int id)
        {
            var pet = _UnitOfWork.PetRepository.GetById(id);
            if (pet != null)
            {
                _UnitOfWork.PetRepository.Remove(id);
                _UnitOfWork.Complete();

                return Ok(new CommonResponseModel<Pet>(pet, "200", "Basariyla silindi"));
            }
            else
            {
                return BadRequest(new CommonResponseModel<Pet>(pet, "403", "hayvan bulunamadi"));
            }
        }
    }


}
