using AutoMapper;
using SmartCertify.Application.DTOs;
using SmartCertify.Application.Interfaces.Courses;
using SmartCertify.Domain.Entities;

namespace SmartCertify.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        //private readonly MappingProfile _mappingProfile;

        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            this._courseRepository = courseRepository;
            this._mapper = mapper;
        }

        public async Task AddCourseAsync(CreateCourseDTO createCourseDTO)
        {
            var course = _mapper.Map<Course>(createCourseDTO);
            //var course = MappingProfile.MapToCourse(createCourseDTO);
            course.CreatedBy = 10;
            course.CreatedOn = DateTime.UtcNow;

            await _courseRepository.AddCourseAsync(course);
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            var course = await _courseRepository.GetCourseByIdAsync(courseId);
            if (course == null) throw new KeyNotFoundException("Course with ID: {courseId} not found");

            await _courseRepository.DeleteCourseAsync(course);
        }

        public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync()
        {
            IEnumerable<Course> courses = await _courseRepository.GetAllCoursesAsync();
            //return MappingProfile.MapToCourseDTO_IEnumerable(courses);
            return _mapper.Map<IEnumerable<CourseDTO>>(courses);
        }

        public async Task<CourseDTO?> GetCourseByIdAsync(int courseId)
        {
            var course = await _courseRepository.GetCourseByIdAsync(courseId);
            return course == null ? null : _mapper.Map<CourseDTO?>(course);
            //return course == null ? null : MappingProfile.MapToCourseDTO(course);

        }

        public async Task<bool> IsTitleDublicateAsync(string title)
        {
            return await _courseRepository.IsTitleDuplicateAsync(title);
        }

        public async Task UpdateCourseAsync(int courseId, UpdateCourseDTO updateCourseDTO)
        {
            var course = await _courseRepository.GetCourseByIdAsync(courseId) ?? throw new KeyNotFoundException("Course not found");

            _mapper.Map(updateCourseDTO, course);
            //course = MappingProfile.MapToCourse(updateCourseDTO);
            await _courseRepository.UpdateCourseAsync(course);
        }

        public async Task UpdateDescriptionAsync(int courseId, string description)
        {
            await _courseRepository.UpdateDescriptionAsync(courseId, description);
        }
    }
}
