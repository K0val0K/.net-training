public static class OctaveHelper
{
    public static string GetDescription(this Octave octave) =>
        octave switch
        {
            Octave.SubContra => "sub-contra",
            Octave.Contra => "contra",
            Octave.Great => "great",
            Octave.Small => "small",
            Octave.First => "1",
            Octave.Second => "2",
            Octave.Third => "3",
            Octave.Fourth => "4",
            Octave.Fifth => "5",
            _ => string.Empty
        };
}
