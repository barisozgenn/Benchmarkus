using AutoMapper;

namespace ModelMapping;
    /// <summary>
    /// Defines AutoMapper profiles for object-object mapping configurations.
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           // Create a mapping configuration from Person to PersonDto
            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses));

            // If Address was different between source and destination, you would configure it here.
            // Since both source and destination use the same Address class, no additional mapping is required.
            // However, to ensure consistency, you can include it explicitly.
            CreateMap<Address, Address>();
        }
        
    }
