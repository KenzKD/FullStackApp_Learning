using AutoMapper;
using SmartCertify.Application.DTOs;
using SmartCertify.Domain.Entities;

namespace SmartCertify.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<CreateCourseDTO, Course>();
            CreateMap<UpdateCourseDTO, Course>().ForAllMembers
                (opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }

        public static CourseDTO MapToCourseDTO(Course course) => new()
        {
            Title = course.Title,
            Description = course.Description,
        };

        public static IEnumerable<CourseDTO> MapToCourseDTO_IEnumerable(IEnumerable<Course> courses)
        {
            return courses.Select(MapToCourseDTO).ToList();
        }

        public static Course MapToCourse(CreateCourseDTO createCourseDTO) => new()
        {
            Title = createCourseDTO.Title,
            Description = createCourseDTO.Description,
        };

        public static Course MapToCourse(UpdateCourseDTO updateCourseDTO) => new()
        {
            Title = updateCourseDTO.Title,
            Description = updateCourseDTO.Description,
        };
    }
}
