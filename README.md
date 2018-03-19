# RowCallBackend

## Structure
This repository contains code for SOAP service writen in Java, REST service written in C#, client consuming the REST service (made with HTML) and another client consuming the SOAP service made with Java.  

Code will first be used as a mandatory assignment for System Integration and later on will be refactored into Final project for System Integration and Development of Large Systems.

## Functionality
Final goal of this project is to have a web application that enables teacher to check attendance of students. We divide this application int three parts: Student's client, Teacher's client and Webservice.

### Student's client
Extremly simple client where student logs in and writes down key generated by teacher. 

### Teacher's client
Teacher has this functionality:
  Login 
  See list of all his classes (CRUD for this) 
  Each class has list of students 
  Generate a key for a class (key is bound to date and time) 

### Webservice
Webservice is a backend for both of these clients and provides them with all data and they need.

# SOAP Service (Java)
Main reason why we decided to use SOAP webservice is to fulfill requirements of mandatory assignment for System Integration. 
For this reason we are using this service for very simple funcitonality (returning a date object).

# REST Service (C#)
This rest can create and retrieve users from a local MSSQL database. 

### Requirements
You will need Visual Studio 2017 with .Net Core 2.x SDK. 

### Setup
1. Clone this repository
2. Open Package Manager Console (Tools > NugetPackageManager > NugetPackageManagerConsole) 
3. Run the following command: EntityFrameworkCore\Update-Database (This will create the database which will contain the users!) 

### Usage
You can choose to use either the client we made or your own (PostMan, Fiddler etc.).
This is a simple RESTful webservice with 3 methods: Get, GetAll and Create. To use these methods use the following URL: 

http://localhost:8080/api/users/{id}

The id parameter is optional and its refering to the user id. It can only be used when calling the GET method (not GetAll!). The Create method will create a user with a random username and email but the password will always be Password123. 

Extra: 

http://localhost:8080/account/create

This method will create a user and you will need to provide the email and password in the body as json. Use the following template (Username are treated as email and will be validated as a email at the server!): 

{
  "userName": "YourEmail", 
  "password": "YourPassword"
}



# Client (HTML)
This client is made with HTML, CSS and Javascript. Run the RESTful webservice before running the client! It should be ready to go when the webservice is running and you can see all users and create a random one. 
