﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YemekDunyası.Properties
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EntitiesUrun : DbContext
    {
        public EntitiesUrun()
            : base("name=EntitiesUrun")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL_ADMİN> TBL_ADMİN { get; set; }
        public virtual DbSet<TBL_KATEGORI> TBL_KATEGORI { get; set; }
        public virtual DbSet<TBL_MUSTERI> TBL_MUSTERI { get; set; }
        public virtual DbSet<TBL_RESTORAN> TBL_RESTORAN { get; set; }
        public virtual DbSet<TBL_SEPET> TBL_SEPET { get; set; }
        public virtual DbSet<TBL_SIPARIS> TBL_SIPARIS { get; set; }
        public virtual DbSet<TBL_URUN> TBL_URUN { get; set; }
    }
}
