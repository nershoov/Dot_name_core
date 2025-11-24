using ExampleApplication.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExampleApplication.Pages.Products
{
    public class EditClassModel : PageModel
    {
        [BindProperty]
        public Product MyProduct { get; set; } = new Product();

        public void OnGet(int Id)
        {
            try
            {
                var localproduct = FakeDatabase._products.FirstOrDefault(x => x.Id == Id);
                if (localproduct == null)
                {
                    throw new Exception($"Животное с ID {Id} не найдено в базе данных");
                }

                MyProduct = localproduct;
            }
            catch (Exception ex)
            {
                TempData["Response"] = $"Ошибка при загрузке животного: {ex.Message}";
                
            }
        }

        public IActionResult OnPost()
        {
            try
            {
                
                var localproduct = FakeDatabase._products.FirstOrDefault(x => x.Id == MyProduct.Id);
                if (localproduct == null)
                {
                    throw new Exception($"Животное с ID {MyProduct.Id} не найдено в базе данных");
                }


                if (!int.TryParse(MyProduct.Price, out int price))
                {
                    throw new Exception("Цена должна быть числом");
                }

                if (price <= 1000)
                {
                    throw new Exception("Цена должна быть больше 1000");
                }

                
                localproduct.Name = MyProduct.Name;
                localproduct.Price = MyProduct.Price;
                localproduct.Color = MyProduct.Color;
                localproduct.Age = MyProduct.Age;
                localproduct.Animal = MyProduct.Animal;

                TempData["Response"] = "товар успешно отредактирован";
            }
            catch (Exception ex)
            {
                TempData["Response"] = $"Ошибка при сохранении данных: {ex.Message}";
                
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}