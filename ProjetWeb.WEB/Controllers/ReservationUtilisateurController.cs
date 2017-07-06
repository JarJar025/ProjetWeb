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
    public class ReservationUtilisateurController : Controller
    {
        private ReservationBL BLresa = new ReservationBL();
        private UtilisateurBL BLuser = new UtilisateurBL();
        private ProfilBL Blprofil = new ProfilBL();
        // GET: Reservation
        public ActionResult Index()
        {
            int ID_User = int.Parse(Session["IDUser"].ToString());
            List<ReservationModel> reservation = new List<ReservationModel>();
            reservation = BLresa.getResaNoPurgeUtilisateur(ID_User);
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
        // GET: Reservation/Edit/5
        public ActionResult Edit(int? id)
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
        // POST: Reservation/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Reservation,Date_Debut_Resa,Date_Fin_Resa,Date_Resa,Nom_User,Purge")] ReservationModel reservation)
        {
            if (ModelState.IsValid)
            {
                //la date est forme US voire plus tard pour la mettre en FR
                BLresa.setEditResa(reservation.id_Reservation, reservation.Date_Debut_Resa, reservation.Date_Fin_Resa, reservation.Date_Resa, reservation.Nom_User, reservation.Purge);
            }
            return RedirectToAction("Index");
        }
        // GET: Utilisateurs/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Reservation/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateConfirmed([Bind(Include = "Date_Debut_Resa,Date_Fin_Resa,Date_Resa,Nom_User,Purge")] ReservationModel reservation)
        {
            int ID_User = int.Parse(Session["IDUser"].ToString());
            UtilisateurModel utilisateur = new UtilisateurModel();
            utilisateur = BLuser.getUtilisateurbyId((int)ID_User);
            List<string> profilNom = new List<string>();
            List<UtilisateurModel> user = new List<UtilisateurModel>();
            user = BLuser.getUtilisateurAll();
            List<string> nomuser = new List<string>();
            foreach ( UtilisateurModel um in user)
            {
                nomuser.Add(um.Nom_User);
            }

            if(nomuser.Contains(reservation.Nom_User))
            {
                if (utilisateur.Nom_User == reservation.Nom_User)
                {

                    if (ModelState.IsValid)
                    {

                        BLresa.setCreateResa(reservation.Date_Debut_Resa, reservation.Date_Fin_Resa, reservation.Date_Resa, reservation.Nom_User, reservation.Purge);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.NomUser = false;
                    ViewBag.Message = "Ceci n'est pas votre Nom d'utilisateur. Veuillez saisir votre Nom";
                    return View();
                }
            }
            else
            {
                ViewBag.NomUser = false;
                ViewBag.Message = "L'utilisateur saisie n'existe pas. Veuillez recommencez";
                return View();
            }

        }
    }
}
