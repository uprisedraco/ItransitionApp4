using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItransitionApp4
{
    internal class Rules
    {
        int[,] vectors;

        int[,] rulesMatrix;

        public Rules(string[] array)
        {
            rulesMatrix = new int[array.Length, array.Length];
            
            int wins = (array.Length - 1) / 2;

            vectors = new int[wins * array.Length, 2];

            GenerateMatrix();

            foreach (string a in array)
            {
                int currentElement = Array.IndexOf(array,a);

                for (int i = 1; i <= wins; i++)
                {
                    vectors[currentElement, 0] = currentElement;

                    vectors[currentElement, 1] = currentElement + i;

                    if(currentElement + i >= array.Length)
                    {
                        vectors[currentElement, 1] = i - (array.Length - currentElement);
                    }

                    rulesMatrix[vectors[currentElement, 0], vectors[currentElement, 1]] = 1;
                }
            }
        }

        private void GenerateMatrix()
        {
            for(int i = 0; i < rulesMatrix.GetLength(0); i++)
            {
                for(int j = 0; j < rulesMatrix.GetLength(1); j++)
                {
                    if(i == j)
                    {
                        rulesMatrix[i, j] = 0;
                    }
                    else
                    {
                        rulesMatrix[i, j] = -1;
                    }
                }
            }
        }

        public int[,] GetMatrix()
        {
            return rulesMatrix;
        }
    }
}
