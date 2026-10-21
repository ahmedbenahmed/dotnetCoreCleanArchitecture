using cleanAch.Domain;
using cleanArch.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cleanArch.Application.Interfaces
{
    public interface ICourseRepository
    {
        public IEnumerable<Course> GetAllCourses();
    }
}
