using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using temfullcn.Models;
using X.PagedList;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace temfullcn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        QlgiaiBongDaContext db = new QlgiaiBongDaContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {

            //var trongtais = db.Trongtais.Take(12).ToList();

            int pageSize = 3;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lst = db.Trongtais.AsNoTracking().OrderBy(x => x.TrongTaiId);
            PagedList<Trongtai> lstPT = new PagedList<Trongtai>(lst, pageNumber, pageSize);

            return View(lstPT);
        }

        public IActionResult Privacy()
        {
            return View();
        }




        [HttpGet]
        public JsonResult GetData(string MaTranDau)
        {
            // Lấy danh sách ID loại sách dựa trên tên loại
            var trongTaiIds = db.TrongtaiTrandaus.AsNoTracking()
                         .Where(x => x.TranDauId == MaTranDau)
                         .Select(x => x.TrongTaiId)
                         .ToList();

            // Lấy danh sách sách dựa trên ID loại sách và chuyển sang class vô danh
            var trongtais = (from p in db.Trongtais
                             where trongTaiIds.Contains(p.TrongTaiId)
                             select new
                             {
                                 HoVaTen = p.HoVaTen,
                                 NgaySinh = p.NgaySinh,
                                 Anh = p.Anh

                             }).ToList();

            // Trả về dữ liệu dưới dạng JSON
            return Json(trongtais);





        }








        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {


            //ViewBag.Clbnha = new SelectList(db.Caulacbos.ToList(), "CauLacBoId", "TenClb");
            //ViewBag.Clbkhach = new SelectList(db.Caulacbos.ToList(), "CauLacBoId", "TenClb");
            //ViewBag.SanVanDongId = new SelectList(db.Sanvandongs.ToList(), "SanVanDongId", "TenSan");


            return View();
        }



        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Trongtai trongtai)
        {
         

            //ViewBag.Clbnha = new SelectList(db.Caulacbos.ToList(), "CauLacBoId", "TenClb");
            //ViewBag.Clbkhach = new SelectList(db.Caulacbos.ToList(), "CauLacBoId", "TenClb");
            //ViewBag.SanVanDongId = new SelectList(db.Sanvandongs.ToList(), "SanVanDongId", "TenSan");

            if (ModelState.IsValid)
            {
                db.Trongtais.Add(trongtai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trongtai);
        }

        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit(string? id)
        {

            var trongTai = db.Trongtais.Where(x => x.TrongTaiId == id).SingleOrDefault();


            return View(trongTai);

        }
        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(Trongtai trongtai)
        {
            if (ModelState.IsValid)
            {
                db.Update(trongtai);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");


        }







        [HttpGet]
        [Route("Details")]
        public IActionResult Details(string? id)
        {

            var trongTai = db.Trongtais.Where(x => x.TrongTaiId == id).SingleOrDefault();


            return View(trongTai);

        }




        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["Error"] = "ID không hợp lệ.";
                return RedirectToAction("Index", "Home");
            }

            try
            {
                // Xóa các bản ghi trong bảng TrongtaiTrandaus liên quan đến Trọng tài
                var lstTrongTaiTranDau = db.TrongtaiTrandaus
                                           .AsNoTracking()
                                           .Where(x => x.TrongTaiId == id)
                                           .ToList();

                if (lstTrongTaiTranDau.Any())
                {
                    db.TrongtaiTrandaus.RemoveRange(lstTrongTaiTranDau);
                    db.SaveChanges();
                }

                // Xóa bản ghi trong bảng Trongtais
                var trongTai = db.Trongtais.FirstOrDefault(x => x.TrongTaiId == id);
                if (trongTai != null)
                {
                    db.Trongtais.Remove(trongTai);
                    db.SaveChanges();
                }

                TempData["Message"] = "Trọng tài đã được xóa thành công.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Xóa trọng tài thất bại: " + ex.Message;
            }

            return RedirectToAction("Index", "Home");
        }












        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
