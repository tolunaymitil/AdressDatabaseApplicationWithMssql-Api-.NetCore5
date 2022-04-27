using AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataLayer.Entities.Enum;
using System;
using System.Collections.Generic;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Response
{
  public class PersonUpdateResponse
  {
    public int PersonID { get; set; }
    public string NameSurname { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderType Gender { get; set; }

    public virtual List<AddressUpdateResponse> Addresses { get; set; }
    public virtual List<ContactUpdateResponse> Contacts { get; set; }
  }
}
