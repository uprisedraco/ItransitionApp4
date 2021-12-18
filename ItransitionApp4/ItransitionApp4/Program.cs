using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItransitionApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length % 2 == 0 || args.Length < 3 || args.Distinct().Count() != args.Length)
            {
                Console.WriteLine("Sorry. There are some rules you need to know to play this game." +
                    "\n1. Elements count need to be odd and => 3." + 
                    "\n2. Elements must be distinct." + 
                    "\nExample: Rock Paper Scissors Lizard Spock");
            }
            else
            {
                Rules rules = new Rules(args);
                RulesTable rulesTable = new RulesTable(args, rules.GetMatrix());
                KeyGenerator keyGenerator = new KeyGenerator(64);
                HMACGenerator hmacGenerator = new HMACGenerator(keyGenerator.GetKey());

                start:
                int i = 1;

                Random random = new Random();
                int computerOption = random.Next(0, args.Length);


                Console.WriteLine();
                Console.WriteLine("HMAC: " + hmacGenerator.GetHMAC(computerOption));

                Console.WriteLine();
                Console.WriteLine("Available moves:");

                foreach (var arg in args)
                {
                    Console.WriteLine();
                    Console.WriteLine(i + " - " + args[i - 1]);
                    i++;
                }

                Console.WriteLine();
                Console.WriteLine("0 - exit");

                Console.WriteLine();
                Console.WriteLine("? - help");

                Console.WriteLine();
                Console.WriteLine("Enter your move: ");

                string enter = Console.ReadLine();
                int option = 0;

                if (enter == "?")
                {
                    rulesTable.DisplayTable();
                    goto start;
                }

                try
                {
                    option = Convert.ToInt32(enter);

                    if (option > 0 && option <= args.Length)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Your move: \n" + args[option - 1]);
                        Console.WriteLine();
                        Console.WriteLine("Computer move: \n" + args[computerOption]);
                        Console.WriteLine();

                        int result = rules.GetMatrix()[option - 1, computerOption];

                        switch (result)
                        {
                            case 0:
                                Console.WriteLine("Draw");
                                break;
                            case 1:
                                Console.WriteLine("Win");
                                break;
                            case -1:
                                Console.WriteLine("Lose");
                                break;
                        }

                        Console.WriteLine();
                        Console.WriteLine("HMAC key: " + keyGenerator.GetKey());

                        goto start;
                    }
                    else if (option != 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Try again");
                        goto start;
                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Try again");
                    goto start;
                }

                Environment.Exit(0);
            }
        }
    }
}
