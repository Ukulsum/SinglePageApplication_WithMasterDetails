using Microsoft.AspNetCore.Mvc;
using SinglePageApplication.Models;
using SinglePageApplication.ViewModels;

namespace SinglePageApplication.Controllers
{
    public class SalesController : Controller
    {
        //SinglePageSalesDbContext db = new SinglePageSalesDbContext();
        private readonly SinglePageSalesDbContext db;
        private readonly IWebHostEnvironment environment;
        public SalesController(SinglePageSalesDbContext _db, IWebHostEnvironment _environment)
        {
            db = _db;
            environment = _environment;
        }
        public IActionResult Single(int? id)
        {
            VmSales oSale = new VmSales();
            var oSM = db.SalesMaster.Where(x => x.SaleId == id).FirstOrDefault();
            if (oSM != null)
            {
                oSale.SaleId = oSM.SaleId;
                oSale.CreateDate = oSM.CreateDate;
                oSale.CustomerName = oSM.CustomerName;
                oSale.Gender = oSM.Gender;
                oSale.Photo = oSM.Photo;
                oSale.CustomerAddress = oSM.CustomerAddress;

                var listSaleDetail = new List<VmSales.VmSaleDetails>();
                var listSD = db.SalesDetail.Where(x => x.SaleId == id).ToList();
                foreach(var oSD in listSD)
                {
                    var oSaleDetail = new VmSales.VmSaleDetails();
                    oSaleDetail.SaleId = oSD.SaleId;
                    oSaleDetail.ProductName = oSD.ProductName;
                    oSaleDetail.ProductType = oSD.ProductType;
                    oSaleDetail.Quentity = oSD.Quentity;
                    oSaleDetail.Price = oSD.Price;

                    listSaleDetail.Add(oSaleDetail);
                }
                oSale.SaleDetails = listSaleDetail;
            }
            oSale = oSale == null ? new VmSales() : oSale;
            ViewData["list"] = db.SalesMaster.ToList();
            return View(oSale);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Single(VmSales model)
        {          
            var oSaleMaster = db.SalesMaster.Find(model.SaleId);
            if(oSaleMaster == null)
            {
                oSaleMaster = new SaleMasters();
                oSaleMaster.SaleId = model.SaleId;
                oSaleMaster.CreateDate = model.CreateDate;
                oSaleMaster.CustomerName = model.CustomerName;
                oSaleMaster.Gender = model.Gender;
                oSaleMaster.Photo = model.Photo;
                oSaleMaster.CustomerAddress = model.CustomerAddress;
                

                db.SalesMaster.Add(oSaleMaster);
            }
            else
            {
                oSaleMaster.SaleId = model.SaleId;
                oSaleMaster.CreateDate = model.CreateDate;
                oSaleMaster.CustomerName = model.CustomerName;
                oSaleMaster.Gender = model.Gender;
                oSaleMaster.Photo = model.Photo;
                oSaleMaster.CustomerAddress = model.CustomerAddress;

                var listSdRem = db.SalesDetail.Where(x => x.SaleId == oSaleMaster.SaleId).ToList();
                db.SalesDetail.RemoveRange(listSdRem);
            }
            db.SaveChanges();
            var lSD = new List<SaleDetails>();
            for(var i=0; i<model.ProductName.Length; i++)
            {
                if (!string.IsNullOrEmpty(model.ProductName[i]))
                {
                    var oSaleDetail = new SaleDetails();
                    oSaleDetail.SaleId = oSaleMaster.SaleId;
                    oSaleDetail.ProductName = model.ProductName[i];
                    oSaleDetail.ProductType = model.ProductType[i];
                    oSaleDetail.Quentity = model.Quentity[i];
                    oSaleDetail.Price = model.Price[i];

                    lSD.Add(oSaleDetail);
                }
            }
            db.SalesDetail.AddRange(lSD);
            db.SaveChanges();
            return RedirectToAction("Single");
        }


        [HttpGet]
        public IActionResult SingleDelete(int id)
        {
            var oSm = (from o in db.SalesMaster where o.SaleId == id select o).FirstOrDefault();
            var oSd = (from o in db.SalesDetail where o.SaleId == id select o).ToList();
            if (oSm != null)
            {
                db.SalesMaster.Remove(oSm);
                db.SalesDetail.RemoveRange(oSd);
                db.SaveChanges();
            }
            return RedirectToAction("Single");
        }

    }
}
