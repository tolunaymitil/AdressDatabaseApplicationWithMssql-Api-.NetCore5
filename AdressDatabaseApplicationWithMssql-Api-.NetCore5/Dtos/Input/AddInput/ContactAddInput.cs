using AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataLayer.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Input.AddInput
{
    public class ContactAddInput
    {
        public int ContactID { get; set; }
        public ContactType ContactType { get; set; }
        public int PersonID { get; set; }
        public string ContactValue { get; set; }
        public bool ContactIsAcceessable { get; set; }
    }
}
