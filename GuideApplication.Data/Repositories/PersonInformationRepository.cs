using GuideApplication.Core.Models;
using GuideApplication.Core.Repositories;

namespace GuideApplication.Data.Repositories
{
    //PersonInformation tablosuna özel metodlar buraya yazılabilir
    public class PersonInformationRepository : Repository<PersonInformation>, IPersonInformationRepository
    {
        public PersonInformationRepository(GuideApplicationDbContext context)
            : base(context)
        { }
    }
}
