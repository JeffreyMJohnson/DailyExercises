using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Write a program that can translate Morse code in the format of ...­­­...

A space and a slash will be placed between words. ..­ / ­­.­

For bonus, add the capability of going from a string to Morse code.

Super­bonus if your program can flash or beep the Morse.

This is your Morse to translate:

.... . .-.. .-.. --- / -.. .- .. .-.. -.-- / .--. .-. --- --. .-. .- -- -- . .-. / --. --- --- -.. / .-.. ..- -.-. -.- / --- -. / - .... . / -.-. .... .- .-.. .-.. . -. --. . ... / - --- -.. .- -.--
*/

namespace _4_7_morse_code_parsing
{
    class Program
    {
        private static Dictionary<string, string> dic = new Dictionary<string,string>();
        private static string code = ".... . .-.. .-.. --- / -.. .- .. .-.. -.-- / .--. .-. --- --. .-. .- -- -- . .-. / --. --- --- -.. / .-.. ..- -.-. -.- / --- -. / - .... . / -.-. .... .- .-.. .-.. . -. --. . ... / - --- -.. .- -.--";
        private static string message = "";
        static void Main(string[] args)
        {
            LoadDictionary();
            ParseIt(code);

        }

        private static string ParseIt(string code)
        {
            string result = "";                                                      
            string[] letters = code.Split(new char[]{' '});

            foreach(var c in letters)
            {
                if (c != "/")
                    Console.Write(c);
                else
                    Console.Write(" ");
            }

            Console.Write("\n\n");
            foreach (var c in letters)
            {
                if (c != "/")
                    Console.Write(dic[c]);
                else
                    Console.Write(" ");
            }

            return result;
        }

        private static void LoadDictionary()
        {
            dic[".-"] = "A";
            dic["-..."] = "B";
            dic["-.-."] = "C";
            dic["-.."] = "D";
            dic["."] = "E";
            dic["..-."] = "F";
            dic["--."] = "G";
            dic["...."] = "H";
            dic[".."] = "I";
            dic[".---"] = "J";
            dic["-.-"] = "K";
            dic[".-.."] = "L";
            dic["--"] = "M";
            dic["-."] = "N";
            dic["---"] = "O";
            dic[".--."] = "P";
            dic["--.-"] = "Q";
            dic[".-."] = "R";
            dic["..."] = "S";
            dic["-"] = "T";
            dic["..-"] = "U";
            dic["...-"] = "V";
            dic[".--"] = "W";
            dic["-..-"] = "X";
            dic["-.--"] = "Y";
            dic["--.."] = "Z";
            dic["/"] = " ";
        }
    }
}
