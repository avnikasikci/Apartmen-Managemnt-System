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
    
    public partial class TBL_CEZALAR
    {
        public int ID { get; set; }
        public Nullable<int> UYE { get; set; }
        public Nullable<System.DateTime> BASLANGIC { get; set; }
        public Nullable<System.DateTime> BITIS { get; set; }
        public Nullable<decimal> PARA { get; set; }
        public Nullable<byte> HAREKET { get; set; }
    
        public virtual TBL_HAREKET TBL_HAREKET { get; set; }
    }
}
