using Repository;
using SchoolApp.Models;
using SchoolApp.Repository;


namespace SchoolApp.UnitOfWork
{
    public class UnitOfWorkSchool : IUnitOfWorkSchool
    {
        private readonly SchoolContext _context;
        private BaseRepositorySQL<Section> _sectionRepository;
        private BaseStudentRepositorySQL _studentRepository;

        public UnitOfWorkSchool(SchoolContext context)
        {
            this._context = context;
            _sectionRepository = new BaseRepositorySQL<Section>(context);
            _studentRepository = new BaseStudentRepositorySQL(context);
        }

        public IRepository<Section> SectionRepository
        {
            get => this._sectionRepository;
        }

        public IRepositoryStudent StudentRepository
        {
            get => this._studentRepository;
        }
    }
}
