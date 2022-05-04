using AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DatabaseApiFront.Controllers
{
  public class DefaultController : Controller
  {
    //public async Task<IActionResult> Index()
    //{
    //  var httpClient = new HttpClient();
    //  var responseMessage = await httpClient.GetAsync("https://localhost:5001/api/Default");
    //  var jsonString = await responseMessage.Content.ReadAsStringAsync();
    //  var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
    //  return View(values);
    //}



    public IActionResult AddPerson()
    {
      AddPersonApiInputModel addPersonInputModel = new AddPersonApiInputModel()
      {
        nameSurname ="Zafer Kırık",
        addresses=new List<AddPersonApiInputModel.Address>
        {
          new AddPersonApiInputModel.Address
          {
            city="Kars",
            county="Digor",
            fullAddress="",
          },
        },
        birthDate=DateTime.Now.AddYears(-40),
        contacts=new List<AddPersonApiInputModel.Contact>
        {
          new AddPersonApiInputModel.Contact
          {
            contactIsAcceessable=true,
            contactType=1,
            contactValue="zafer.krk@hotmail.com"
            
          }
        },
        gender=1,
      };

      var client = new RestClient("http://localhost:5001/api/person");
      client.Timeout = -1;
      var request = new RestRequest(Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(addPersonInputModel);
      IRestResponse response = client.Execute(request);
      if (response.IsSuccessful == false)
      {

        if (response.StatusCode==HttpStatusCode.BadRequest)
        {
          ViewBag.Error = "Hata:";
          ViewBag.ErrorMessageList= JsonSerializer.Deserialize<List<string>>(response.Content);
          return View();
        }
        if (response.StatusCode == HttpStatusCode.InternalServerError)
        {
          ViewBag.Error = "Hay aksi! servisde problem var. 312983712893712831982 bu kod ile destek ekibine ulaşabilirsin";

          return View();
        }

        ViewBag.Error = "Hay aksi beklenmedik problemlerle karşılaştık";

        return View();
      }
      else
      {
        ViewBag.Success = "Başarıyla kaydedildi";
      }
      AddPersonApiResponse addPersonApiResponse = JsonSerializer.Deserialize<AddPersonApiResponse>(response.Content);

      return View();
    }
    //[HttpPost]
    //public IActionResult AddPerson(AddPersonApiInputModel addPersonApiInputModel)
    //{

    //  var client = new RestClient("http://localhost:5001/api/person");
    //  client.Timeout = -1;
    //  var request = new RestRequest(Method.POST);
    //  request.AddHeader("Content-Type", "application/json");
    //  request.AddJsonBody(addPersonInputModel);
    //  IRestResponse response = client.Execute(request);
    //  if (response.IsSuccessful==false)
    //  {
    //    ViewBag.Error = "Hay aksi beklenmedik problemlerle karşılaştık";

    //    return View();
    //  }
    //  else
    //  {
    //    ViewBag.Success = "Başarıyla kaydedildi";
    //  }
    //  AddPersonApiResponse addPersonApiResponse = System.Text.Json.JsonSerializer.Deserialize<AddPersonApiResponse>(response.Content);


    //  return View();
    //}

  }



  public class AddPersonApiResponse
  {
    public int personID { get; set; }
    public string nameSurname { get; set; }
    public DateTime birthDate { get; set; }
    public int gender { get; set; }
    public List<Address> addresses { get; set; }
    public List<Contact> contacts { get; set; }
    public class Address
    {
      public int addressID { get; set; }
    }

    public class Contact
    {
      public int contactID { get; set; }
    }
  }



  public class AddPersonApiInputModel
  {
    public int personID { get; set; }
    public DateTime birthDate { get; set; }
    public string nameSurname { get; set; }
    public int gender { get; set; }
    public List<Address> addresses { get; set; }
    public List<Contact> contacts { get; set; }
    public class Address
    {
      public int addressID { get; set; }
      public string city { get; set; }
      public string county { get; set; }
      public string fullAddress { get; set; }
      public int personID { get; set; }
    }

    public class Contact
    {
      public int contactID { get; set; }
      public int contactType { get; set; }
      public int personID { get; set; }
      public string contactValue { get; set; }
      public bool contactIsAcceessable { get; set; }
    }
  }

  public class Class1
  {
    public int AddressID { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public string FullAddress { get; set; }
    public int PersonID { get; set; }
    public virtual Person Person { get; set; }
  }

}