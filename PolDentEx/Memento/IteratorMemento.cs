using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolDentEx.Memento
{
    public class IteratorMemento
    {
        private readonly TeethIterator _state;

        public IteratorMemento(TeethIterator state)
        {
            _state = state;
        }

        public TeethIterator Getstate()
        {
            return _state;
        }
    }
}