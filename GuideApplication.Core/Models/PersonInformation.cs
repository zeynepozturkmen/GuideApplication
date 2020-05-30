using System;
using System.Collections.Generic;
using System.Text;

namespace GuideApplication.Core.Models
{
    public class PersonInformation : BaseEntity
    {
        //Kisi bilgileri tablosu
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
