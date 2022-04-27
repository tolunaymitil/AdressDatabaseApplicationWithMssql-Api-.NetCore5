using AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataLayer.Entities;
using AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Input;
using AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Response;
using AutoMapper;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.Mapping.AutoMapper
{
  public class GeneralMapping : Profile
  {
    public GeneralMapping()
    {
      CreateMap<PersonUpdateInput, Person>().ReverseMap();
      CreateMap<AddresUpdateInput, Address>().ReverseMap();
      CreateMap<ContactUpdateInput, Contact>().ReverseMap();

      CreateMap<PersonUpdateResponse, Person>().ReverseMap();
      CreateMap<AddressUpdateResponse, Address>().ReverseMap();
      CreateMap<ContactUpdateResponse, Contact>().ReverseMap();
    }
  }
}
