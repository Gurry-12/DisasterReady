# 🌪️ DisasterReady - Backend

**DisasterReady** is a backend service for a real-time disaster management system, built using **ASP.NET Core Web API** with **Clean Architecture** principles. It is designed to support features like real-time alerts, user role management, logging, and disaster-related activity tracking.

---

## 📁 Project Structure

```
DisasterReady/
│
├── DisasterReady.API/               # Entry point – Controllers, Swagger, Middlewares
├── DisasterReady.Application/       # Business logic, DTOs, Services, Interfaces
├── DisasterReady.Domain/            # Core entities and domain models
├── DisasterReady.Infrastructure/    # Shared infrastructure services (e.g., email, caching)
├── DisasterReady.Persistence/       # EF Core, Repositories, DbContext, migrations
├── DisasterReady.Shared/            # Common models (constants, enums, helpers)
└── README.md
```

---

## 🧱 Architecture Overview

* **Clean Architecture**
* **.NET 8 Web API**
* **Entity Framework Core**
* **Swagger** for API documentation

---

## ✅ Current Modules

* 🔐 **User Management**

  * Create, update, delete users
  * Update user roles/status
* 📢 **Activity Tracking**

  * Logs disaster-related activities
* 📁 **Role Management**
* 📝 **Audit Logging** via BaseAuditableEntity

---

## 🧰 Tools & Libraries

* ASP.NET Core 8
* Entity Framework Core
* Swagger / Swashbuckle
* AutoMapper
* MediatR (optional for CQRS pattern)

---

## 🌐 Future Goals

* 🧱 Implement custom `Result<T>` response pattern for unified API results
* 🎧 Real-time voice communication with noise cancellation (e.g., ElevenLabs, WebRTC)
* 🧠 AI-based disaster prediction service integration
* 📊 Admin dashboards with analytics & heatmaps
* 🛍️ Citizen disaster reporting module
* 👥 NGO and Government collaboration features
* 🚀 Docker + Kubernetes deployment setup
* 📊 CI/CD pipeline (GitHub Actions)
* 📲 Mobile app integration layer (API ready)
* 📜 Structured logging (Serilog or similar) if needed

---

## 🛡️ License

MIT License

---

## 👨‍💻 Maintainer

**Gurpreet Singh**

