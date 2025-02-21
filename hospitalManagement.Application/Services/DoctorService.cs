using AutoMapper;
using hospitalManagement.Application.Dtos.Auth;
using hospitalManagement.Application.Dtos.Users;
using hospitalManagement.Application.Helpers;
using hospitalManagement.Application.Interfaces.Services;
using hospitalManagement.Application.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<DoctorDto>> GetDoctorByIdAsync(Guid id)
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(id);
            if (doctor == null)
            {
                return Result<DoctorDto>.FailureResult("Doctor not found");
            }
            var dto = _mapper.Map<DoctorDto>(doctor);
            return Result<DoctorDto>.SuccessResult(dto, "Doctor retrieved successfully");
        }

        public async Task<Result<IEnumerable<DoctorDto>>> GetAllDoctorsAsync()
        {
            var doctors = await _unitOfWork.Doctors.ListAllAsync();
            var dtos = _mapper.Map<IEnumerable<DoctorDto>>(doctors);
            return Result<IEnumerable<DoctorDto>>.SuccessResult(dtos, "Doctors retrieved successfully");
        }

        public async Task<Result<DoctorDto>> CreateDoctorAsync(RegisterDoctorDto registerDoctorDto)
        {
            // same like RegisterDoctorAsync in AuthenticationService.
            return Result<DoctorDto>.FailureResult("Use the registration endpoint for doctors");
        }

        public async Task<Result<DoctorDto>> UpdateDoctorAsync(DoctorDto doctorDto)
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(doctorDto.Id);
            if (doctor == null)
            {
                return Result<DoctorDto>.FailureResult("Doctor not found");
            }

            _mapper.Map(doctorDto, doctor);
            await _unitOfWork.Doctors.UpdateAsync(doctor);
            await _unitOfWork.CommitAsync();

            var updatedDto = _mapper.Map<DoctorDto>(doctor);
            return Result<DoctorDto>.SuccessResult(updatedDto, "Doctor updated successfully");
        }

        public async Task<Result<bool>> DeleteDoctorAsync(Guid id)
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(id);
            if (doctor == null)
            {
                return Result<bool>.FailureResult("Doctor not found");
            }
            await _unitOfWork.Doctors.DeleteAsync(doctor);
            await _unitOfWork.CommitAsync();
            return Result<bool>.SuccessResult(true, "Doctor deleted successfully");
        }
    }
}
