using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExampleTrying
{
  internal class Program
  {
    static List<Contact> List = new List<Contact>()
    {
      new Contact()
      {
        Value="kırık",
        Type=5
      },
      new Contact()
      {
        Value="Mitil",
        Type=6
      }
    };
    static Person person = new()
    {
      Contact = List
    };
    static Person person2 = new()
    {
      Contact = List
    };
    static Person person3 = new()
    {
      Contact = List
    };
    static List<Person> persons = new List<Person>()
    {
      person,person2,person3
    };
    static void Main(string[] args)
    {
      //string email = "zafer.krk@hotmail.com";
      //string email2 = "zafer_krk@x.digital";

      //Validate(email);
      //Validate(email2);

      //string[] phones ={ "5319665918", "531-9665-918" };
      //foreach (var phone in phones)
      //{

      //  ValidateGsm(phone);
      //}


      var q = persons.Where(x => x.Contact.Any(f=>f.Type==5));



      Console.WriteLine();
    }
    static void Validate(string email)
    {
      Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,30})+)$");
      Match match = regex.Match(email);
      if (match.Success)
        Console.WriteLine("Bu bir email");
      else
      {
        Console.WriteLine("Bu bir email değil");
      }

    }
    static void ValidateGsm(string phone)
    {
      Regex regex = new Regex(@"^\(?([0-9]{3})\)?([0-9]{3})?([0-9]{4})$");
      Match match = regex.Match(phone);
      if (match.Success)
        Console.WriteLine("Bu bir telefon");
      else
      {
        Console.WriteLine("Bu bir telefon değil");
      }
    }
  }
  public class Person
  {
    public List<Contact> Contact { get; set; }
  }
  public class Contact
  {
    public string Value { get; set; }
    public int Type { get; set; }
  }
}
