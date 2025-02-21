using hospitalManagement.Application.Interfaces.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Interfaces.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IDoctorRepository Doctors { get; }
        IPatientRepository Patients { get; }
        IAppointmentRepository Appointments { get; }
        IMedicalRecordRepository MedicalRecords { get; }
        IPrescriptionRepository Prescriptions { get; }
        IInvoiceRepository Invoices { get; }
        IPaymentRepository Payments { get; }
        ILabTestRepository LabTests { get; }
        IResourceRepository Resources { get; }
        IResourceAllocationRepository ResourceAllocations { get; }
        IStaffScheduleRepository StaffSchedules { get; }

        Task<int> CommitAsync();
    }
}
