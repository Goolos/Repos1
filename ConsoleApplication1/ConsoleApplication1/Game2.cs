using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Game2 : Game
    {
        public Game2(int[] mas) : base(mas)
        {
            if (ThisGameIsEnd()) throw new ArgumentException("Игра закончена!");
        }
        public bool ThisGameIsEnd()
        {
            int count = 1, lastValue = Side;

            for (int i = 0; i < Side; i++)
            {
                for (int j = 0; j < Side; j++)
                {
                    if ((i != Side - 1) || (j != Side - 1))
                    {
                        if (Numbers[i, j] != count)
                        {
                            return false;
                        }
                        count++;
                    }
                    else if (Numbers[Side - 1, Side - 1] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static Game2 Randomize(Game Values)
        {
            int[] values = new int[Values.Side * Values.Side];
            int count = 0;
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = -1;
            }
            Random Gen = new Random();
            while (count != values.Length)
            {
                int a = Gen.Next(0, values.Length);
                if (!values.Contains(a))
                {
                    values[count] = a;
                    count++;
                }
            }
            return new Game2(values);
        }
    }
}
