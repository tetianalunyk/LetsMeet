using AutoMapper;
using LetsTogether.BLL.DTO;
using LetsTogether.DAL.Entities;
using LetsTogether.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsTogether.Web.Mapper
{
    public class AutoMapping : AutoMapper.Profile
    {
        public AutoMapping()
        {
            CreateMap<EventsDTO, MyEventsModel>();

            CreateMap<RegisterModel, UserDTO>()
               .ForMember(dest => dest.Gender, opts => opts.MapFrom(src => src.Sex))
               .ForMember(dest => dest.Location, opts => opts.MapFrom(src => new Location
               {
                   City = src.city_state,
                   Country = src.country
               }))
               .ForMember(dest => dest.Role, opts => opts.MapFrom(src => "user"))
               .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.Login));

            CreateMap<EventModel, EventDTO>()
                .ForMember(dest => dest.Event, opts => opts.MapFrom(src => new Event
                {
                    Title = src.Title,
                    Description = src.Description,
                    DateFrom = src.DateFrom,
                    DateTo = src.DateTo
                }))
                .ForMember(dest => dest.Location, opts => opts.MapFrom(src => new Location
                {
                    City = src.city_state,
                    Country = src.country
                }))
                .ForMember(dest => dest.Categories, opts => opts.MapFrom(src => src.SelectedCategories))
                .ForMember(dest => dest.Photo, opts => opts.MapFrom(src => src.formFile));

            CreateMap<EditProfileModel, EditProfileDTO>()
                .ForMember(dest => dest.Location, opts => opts.MapFrom(src => (src.country != null) ? new Location
                {
                    Country = src.country,
                    City = src.city_state
                } : null));

            CreateMap<User, EditProfileModel>()
                .ForMember(dest => dest.country, opts => opts.MapFrom(src => src.Profile.Location.Country))
                .ForMember(dest => dest.city_state, opts => opts.MapFrom(src => src.Profile.Location.City))
                .ForMember(dest => dest.Birthday, opts => opts.MapFrom(src => src.Profile.Birthday));

        }
    }
}
