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
    
    public partial class TBL_Gider
    {
        public TBL_Gider()
        {
            this.TBL_Aidat = new HashSet<TBL_Aidat>();
        }
    
        public int İD { get; set; }
        public Nullable<byte> GiderKategori { get; set; }
        public string GiderAd { get; set; }
        public Nullable<int> GiderTl { get; set; }
        public string GiderBilgi { get; set; }
    
        public virtual ICollection<TBL_Aidat> TBL_Aidat { get; set; }
        public virtual TBL_Gelir TBL_Gelir { get; set; }
        public virtual TBL_KATEGORI TBL_KATEGORI { get; set; }
    }
}