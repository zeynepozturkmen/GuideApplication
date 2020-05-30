using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideApplication.WebApi.Resources
{
    public class SavePersonResource
    {
        //Kişi bilgilerini eklemek için kaynak model (RequestModel)
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
