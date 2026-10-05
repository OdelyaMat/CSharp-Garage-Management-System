using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    // $G$ NTT-999 (-5) Bad use of exceptions here. Shouldn't use exception in a UI class,
    // for standard input validation flow. While the UI can catch exceptions thrown 
    // by the logic layer, it should not throw its own exceptions to manage internal loops. 
    // Use safe parsing methods like 'TryParse' to handle predictable user typos instead.
    // In UI layer it is better to directly show error mesaage to the user.
    // $G$ DSN-999 (-3) This class should be static.
    public class InputReader
    {
        // $G$ NTT-999 (-5) You should have used string.IsNullOrEmpty() here.
        public string ReadNonEmptyString(string i_Message)
        {
            Console.Write(i_Message);
            string input = Console.ReadLine();

            if (input == null || input == "")
            {
                throw new FormatException("Input cannot be empty.");
            }

            return input;
        }

        public int ReadIntInRange(string i_Message, int i_MinValue, int i_MaxValue)
        {
            int value;

            Console.Write(i_Message);

            if (!int.TryParse(Console.ReadLine(), out value))
            {
                throw new FormatException("Input must be an integer.");
            }

            if (value < i_MinValue || value > i_MaxValue)
            {
                throw new ValueRangeException(i_MinValue, i_MaxValue);
            }

            return value;
        }

        public float ReadFloatInRange(string i_Message, float i_MinValue, float i_MaxValue)
        {
            float value;

            Console.Write(i_Message);

            if (!float.TryParse(Console.ReadLine(), out value))
            {
                throw new FormatException("Input must be a number.");
            }

            if (value < i_MinValue || value > i_MaxValue)
            {
                throw new ValueRangeException(i_MinValue, i_MaxValue);
            }

            return value;
        }

        public float ReadPositiveFloat(string i_Message)
        {
            float value;

            Console.Write(i_Message);

            if (!float.TryParse(Console.ReadLine(), out value))
            {
                throw new FormatException("Input must be a number.");
            }

            if (value < 0)
            {
                throw new ValueRangeException(0, float.MaxValue);
            }

            return value;
        }

        public int ReadPositiveInt(string i_Message)
        {
            int value;

            Console.Write(i_Message);

            if (!int.TryParse(Console.ReadLine(), out value))
            {
                throw new FormatException("Input must be an integer.");
            }

            if (value < 0)
            {
                throw new ValueRangeException(0, int.MaxValue);
            }

            return value;
        }

        public bool ReadBool(string i_Message)
        {
            bool value;

            Console.Write(i_Message);

            if (!bool.TryParse(Console.ReadLine(), out value))
            {
                throw new FormatException("Input must be true or false.");
            }

            return value;
        }

        public T ReadEnum<T>(string i_Message)
        {
            Console.WriteLine(i_Message + ":");

            string[] enumNames = Enum.GetNames(typeof(T));

            foreach (string name in enumNames)
            {
                Console.WriteLine("- {0}", name);
            }

            string input = ReadNonEmptyString("Enter value: ");

            foreach (string name in enumNames)
            {
                if (name.ToLower() == input.ToLower())
                {
                    return (T)Enum.Parse(typeof(T), name);
                }
            }

            throw new ArgumentException("Invalid option.");
        }
    }
}