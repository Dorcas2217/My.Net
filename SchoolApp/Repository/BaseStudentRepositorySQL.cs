using Repository;
using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Repository
{
    public class BaseStudentRepositorySQL : BaseRepositorySQL<Student>, IRepositoryStudent
    {
        public BaseStudentRepositorySQL(SchoolContext dbContext) : base(dbContext)
        {
        }

        public IList<Student> GetStudentsBySectionOrderByYearResultsDesc()
        {
            IList<Student> students =  (from Student student in _dbContext.Students
                                       orderby student.Section , student.YearResult descending
                                       select student).ToList();
            return students;
        }
    }
}
