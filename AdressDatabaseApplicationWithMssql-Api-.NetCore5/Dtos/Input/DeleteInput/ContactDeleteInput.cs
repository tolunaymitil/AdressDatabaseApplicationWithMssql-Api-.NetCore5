using AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataLayer.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Input.DeleteInput
{
    public class ContactDeleteInput
    {
        public int ContactID { get; set; }
        public ContactType ContactType { get; set; }
        public int PersonID { get; set; }
    }
}
