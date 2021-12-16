# Logiwa Case Study

Welcome to my **Logiwa Case Study(Code Challenge)!** I have prepared an e-commerce merchandising management system for **Logiwa.**
Our main goal in this project is to create a business flow for CRUD transactions in our "Product" domain.


## Technology Stack

- .NetCore 5.0
- C#
- RestAPI
- .Net Framework
- ASP .NetCore
- Entity Framework Core
- AutoMapper, FluentValidation,SwashBuckle(Swagger)
- MSSQL (In Memory Database)
It has been designed and coded in accordance with the Domain Driven Design structure and layered architecture(Onion architecture).

## Endpoints
**Product Controller**

![Product Controller](https://i.ibb.co/zs5Fq2v/resim-2021-12-14-224210.png)

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

In order to testability of the web api project, There are 2 tables named "Product" and "Category". With these data the project is ready to run and tested.

![SeedingData](https://i.ibb.co/4gvsm0X/resim-2021-12-14-225842.png)

# To Do / Nice to Have

Done? | To Do
:---:| ---
⬜️| Redis DB
✅| SQL Server (DB Change)
✅| Docker Deployment
✅| Unit Test
⬜️| Generic Repository
