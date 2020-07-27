# Tiered software development project

This is my project for SDV701 course.
During the course I've developed a database-driven system, that is required to manage the inventory of some company.
Architecture includes:

- gRPC service server-side application
- WPF client for administration, managing items at warehouse and viewing orders
- WEB client for customers

## Server part

Server-side application built using .net Core 3.1 gRPC service with MSSQL Server as data storage.
The app supports gRPC calls over HTTP/2 and gRPC Web for web client communication.
Most of server-side logic, like item quantity checks and forming orders located inside SQL stored procedures.
Listing of procedures can be found [here](Database_Scripts.sql)
