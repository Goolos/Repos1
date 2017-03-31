using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    struct History
    {
        public int value;
        public int x;
        public int y;
        public History(int value, int x, int y)
        {
            this.value = value;
            this.x = x;
            this.y = y;
            //point
        }
    }
    class Game3 : Game2
    {
        public readonly List<History> history;
        public Game3(int[] mas) : base(mas)
        {
            history = new List<History>();
        }
        public override bool ShiftOrImpossible(int value)
        {
            if (base.ShiftOrImpossible(value))
            {
                history.Add(new History(value, base.GetLocation(value).x, base.GetLocation(value).y));
                return true;
            }
            else return false;
        }
        public void DeleteLastStep()
        {
            base.ShiftOrImpossible(history.Last().value);
            history.Remove(history.Last());
        }
        public void GetHistory()
        {
            foreach (var i in history)
            {
                Console.WriteLine("Значение{0},Координатa{1},{2}", i.value, i.x, i.y);
            }
        }

    }
}