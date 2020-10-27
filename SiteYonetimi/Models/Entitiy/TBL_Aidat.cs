//------------------------------------------------------------------------------
// <auto-generated>
//    Bu kod bir şablondan oluşturuldu.
//
//    Bu dosyada el ile yapılan değişiklikler uygulamanızda beklenmedik davranışa neden olabilir.
//    Kod yeniden oluşturulursa, bu dosyada el ile yapılan değişikliklerin üzerine yazılacak.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SiteYonetimi.Models.Entitiy
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_Aidat
    {
        public TBL_Aidat()
        {
            this.TBL_Borc = new HashSet<TBL_Borc>();
            this.TBL_HAREKET = new HashSet<TBL_HAREKET>();
        }
    
        public int İD { get; set; }
        public Nullable<int> DaireİD { get; set; }
        public Nullable<System.DateTime> KesimTarih { get; set; }
        public Nullable<System.DateTime> SonÖdeme { get; set; }
        public Nullable<int> ToplamGider { get; set; }
        public Nullable<int> Ödenecek { get; set; }
        public Nullable<bool> Alındı { get; set; }
        public string AidatAd { get; set; }
        public Nullable<byte> Kategori { get; set; }
        public Nullable<System.DateTime> OdenenTarih { get; set; }
    
        public virtual TBL_Daireler TBL_Daireler { get; set; }
        public virtual TBL_Gider TBL_Gider { get; set; }
        public virtual TBL_KATEGORI TBL_KATEGORI { get; set; }
        public virtual TBL_UYELER TBL_UYELER { get; set; }
        public virtual ICollection<TBL_Borc> TBL_Borc { get; set; }
        public virtual ICollection<TBL_HAREKET> TBL_HAREKET { get; set; }
    }
}
