using ExampleApplication.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExampleApplication.Pages.Products
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Product NewProduct { get; set; } = new Product();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            
            if (int.TryParse(NewProduct.Price, out int price) && price > 1000)
            {
                
                int newId = FakeDatabase._products.Any() 
                    ? FakeDatabase._products.Max(p => p.Id) + 1 
                    : 1;

                
                var newProduct = new Product
                {
                    Id = newId,
                    Name = NewProduct.Name,
                    Price = NewProduct.Price,
                    Color = NewProduct.Color,
                    Age = NewProduct.Age,
                    Animal = NewProduct.Animal,
                };

            
                FakeDatabase._products.Add(newProduct);
                
                TempData["Response"] = "Товар успешно добавлен!";
            }
            else
            {
                TempData["Response"] = "Товар не добавлен, цена должна быть больше 1000";
            }

            return RedirectToPage("Index");
        }
    }
}