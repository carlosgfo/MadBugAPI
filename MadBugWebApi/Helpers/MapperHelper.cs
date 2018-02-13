using AutoMapper;
using MadBug.Domain;
using MadBugWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadBugWebApi.Helpers
{
    public class MapperHelper
    {
        internal static IMapper mapper;

        static MapperHelper()
        {
            var config = new MapperConfiguration(x => 
            {
                x.CreateMap<Bug, BugApi>().ReverseMap();
                x.CreateMap<Bug, CreateBugApi>().ReverseMap();
                x.CreateMap<User, UserApi>().ReverseMap();
            });
            mapper = config.CreateMapper();
        }

        public static T Map<T>(object source)
        {
            return mapper.Map<T>(source);
        }
    }
}