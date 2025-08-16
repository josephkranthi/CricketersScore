# 🏏 Cricketers Project

A **Full Stack Web Application** built with **Angular 18** (frontend) and **ASP.NET Core 8** (backend).  
This project demonstrates CRUD operations, routing, service layer, and API integration with SQL Server.

---

## 🛠️ Tech Stack

- **Frontend:** Angular 18, TypeScript, HTML, CSS, Bootstrap, JavaScript  
- **Backend:** ASP.NET Core 8 Web API, Entity Framework Core  
- **Database:** SQL Server  
- **Tools:** Visual Studio 2022, GitHub  

---

## ✨ Features

- Angular UI with Template-driven forms  
- CRUD operations (Create, Read, Update, Delete) for Cricketers  
- ASP.NET Core REST API backend  
- Angular Routing (Cricketers & About pages)  
- Service-based architecture for cleaner code  
- Reactive Forms setup (commented for future reference)  

---

## 🗄️ Database Setup

The project uses a **SQL Server** database to store Cricketers data.  

```sql
CREATE TABLE [dbo].[Cricketers](
    [rank] INT NOT NULL,
    [name] VARCHAR(100) NOT NULL,
    [score] INT NOT NULL,
PRIMARY KEY CLUSTERED ([rank] ASC)
);
```
## 🌐 API Endpoints

| Method | Endpoint             | Description                              |
| ------ | -------------------- | ---------------------------------------- |
| GET    | `/Cricketers`        | Get all cricketers                       |
| GET    | `/Cricketers/{id}`   | Get a cricketer by ID                    |
| POST   | `/Cricketers`        | Create a new cricketer (JSON body)       |
| PUT    | `/Cricketers/{id}`   | Update an existing cricketer (JSON body) |
| DELETE | `/Cricketers/{id}`   | Delete a cricketer by ID                 |

### 📦 Example Request Body (POST / PUT)
```json
{
  "rank": 1,
  "name": "Virat Kohli",
  "score": 95
}
```

### 🚀 How to Run the Project
To run the project, follow these steps:

* Clone the repository - git clone https://github.com/<your-username>/TeacherProject.git
* Open the project in Visual Studio 2019 or later.
* Ensure that you have SQl Server installed and running on your machine.
* Update appsettings.json with your SQL Server connection string.
* Run the project → API runs on https://localhost:5001 or http://localhost:5000.
* Frontend (Angular 17)
  ``` text 
cd ClientApp
npm install
ng serve -o
```
Runs the Angular app at http://localhost:4200/.
