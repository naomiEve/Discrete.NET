using System.Numerics;
using System.Text;
using Discrete.NET.Cryptography.RSA;

(var priv, var pub) = KeyPairGenerator.GenerateKeypair();

Console.WriteLine($"N: {pub.N}");
Console.Write("Write your message: ");
var s = Console.ReadLine()!;

var b = Encoding.ASCII.GetBytes(s);
var m = new BigInteger(b);

Console.WriteLine($"Unencrypted message number: {m}");

var m_prime = pub.Encrypt(m);
Console.WriteLine($"m^({pub.E}) mod {pub.N}: {m_prime}");

var m_dec = priv.Decrypt(m_prime, pub);
Console.WriteLine($"enc^({priv.D}) mod {pub.N}: {m_dec}");

var bytes = m_dec.ToByteArray();
var s1 = Encoding.ASCII.GetString(bytes);
Console.WriteLine($"Decrypted message: {s1}");