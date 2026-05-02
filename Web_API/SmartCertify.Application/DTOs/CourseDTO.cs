using System.ComponentModel.DataAnnotations;

namespace SmartCertify.Application.DTOs
{
    public class CourseDTO
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
    }

    public class CreateCourseDTO
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
    }

    public class UpdateCourseDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
    }

    public class CourseUpdateDescriptionDTO
    {
        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
    }
}