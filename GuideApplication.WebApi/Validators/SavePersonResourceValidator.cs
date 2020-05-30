using FluentValidation;
using GuideApplication.WebApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideApplication.WebApi.Validators
{
    public class SavePersonResourceValidator : AbstractValidator<SavePersonResource>
    {
        //Tablomuzdaki kolonların boş geçilemez oldugunu ya da kac karakter sınırında oldugunu belirtmek için kullanıyoruz. FrontEnd tarafında javascript ile de kolonun boş geçilmeyecegi belirtilebilir ancak javascript kapatılıp,kötü niyette kullanılabilir. Bunun için backendde de bu kontrolleri yapmalıyız.
        public SavePersonResourceValidator()
        {
            RuleFor(a => a.FullName)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
