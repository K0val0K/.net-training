using System;

namespace Task1
{
    public class MatrixChangedEventArgs<T> : EventArgs
    {
        public T Old { get; }
        public T New { get; }
        public int Index { get; }
        public MatrixChangedEventArgs(T old, T @new, int index) => (Old, New, Index) = (old, @new, index);
    }
}
