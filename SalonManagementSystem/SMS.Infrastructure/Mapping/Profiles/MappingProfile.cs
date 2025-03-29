using AutoMapper;
using SMS.Application.DTOs;
using SMS.Application.DTOs.Admin;
using SMS.Domain;
using SMS.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Admin, AdminCommonDto>().ReverseMap();
            CreateMap<Admin,AdminLoginDto>().ReverseMap();
            CreateMap<Admin, AdminRegisterDto>().ReverseMap();
            CreateMap<Admin,AdminUpdateViewDto>().ReverseMap();
            CreateMap<Appoiontment,BookAppointmentCustomerDto>().ReverseMap();
            CreateMap<Appoiontment,CancelAppointmentCustomerDto>().ReverseMap();
            CreateMap<Appoiontment,UpdateViewSalonDto>().ReverseMap();
            CreateMap<Appoiontment,ViewAppointmentDto>().ReverseMap();
            CreateMap<Customer,CustomerLoginDto>().ReverseMap();
            CreateMap<Customer,CustomerRegisterDto>().ReverseMap();
            CreateMap<Customer,CustomerUpdateViewDto>().ReverseMap();
            CreateMap<Payment,PaymentDto>().ReverseMap();
            CreateMap<RevenueManager,RevenueManager>().ReverseMap();
            CreateMap<Salon,SalonCommonDto>().ReverseMap();
            CreateMap<Salon,RegisterSalonDto>().ReverseMap();
            CreateMap<Salon,SalonStatusDto>().ReverseMap();
            CreateMap<Salon,UpdateViewSalonDto>().ReverseMap();
            CreateMap<SalonServices, ServicesDto>().ReverseMap();
            CreateMap<Slot,SlotDto>().ReverseMap();
            CreateMap<StyistServiceLink,StylistServiceLinkDto>().ReverseMap();
            CreateMap<StylesList,StylesListDto>().ReverseMap();
            CreateMap<Stylist,StylistCommonDto>().ReverseMap();
            CreateMap<Stylist,AddStylistDto>().ReverseMap();
            CreateMap<Stylist, UpdateViewStylistDto>().ReverseMap();



        }

    }
}
