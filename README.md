# SearchTerm.API

The Solution File contains 3 Projects
SearchTerm.Api
SearchTerm.Tests
SearchTerm.UI

Pre-requirement
Node.js must be installed in the machine and can be downloaded from here https://nodejs.org/en/

#SearchTerm.Api
This Asp.net Core rest api project with .Net framework .Net 6.0 implemets the asynchronous api end points actions for CreateUsers and GetUsers based on the search string passed.The architecture is MVC with DI Design pattern/Abstract Fatory with EF core inmemory Database.

Validation - FluentValidation.
Object Mapping - AutoMapper
Exception - GlobalExceptionHanlder added as Middleware
CORS enabled for just the Angular UI

These are added to the project through Nuget package manager

SearchTerm.API project can be run in isolation and can be tested usimg swagger by rightclicking on the Api project and Debug->start new instance

![image](https://user-images.githubusercontent.com/100000716/220478535-c340b492-6f0f-4055-8bb3-9372f3c0e28a.png)

![image](https://user-images.githubusercontent.com/100000716/220478412-19c3d53c-5adf-4c0a-a8c5-cc13632715bf.png)

and Api's can be tested in swagger

![image](https://user-images.githubusercontent.com/100000716/220478675-0ac89f89-ff22-41a8-8375-12c102b324f4.png)
![image](https://user-images.githubusercontent.com/100000716/220478701-c07f4d53-2796-4107-a27b-899255ddd8db.png)

Post User Example
![image](https://user-images.githubusercontent.com/100000716/220478948-18b226c4-5396-4509-871c-a05a429d4ecb.png)
![image](https://user-images.githubusercontent.com/100000716/220478979-7e021cbe-d595-48a7-9a19-c45dfc1af6c6.png)

#SearchTerm.UI
The UI project must be run in parellel with Api as UI end api running.
Once tbe project is successfully started,Angular app can be accessed in the browser with  http://localhost:4200

![image](https://user-images.githubusercontent.com/100000716/220479502-824be00c-30b7-40ba-99b3-91b1b486a960.png)
![image](https://user-images.githubusercontent.com/100000716/220479592-8e0f699e-cfdc-4f25-8b81-4a3e1c4702fb.png)

Searcning for a user will display matched user

![image](https://user-images.githubusercontent.com/100000716/220479701-a3d561df-1d3b-49d7-96fd-9317bd69ddce.png)
![image](https://user-images.githubusercontent.com/100000716/220480859-22729809-0401-4605-91d8-640592b91559.png)

#SearchTerm.Tests
Controller
Service and Repository methods are tested, can be run in Visual studio test exloper

![image](https://user-images.githubusercontent.com/100000716/220480991-39f5a0c5-1d9f-4f4a-af37-bb87f2b7540c.png)


