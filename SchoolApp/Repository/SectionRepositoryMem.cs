using Repository;
using SchoolApp.Models;
using System.Linq.Expressions;


namespace SchoolApp.Repository
{
    public class SectionRepositoryMem : IRepository<Section>
    {
        private List<Section> _sections;

        public SectionRepositoryMem()
        {
            this._sections = new List<Section>();
        }

        public void Delete(Section entity)
        {
            this._sections.Remove(entity);
        }

        public IList<Section> GetAll()
        {
            return this._sections;
        }

        public Section GetById(int id)
        {
            return _sections.SingleOrDefault(s => s.SectionId == id);
        }

        public void Insert(Section entity)
        {
            this._sections.Add(entity);
        }

        public bool Save(Section entity, Expression<Func<Section, bool>> predicate)
        {
            Section s = SearchFor(predicate).SingleOrDefault();

            if (s == null)
            {
                Insert(entity);
            }
            return true;
        }

        public IList<Section> SearchFor(Expression<Func<Section, bool>> predicate)
        {
            return this._sections.AsQueryable().Where(predicate).ToList();
        }
    }
}
