# Logiwa Case Study

Welcome to my **Logiwa Case Study(Code Challenge)!** I have prepared an e-commerce merchandising management system for **Logiwa.**
Our main goal in this project is to create a business flow for CRUD transactions in our "Product" domain.


## Technology Stack

- .Net Core 5.0
- C#
- RestAPI (.Net Core Web API)
- Entity Framework Core
- AutoMapper
- FluentValidation
- SwashBuckle(Swagger)
- MSSQL - SQL Server
- Redis
- Docker
- xUnit


## Endpoints
**Product Controller**

![Product Controller](https://i.ibb.co/VgCKt7m/resim-2021-12-18-021605.png)

- /api/product/ [HttpGet]
> This HttpGet action lists all Products.

- /api/product/GetByCriteria [HttpGet]
> This HttpGet action lists Products by Criteria. (Filtering action)

- /api/product/GetByQuantity [HttpGet]
> This HttpGet action lists Products by Stock Quantity. (Filtering action)

- /api/product/ [HttpPost]
> This HttpPost action creates product according to our validation rules.

- /api/product/ [HttpPut]
> This HttpPut action updates the product that chosen by Product's ID.

- /api/product/{id} [HttpDelete]
> This HttpDelete deletes the product that chosen by Product's ID.

<br>

**Category Controller**

![CategoryController](https://i.ibb.co/LtfsYJg/resim-2021-12-15-010926.png)

- /api/category/ [HttpGet]
> This HttpGet action lists all Categories.

- /api/category/ [HttpPost]
> This HttpPost action creates category category.

- /api/category/ [HttpPut]
> This HttpPut action updates the category that chosen by Category's ID.

- /api/category/{id} [HttpDelete]
> This HttpDelete deletes the category that chosen by Category's ID.

## Seed Data

In order to testability of the web api project, There are 2 tables seeded "Product" and "Category". With these data the project is ready to run and tested.

![SeedingData](https://i.ibb.co/4gvsm0X/resim-2021-12-14-225842.png)

## Dockerize

In order to launch the project, Docker Desktop (with SQLServer, Redis images) is required.

![DockerContainers](https://i.ibb.co/gw8qMbx/resim-2021-12-18-021841.png)

## Unit Test

xUnit used as testing technique which using for individual modules are tested to determine if there are any issues.

![UnitTests](https://i.ibb.co/wsXLhVj/resim-2021-12-18-022710.png)

## Product Validation Rules

- Title cannot be null or empty and have a maximum character limitation of 200.
- Product can only have one category.
- Product must have a category to be live.
- Product should have a minimum stock quantity in Category level and Products with stock quantity under this limit cannot be live.

![ProductValidationRules](https://i.ibb.co/jHCZL2f/resim-2021-12-18-022407.png)

# To Do / Nice to Have

Done? | To Do | Date
:---:| :---: | ---
✅| SQL Server (DB Change) | 15.12.2021
✅| Docker Deployment | 15.12.2021
✅| Unit Test | 16.12.2021
✅| Redis Cache | 17.12.2021
⬜️| Generic Repository | 
