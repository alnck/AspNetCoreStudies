using AutoMapper;

namespace BP.Api.Extensions
{
  public static class ConfigureMappingProfileExtension
  {
    public static IServiceCollection ConfigureMapping(this IServiceCollection service)
    {
      var mappingConfig = new MapperConfiguration(i => i.AddProfile(new AutoMapperMappingProfile()));
      
      IMapper mapper = mappingConfig.CreateMapper();

      service.AddSingleton(mapper);

      return service;
    }
  }

  public class AutoMapperMappingProfile: Profile
  {
    public AutoMapperMappingProfile()
    {
      CreateMap<BP.Api.Data.Models.Contact,BP.Api.Models.ContactDVO>()
        .ForMember(x=>x.FullName, y=>y.MapFrom(z=>z.FirstName+" "+z.LastName))
        //.ForMember(x=>x.Id,y=>y.MapFrom(z=>z.Id)) // Key'ler aynı ise yapmaya gerek yok. Bu işlem auto mapper tarafından otomatik olarak yapılır.
        .ReverseMap();
    }
  }
}
