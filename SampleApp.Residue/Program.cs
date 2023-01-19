using Discrete.NET.Residue;

var a = GetStringFromStdin("First number: ");
var b = GetStringFromStdin("Second number: ");

var n = GetStringFromStdin("Precision: ");

// Create the residue number world
var world = new ResidueNumberSystemWorld(int.Parse(n));

// Create both integers.
var i1 = world.CreateInt(a);
var i2 = world.CreateInt(b);
var i3 = i1 + i2;
var i4 = i1 - i2;

Console.WriteLine($"The result of a+b is: {i3.ToBigInteger()}");
Console.WriteLine($"The result of a-b is {i4.ToBigInteger()}");

static string GetStringFromStdin(string prompt)
{
    Console.Write(prompt);

    return Console.ReadLine()!;
}