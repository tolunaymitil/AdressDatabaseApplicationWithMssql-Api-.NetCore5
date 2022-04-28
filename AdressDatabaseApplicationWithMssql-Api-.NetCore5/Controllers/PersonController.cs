using AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataAccessLayer;
using AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataLayer.Entities;
using AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Input;
using AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Input.AddInput;
using AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Response;
using AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Response.AddResponse;
using AdressDatabaseApplicationWithMssql_Api_.NetCore5.Validator.FluentValidation;
using AdressDatabaseApplicationWithMssql_Api_.NetCore5.Validator.FluentValidation.AddValidator;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IMapper _mapper;

        public PersonController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //
        [HttpPut]
        public IActionResult PersonUpdate(PersonUpdateInput personUpdateInput)
        {
            //input dto validate et 
            PersonUpdateInputValidator validationRules = new PersonUpdateInputValidator();
            ValidationResult validationResult = validationRules.Validate(personUpdateInput);
            if (validationResult.IsValid == false)
            {
                List<string> errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
                return BadRequest(validationResult.Errors);
            }

            using var c = new Context();
            Person personUpdate = c.Persons
              .Include(f => f.Addresses)
              .Include(f => f.Contacts)
            .FirstOrDefault(f => f.PersonID == personUpdateInput.PersonID);
            if (personUpdate == null)
            {
                return NotFound();
            }
            personUpdate = _mapper.Map<Person>(personUpdateInput);
            #region BoktanYontem
            //personUpdate.BirthDate = personUpdateInput.BirthDate;
            //personUpdate.Gender = personUpdateInput.Gender;
            //personUpdate.Addresses= _mapper.Map<List<Address>>(personUpdateInput.Addresses);
            //personUpdate.Addresses = personUpdateInput.Addresses.Select(f => new Address
            //{
            //  AddressID = f.AddressID,
            //  City = f.City,
            //  County = f.County,
            //  FullAddress = f.FullAddress,
            //  PersonID=personUpdateInput.PersonID
            //}).ToList();
            #endregion
            c.ChangeTracker.Clear();
            c.Update(personUpdate);
            c.SaveChanges();


            PersonUpdateResponse personUpdateMapped = _mapper.Map<PersonUpdateResponse>(personUpdate);
            return Ok(personUpdateMapped);
        }
        [HttpPost]
        public IActionResult PersonAdd(PersonAddInput personAddInput)
        {
            PersonAddInputValidator validationRules = new PersonAddInputValidator();
            ValidationResult validationResult = validationRules.Validate(personAddInput);
            if (validationResult.IsValid == false)
            {
                List<string> errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
                return BadRequest(validationResult.Errors);
            }
            using var c = new Context();

            Person personAdd = _mapper.Map<Person>(personAddInput);
            c.ChangeTracker.Clear();
            c.Add(personAdd);
            c.SaveChanges();

            PersonAddResponse personUpdateMapped = _mapper.Map<PersonAddResponse>(personAdd);
            return Ok(personUpdateMapped);
        }
        [HttpDelete("{id}")]
        public IActionResult PersonDelete(int id )
        {
            using var c = new Context();
            Person personDelete= c.Persons.Include(f => f.Addresses).Include(f => f.Contacts).FirstOrDefault(f => f.PersonID == id);
            if (personDelete == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(personDelete);
                c.SaveChanges();
            }
            return Ok("Başarıyla Silindi");
        }
        [HttpGet]
        public IActionResult PersonGetAll()
        {
            using (var c = new Context())
            {

                var values = c.Persons.Include(f => f.Addresses).Include(f => f.Contacts).ToList();
                return Ok(values);


            }
        }
    }
}
