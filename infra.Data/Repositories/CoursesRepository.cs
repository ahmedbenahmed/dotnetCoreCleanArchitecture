using cleanAch.Domain;
using cleanArch.Application.Interfaces;
using infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infra.Data.Repositories
{
    public class CoursesRepository : ICourseRepository
    {
        private readonly UniversityDbContext _context;

        public CoursesRepository(UniversityDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }
    }
}
