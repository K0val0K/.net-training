using System;


class DiagonalMatrix
{
    private int[] _elements = null; // 1

    public int Size { get; init; } = 0; // 2

    public DiagonalMatrix(params int[] elements) //3
    {
        if (elements == null)
        {
            Size = 0;
            _elements = new int[Size];
        }
        else
        {
            Size = elements.Length;
            _elements = new int[Size];

            for (int i = 0; i < Size; i++)
            {
                _elements[i] = elements[i];
            }
        }
    }

    public int this[int i, int j] // 4
    {
        get
        {
            if (i == j && i < Size && i >= 0)
            {
                return _elements[i];
            }
            return 0;
        }
        set
        {
            if (i == j && i < Size && i >= 0)
            {
                _elements[i] = value;
            }
        }
    }

    public int Track() // 5
    {
        int sum = 0;
        for (int i = 0; i < Size; i++)
        {
            sum += _elements[i];
        }
        return sum;
    }

    public override bool Equals(object obj) // 6
    {
        if(obj is DiagonalMatrix)
        {
            DiagonalMatrix compared = (DiagonalMatrix)obj;
            if (Size == compared.Size)
            {
                for(int i = 0; i < Size; i++)
                {
                    if(_elements[i] != compared._elements[i])
                    {
                        return false;
                    }
                }
                return true;

            }
        }
        return false;
    }

    public override int GetHashCode() => ToString().GetHashCode();

    public override string ToString() // 6
    {
        if (Size == 0) return "";
        char[] diag = new char[(Size * 2) - 1];
        for(int i = 0, j = 0; i < diag.Length; i++)
        {
            if(i % 2 == 0)
            {
                diag[i] = Convert.ToChar(_elements[j] + '0');
                j++;
            }
            else
            {
                diag[i] = ',';
            }
        }
        string result = new String(diag);
        return $"D = diag{{{result}}}";
        
    }
}

static class DiagonalMatrixExtension
{
    public static DiagonalMatrix Sum(this DiagonalMatrix a, DiagonalMatrix b) // 7
    {
        int bigSize = 0;
        int smallSize = 0;
        if (a.Size != b.Size)
        {
            if(a.Size > b.Size)
            {
                bigSize = a.Size;
                smallSize = b.Size;
            }
            else
            {
                bigSize = b.Size;
                smallSize = a.Size;
            }
        }
        else
        {
            bigSize = smallSize = a.Size;
        }
    
        int[] newMatrixElements = new int[bigSize];
        for(int i = 0; i < bigSize; i++)
        {
            if(i < smallSize)
            {
                newMatrixElements[i] = a[i, i] + b[i, i];
                var elem = a[i, i] + b[i, i];
            }
            else
            {
                newMatrixElements[i] = 0;
            }
        }
        return new DiagonalMatrix(newMatrixElements);
    }
}

