using ExampleApplication.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExampleApplication.Pages.Products
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Product ProductToDelete { get; set; } = new Product();

        public void OnGet(int id)
        {
            var product = FakeDatabase._products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                ProductToDelete = product;
            }
        }

        public IActionResult OnPost()
        {
            var product = FakeDatabase._products.FirstOrDefault(x => x.Id == ProductToDelete.Id);
            if (product != null)
            {
                FakeDatabase._products.Remove(product);
                TempData["Response"] = $"Животное \"{product.Name}\" успешно удалено!";
            }
            else
            {
                TempData["Response"] = "Животное не найдено!";
            }

            return RedirectToPage("Index");
        }
    }
}