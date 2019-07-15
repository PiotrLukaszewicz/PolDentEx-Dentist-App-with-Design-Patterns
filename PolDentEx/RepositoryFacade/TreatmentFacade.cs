using PolDentEx.DAL;
using System.Collections;
using System.Linq;

namespace PolDentEx.RepositoryFacade
{
    public class TreatmentFacade
    {
        private readonly ITreatmentRepository _repository;

        public TreatmentFacade(ITreatmentRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable GetTreatments()
        {
            return _repository.GetAll().ToList();
        }
    }
}