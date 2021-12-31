using System;

// We don’t provide test cases in this language yet, but have outlined the signature for you. Please write your code below, and don’t forget to test edge cases!
public class RotationalCipher
{
    static void Main(String[] args)
    {
        // Call rotationalCipher with test cases here
        String input = "Zebra-493?";
        int retationFactor = 3;
        String output = rotationalCipher(input, retationFactor);
        Console.WriteLine(output);
    }

    private static string rotationalCipher(String input, int rotationFactor)
    {
        // Write your code here
        int roNum = rotationFactor % 10;
        int roChr = rotationFactor % 26;

        string result = string.Empty;
        foreach (char c in input)
        {
            if (c >= 'A' && c <= 'Z')
            {
                if (c + roChr > 'Z') result += ((char)(c - 26 + roChr));
                else result += ((char)(c + roChr));
            }
            else if (c >= 'a' && c <= 'z')
            {
                if (c + roChr > 'z') result += ((char)(c - 26 + roChr));
                else result += ((char)(c + roChr));
            }
            else if (c >= '0' && c <= '9')
            {
                if (c + roNum > '9') result += ((char)(c - 10 + roNum));
                else result += ((char)(c + roNum));
            }
            else
            {
                result += c;
            }
        }
        return result;
    }
}