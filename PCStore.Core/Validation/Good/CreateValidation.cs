using FluentValidation;
using PCStore.Core.DTO_s.Good;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Core.Validation.Good
{
    public class CreateValidation : AbstractValidator<GoodDto>
    {
        public CreateValidation()
        {
            RuleFor(r => r.Title).NotEmpty();
            RuleFor(r => r.Description).NotEmpty();
            RuleFor(r => r.Price).NotEmpty();
            RuleFor(r => r.Producer).NotEmpty();
            RuleFor(r => r.Specs).NotEmpty();
            RuleFor(r => r.CategoryId).NotEmpty();
        }
    }
}
