using Image_Upload_DFA_.Models;
using Microsoft.AspNetCore.Mvc;

namespace Image_Upload_DFA_.Controllers
{
    public class ProductController : Controller
    {
        private readonly ImageDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductController(ImageDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductVM product)
        {
            string filename = "";

            if (product.Picture != null) {

                var ext = Path.GetExtension(product.Picture.FileName);
                var size = product.Picture.Length;

                if (ext.Equals(".png") || ext.Equals(".jpg") || ext.Equals(".jpeg"))
                {

                    if(size <= 1000000)
                    {
                        string folder = Path.Combine(_env.WebRootPath, "Images");
                        filename = product.Picture.FileName;
                        string filepath = Path.Combine(folder, filename);
                        product.Picture.CopyTo(new FileStream(filepath, FileMode.Create));

                        Product p = new Product()
                        {
                            Name = product.Name,
                            Price = product.Price,
                            ImagePath = filename
                        };

                        _context.Products.Add(p);
                        _context.SaveChanges();
                        TempData["Success"] = "Product Added...";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Size_Error"] = "The file should be less than 1MB";
                    }

                }
                else
                {
                    TempData["Ext_Error"] = "Only .png, .jpg, .jpeg allowed.";
                }
            }
             
            return View();
        }
    }
}
