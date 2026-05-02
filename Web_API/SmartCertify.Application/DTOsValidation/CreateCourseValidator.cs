using FluentValidation;
using SmartCertify.Application.DTOs;
using SmartCertify.Application.Interfaces.Courses;

namespace SmartCertify.Application.DTOsValidation
{
    public class CreateCourseValidator : AbstractValidator<CreateCourseDTO>
    {
        private readonly ICourseRepository courseRepository;

        public CreateCourseValidator(ICourseRepository courseRepository)
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().MaximumLength(50)
                .MustAsync(async (title, cancellation) => 
                    !await courseRepository.IsTitleDuplicateAsync(title))
                .WithMessage("Title must be unique.");
            RuleFor(x => x.Description).NotEmpty().NotNull().MaximumLength(500);
            this.courseRepository = courseRepository;
        }
    }
}
