using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolDentEx.Memento
{
    public class IteratorCaretaker
    {
        private List<IteratorMemento> _mementos;

        public IteratorCaretaker()
        {
            _mementos = new List<IteratorMemento>();
        }

        public void AddMemento(IteratorMemento m)
        {
            _mementos.Add(m);
        }

        public IteratorMemento GetMemento(int index)
        {
            return _mementos[index];
        }
    }
}