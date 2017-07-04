using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetWeb.BL;
using ProjetWeb.MODEL;
namespace ProjetWeb.WEB.Controllers
{
    public class ReservationLecteursController : Controller
    {
        private ReservationBL BLresa = new ReservationBL();

        // GET: Reservation
        public ActionResult Index()
        {
            List<ReservationModel> reservation = new List<ReservationModel>();
            reservation = BLresa.getResaNoPurge();
            return View(reservation);

        }
        // GET: Reservation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationModel reservation = new ReservationModel();
            reservation = BLresa.getResaById((int)id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }
    }
}
