using System;
using System.Collections.Generic;

namespace Task1
{
    class MatrixTracker<T>
    {
        private Stack<MatrixChangedEventArgs<T>> _changedList = new Stack<MatrixChangedEventArgs<T>>();
        private readonly DiagonalMatrix<T> _matrixLink;

        public MatrixTracker(DiagonalMatrix<T> matrix) 
        {
            _matrixLink = matrix;
            matrix.ElementChanged += (matrix, e) => _changedList.Push(e);
        }

        public void Undo()
        {
            if(_changedList.Count != 0)
            {
                _matrixLink.BackToState(_changedList.Pop());
            }
            // надо ли выбрасывать исключение когда стек изменений пуст?
        }
    }
}
