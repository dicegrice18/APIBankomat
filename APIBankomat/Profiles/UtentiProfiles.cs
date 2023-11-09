﻿using APIBankomat.DB;
using APIBankomat.Dtos;
using AutoMapper;

namespace APIBankomat.Profiles
{
    public class UtentiProfiles : Profile
    {
        public UtentiProfiles()
        {
            CreateMap<DB.Utenti, Dtos.Utente>().ReverseMap();
            CreateMap<DB.Utenti, Dtos.UtentePost>().ReverseMap();


            CreateMap<Banche, Banca>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.BancheFunzionalita, opt => opt.MapFrom(src => src.BancheFunzionalita.Select(bf => bf.IdFunzionalitaNavigation.Nome)));


            //CreateMap<DB.Banche, Dtos.Banca>().ReverseMap();
            //CreateMap<DB.Funzionalitum, Dtos.Funzionalita>().ReverseMap();
            //CreateMap<DB.BancheFunzionalitum, Dtos.BancheFunzionalita>().ReverseMap();
        }
    }
}
