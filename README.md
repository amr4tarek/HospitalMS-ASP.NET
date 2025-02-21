# Hospital Management System

A robust and scalable Hospital Management System built with ASP.NET Core Web API. This project demonstrates role-based access control, domain-driven design, integration with Stripe for payments, and real-time notifications using SignalR.

---

## Table of Contents

- [Features](#features)
- [Architecture & Tech Stack](#architecture--tech-stack)
- [Project Structure](#project-structure)
- [Installation & Setup](#installation--setup)
- [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
- [Testing the Application](#testing-the-application)
---

## Features

- **Authentication & Role-Based Authorization:**  
    - Supports multiple roles (Doctor, Patient, Staff, Nurse, Admin, etc.) using ASP.NET Core Identity.
    - JWT-based authentication for securing endpoints.
    
- **Domain-Driven Design:**  
    - Clean separation of concerns using Onion Architecture with dedicated Domain, Application, Infrastructure, and API layers.
    
- **Payment Processing with Stripe:**  
    - Integrated Stripe Payment API (using PaymentIntents) to handle test-mode payment transactions.
    
- **Real-Time Notifications with SignalR:**  
    - SignalR hub for broadcasting real-time notifications (e.g., payment status, appointment updates).
    
- **Comprehensive CRUD Operations:**  
    - Manage doctors, patients, appointments, medical records, prescriptions, invoices, payments, lab tests, resources, resource allocations, and staff schedules.
    
- **Extensible & Scalable:**  
    - Designed with a Unit of Work pattern and generic/specialized repositories.
    - AutoMapper for clean DTO-to-entity mapping.

---

## Architecture & Tech Stack

- **Backend Framework:** ASP.NET Core Web API  
- **Authentication:** ASP.NET Core Identity with JWT  
- **Database:** SQL Server (Entity Framework Core ORM)  
- **Real-Time Communication:** SignalR  
- **Payment Processing:** Stripe Payment API (PaymentIntents)  
- **Mapping:** AutoMapper  
- **API Documentation:** Swagger/OpenAPI (optional)  

---

## Project Structure

The project is organized using the Onion Architecture:

- **hospitalManagement.API:**  
    Contains API controllers and startup configuration.
    
- **hospitalManagement.Application:**  
    Contains DTOs, Interfaces, service implementations , SignalR hubs, and mapping profiles.
    
- **hospitalManagement.Domain:**  
    Contains domain entities.
    
- **hospitalManagement.Infrastructure:**  
    Contains Entity Framework DbContext, repository implementations, unit of work, and configuration classes.

---

## Installation & Setup

1. **Clone the Repository:**

     ```bash
     git clone https://github.com/yourusername/hospital-management-system.git
     cd hospital-management-system
     ```

2. **Configure the Database:**

     - Update the connection string in `appsettings.json` under the API or Infrastructure project:
         
         ```json
         "ConnectionStrings": {
                 "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=HospitalManagementDB;Trusted_Connection=True;"
         }
         ```

3. **Configure Stripe and JWT Settings:**

     In your `appsettings.json`, configure your Stripe and JWT settings:

     ```json
     {
         "Stripe": {
             "SecretKey": "your_stripe_secret_key_here",
             "PublishableKey": "your_stripe_publishable_key_here"
         },
         "Jwt": {
             "Key": "your_jwt_secret_key_here",
             "Issuer": "your_issuer",
             "Audience": "your_audience",
             "ExpireDays": "30"
         }
     }
     ```

4. **Install Dependencies:**

     Using the .NET CLI, navigate to each project folder and run:

     ```bash
     dotnet restore
     ```

5. **Database Migration:**

     Apply migrations to create the database schema:

     ```bash
     dotnet ef database update --project hospitalManagement.Infrastructure
     ```

---

## Running the Application

You can run the API using Visual Studio, Visual Studio Code, or via the .NET CLI:

```bash
dotnet run --project hospitalManagement.API
```

The API will start (by default on `https://localhost:7222` or as configured) and Swagger UI (if enabled) will be available at `https://localhost:7222/swagger`.

---

## API Endpoints

Below is an overview of key endpoints. Full details are available via Swagger/OpenAPI if enabled.

### Authentication
- `POST /api/authentication/login`  
- `POST /api/authentication/register/doctor`  
- `POST /api/authentication/register/patient`  
- `POST /api/authentication/register/staff`

### Doctor Management
- `GET /api/doctor/{id}`  
- `GET /api/doctor`  
- `PUT /api/doctor`  
- `DELETE /api/doctor/{id}`

### Patient Management
- `GET /api/patient/{id}`  
- `GET /api/patient`  
- `PUT /api/patient`  
- `DELETE /api/patient/{id}`

### Appointments
- `GET /api/appointment/{id}`  
- `GET /api/appointment/doctor/{doctorId}`  
- `GET /api/appointment/patient/{patientId}`  
- `POST /api/appointment`  
- `PUT /api/appointment`  
- `DELETE /api/appointment/{id}`

### Medical Records
- `GET /api/medicalrecord/{id}`  
- `GET /api/medicalrecord/{id}`  
- `GET /api/medicalrecord/patient/{patientId}`  
- `POST /api/medicalrecord`  
- `PUT /api/medicalrecord`  
- `DELETE /api/medicalrecord/{id}`  

### Prescriptions
- `GET /api/prescription/{id}`  
- `GET /api/prescription/medicalRecord/{medicalRecordId}`  
- `POST /api/prescription`  
- `PUT /api/prescription`  
- `DELETE /api/prescription/{id}`  

### Invoices
- `GET /api/invoice/{id}`  
- `GET /api/invoice/patient/{patientId}`  
- `POST /api/invoice`  
- `PUT /api/invoice`  
- `DELETE /api/invoice/{id}`  

### Payments
- `GET /api/payment/{id}`  
- `GET /api/payment/invoice/{invoiceId}`  
- `POST /api/payment/process`  

### Lab Tests
- `GET /api/labtest/{id}`  
- `GET /api/labtest/patient/{patientId}`  
- `POST /api/labtest`  
- `PUT /api/labtest`  
- `DELETE /api/labtest/{id}`  

### Resources
- `GET /api/resource/{id}`  
- `GET /api/resource`  
- `POST /api/resource`  
- `PUT /api/resource`  
- `DELETE /api/resource/{id}`  

### Resource Allocations
- `GET /api/resourceallocation/{id}`  
- `GET /api/resourceallocation/appointment/{appointmentId}`  
- `POST /api/resourceallocation`  
- `PUT /api/resourceallocation`  
- `DELETE /api/resourceallocation/{id}`  

### Staff Schedules
- `GET /api/staffschedule/{id}`  
- `GET /api/staffschedule/staff/{staffId}`  
- `POST /api/staffschedule`  
- `PUT /api/staffschedule`  
- `DELETE /api/staffschedule/{id}`  

### Payments & Notifications
- `POST /api/payment/process` – Processes a payment via Stripe and triggers a notification.
- `POST /api/notification/payment` – Manually trigger a payment notification.
- `POST /api/notification/appointment` – Manually trigger an appointment notification.

---

## Testing the Application

### Authentication & Role-Based Access
1. **Register Users:**  
     - Use the respective registration endpoints for doctors, patients, and staff.
2. **Login:**  
     - Authenticate using `/api/authentication/login` and obtain a JWT token.
3. **Role-Based Endpoints:**  
     - Use the JWT token to access protected endpoints (e.g., `/api/doctor`, `/api/patient`).

### Stripe Payment Testing
1. **Ensure Test Mode:**  
     - Use Stripe test API keys and the test token (`tok_visa` in the service) for payments.
2. **Process Payment:**  
     - Send a POST request to `/api/payment/process` with a PaymentDto JSON body.
3. **Verify:**  
     - Check the API response and your Stripe dashboard (in test mode) for the created payment.

### Real-Time Notifications (SignalR)
1. **Connect a SignalR Client:**  
     - Use a browser console or Postman’s WebSocket client to connect to `wss://localhost:7222/hubs/notification`.
2. **Trigger Notifications:**  
     - After processing a payment or appointment update, observe the real-time notification messages in the client.
