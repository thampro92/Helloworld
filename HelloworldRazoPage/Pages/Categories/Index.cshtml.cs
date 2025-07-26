using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HelloworldRazorPage.Data;
using HelloworldRazorPage.Models;

namespace HelloworldRazorPage.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public List<Category> categories { get; set; } = new List<Category>(); // Thêm public và khởi tạo
        
        public IndexModel(ApplicationDBContext db)
        {
            _db = db;
        }
        
        public void OnGet()
        {
            categories = _db.categories.ToList();
        }
    }
}
