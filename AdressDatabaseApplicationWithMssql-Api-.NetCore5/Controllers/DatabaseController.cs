using AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataAccessLayer;
using AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DatabaseController : ControllerBase
  {
    [HttpGet]
    public IActionResult PersonsInformation()
    {
      using (var c = new Context())
      {

        var values = c.Persons.Include(f => f.Addresses).Include(f => f.Contacts).ToList();
        return Ok(values);


      }

      //using var c = new Context();
      //var values = c.Persons.ToList();
      //return Ok(values);
    }
    [HttpPost]
    public IActionResult PersonAdd(Person person)
    {
      using var c = new Context();
      c.Add(person);
      c.SaveChanges();
      return Ok();
    }
    [HttpGet("{id}")]

    public IActionResult PersonGetWithByID(int id)
    {
      using var c = new Context();
      var personGet = c.Persons.Include(f => f.Addresses).Include(f => f.Contacts).FirstOrDefault(f => f.PersonID == id);
      if (personGet == null)
      {
        return NotFound();
      }
      return Ok(personGet);


    }
    [HttpDelete("{id}")]
    public IActionResult PersonDeleteWithByID(int id)
    {
      using var c = new Context();
      var personDelete = c.Persons.Include(f => f.Addresses).Include(f => f.Contacts).FirstOrDefault(f => f.PersonID == id);
      if (personDelete == null)
      {
        return NotFound();
      }
      else
      {
        c.Remove(personDelete);
        c.SaveChanges();
      }
      return Ok(personDelete);
    }
    [HttpPut]
    public IActionResult PersonUpdate(Person person)
    {
      using var c = new Context();
     
      var personUpdate = c.Persons.Find(person.PersonID);
      person.NameSurname = personUpdate.NameSurname;
      if (person == null)
      {
        return NotFound();
      }
      personUpdate.NameSurname = person.NameSurname;
      personUpdate.BirthDate = person.BirthDate;
      personUpdate.Gender = person.Gender;

      return Ok(personUpdate);
    }
  }


}
