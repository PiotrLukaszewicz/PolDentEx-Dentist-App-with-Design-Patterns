using PolDentEx.Models;
using System.Collections.Generic;

namespace PolDentEx.Builder
{
    public abstract class JawBuilder
    {
        protected readonly List<Tooth> Product = new List<Tooth>();
        public abstract void BuildJaw(int patientId);

        public List<Tooth> GetResult()
        {
            return Product;
        }
    }
}