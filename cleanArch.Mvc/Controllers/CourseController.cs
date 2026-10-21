using cleanArch.Application.Interfaces;
using cleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace cleanArch.Mvc.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            CourseViewModel courseViewModel = _courseService.GetAllCourses();
            return View(courseViewModel);
        }
    }
}
