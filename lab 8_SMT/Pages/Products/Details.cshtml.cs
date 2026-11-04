using lab_8_SMT.Data;
using lab_8_SMT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab_8_SMT.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly ProductRepository _repository;

        public DetailsModel(ProductRepository repository)
        {
            _repository = repository;
        }

        public Product Product { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            Product = product;

            return Page();
        }
    }
}