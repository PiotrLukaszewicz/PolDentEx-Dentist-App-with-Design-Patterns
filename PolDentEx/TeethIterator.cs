using PolDentEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolDentEx
{
    public interface ITeethIterator<T>
    {
        bool HasNext();
        T NextTooth();
        bool HasNextQuarter();
        T NextQuarterTooth();
    }

    public class TeethIterator : ITeethIterator<Tooth>, ICloneable
    {
        private List<Tooth> _teeth;
        private int _currentIndex;
        private int _quarter;

        public TeethIterator(List<Tooth> teeth)
        {
            _teeth = teeth;
            _currentIndex = 0;
            _quarter = _teeth.Count / 4;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public bool HasNext()
        {
            return _currentIndex < _teeth.Count;
        }

        public bool HasNextQuarter()
        {
            return _currentIndex < _teeth.Count - _quarter;
        }

        public Tooth NextQuarterTooth()
        {
            if (HasNextQuarter())
            {
                if (_currentIndex < _quarter)
                    _currentIndex = _quarter;
                if (_currentIndex < 2 * _quarter)
                    _currentIndex = 2 * _quarter;
                else
                    _currentIndex = 3 * _quarter;
            }
            return null;
        }

        public Tooth NextTooth()
        {
            if (!HasNext()) _currentIndex = 0 ;
            return _teeth[_currentIndex++];

        }

        public Tooth CurrentTooth()
        {
            return _teeth[_currentIndex];
        }
    }
}