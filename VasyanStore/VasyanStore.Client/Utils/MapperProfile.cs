using VasyanStore.Client.Models;
using VasyanStore.DataAccess.Entities;

namespace VasyanStore.Client.Utils
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            // Game => GameViewModel
            CreateMap<Game, GameViewModel>()
                //.ForMember(x=> x.Price, opt => opt.MapFrom(m=>m.Price * 2))
                .ForMember(x => x.Genre, otp => otp.MapFrom(m => m.Genre.Name))
                .ForMember(x => x.Developer, otp => otp.MapFrom(m => m.Developer.Name));

            // GameViewMode => Game
            CreateMap<GameViewModel, Game>()
                .ForMember(x => x.Genre, opt => opt.MapFrom(m => new Genre { Name = m.Name }))
                .ForMember(x => x.Developer, opt => opt.MapFrom(m => new Developer { Name = m.Name }));

        }
    }
}