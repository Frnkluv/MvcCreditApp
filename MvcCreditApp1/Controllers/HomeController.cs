using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCreditApp1.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace MvcCreditApp1.Controllers
{
    public class HomeController : Controller
    {
        private CreditContext db = new CreditContext();
        
        private void GiveCredits()
        {
            var allCredits = db.Credits.ToList<Credit>();
            ViewBag.Credits = allCredits;
        }

        public ActionResult BidSearch (string name)
        {
            var allBids = db.Bids.Where(b => b.CreditHead.Contains(name)).ToList();

            if (allBids.Count == 0)
            {
                //return HttpNotFound();
                return Content($"Указанный кредит {name} не найден.");
            }

            return PartialView(allBids);
        }

        public ActionResult Index()
        {
            // Получение всех записей о кредитах
            GiveCredits();

            return View();
        }

        /* возвращает соответствующее представление c получением всех записей о 
         * кредитах и заявках */
        [HttpGet]
        public ActionResult CreateBid()
        {
            GiveCredits();
            var allBids = db.Bids.ToList<Bid>();
            ViewBag.Bids = allBids;

            return View();
        }

        /* Второй метод принимает переданную ему в запросе POST модель newBid и 
         * добавляет ее в базу данных. В конце возвращается строка уведомительного 
         * сообщения */
        [HttpPost]
        public string CreateBid(Bid newBid)
        {
            newBid.BidDate = DateTime.Now;
            // добавляю новую заявку в бд
            db.Bids.Add(newBid);
            // сохраняю
            //db.SaveChanges();

            // ловлю ошибку когда регаю пустое имя на стр. с выпадающим списком
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Response.Write("Error: " + validationError.ErrorMessage);
                    }
                }
            }

            // эта срань тоже выходит при ошибке
            return "Спасибо, <b>" + newBid.Name + "</b>, за выбор нашего банка. " +
                "Ваша заявка будет рассмотрена в течении 10 дней.";
        }
    }
}