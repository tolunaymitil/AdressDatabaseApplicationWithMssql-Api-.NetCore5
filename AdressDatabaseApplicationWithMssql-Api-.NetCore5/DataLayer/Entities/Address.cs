using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataLayer.Entities
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string FullAddress { get; set; }
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }

    }
}
