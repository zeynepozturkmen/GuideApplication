using System;

namespace GuideApplication.Core.Models
{
    public class BaseEntity
    {
        //Tüm tablolarda kolonların tekrar edilmemesi için base bir tablo olusturuldu
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
