﻿using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using System.Runtime.CompilerServices;

namespace CityInfo.API.Profiles
{
    public class PointOfInterestProfile : Profile
    {
        public PointOfInterestProfile()
        {
            CreateMap<PointOfInterest, PointOfInterestDto>();
        }
    }
}
