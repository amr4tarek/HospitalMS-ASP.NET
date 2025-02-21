using hospitalManagement.Application.Dtos.Users;
using hospitalManagement.Application.Dtos;
using hospitalManagement.Domain.Models.Users;
using hospitalManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;

namespace hospitalManagement.Application.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
      
            CreateMap<User, ApplicationUserDto>().ReverseMap();

            
            CreateMap<Doctor, DoctorDto>()
                .ForMember(dest => dest.ApplicationUser, opt => opt.MapFrom(src => src.ApplicationUser))
                .ForMember(dest => dest.Appointments, opt => opt.MapFrom(src => src.Appointments))
                .ForMember(dest => dest.MedicalRecords, opt => opt.MapFrom(src => src.MedicalRecords))
                .ForMember(dest => dest.LabTests, opt => opt.MapFrom(src => src.LabTests))
                .ReverseMap();

            
            CreateMap<Patient, PatientDto>()
                .ForMember(dest => dest.ApplicationUser, opt => opt.MapFrom(src => src.ApplicationUser))
                .ReverseMap();

            CreateMap<Appointment, AppointmentDto>().ReverseMap();

            CreateMap<MedicalRecord, MedicalRecordDto>()
                .ForMember(dest => dest.Prescriptions, opt => opt.MapFrom(src => src.Prescriptions))
                .ReverseMap();

            CreateMap<Prescription, PrescriptionDto>().ReverseMap();

            CreateMap<Invoice, InvoiceDto>()
                .ForMember(dest => dest.Payments, opt => opt.MapFrom(src => src.Payments))
                .ReverseMap();

            CreateMap<Payment, PaymentDto>().ReverseMap();

            
            CreateMap<LabTest, LabTestDto>().ReverseMap();

           
            CreateMap<Resource, ResourceDto>().ReverseMap();

            
            CreateMap<ResourceAllocation, ResourceAllocationDto>().ReverseMap();


            CreateMap<StaffSchedule, StaffScheduleDto>().ReverseMap();
        }
    }
}
