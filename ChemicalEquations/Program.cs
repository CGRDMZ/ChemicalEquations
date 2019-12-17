using System;

namespace ChemicalEquations
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string input;

            string[] formula;

            string[] Side;

            string[] elements = new string[0];

            

            input = Console.ReadLine();
            input = input.ToUpper().Replace(" ", ""); // replace whitespaces with empty in order to replace them.

            formula = input.Split('='); // we divide the equation at the point of equal sign

            // keeps the number of elements for 2 sides of the equation
            int[] carbonCounter = new int[formula.Length];
            int[] hydrogenCounter = new int[formula.Length];
            for (int i = 0; i < formula.Length; i++)
            {
                carbonCounter[i] = 0;
                hydrogenCounter[i] = 0;
            }

            int left;
            int right;

            bool valid = true;
            // this code supports to check more than one equation at one line ex: (1234C2+2C3+C+C12345=C14820=1234C2+2C3+C+C12345=C14820)
            // but for this homework we need to check if there is only one equal sign.
            if (formula.Length != 2)
            {
                valid = false;
            }

            for (int l = 0; l < formula.Length; l++)
            {
                // for every part of the equation we split it by the plus points. This gives us every element of the side we are looking.
                Side = formula[l].Split("+");

                // loops all the elements in the side
                for (int i = 0; i < Side.Length; i++)
                {
                    for (int j = 0; j < Side[i].Length; j++)
                    {
                        if (Side[i][j] == 'C')
                        {
                            elements = Side[i].Split('C');
                            for (int k = 0; k < elements.Length; k += 2)
                            {
                                //Console.WriteLine(elements[k]);
                                //Console.WriteLine(elements[k + 1]);

                                //left = Convert.ToInt32(elements[k]);
                                int.TryParse(elements[k], out left);
                                //right = Convert.ToInt32(elements[k + 1]);
                                int.TryParse(elements[k + 1], out right);

                                // if the element is a empty string then set the value to 1
                                if (elements[k] == "")
                                {
                                    left = 1;
                                }
                                if (elements[k + 1] == "")
                                {
                                    right = 1;
                                }

                                carbonCounter[l] += left * right;
                            }
                        }
                        else if (Side[i][j] == 'H')
                        {
                            elements = Side[i].Split('H');
                            for (int k = 0; k < elements.Length; k += 2)
                            {
                                //Console.WriteLine(elements[k]);
                                //Console.WriteLine(elements[k + 1]);

                                //left = Convert.ToInt32(elements[k]);
                                int.TryParse(elements[k], out left);
                                //right = Convert.ToInt32(elements[k + 1]);
                                int.TryParse(elements[k + 1], out right);

                                if (elements[k] == "")
                                {
                                    left = 1;
                                }
                                if (elements[k + 1] == "")
                                {
                                    right = 1;
                                }

                                hydrogenCounter[l] += left * right;
                            }
                        }
                        else if (!('0' <= Side[i][j] && Side[i][j] <= '9')) // if the index value is not c or h, to this equation to be valid it should be a number
                                                                            // if not, then not valid. 
                        {
                            valid = false;
                        }
                    }

                    //Console.WriteLine(leftSide[i]);
                }
            }

            if (valid)
            {
                Console.WriteLine();
                Console.WriteLine($"carbon counter for left = {carbonCounter[0]}");
                Console.WriteLine($"carbon counter for right = {carbonCounter[1]}");

                Console.WriteLine();
                Console.WriteLine($"hydrogen counter for left = {hydrogenCounter[0]}");
                Console.WriteLine($"hydrogen counter for right = {hydrogenCounter[1]}");

                Console.WriteLine();

                if (carbonCounter[0] == carbonCounter[1] && hydrogenCounter[0] == hydrogenCounter[1])
                {
                    Console.WriteLine("This formula is tantamount");
                }
                else
                {
                    Console.WriteLine("This formula is not tantamount");
                }
            }
            else
            {
                Console.WriteLine("Invalid character");
            }

            Console.ReadLine();
        }
    }
}