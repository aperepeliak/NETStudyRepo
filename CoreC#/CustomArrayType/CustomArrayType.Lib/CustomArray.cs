using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomArrayType.Lib
{
    public class CustomArray<T> : IEnumerable<T>
    {
        Array _arr;
        public int Length => _arr.Length;
        public int LowerBound => _arr.GetLowerBound(0);

        public CustomArray(int length, int lowerBound)
        {
            _arr = Array
                .CreateInstance(typeof(T), new int[] { length }, new int[] { lowerBound });
        }

        public T this[int index]
        {
            get
            {
                if (index < LowerBound || index >= (LowerBound + Length))
                {
                    throw new IndexOutOfRangeException
                        ($"\nInvalid index.\nThe array is of length {Length} and lowerBound[{LowerBound}]");
                }
                return (T)_arr.GetValue(index);
            }
            set
            {
                if (index < LowerBound || index >= (LowerBound + Length))
                {
                    throw new IndexOutOfRangeException
                        ($"\nInvalid index.\nThe array is of length {Length} and lowerBound[{LowerBound}]");
                }
                _arr.SetValue(value, index);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _arr)
                yield return (T)item;
        }
        IEnumerator IEnumerable.GetEnumerator() => _arr.GetEnumerator();
    }
}
