using AutoMapper;
using GuideApplication.Core.Models;
using GuideApplication.WebApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideApplication.WebApi.Mapping
{
    public class MappingProfile : Profile
    {
        //RequestModel'den entity'e tek tek veri aktarıp, crud işlemi yapmak yerine; birebir aynı kolon isimleri ve aynı kolon sayısında oluşturdugumuz kaynak model(resourceModel) ile entity arasında otomatik eşleme yapılıyor.
        public MappingProfile()
        {
            // Alandan kaynaga
            //ekleme işmei için ;
            CreateMap<PersonInformation, PersonResource>();

            // kaynaktan alana
            CreateMap<PersonResource, PersonInformation>();
            //güncelleme işlemi için
            CreateMap<SavePersonResource, PersonInformation>();
        }
    }
}
