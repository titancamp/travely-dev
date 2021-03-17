﻿using AutoMapper;
using Google.Protobuf.Collections;
using System.Collections.Generic;
using Travely.PropertyManager.API.MappingProfiles.Converters;
using Travely.PropertyManager.Service.Models.Commands;
using Travely.PropertyManager.Service.Models.Queries;
using Travely.PropertyManager.Service.Models.Responses;

namespace Travely.PropertyManager.API.MappingProfiles
{
    public class PropertyMappingProfile : Profile
    {
        public PropertyMappingProfile()
        {
            CreateMap(typeof(RepeatedField<>), typeof(ICollection<>)).ConvertUsing(typeof(RepeatedFieldToCollectionConverter<,>));


            CreateMap<AddPropertyRequest, AddPropertyCommand>();

            CreateMap<GetPropertiesRequest, GetPropertiesQuery>();

            CreateMap<PropertyResponse, GetPropertiesResponse>();

            CreateMap<Travely.PropertyManager.API.OrderingBaseModel, Travely.PropertyManager.Service.Models.Base.OrderingBaseModel>();
            CreateMap<Travely.PropertyManager.API.FilteringBaseModel, Travely.PropertyManager.Service.Models.Base.FilteringBaseModel>();
        }
    }
}