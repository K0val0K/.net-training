using System;
using System.Text;

namespace Task1
{
    public class DiagonalMatrix<T>
    {
        private readonly T[] _data; //1 

        public int Size => _data.Length; //3

        public DiagonalMatrix() : this(0) { }

        public DiagonalMatrix(int length) // 2
        {
            if (length < 0)
            {
                throw new ArgumentException("Index must be positive");
            }
            _data = new T[length];
        }

        public T this[int i, int j] //4,5,6
        {
            get {
                if(!IsCorrect(i) || !IsCorrect(j)) 
                {
                    throw new IndexOutOfRangeException("out of range");
                }
                return (i == j) ? _data[i] : default(T);
            } 
            set
            {
                if (!IsCorrect(i) || !IsCorrect(j))
                {
                    throw new IndexOutOfRangeException("out of range");
                }
                if (i == j)
                {
                    var oldValue = _data[i];
                    _data[i] = value;
                    if(!value.Equals(oldValue))
                    {
                        OnElementChanged(new MatrixChangedEventArgs<T>(oldValue, value, i));
                    }
                }
            }
        }

        public void BackToState(MatrixChangedEventArgs<T> state)
        {
            _data[state.Index] = state.Old;
        }

        private bool IsCorrect(int i) => i >= 0 && i < Size;

        public event EventHandler<MatrixChangedEventArgs<T>> ElementChanged;
        
        protected virtual void OnElementChanged(MatrixChangedEventArgs<T> e)
        {
            ElementChanged?.Invoke(this, e);
        }

    }
}
