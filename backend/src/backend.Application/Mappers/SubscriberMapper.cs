using AutoMapper;
using backend.Application.Models;
using backend.DataAccess.Entities;
using System.Diagnostics.CodeAnalysis;

namespace backend.Application.Mappers
{
    [ExcludeFromCodeCoverage]
    public class SubscriberMapper : Profile
    {
        public SubscriberMapper()
        {
            CreateMap<NewSubscriberModel, Subscriber>();
            CreateMap<Subscriber, SubscriberResponseModel>();
        }

    }
}
