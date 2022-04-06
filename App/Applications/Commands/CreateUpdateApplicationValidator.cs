using App.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace App.Applications.Commands
{
    public class CreateUpdateApplicationValidator : AbstractValidator<CreateApplicationCommand>
    {
        private readonly IApplicationContext _applicationContext;

        public CreateUpdateApplicationValidator(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(150).WithMessage("{PropertyName} must not exceed 150 characters.")
                .MustAsync(IsUniqueApplication).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.Groups)
                .NotNull().WithMessage("{PropertyName} must have at least 1 element");                    
        }

        private async Task<bool> IsUniqueApplication(string applicationName, CancellationToken cancellationToken)
        {
            return await _applicationContext.Applications.Where(it => it.Name.Contains(applicationName)).FirstOrDefaultAsync() == null;
        }
    }
}
