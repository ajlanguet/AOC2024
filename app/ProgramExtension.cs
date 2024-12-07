
public static class ProgramExtension
{
    public static string RemoveWhiteSpace(this string input)
    {
        return new string(input.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
    }

    public static int[] GiveIntegers(this string input, string remove)
    {
        string[] vals = input.Split(remove);

        return Array.ConvertAll(vals, int.Parse);
    }
}