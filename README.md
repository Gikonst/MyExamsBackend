# Exam and Certification Platform

## Overview

This platform allows users to register, take exams, and manage certificates. Administrators can manage exams, questions, answers, and programming languages. It features secure authentication and a scalable design with many-to-many relationships.

---

## Features

### User
- Register and log in.
- Take exams and view/download certificates.

### Admin
- Manage exams, questions, answers, and programming languages.

---

## Tech Stack

- **Backend**: ASP.NET Core, Entity Framework Core, AutoMapper, BCrypt.Net.
- **Database**: MS SQL Server with 6 models and 8 tables.
- **Utilities**: Newtonsoft.Json for JSON handling, Identity for authentication.

---

## API Highlights

- **User**: Register, login, take exams, manage certificates.
- **Admin**: CRUD operations for exams, questions, and programming languages.
- **Total**: 32 endpoints.

---

## Setup

1. Clone the repository:
https://github.com/your-repo/exam-certification-platform.git

2. Go to appsettings.json:

Paste under "AllowedHosts": "*",:
  "JwtSettings": {
    "Key": "EnterYour32CharacterKeyHere",
    "Issuer": "YourApp",
    "Audience": "YourAppAudience",
    "DurationInMinutes": 60,
  },
  "ConnectionStrings": {
    "DefaultConnection": ""
  }

3. Open NuGet Package Concole in Visual Studio:
Type: "Add-Migration Initial_Create" + Press Enter

After it is built successfully type: Update_Database

# Voila you are ready to go!

