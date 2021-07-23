using System;


namespace Task1
{
    static class DiagonalMatrixHelper
    {
        public static DiagonalMatrix<TOut> Add<T1, T2, TOut>(this DiagonalMatrix<T1> self, DiagonalMatrix<T2> other,
            Func<T1, T2, TOut> sum) 
        {
            int bigSize = 0;
            int smallSize = 0;
            if (self.Size != other.Size)
            {
                (bigSize, smallSize) = (self.Size > other.Size) ? (self.Size, other.Size) : (other.Size, self.Size);
            }
            else
            {
                bigSize = smallSize = self.Size;
            }

            var newMatrix = new DiagonalMatrix<TOut>(bigSize);
            for (int i = 0; i < bigSize; i++)
            {
                if (i < smallSize)
                {
                    newMatrix[i, i] = sum(self[i,i], other[i,i]);
                }
                else
                {
                    newMatrix[i, i] = self.Size > other.Size ? sum(self[i, i], default(T2)) : sum(default(T1), other[i,i]);
                    //newMatrix[i, i] = default(TOut); // альтернатива
                }
            }
            return newMatrix;
        }
    }
}
