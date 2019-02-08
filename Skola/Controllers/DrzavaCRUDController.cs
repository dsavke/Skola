using Skola.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace Skola.Controllers
{
    public class DrzavaCRUDController : Controller
    {
        // GET: DrzavaCRUD
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult List(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            { 
                using (var context = new SkolaContext()) {

                    var states = context.Drzavas.Select(d => new
                    {
                        d.DrzavaID,
                        d.Naziv
                    }).ToList();

                    var count = states.Count;

                    var records = states.OrderBy(jtSorting).Skip(jtStartIndex).Take(jtPageSize).ToList();

                    return Json(new { Result = "OK", Records = records, TotalRecordCount = count });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Create(Drzava drzava)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                using (var context = new SkolaContext())
                {
                    context.Drzavas.Add(drzava);
                    context.SaveChanges();
                    return Json(new { Result = "OK", Record = drzava });

                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Update(Drzava drzava)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                using (var context = new SkolaContext())
                {
                    Drzava updatedDrzava = context.Drzavas.Find(drzava.DrzavaID);

                    updatedDrzava.DrzavaID = drzava.DrzavaID;
                    updatedDrzava.Grads = drzava.Grads;
                    updatedDrzava.Naziv = drzava.Naziv;

                    context.SaveChanges();

                    return Json(new { Result = "OK" });

                }

                
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Delete(int drzavaID)
        {
            try
            {

                using (var context = new SkolaContext())
                {
                    context.Drzavas.Remove(context.Drzavas.Find(drzavaID));
                    context.SaveChanges();
                    return Json(new { Result = "OK" });
                }
                
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

    }
}