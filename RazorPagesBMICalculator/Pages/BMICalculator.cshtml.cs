using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace RazorPagesBMICalculator.Pages
{
    public class BMICalculatorModel : PageModel
    {
        [TempData]
        public string ResultInfo { get; set; }

        [Required]
        [BindProperty]
        public double Weight { get; set; }
        [Required]
        [BindProperty]
        public int Height { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            double result = (Weight / (((double)Height / 100) * ((double)Height / 100)));

            if (result < 18.5)
            {
                ResultInfo = $"Underweight (BMI: {result})! Time to eat a few donuts!";
            }
            else if (result < 24.9)
            {
                ResultInfo = $"Normal weight (BMI: {result})! It's OK to eat a few donuts!";
            }
            else if (result < 29.9)
            {
                ResultInfo = $"Overweight (BMI: {result})! But have you heard of anybody who died because of a donut?";
            }
            else
            {
                ResultInfo = $"Obese (BMI: {result})! OK, just one donut, right?";
            }

            return RedirectToPage();
        }
    }
}