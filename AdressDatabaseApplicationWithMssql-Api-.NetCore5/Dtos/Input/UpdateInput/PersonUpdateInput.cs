using AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataLayer.Entities.Enum;
using System;
using System.Collections.Generic;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Input
{
  public class PersonUpdateInput
  {
    public int PersonID { get; set; }
    public DateTime BirthDate { get; set; }
    public string NameSurname { get; set; }
    public GenderType Gender { get; set; }
    public List<AddresUpdateInput> Addresses { get; set; }
    public List<ContactUpdateInput> Contacts { get; set; }
  }
}
