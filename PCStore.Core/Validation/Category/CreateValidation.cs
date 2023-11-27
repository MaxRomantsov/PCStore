using FluentValidation;
using PCStore.Core.DTO_s.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Core.Validation.Category
{
    public class CreateValidation : AbstractValidator<CategoryDto>
    {
        public CreateValidation()
        {
            RuleFor(r => r.Name).NotEmpty();
        }
    }
}
