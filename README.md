# SearchTerm.API

The Solution File contains 3 Projects
SearchTerm.Api
SearchTerm.Tests
SearchTerm.UI

SearchTerm.Api
This Asp.net Core rest api project with .Net framework .Net 6.0 implemets the asynchronous api end points actions for CreateUsers and GetUsers based on the search string passed.The architecture is MVC with DI Design pattern/Abstract Fatory with EF core inmemory Database.

Validation - FluentValidation.
Object Mapping - AutoMapper
Exception - GlobalExceptionHanlder added as Middleware
CORS enabled for just the Angular UI

SearchTerm.API project can be run in isolation and can be tested usimg swagger by rightclicking on the Api project and Debug->start new instance
![image](https://user-images.githubusercontent.com/100000716/220478535-c340b492-6f0f-4055-8bb3-9372f3c0e28a.png)

![image](https://user-images.githubusercontent.com/100000716/220478412-19c3d53c-5adf-4c0a-a8c5-cc13632715bf.png)

and Api's can be tested in swagger
![image](https://user-images.githubusercontent.com/100000716/220478675-0ac89f89-ff22-41a8-8375-12c102b324f4.png)
![image](https://user-images.githubusercontent.com/100000716/220478701-c07f4d53-2796-4107-a27b-899255ddd8db.png)

Post User Example
![image](https://user-images.githubusercontent.com/100000716/220478948-18b226c4-5396-4509-871c-a05a429d4ecb.png)
![image](https://user-images.githubusercontent.com/100000716/220478979-7e021cbe-d595-48a7-9a19-c45dfc1af6c6.png)
