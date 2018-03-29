using BotDetect.Web.Mvc;
using BotDetect.Web.UI;

using Doandinhduong.Common;
using Doandinhduong.Models;
using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Doandinhduong.Controllers
{
    public class NguoidungController : BaseController
    {
        //
        // GET: /Nguoidung/

        [HttpGet]
        public ActionResult Index(string username)
        {
            var model = new NguoidungDao().GetThongtin(username);
            if (model == null)
            {
                SetViewBag();
                SetViewBagGioitinh();
            }
            else
            {
                SetViewBag(model.Loai);
                SetViewBagGioitinh(model.Gioitinh);
            }
            
            return View(model);
            
        }
       
        public void SetViewBag(string tenloai = null)
        {
            var dao = new KieuNguoiDao();
            ViewBag.Loai = new SelectList(dao.ListAll(), "Loai", "Loai", tenloai);
        }
        public void SetViewBagGioitinh(string Gioitinh = null)
        {
            var dao = new SexDao();
            ViewBag.Gioitinh = new SelectList(dao.ListAll(), "Gioitinh", "Gioitinh", Gioitinh);
        }
       
        
        [HttpGet]
        public ActionResult ThongtinNguoidung(int id)
        {
            var model = new NguoidungDao().ListBykieunguoimuctieu(id);

            return View(model);
        }
        [HttpGet]
        public ActionResult TheodoiNguoidung(string username)
        {
            var model = new NguoidungDao().Listbytheodoinguoidung(username);

            return View(model);
        }
        public ActionResult Edit(string username)
        {
            var model = new NguoidungDao().GetById(username);

            return View(model);
        }
       
        [HttpPost]
        public ActionResult Edit(Nguoidung nguoidung) // Tạo tài khoản
        {
            var url = "ThongtinNguoidung/" + nguoidung.ID_Nguoidung;
            if (ModelState.IsValid)
            {
                var dao = new NguoidungDao();
                var result = dao.Update(nguoidung);
                if (result)
                {
                    return RedirectToAction("ThongtinNguoidung", "Nguoidung", new { @id = nguoidung.ID_Nguoidung });
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View(url);

        }
        public ActionResult Getthongtincalo(string username)
        {
            var model = new NguoidungDao().GetThongtin(username);
           

            return View(model);
        }
        [HttpPost]
        public JsonResult Changethongtin(string username, int tuoi, string gioitinh, decimal cannang, decimal chieucao, string kieunguoi)
        {
            var result = new NguoidungDao().Changethongtin(username, tuoi, gioitinh, cannang, chieucao, kieunguoi);
            return Json(new
            {
                status = result
            });
        }
        [HttpPost]

        public JsonResult Changecalo(string username, decimal? calories)
        {
            var result = new NguoidungDao().Changecalo(username, calories);
            return Json(new
            {
                status = result
            });
        }
    }
}
