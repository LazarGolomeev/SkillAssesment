using AutoMapper;
using WolfPack.Dtos;
using WolfPack.Models;

namespace WolfPack.Profiles
{
    public class WolvesProfile: Profile
    {
        public WolvesProfile()
        {
            //Source to target
            CreateMap<Wolf, WolfReadDto>();
            CreateMap<WolfCreateDto, Wolf>();
            CreateMap<WolfUpdateDto, Wolf>();
            CreateMap<Wolf, WolfUpdateDto>();
            CreateMap<Pack,PackReadDto>();
            CreateMap<PackCreateDto,Pack>();
            CreateMap<PackUpdateDto, Pack>();
            CreateMap<Pack, PackUpdateDto>();
        }
    }
}