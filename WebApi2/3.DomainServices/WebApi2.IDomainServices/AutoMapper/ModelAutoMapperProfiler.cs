using AutoMapper;
using WebApi2.EntityModels.Core;
using WebApi2.EntityModels.Identity;
using WebApi2.EntityModels.Queues;
using WebApi2.Utility;
using WebApi2.ViewModels;
using WebApi2.ViewModels.Core;
using WebApi2.ViewModels.Identity.WebApi;


namespace WebApi2.IDomainServices.AutoMapper
{
    public class ModelAutoMapperProfiler : Profile
    {
        public ModelAutoMapperProfiler()
        {
           CreateMap<BaseEntity, BaseViewModel>().ReverseMap();
           CreateMap<AuditableEntity, AuditableViewModel>().ReverseMap();
           CreateMap<IdentityColumnEntity, IdentityColumnViewModel>().ReverseMap();

           CreateMap<User, IdentityUserViewModel>()
                            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));

           CreateMap<IdentityUserViewModel, User>()
                            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));


           CreateMap<Role, IdentityRoleViewModel>()
                            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RoleId));
           CreateMap<IdentityRoleViewModel, Role>()
                            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id));

           CreateMap<EmailQueue, EmailQueueViewModel>().ReverseMap();
           CreateMap<RequestQueue, RequestQueueViewModel>().ReverseMap();
           CreateMap<PdfQueue, PdfQueueViewModel>().ReverseMap();


           CreateMap<Client, ClientViewModel>()
                .ForMember(dest => dest.ApplicationType, opt => opt.ResolveUsing<ApplicationTypeEnumResolver, int>(src => src.ApplicationType));

           CreateMap<ClientViewModel, Client>()
                            .ForMember(dest => dest.ApplicationType, opt => opt.ResolveUsing<ApplicationTypeIntResolver, ApplicationTypes>(src => src.ApplicationType));

           CreateMap<RefreshToken, RefreshTokenViewModel>().ReverseMap();

           CreateMap<ExternalLogin, ExternalLoginViewModel>().ReverseMap();

           CreateMap<ExternalLogin, UserLoginInfoViewModel>().ReverseMap();


        }
    }
}
