using AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataLayer.Entities;
using AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Input;
using AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Input.AddInput;
using AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Input.DeleteInput;
using AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Response;
using AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Response.AddResponse;
using AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Response.DeleteResponse;
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

      CreateMap<PersonAddInput, Person>().ReverseMap();
      CreateMap<AddressAddInput, Address>().ReverseMap();
      CreateMap<ContactAddInput, Contact>().ReverseMap();

      CreateMap<PersonAddResponse, Person>().ReverseMap();
      CreateMap<AddressAddResponse, Address>().ReverseMap();
      CreateMap<ContactAddResponse, Contact>().ReverseMap();

      CreateMap<PersonDeleteInput, Person>().ReverseMap();
      CreateMap<AddressDeleteInput, Address>().ReverseMap();
      CreateMap<ContactDeleteInput, Contact>().ReverseMap();

      CreateMap<PersonDeleteResponse, Person>().ReverseMap();
      CreateMap<AddressDeleteResponse, Address>().ReverseMap();
      CreateMap<ContactDeleteResponse, Contact>().ReverseMap();


      CreateMap<PersonGetAllWithPagingResponse, Person>().ReverseMap();
      CreateMap<AddressGetAllWithPagingResponse, Address>().ReverseMap();
      CreateMap<ContactGetAllWithPagingResponse, Contact>().ReverseMap();
    }
  }
}
