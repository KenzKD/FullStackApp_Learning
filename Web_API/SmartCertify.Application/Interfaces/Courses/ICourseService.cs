using SmartCertify.Application.DTOs;
using SmartCertify.Domain.Entities;

namespace SmartCertify.Application.Interfaces.Courses
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDTO>> GetAllCoursesAsync();
        Task<CourseDTO?> GetCourseByIdAsync(int courseId);
        Task<bool> IsTitleDublicateAsync(string title);
        Task AddCourseAsync(CreateCourseDTO createCourseDTO);
        Task UpdateCourseAsync(int courseId, UpdateCourseDTO updateCourseDTO);
        Task DeleteCourseAsync(int courseId);
        Task UpdateDescriptionAsync(int courseId, string description);
    }
}
