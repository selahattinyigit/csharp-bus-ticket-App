//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OtobusBiletAPP
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbBiletler
    {
        public int bilet_id { get; set; }
        public Nullable<int> sefer_id { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string tc { get; set; }
        public string telefon { get; set; }
        public Nullable<int> koltuk_no { get; set; }
        public Nullable<double> ucret { get; set; }
        public Nullable<bool> cinsiyet { get; set; }
        public string kullanici_adi { get; set; }
    
        public virtual tbKullanicilar tbKullanicilar { get; set; }
        public virtual tbSeferler tbSeferler { get; set; }
    }
}