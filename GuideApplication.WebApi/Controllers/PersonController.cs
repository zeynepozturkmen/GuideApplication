using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GuideApplication.Core.Models;
using GuideApplication.Core.Services;
using GuideApplication.WebApi.Resources;
using GuideApplication.WebApi.Validators;
using Microsoft.AspNetCore.Mvc;

namespace GuideApplication.WebApi.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonInformationService _personService;
        private readonly IMapper _mapper;

        public PersonController(IPersonInformationService personService, IMapper mapper)
        {
            this._mapper = mapper;
            this._personService = personService;
        }

        [HttpGet]
        [Route("get/all")]
        public async Task<ActionResult<IEnumerable<PersonResource>>> GetAllArtists()
        {
            var persons = await _personService.GetAllPersons();
            var personResources = _mapper.Map<IEnumerable<PersonInformation>, IEnumerable<PersonResource>>(persons);

            return Ok(personResources);
        }

        [HttpGet]
        [Route("get/byId")]
        public async Task<ActionResult<PersonResource>> GetArtistById(int id)
        {
            //istenilen kisi bilgisi getiriliyor.
            var person = await _personService.GetPersonById(id);
            //AutoMapper ile otomatik eşleme yapılıyor.
            var personResource = _mapper.Map<PersonInformation, PersonResource>(person);

            return Ok(personResource);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<PersonResource>> CreatePerson([FromBody] SavePersonResource savePersonResource)
        {
            //Model dogrulama kontrolü yapılıyor.
            var validator = new SavePersonResourceValidator();
            var validationResult = await validator.ValidateAsync(savePersonResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            
            //AutoMapper
            var personToCreate = _mapper.Map<SavePersonResource, PersonInformation>(savePersonResource);
            //kisi ekleniyor
            var newPerson = await _personService.CreatePerson(personToCreate);
            //eklenen kisi cagırılıyor
            var person = await _personService.GetPersonById(newPerson.Id);
            //Getirilen kisi autoMapper ile verileri esleniyor ve response'da bu veriler dönülüyor
            var personResource = _mapper.Map<PersonInformation, PersonResource>(person);

            return Ok(personResource);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<PersonResource>> UpdatePerson([FromBody] SavePersonResource savePersonResource)
        {
            //Model dogrulama kontrolü yapılıyor.
            var validator = new SavePersonResourceValidator();
            var validationResult = await validator.ValidateAsync(savePersonResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok
            //güncellenecek kişi bulunuyor
            var personToBeUpdated = await _personService.GetPersonById(savePersonResource.Id);
            //kişi bulunamadıysa hata dönüyor
            if (personToBeUpdated == null)
                return NotFound();

            //AutoMapper
            var person = _mapper.Map<SavePersonResource, PersonInformation>(savePersonResource);
            //Kişi güncelleniyor
            await _personService.UpdatePerson(personToBeUpdated, person);
            //güncellenen kişi getiriliyor
            var updatedPerson = await _personService.GetPersonById(savePersonResource.Id);
            //Getirilen kisi autoMapper ile verileri esleniyor ve response'da bu veriler dönülüyor
            var updatedPersonResource = _mapper.Map<PersonInformation, PersonResource>(updatedPerson);

            return Ok(updatedPersonResource);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _personService.GetPersonById(id);

            await _personService.DeletePerson(person);

            return NoContent();
        }
    }
}


