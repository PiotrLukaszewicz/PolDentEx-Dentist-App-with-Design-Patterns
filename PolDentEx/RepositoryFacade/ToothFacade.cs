using PolDentEx.DAL;
using PolDentEx.Models;
using System.Collections.Generic;
using System.Linq;

namespace PolDentEx.RepositoryFacade
{
    public class ToothFacade
    {
        private readonly IToothRepository _repository;

        public ToothFacade(IToothRepository repository)
        {
            _repository = repository;
        }
    }
}