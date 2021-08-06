using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class SparseMatrix : IEnumerable<int>
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Size { get; private set; }

        private int _version;
        private Dictionary<int, int> _matrix = new Dictionary<int, int>();

        public SparseMatrix(int m, int n)
        {
            if(!(m > 0 && n > 0))
            {
                throw new ArgumentException("Number of columns and rows must be greater then 0");
            }
            Height = m;
            Width = n;
            Size = m * n;
        }

        public int this[int row, int col]
        {
            get {
                CheckIndexes(row, col);
                var index = row * Width + col;
                _matrix.TryGetValue(index, out int result);
                 return result;
            }
            set {
                CheckIndexes(row, col);
                var index = row * Width + col;
                _matrix[index] = value;
                _version++;
            }

        }

        public IEnumerable<(int, int, int)> GetNonzeroElements()
        {
            var columnOrderedDict = new SortedDictionary<int, int>();
            foreach(var item in _matrix)
            {
                GetIndex(item.Key, out int row, out int col);
                var newKey = col * Height + row;
                columnOrderedDict[newKey] = item.Value;
            }
            foreach (var item in columnOrderedDict)
            {
                GetIndex(item.Key, out int row, out int col, true);
                yield return (row, col, item.Value);
            }
        }

        public int GetCount(int x)
        {
            if (x == 0) return Size - _matrix.Count;
            var count = 0;
            foreach(var item in this)
            {
                if (item == x) count++;
            }
            return count;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for(var i = 0; i < Height; i++)
            {
                result.Append("{ ");
                for(var j = 0; j < Width; j++)
                {
                    var index = i * Width + j;
                    _matrix.TryGetValue(index, out int number);
                    result.Append(number.ToString() + " ");
                }
                result.Append("}\n");
            }
            return result.ToString();
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new SparseMartixEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class SparseMartixEnumerator : IEnumerator<int>
        {
            private readonly SparseMatrix _sparseMatrix;
            private readonly int _capturedVersion;
            private int _position = -1;

            public SparseMartixEnumerator(SparseMatrix sparseMatrix)
            {
                _sparseMatrix = sparseMatrix;
                _capturedVersion = sparseMatrix._version;
            }

            public int Current
            {
                get {
                    _sparseMatrix._matrix.TryGetValue(_position, out int current);
                    return current;
                }
            }

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if(_capturedVersion != _sparseMatrix._version)
                {
                    throw new InvalidOperationException();
                }

                if (_position >= _sparseMatrix.Size - 1)
                {
                    return false;
                }
                _position++;
                return true;
            }

            public void Reset() => _position = -1;

            public void Dispose() 
            {}
        }

        private void GetIndex(int key, out int row, out int col, bool isColumnSotred = false)
        {
            if(!isColumnSotred)
            {
                row = key / Width;
                col = key % Width;
            }
            else
            {
                col = key / Height;
                row = key % Height;
            }
           
        }

        private void CheckIndexes(int i, int j)
        {
            if(j < 0 || j > Width - 1)
            {
                throw new IndexOutOfRangeException(nameof(i));
            }
            if(i < 0 || i > Height - 1)
            {
                throw new IndexOutOfRangeException(nameof(j));
            }
        }

    }
}
