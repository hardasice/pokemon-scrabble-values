using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class MainClass
{
    public static void Main(string[] args)
    {
        // Variables
        Dictionary<string, int> scrabbleLetterValues = CreateScrabbleDictionary();
        List<string> pokemonNameList = CreatePokemonNameList();

        // Dictionary with pokemon names and their scrabble values
        Dictionary<string, int> pokemonScrabbleDict = ConnectNameWithValueDict(pokemonNameList, scrabbleLetterValues);

        // Order names by values
        var pokemonList = (from pokemon in pokemonScrabbleDict
                           orderby pokemon.Value ascending
                           select pokemon).ToList();

        // Output Pokemon and their scrabble values
        Console.WriteLine("{0,-15} {1,2}\n", "Name", "Value");
        foreach (var pokemon in pokemonList)
        {
            Console.WriteLine("{0,-15} {1,5}", pokemon.Key, pokemon.Value);
        }

        Console.ReadLine();
    }

    public static Dictionary<string, int> CreateScrabbleDictionary()
    {
        var dict = new Dictionary<string, int>() {
            { "a" , 1 },
            { "b" , 3 },
            { "c" , 3 },
            { "d" , 2 },
            { "e" , 1 },
            { "f" , 4 },
            { "g" , 2 },
            { "h" , 4 },
            { "i" , 1 },
            { "j" , 8 },
            { "k" , 5 },
            { "l" , 1 },
            { "m" , 3 },
            { "n" , 1 },
            { "o" , 1 },
            { "p" , 3 },
            { "q" , 10 },
            { "r" , 1 },
            { "s" , 1 },
            { "t" , 1 },
            { "u" , 1 },
            { "v" , 4 },
            { "w" , 4 },
            { "x" , 8 },
            { "y" , 4 },
            { "z" , 10 }
        };

        return dict;
    }

    public static List<string> CreatePokemonNameList()
    {
        var list = new List<string>();
        string[] lines = File.ReadLines("../../../TextFiles/pokemonNames.txt").ToArray();

        foreach (string line in lines)
        {
            list.Add(line);
        }

        return list;
    }

    public static Dictionary<string, int> ConnectNameWithValueDict(List<string> names, Dictionary<string, int> values)
    {
        var dict = new Dictionary<string, int>();

        foreach (string name in names)
        {
            var nameValue = 0;
            foreach (char letter in name)
            {
                if (Char.IsLetter(letter))
                {
                    var lowerLetter = Char.ToLower(letter).ToString();
                    var letterValue = values[lowerLetter];
                    nameValue += letterValue;
                }
            }
            dict.Add(name, nameValue);
        }

        return dict;
    }
}