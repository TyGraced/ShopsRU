The project is divided into 4: API, Core, Infrastructure and shopsRUs.Test

The API is what is used to launch the project as that is where the startup and controllers are.

The Core contains the entities, the requests and response objects.

The infrastructure contains the services/repositories and interfaces and the AppDbContext and migrations.

The shopRUs contains test cases for DiscountService, Product Controller and CustomerService.

When you run the project via the API, it takes you to the Swagger UI where you can test all the endpoints and consume.

I used SQLite for the database.

After cloning athe project, restore all dependencies.

Already, the products have been seeded. So just run migration using package-manager console command - update-database.

Then you're good to go.

Also, I have provided endpoints for creating customers, getting customers, creating products and getting products.

