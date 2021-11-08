namespace Core.Dtos.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Customers
        {
            public const string GetAll = Base + "/allcustomers";

            public const string GetById = Base + "/customers/get/{customerId}";

            public const string GetByName = Base + "/customers/{name}";

            public const string Create = Base + "/customers";
        }

        public static class Discounts
        {
            public const string GetAll = Base + "/discounts/all";

            public const string GetByType = Base + "/discounts/{discountType}";

            public const string Create = Base + "/discounts";
        }

        public static class Invoice
        {
            public const string Get = Base + "/totalInvoiceAmount";
        }

        public static class Products
        {
            public const string GetAll = Base + "/products";

            public const string GetByName = Base + "/products/get/{productName}";

            public const string GetById = Base + "/products/{productId}";

            public const string Create = Base + "/products";

        }
    }
}
