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
    public class TreatmentController : ControllerBase
    {
        private UnitOfWork _UnitOfWork { get; set; }

        public TreatmentController()
        {
            _UnitOfWork = new UnitOfWork(new DatabaseContext());
        }

        /// <summary>
        /// Get All Treatment Data
        /// </summary>
        /// <returns>
        ///     {
        ///     "items":Treatment,
        ///     "status",
        ///     "errormessage"
        ///     }
        /// </returns>
        // GET: api/<TreatmentController>
        [HttpGet("getAllTreatments")]
        public IActionResult Get()
        {
            var treatments = _UnitOfWork.TreatmentRepository.GetAll();
            if(!treatments.Any())
            {
                return Ok(new CommonResponseModel<IEnumerable<Treatment>>(treatments, "204", "Eleman bulunamadi"));
            }
            else
            {
                return Ok(new CommonResponseModel<IEnumerable<Treatment>>(treatments, "200", "Basarili"));
            }
        }

        /// <summary>
        ///     Get treatment data with given id input
        /// </summary>
        /// <param>
        ///     int id
        /// </param>
        /// <returns>
        ///     {
        ///     "items":Treatment,
        ///     "status",
        ///     "errormessage"
        ///     }
        /// </returns>
        // GET api/<TreatmentController>/5
        [HttpGet("getTreatmentById")]
        public IActionResult Get(int id)
        {
            var pet = _UnitOfWork.TreatmentRepository.GetById(id);
            if(pet == null)
            {
                return Ok(new CommonResponseModel<Treatment>(null, "204", "Eleman yok"));
            }
            else
            {
                return Ok(new CommonResponseModel<Treatment>(pet, "200", "Basarili"));
            }
            
        }

        /// <summary>
        ///     add treatment if passport number of request exists in Pet table
        /// </summary>
        /// <param 
        ///     TreatmentRequestModel
        /// </param>
        /// <returns>
        ///     {
        ///     "items":Treatment,
        ///     "status",
        ///     "errormessage"
        ///     }
        /// </returns>
        // POST api/<TreatmentController>/
        [HttpPost("addPetTreatment")]
        public IActionResult Post([FromBody] TreatmentRequestModel treatReq)
        {
            var found = _UnitOfWork.PetRepository.GetAll().FirstOrDefault(item => item.PassportNumber == treatReq.PassportNumber);
            if(found != null)
            {
                var treatment = new Treatment()
                {
                    PassportNumber = treatReq.PassportNumber,
                    VetName = treatReq.VetName,
                    Info = treatReq.Info,
                    IsActive = true,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,

                };
                _UnitOfWork.TreatmentRepository.Add(treatment);
                _UnitOfWork.Complete();

                return Ok(new CommonResponseModel<Treatment>(treatment, "200", "Basariyla eklendi"));
            }
            else
            {
                return BadRequest(new CommonResponseModel<Treatment>(null, "406", "Bu pasaport numarasiyla hayvan bulunmuyor"));
            }
           
        }


        /// <summary>
        ///     Get Vet's unique patient list by vetname
        /// </summary>
        /// <param>string  vetname </param>
        /// <returns>
        ///       {
        ///     "items":[Pet],
        ///     "status",
        ///     "errormessage"
        ///     }
        /// </returns>
        // GET: api/<TreatmentController>
        [HttpGet("getPetWithVetname")]
        public IActionResult Get(string vetname)
        {
            var allTreatments = _UnitOfWork.TreatmentRepository.GetAll().Where(x => x.VetName == vetname);
            if (!allTreatments.Any())
            {
                return Ok(new CommonResponseModel<IEnumerable<Treatment>>(allTreatments, "204", "Eleman bulunamadi"));
            }
            else
            {
                var seen = new List<string>();

                var found = "";
                Pet pet;
                var pets = new List<Pet>();

                foreach (var treatmentItem in allTreatments)
                {
                    found = seen.FirstOrDefault(passportNumberCheck => passportNumberCheck.Contains(treatmentItem.PassportNumber));
                    if (found == null)
                    {
                        pet = _UnitOfWork.PetRepository.GetAll().FirstOrDefault(x => x.PassportNumber == treatmentItem.PassportNumber);
                        pets.Add(new Pet()
                        {
                            PassportNumber = pet.PassportNumber,
                            AnimalType = pet.AnimalType,
                            IsActive = pet.IsActive,
                            NeutoringState = pet.NeutoringState,
                            Name = pet.Name,
                            CreateDate = pet.CreateDate,
                            UpdateDate = pet.UpdateDate,
                            Id = pet.Id,
                            DeleteDate = pet.DeleteDate
                        });
                        seen.Add(treatmentItem.PassportNumber);
                    }
                    found = null;

                }


                return Ok(new CommonResponseModel<IEnumerable<Pet>>(pets, "200", "Basarili"));
            }

            
        }

        /// <summary>
        ///     Get All data from Treatment table with passport number input
        /// </summary>
        /// <param string PassportNumber</param>
        /// <returns></returns>
        // GET: api/<TreatmentController>
        [HttpGet("getAllWithPassportName")]
        public IActionResult getAllTreatmentsPassportname(string PassportNumber)
        {
            var treatments = _UnitOfWork.TreatmentRepository.GetAll().Where(item => item.PassportNumber == PassportNumber);
            if (!treatments.Any())
            {
                return Ok(new CommonResponseModel<IEnumerable<Treatment>>(treatments, "204", "Eleman bulunamadi"));
            }
            else
            {
                return Ok(new CommonResponseModel<IEnumerable<Treatment>>(treatments, "200", "Basarili"));
            }
        }

        /// <summary>
        /// if given id can found by database, delete the record from Treatment table
        /// </summary>
        /// <parameters>
        ///  int id
        /// </parameters>
        /// <returns>
        ///     {
        ///     "items":Treatment,
        ///     "status",
        ///     "errormessage"
        ///     }
        /// </returns>
        // POST api/<PetController>/
        [HttpDelete("deleteById")]
        public IActionResult Delete(int id)
        {
            var treatment = _UnitOfWork.TreatmentRepository.GetById(id);
            if (treatment != null)
            {
                _UnitOfWork.TreatmentRepository.Remove(id);
                _UnitOfWork.Complete();

                return Ok(new CommonResponseModel<Treatment>(treatment, "200", "Basariyla silindi"));
            }
            else
            {
                return BadRequest(new CommonResponseModel<Treatment>(treatment, "403", "tedavi bulunamadi"));
            }

        }


    }
    
}
