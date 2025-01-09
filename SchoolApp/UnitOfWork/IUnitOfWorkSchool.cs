using Repository;
using SchoolApp.Models;
using SchoolApp.Repository;


namespace SchoolApp.UnitOfWork
{
    public interface IUnitOfWorkSchool
    {
        IRepository<Section> SectionRepository { get; }
        IRepositoryStudent StudentRepository { get;  }
    }
}
