# RowCallBackend

## Structure
This repository contains code for SOAP service writen in Java, REST service written in C# and client consuming both of these services that is written in C# as well.

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


# Client (C#)
