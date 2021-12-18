using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace ItransitionApp4
{
    internal class RulesTable
    {
        ConsoleTable rulesTable;

        public RulesTable(string[] array, int[,] rules)
        {
            rulesTable = new ConsoleTable("P \\ E");
            rulesTable.AddColumn(array);

            for (int i = 0; i < rules.GetLength(0); i++)
            {
                string[] s = new string[array.Length + 1];

                s[0] = array[i];

                for (int j = 0; j < rules.GetLength(1); j++)
                {
                    int result = rules[i, j];

                    switch (result)
                    {
                        case 0:
                            s[j + 1] = "Draw";
                            break;
                        case 1:
                            s[j + 1] = "Win";
                            break;
                        case -1:
                            s[j + 1] = "Lose";
                            break;
                    }
                }

                rulesTable.AddRow(s);
            }
        }

        public void DisplayTable()
        {
            Console.WriteLine();
            Console.WriteLine("P - player" + "\nE - enemy");
            Console.WriteLine();
            rulesTable.Write();
        }
    }
}
