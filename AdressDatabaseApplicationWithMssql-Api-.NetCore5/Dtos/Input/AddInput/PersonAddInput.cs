using AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataLayer.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Input.AddInput
{
    public class PersonAddInput
    {
        public int PersonID { get; set; }
        public DateTime BirthDate { get; set; }
        public string NameSurname { get; set; }
        public GenderType Gender { get; set; }
        public List<AddressAddInput> Addresses { get; set; }
        public List<ContactAddInput> Contacts { get; set; }
    }
}
