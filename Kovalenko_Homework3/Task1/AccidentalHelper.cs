public static class AccidentalHelper
{
    public static string GetDescription(this Accidental accidental) =>
        accidental switch
        {
            Accidental.Flat => "b",
            Accidental.Sharp => "#",
            _ => string.Empty
        };
}
