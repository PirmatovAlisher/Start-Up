https://github.com/user-attachments/assets/1b7ee889-f847-4637-b642-efec8ea3a9bc

# Star Up 🚀


**Star Up** is a dynamic web application built for business owners. It serves as a complete one-stop solution for showcasing company information, services, portfolios, teams, testimonials, and contact details—all while offering a flexible, real-time content management system. This project was developed as a learning exercise to explore full-stack development with a modern tech stack.

## 📑 Table of Contents

- [Overview](#-overview)
- [Features](#-features)
  - [User Features](#-user-features)
  - [Admin Features](#-admin-features)
- [Tech Stack](#-tech-stack)
- [Project Structure](#-project-structure)
- [Video Demonstrations](#-video-demonstrations)
- [Learnings](#-learnings)
- [Contact](#-contact)

## 🎯 Overview 

**Star Up** started as a learning project where I combined a free landing page front end with a fully customized back end. The project is tailored for business owners who want to showcase comprehensive details about their companies—including services, portfolios, teams, and customer testimonials—while keeping content management seamless and secure.

## ✨ Features 

### 👤 User Features 
- **Account Management:**  
  Users can update their account details, including:
  - 👤 Username
  - ✉️ Email
  - 📞 Phone Number
  - 🖼️ Profile Photo
  - 🔒 Password  
  All changes are secured by requiring the current password for confirmation.

- **Password Recovery:**  
  If a user forgets their login password, a reset link is emailed to them for secure recovery.

- **Interactive Dashboard:**  
  In the Admin Panel, users see a dashboard displaying key metrics such as:
  - Number of Services
  - Number of Teams
  - Number of Testimonials
  - Number of Categories
  - Number of Portfolio Items
  - Number of Registered Users

### 👨‍💼 Admin Features 
- **Full Control:**  
  Only Admin users have complete control over all aspects of the web application.

- **CRUD Functionality:**  
  Admins can manage content with full Create, Read, Update, and Delete (CRUD) capabilities for various pages:
  - ℹ️ About
  - 📂 Category
  - 📞 Contact
  - 🏠 Home Page
  - 🖼️ Portfolio
  - 🛠️ Service
  - 👥 Team
  - 💬 Testimonial

- **User Management:**  
  A dedicated page displays all registered users and their details for effective monitoring.

- **Robust Data Management:**  
  Using an MS SQL database with EntityFrameworkCore ensures data integrity and scalability.

## 🛠️ Tech Stack 

**Star Up** leverages a modern ASP.NET MVC framework alongside other robust libraries and technologies:

- **Backend:**
  - ASP.NET MVC (.NET8) ⚙️
  - MS SQL Database 🗄️
  - EntityFrameworkCore 📚
  - Fluent Validation ✅
  - Identity Library 🔐

- **Notifications & Mapping:**
  - Toaster Notification (NToastNotify) for real-time pop-up alerts 🍞🔔
  - Auto Mapper for seamless object-to-object mapping 🔄

## 🗂️ Project Structure 

The project is organized into distinct layers to ensure maintainability and a clear separation of concerns:

```
StartUp.sln
├── CoreLayer/            # Base Entities, Enumerations, and Models
├── EntityLayer/          # Identity Models, Application Models, and their corresponding View Models
├── RepositoryLayer/      # Context, Extensions, Repositories, and Unit of Work implementations
├── ServiceLayer/         # Auto Mapper, Exception Handling, Extensions, Filters, Middlewares, and Business Services
└── UILayer/              # Controllers, Views, and static resources (including an `Images` folder in `wwwroot`)
```
## Video Demonstrations


https://github.com/user-attachments/assets/62b7e0ce-a0e3-4a50-a4c7-ff2477d9ca92



https://github.com/user-attachments/assets/c7f2aed0-7f01-40f4-bb2f-20ed9667b0a1


## 🧠 Learnings

Throughout the development of Star Up, I gained valuable insights and practical experience in various areas of web development:
- **Full-Stack Integration:**
  - Learned how to seamlessly integrate front-end assets with a robust back-end using ASP.NET MVC, which has broadened my understanding of client-server architecture.
- **Database Management:**
  - Enhanced my skills in using MS SQL and EntityFrameworkCore by designing and configuring a secure, scalable database schema tailored for dynamic content management.
- **Security Practices:**
  - Implemented authentication and authorization mechanisms with Identity library and secured sensitive operations by enforcing password confirmation and reset processes.
- **Modular Architecture:**
  - Adopted a layered project structure (Core, Entity, Repository, Service, UI) that significantly improved code maintainability, scalability, and the overall organization of the application.
- **Third-Party Integrations:**
  - Integrated additional libraries like NToastNotify for user notifications and Auto Mapper for efficient model mapping, expanding my toolkit for building interactive and responsive web applications.
- **Fluent Validation & Exception Handling:**
  - Gained practical experience with Fluent Validation for enforcing input rules and implemented robust exception handling strategies to maintain application stability.
- **Version Control & Collaboration:**
  - Learned best practices in using Git for version control, which will aid future collaborative projects and improve the overall development workflow.

## 📬 Contact
👤 Alisher
<br>  
📧 pirmatovalisher000@gmail.com 
<br>  
📞 **Phone:** +998 (94) 361-99-25
<br>  
💼 [hh.uz](https://hh.uz/resume/a1a1a635ff0e951e320039ed1f4f6e786e7757) 
 












