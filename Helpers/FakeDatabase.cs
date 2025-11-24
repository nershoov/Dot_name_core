namespace ExampleApplication.Helpers
{
    static public class FakeDatabase
    {
        static public List<Product> _products = new List<Product>() {
            new Product{
                Id = 1,
                Name = "Бобик",
                Price = "12000",
                Color = "brown",
                Age = "3",
                Animal = "dog"
            },
            new Product{
                Id = 2,
                Name = "Маруся",
                Price = "10000",
                Color = "black",
                Age = "2",
                Animal = "cat"
            },
            new Product{
                Id = 3,
                Name = "Антон",
                Price = "2000",
                Color = "green",
                Age = "10",
                Animal = "turtle"
            },
            new Product{
                Id = 4,
                Name = "Лариса",
                Price = "3500",
                Color = "white",
                Age = "1",
                Animal = "rat"
            }
        };
    }
}
