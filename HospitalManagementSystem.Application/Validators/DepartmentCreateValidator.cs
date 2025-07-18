using FluentValidation;
using HospitalManagementSystem.Application.DTOs;

namespace HospitalManagementSystem.Application.Validators
{
    public class DepartmentCreateValidator : AbstractValidator<DepartmentCreateDto>
    {
        public DepartmentCreateValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Departman ismi bos olamaz")
                .MaximumLength(50).WithMessage("Departman ismi en fazla 50 karakter olabilir");
        }
    }
}
