﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetWeb.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BDD_GRP2Entities : DbContext
    {
        public BDD_GRP2Entities()
            : base("name=BDD_GRP2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Fonctionnalite> Fonctionnalite { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Ligne_Reservation> Ligne_Reservation { get; set; }
        public virtual DbSet<Profil> Profil { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Ressource> Ressource { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Utilisateur> Utilisateur { get; set; }
    }
}