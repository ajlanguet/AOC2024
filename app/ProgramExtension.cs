
public static class ProgramExtension
{
   public static string RemoveWhiteSpace(this string input)
    {
        return new string(input.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
    }

    public static int[] GivesIntegers(this string input)
    {
        string[] vals = input.Split("   ");

        int[] intvals = Array.ConvertAll(vals, int.Parse);

        return intvals;
    }
}