
using AutoMapper;
using Cedro.Projeto.Restaurante.Api.ViewModel;
using Cedro.Projeto.Restaurante.Domain.Entities;

namespace Cedro.Projeto.Restaurante.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Prato, PratoViewModel>();
            Mapper.CreateMap<Domain.Entities.Restaurante, RestauranteViewModel>();
        }
    }
}