using Discrete.NET.Congruences;
using Discrete.NET.Euclidean;

var a = GetIntFromStdin("Give the a parameter: ");
var b = GetIntFromStdin("Give the b parameter: ");
var n = GetIntFromStdin("Give the modulo: ");

if (a == null ||
    b == null ||
    n == null)
{
    Console.WriteLine("Invalid parameters.");
    Environment.Exit(1);
}

var cong = new Congruence(a.Value, b.Value, n.Value);
Console.WriteLine($"The congruence before attempting to reduce: {cong}");
cong.Simplify();
Console.WriteLine($"The congruence after attempting to reduce: {cong}");

static int? GetIntFromStdin(string prompt)
{
    Console.Write(prompt);
    if (int.TryParse(Console.ReadLine(), out int result))
        return result;

    return null;
}