
using AutoMapper;
using Cedro.Projeto.Restaurante.Api.ViewModel;
using Cedro.Projeto.Restaurante.Domain.Entities;
namespace Cedro.Projeto.Restaurante.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<RestauranteViewModel, Domain.Entities.Restaurante>();
            Mapper.CreateMap<PratoViewModel, Prato>();
        }
    }
}