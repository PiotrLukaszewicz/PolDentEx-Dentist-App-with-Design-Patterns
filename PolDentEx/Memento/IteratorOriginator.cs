using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolDentEx.Memento
{
    public class IteratorOriginator
    {
        private TeethIterator _state;

        public void SetState(TeethIterator state)
        {
            _state = state;
        }

        public IteratorMemento Save()
        {
            return new IteratorMemento(_state);
        }

        public void Restore(IteratorMemento m)
        {
            _state = m.Getstate();
        }
    }
}