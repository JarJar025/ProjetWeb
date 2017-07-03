using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetWeb.DAL;
using ProjetWeb.MODEL;
using System.Data.Entity;

namespace ProjetWeb.BL
{
    public class ReservationBL
    {
        private BDD_GRP2Entities db = new BDD_GRP2Entities();
        public List<ReservationModel> getResaAll()
        {
            var lesReservations = db.Reservation.Select(r => new ReservationModel()
            {
                id_Reservation = r.ID_Reservation,
                Date_Debut_Resa = (DateTime)r.Date_Debut_Reservation,
                Date_Fin_Resa = (DateTime)r.Date_Fin_Reservation,
                Date_Resa = (DateTime)r.Date_Reservation,
                Nom_User = db.Utilisateur.Where(v => v.ID_User == r.ID_User).FirstOrDefault().Nom_Utilisateur
            });
            List<ReservationModel> resaAll = new List<ReservationModel>();
            resaAll = lesReservations.ToList();
            return resaAll;
        }
        public ReservationModel getResaById(int id_res)
        {
            var ResaById = db.Reservation.Where(r => r.ID_Reservation == id_res).Select(r => new ReservationModel()
            {
                id_Reservation = r.ID_Reservation,
                Date_Debut_Resa = (DateTime)r.Date_Debut_Reservation,
                Date_Fin_Resa = (DateTime)r.Date_Fin_Reservation,
                Date_Resa = (DateTime)r.Date_Reservation,
                Nom_User = db.Utilisateur.Where(v => v.ID_User == r.ID_User).FirstOrDefault().Nom_Utilisateur

            }).FirstOrDefault();
            return ResaById;
        }
        public List<ReservationModel> getResaNoPurge()
        {
            var ReservationNoPurge = db.Reservation.Where(p => p.Purge == false).Select(r => new ReservationModel()
            {
                id_Reservation = r.ID_Reservation,
                Date_Debut_Resa = (DateTime)r.Date_Debut_Reservation,
                Date_Fin_Resa = (DateTime)r.Date_Fin_Reservation,
                Date_Resa = (DateTime)r.Date_Reservation,
                Nom_User = db.Utilisateur.Where(v => v.ID_User == r.ID_User).FirstOrDefault().Nom_Utilisateur
            }).ToList();
            return ReservationNoPurge;
        }
        public ReservationModel setEditResa(int id_Reservation, DateTime Date_Debut_Resa, DateTime Date_Fin_Resa, DateTime Date_Resa, string Nom_User, Boolean purge)
        {
            Reservation reservation = new Reservation();
            reservation.ID_Reservation = id_Reservation;
            reservation.Date_Debut_Reservation = Date_Debut_Resa;
            reservation.Date_Fin_Reservation = Date_Fin_Resa;
            reservation.Date_Reservation = Date_Resa;
            reservation.ID_User = db.Utilisateur.Where(v => v.Nom_Utilisateur == Nom_User).FirstOrDefault().ID_Profil;
            reservation.Purge = purge;
            db.Entry(reservation).State = EntityState.Modified;
            db.SaveChanges();
            ReservationModel reservationm = new ReservationModel();
            reservationm.id_Reservation = reservation.ID_Reservation;
            reservationm.Date_Debut_Resa = (DateTime)reservation.Date_Debut_Reservation;
            reservationm.Date_Fin_Resa = (DateTime)reservation.Date_Fin_Reservation;
            reservationm.Date_Resa = (DateTime)reservation.Date_Reservation;
            reservationm.id_User = (int)reservation.ID_User;
            reservation.Purge = (Boolean)reservation.Purge;
            return reservationm;
        }
        public void setCreateResa(DateTime Date_Debut_Resa, DateTime Date_Fin_Resa, DateTime Date_Resa, string Nom_User, Boolean purge)
        {
            // On lie les réponses du formulaire d'ajout qui seront en paramètres à une reservation de la BDD
            Reservation reservation = new Reservation();
            reservation.Date_Debut_Reservation = Date_Debut_Resa;
            reservation.Date_Fin_Reservation = Date_Fin_Resa;
            reservation.Date_Reservation = Date_Resa;
            reservation.ID_User = db.Utilisateur.Where(v => v.Nom_Utilisateur == Nom_User).FirstOrDefault().ID_User;
            reservation.Purge = false;
            // On ajoute la reservation
            db.Reservation.Add(reservation);
            db.SaveChanges();
        }
        public void setRemoveResa(int id_Reservation)
        {
            // On récupère la reservation suivant son id
            Reservation reservation = db.Reservation.FirstOrDefault(r => r.ID_Reservation == id_Reservation);
            // On passe l'élément "purge" à true
            reservation.Purge = true;
            // On applique ces changements
            db.Entry(reservation).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
