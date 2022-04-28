using AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataLayer.Entities.Enum;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Input
{
  public class ContactUpdateInput
  {
        public int ContactID { get; set; }
        public ContactType ContactType { get; set; }
        public int PersonID { get; set; }
        public string ContactValue { get; set; }
        public bool ContactIsAcceessable { get; set; }
    }
}
