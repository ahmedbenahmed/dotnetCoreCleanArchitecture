

using cleanArch.Application.Interfaces;
using cleanArch.Application.ViewModels;

namespace cleanArch.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public CourseViewModel GetAllCourses()
        {
            return new CourseViewModel
            {
                Courses = _courseRepository.GetAllCourses()
            };
        }
    }
}
