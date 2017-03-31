using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Game
    {
        public int Side { get; }
        private int xOfNull;
        private int yOfNull;
        public int[,] Numbers;
        public Game(int[] mas)
        {
            Side = (int)Math.Sqrt(mas.Length);
            ToMakeAField(mas);
        }
        private void ToMakeAField(int[] mas)
        {
            int count = 0;
            Numbers = new int[Side, Side];
            for (int i = 0; i < Side; i++)
            {
                for (int j = 0; j < Side; j++)
                {
                    if (mas[count] == 0)
                    {
                        xOfNull = i;
                        yOfNull = j;
                        Numbers[i, j] = mas[count];
                        count++;
                    }
                    else
                    {
                        Numbers[i, j] = mas[count];
                        count++;
                    }
                }
            }
        }
        public Point GetLocation(int value)
        {
            Point point = null;
            if ((value < Math.Pow(Side, 2)) && (value >= 0))
            {
                for (int i = 0; i < Side; i++)
                {
                    for (int j = 0; j < Side; j++)
                    {
                        if (Numbers[i, j] == value)
                            point = new Point(i, j);
                    }
                }
            }
            return point;
        }
        public virtual bool ShiftOrImpossible(int value)
        {
            int firsttemp = 0;
            int secondtemp = 0;
            for (int i = 0; i < Side; i++)
            {
                for (int j = 0; j < Side; j++)
                {
                    if (Numbers[i, j] == value)
                    {
                        firsttemp = i;
                        secondtemp = j;
                    }
                }
            }
            if (Math.Abs(firsttemp - xOfNull) + Math.Abs(secondtemp - yOfNull) == 1)
            {
                Numbers[xOfNull, yOfNull] = Numbers[firsttemp, secondtemp];
                xOfNull = firsttemp;
                yOfNull = secondtemp;
                Numbers[xOfNull, yOfNull] = 0;
                return true;
            }
            else return false;
        }
        public bool CorrectArray(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if ((!mas.Contains(i)) || (mas[i] < 0))
                {
                    return false;
                }
            }
            return true;
        }
        public bool CorrectIntSize(int size)
        {
            return ((Math.Sqrt(size) % 1) == 0);
        }
    }
}