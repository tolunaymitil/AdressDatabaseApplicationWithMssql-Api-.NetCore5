using AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataLayer.Entities.Enum;
using System;
using System.Collections.Generic;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Input.GetAllWithPaging
{
  public class PersonGetAllWithPagingInput
  {

    public string NameSurname { get; set; }
    public DateTime? BirthDate { get; set; }
    public GenderTypeWithNull Gender { get; set; }
    public List<ContactQueryInput> ContactQuery { get; set; }
    public string AddressCity { get; set; }

    public int Take { get; set; }
    public int Skip { get; set; }
  }
  public enum GenderTypeWithNull
  {
    NULL,
    Male = 1,
    Female = 2
  }
  public class ContactQueryInput
  {
    public ContactType ContactType { get; set; }
    public string ContactValue { get; set; }
  }
}
