using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Chek
    {
        public void CheckingOnTheSquare(double Length)
        {
            if (Length % Math.Sqrt(Length) != 0 && Length > 1)
            {
                throw new ArgumentException("Values less than you need! ");
            }

        }


        public void ChekOnTherepeat(double Length, List<int> gameArea)
        {

            for (int i = 0; i < Length; ++i)
            {
                for (int y = i + 1; y < Length; ++y)
                {

                    if (gameArea[i] == gameArea[y])
                    {
                        Console.WriteLine(gameArea[i] + " ==" + gameArea[y]);
                        throw new ArgumentException("Chips must not be repeated! ");
                    }


                }
            }

        }


        public void ChekOnTheNullChik(double Length, List<int> gameArea)
        {

            bool temp = false;
            for (int y = 0; y < Length; ++y)
            {
                if (gameArea[y] == 0)
                {
                    temp = true;

                }
            }
            if (!temp)
            {
                throw new ArgumentException("Нет пустой ячейки!");
            }

        }

        public bool CheckForCorrectness(List<int> GameArea)
        {

            int summ = 0;

            summ += GameArea[0] - 1;
            for (int i = 1; i < GameArea.Count - 1; ++i)
            {
                if (GameArea[i] > 0)
                {
                    if (GameArea[i] < GameArea[i - 1] && GameArea[i - 1] - 2 >= 0)
                    {
                        summ += GameArea[i - 1] - LeftNumber(GameArea, i, GameArea[i - 1]);
                    }
                    else
                    {
                        summ += GameArea[i - 1] - 1;
                    }
                }
                else
                {
                    summ += i;
                }

            }

            //Console.WriteLine(summ);
            if (summ % 2 == 0)
            {
                return true;
            }

            else return false;

        }

        public int LeftNumber(List<int> GameArea, int i, int Chik)
        {
            int plusChek = 0;
            for (int x = 0; x < i; ++x)
            {
                if (Chik > GameArea[x])
                {
                    ++plusChek;
                }
            }
            return plusChek;
        }

    }
}