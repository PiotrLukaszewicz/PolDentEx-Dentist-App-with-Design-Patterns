using PolDentEx.Memento;
using PolDentEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolDentEx.ViewModel
{
    public class FastViewModel
    {
        public IteratorCaretaker Caretraker { get; set; }
        public IteratorOriginator Originator { get; set; }
        public Tooth Tooth { get; set; }
        public TeethIterator Iterator { get; set; }
        public int Step { get; set; }
    }
}