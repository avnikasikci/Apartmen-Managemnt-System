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
    
    public partial class TBL_KATEGORI
    {
        public TBL_KATEGORI()
        {
            this.TBL_Aidat = new HashSet<TBL_Aidat>();
            this.TBL_Gelir = new HashSet<TBL_Gelir>();
            this.TBL_Gider = new HashSet<TBL_Gider>();
            this.TBL_KITAP = new HashSet<TBL_KITAP>();
        }
    
        public byte ID { get; set; }
        public string AD { get; set; }
        public Nullable<bool> DURUM { get; set; }
    
        public virtual ICollection<TBL_Aidat> TBL_Aidat { get; set; }
        public virtual ICollection<TBL_Gelir> TBL_Gelir { get; set; }
        public virtual ICollection<TBL_Gider> TBL_Gider { get; set; }
        public virtual ICollection<TBL_KITAP> TBL_KITAP { get; set; }
    }
}
