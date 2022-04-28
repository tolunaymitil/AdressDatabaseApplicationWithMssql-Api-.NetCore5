using AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataLayer.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Input.DeleteInput
{
    public class PersonDeleteInput
    {
        public int PersonID { get; set; }
        public DateTime BirthDate { get; set; }
        public string NameSurname { get; set; }
        public GenderType Gender { get; set; }
        public List<AddresUpdateInput> Addresses { get; set; }
        public List<ContactUpdateInput> Contacts { get; set; }
    }
}
