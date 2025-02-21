using hospitalManagement.Application.Interfaces.Repos;
using hospitalManagement.Application.Interfaces.UoW;
using hospitalManagement.Infrastructure.Data;
using hospitalManagement.Infrastructure.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HMDbContext _context;

        private IDoctorRepository _doctorRepository;
        private IPatientRepository _patientRepository;
        private IAppointmentRepository _appointmentRepository;
        private IMedicalRecordRepository _medicalRecordRepository;
        private IPrescriptionRepository _prescriptionRepository;
        private IInvoiceRepository _invoiceRepository;
        private IPaymentRepository _paymentRepository;
        private ILabTestRepository _labTestRepository;
        private IResourceRepository _resourceRepository;
        private IResourceAllocationRepository _resourceAllocationRepository;
        private IStaffScheduleRepository _staffScheduleRepository;

        public UnitOfWork(HMDbContext context)
        {
            _context = context;
        }

        public IDoctorRepository Doctors =>
            _doctorRepository ??= new DoctorRepository(_context);

        public IPatientRepository Patients =>
            _patientRepository ??= new PatientRepository(_context);

        public IAppointmentRepository Appointments =>
            _appointmentRepository ??= new AppointmentRepository(_context);

        public IMedicalRecordRepository MedicalRecords =>
            _medicalRecordRepository ??= new MedicalRecordRepository(_context);

        public IPrescriptionRepository Prescriptions =>
            _prescriptionRepository ??= new PrescriptionRepository(_context);

        public IInvoiceRepository Invoices =>
            _invoiceRepository ??= new InvoiceRepository(_context);

        public IPaymentRepository Payments =>
            _paymentRepository ??= new PaymentRepository(_context);

        public ILabTestRepository LabTests =>
            _labTestRepository ??= new LabTestRepository(_context);

        public IResourceRepository Resources =>
            _resourceRepository ??= new ResourceRepository(_context);

        public IResourceAllocationRepository ResourceAllocations =>
            _resourceAllocationRepository ??= new ResourceAllocationRepository(_context);

        public IStaffScheduleRepository StaffSchedules =>
            _staffScheduleRepository ??= new StaffScheduleRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
