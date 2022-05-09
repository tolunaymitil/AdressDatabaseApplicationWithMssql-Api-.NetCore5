using AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataLayer.Entities.Enum;
using System;
using System.Collections.Generic;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Response
{

  public class PersonGetAllWithPagingWrapper
  {
    public List<PersonGetAllWithPagingResponse> Rows { get; set; }
    public int TotalCount { get; set; }
    public List<string> CityNames { get; set; }
  }
  public class PersonGetAllWithPagingResponse
  {
    public int PersonID { get; set; }
    public string NameSurname { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderType Gender { get; set; }
    public List<AddressGetAllWithPagingResponse> Addresses { get; set; }

    public List<ContactGetAllWithPagingResponse> Contacts { get; set; }

  }
  public class AddressGetAllWithPagingResponse
  {
    public int AddressID { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public string FullAddress { get; set; }
    public int PersonID { get; set; }

  }
  public class ContactGetAllWithPagingResponse
  {
    public int ContactID { get; set; }
    public ContactType ContactType { get; set; }
    public string ContactValue { get; set; }
    public bool ContactIsAcceessable { get; set; }
    public int PersonID { get; set; }
  }
}
