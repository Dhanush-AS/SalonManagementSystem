Salon Management System

Overview

The Salon Management System is a web-based application built using ASP.NET Core MVC and Web API, designed to streamline salon operations such as booking appointments, managing services, and handling user roles (Admin & Customers). The system is integrated with Azure Cosmos DB for data storage and various Azure Cloud services for scalability and performance.

Features

1. User Management

Admin and Customer roles

Secure user authentication with JWT

Customer registration & approval process by Admin

2. Salon & Service Management

Admin can add, update, and remove salons

Define available services (haircut, styling, spa, etc.)

Pricing and duration management

3. Appointment Booking System

Customers can book appointments based on available slots

Appointment confirmation & cancellation

Booking history for customers

4. Real-time Notifications & Messaging

Appointment reminders via email notifications

Admin notifications for new bookings & cancellations

5. Payment & Billing (Future Scope)

Integration with payment gateways for online payments

Technology Stack

Backend

ASP.NET Core Web API (for handling business logic)

ASP.NET Core MVC (for web interface)

C# & Entity Framework Core (for database interactions)

Azure Cosmos DB (NoSQL database)

Frontend

Razor Views (MVC) for UI

Bootstrap, HTML, CSS, JavaScript for styling

Cloud & DevOps

Azure Service Bus (for event-driven notifications)

Azure App Service (for hosting the application)

Azure Function App & WebJobs (for background tasks)

Azure Key Vault (for secure credentials management)

Azure DevOps (CI/CD pipeline for automated deployment)

Application Insights (for monitoring and diagnostics)



Developed by Dhanush 🚀

