using System;

public class Class1
{
    static void Main(string[] args)
    {
        string s = "abcdef";
        System.IO.File.WriteAllText("d:1.txt", s, Encoding.Default);
    }
}
