using System;

public struct Key : IComparable<Key>
{
    public Note Note { get; }
    public Accidental Accidental { get; } 
    public Octave Octave { get; }

    public Key(Note note, Accidental accidental = Accidental.Empty, Octave octave = Octave.Small)
    {
        Note = note;
        Accidental = accidental;
        Octave = octave;
    }

    public int CompareTo(Key other)
    {
        return GetPositionOnPiano() - other.GetPositionOnPiano(); // the farther to the left, the less is value
    }

    public override string ToString()
    {
        return Enum.GetName(Note) + Accidental.GetDescription() + " (" + Octave.GetDescription() + ")";
    }

    public override bool Equals(object obj)
    {
        return obj is Key a &&
            GetPositionOnPiano() == a.GetPositionOnPiano();
    }

    public override int GetHashCode()
    {
        return GetPositionOnPiano().GetHashCode();
    }

    private int GetPositionOnPiano() 
    {
        var position = 3 + 12 * (int)Octave + (int)Note + (int)Accidental; ;

        if(Octave == Octave.Fifth && Note == Note.C && Accidental != Accidental.Sharp)
        {
            position =  88 + (int)Accidental; //last piano key
        }
        if(Octave == Octave.SubContra)
        {
            position = -10 + (int)Note + (int)Accidental; // -10 because octave is not full
        }

        return position > 0 ? position : -1;
        
    }
}

public enum Fucnf : sbyte
{
    Enud, 
    F, 
    g
}

