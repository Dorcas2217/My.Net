using Repository;
using SchoolApp.Models;
using SchoolApp.Repository;

namespace SchoolApp.UnitOfWork
{
    public class UnitOfWorkSchoolMem : IUnitOfWorkSchool
    {
        private SectionRepositoryMem _sectionRepositoryMem;
        private StudentRepositoryMem _studentRepositoryMem;

        public UnitOfWorkSchoolMem()
        {
            this._sectionRepositoryMem = new SectionRepositoryMem();
            this._studentRepositoryMem = new StudentRepositoryMem();
        }

        public IRepository<Section> SectionRepository 
        {
            get { return this._sectionRepositoryMem; }
        }

        public IRepositoryStudent StudentRepository
        {
            get { return this._studentRepositoryMem; }
        }
    }
}
