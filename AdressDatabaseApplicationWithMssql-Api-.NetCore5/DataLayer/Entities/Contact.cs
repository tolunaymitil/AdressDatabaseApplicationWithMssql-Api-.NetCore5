using AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataLayer.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataLayer.Entities
{
    public class Contact 
    {
        [Key]
        public int ContactID { get; set; }
        public ContactType ContactType { get; set; }
        public string ContactValue { get; set; }
        public bool ContactIsAcceessable { get; set; }
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
    }
}
