namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Input
{
  public class AddresUpdateInput
  {
    public int AddressID { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public string FullAddress { get; set; }
    public int PersonID { get; set; }
  }
}
