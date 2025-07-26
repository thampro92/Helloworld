using Helloworld.Data;
using Helloworld.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helloworld.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDBContext _db;
        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            // Lấy danh sách các Category từ cơ sở dữ liệu
            List<Category> categories = _db.categories.ToList();
            return View(categories);
        }

        // GET - Create
        public IActionResult Create()
        {
            return View();
        }

        // POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj == null)
            {
                return NotFound(); // Trả về NotFound nếu đối tượng Category là null
            }

            if (obj.Name == obj.DisplayOrder)
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name"); // Thêm lỗi tùy chỉnh nếu Name và DisplayOrder giống nhau
            }

            if (ModelState.IsValid)
            {
                _db.categories.Add(obj); // Thêm đối tượng Category vào DbSet
                _db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                TempData["success"] = "Category created successfully"; // Hiển thị thông báo thành công
                return RedirectToAction("Index"); // Chuyển hướng về trang Index
            }
            return View(obj); // Trả về view Create nếu có lỗi
        }

        // GET - Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound(); // Trả về NotFound nếu id là null hoặc 0
            }
            var categoryFromDb = _db.categories.Find(id); // Tìm Category theo id
            if (categoryFromDb == null)
            {
                return NotFound(); // Trả về NotFound nếu không tìm thấy Category
            }
            return View(categoryFromDb); // Trả về view Edit với đối tượng Category
        }

        // POST - Edit
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (category == null)
            {
                return NotFound(); // Trả về NotFound nếu đối tượng Category là null
            }
            if (category.Name == category.DisplayOrder)
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name"); // Thêm lỗi tùy chỉnh nếu Name và DisplayOrder giống nhau
            }
            if (ModelState.IsValid)
            {
                _db.categories.Update(category); // Cập nhật đối tượng Category trong DbSet
                _db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                TempData["success"] = "Category updated successfully"; // Hiển thị thông báo thành công
                return RedirectToAction("Index"); // Chuyển hướng về trang Index
            }
            return View(category); // Trả về view Edit nếu có lỗi
        }

        // GET - Delete    
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var categoryFromDb = _db.categories.Find(id); // Tìm Category theo id
            if (categoryFromDb == null)
            {
                return NotFound(); // Trả về NotFound nếu không tìm thấy Category
            }
            
            return View(categoryFromDb); // Trả về view Delete với đối tượng Category
        }

        // POST - Delete
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound(); // Trả về NotFound nếu id là null hoặc 0
            }
            var categoryFromDb = _db.categories.Find(id); // Tìm Category theo id
            if (categoryFromDb == null)
            {
                return NotFound(); // Trả về NotFound nếu không tìm thấy Category
            }
            _db.categories.Remove(categoryFromDb); // Xóa Category khỏi DbSet
            _db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            TempData["success"] = "Category deleted successfully"; // Hiển thị thông báo thành công
            return RedirectToAction("Index"); // Chuyển hướng về trang Index    
        }
    }
}
