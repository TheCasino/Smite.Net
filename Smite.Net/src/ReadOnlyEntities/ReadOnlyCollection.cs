using System;
using System.Collections;
using System.Collections.Generic;

namespace Smite.Net.ReadOnlyEntities
{
    public sealed class ReadOnlyCollection<T> : IReadOnlyCollection<T>
    {
        private readonly Func<int> _countFunc;
        private readonly IEnumerable<T> _enum;

        internal ReadOnlyCollection(IEnumerable<T> @enum, Func<int> countFunc)
        {
            _countFunc = countFunc;
            _enum = @enum;
        }

        public int Count => _countFunc.Invoke();

        public IEnumerator<T> GetEnumerator()
        {
            return _enum.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _enum.GetEnumerator();
        }
    }
}
