using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {


            List<int> ChikForGame = new List<int>();
            Chek ch = new Chek();


            Console.WriteLine("Рандом или из файла жми 1 Рандом, жми 2 из файла: ");
            string numb = Console.ReadLine();
            if (numb == "1")
            {
                Console.WriteLine("Введите кол-во фишек в игре: ");
                int perem = Convert.ToInt32(Console.ReadLine());
                ch.CheckingOnTheSquare(perem);

                bool ChekTrue = false;

                for (int length = 0; length < perem; length++)
                {

                    ChikForGame.Add(length);

                }
                while (!ChekTrue)
                {

                    ch.CheckForCorrectness(ChikForGame);
                    Game2 RandomGameArea = new Game2(ChikForGame, ch);
                    RandomGameArea.Mixer(ChikForGame);

                    if (ch.CheckForCorrectness(ChikForGame))
                    {
                        ChekTrue = true;
                    }


                }
            }

            else if (numb == "2")
            {
                ChikForGame = FromSCV(ChikForGame);
                ch.CheckForCorrectness(ChikForGame);
                ch.CheckingOnTheSquare(ChikForGame.Count);
            }
            else
            {
                throw new ArgumentException("Жаль, вы должны были выбрать поле");

            }

            ch.CheckForCorrectness(ChikForGame);
            ch.ChekOnTheNullChik(ChikForGame.Count, ChikForGame);
            ch.ChekOnTherepeat(ChikForGame.Count, ChikForGame);


            var game = new Game3(ChikForGame, ch);




            funcOut(game);

            string N = "";
            int scoreGame = 0;

            while (N != "N")
            {
                if (game.PublicIntHistory > 0)
                {

                    Console.WriteLine("Вернуться назад???? ");
                    string MoveBack = Console.ReadLine();

                    bool ChekBack = false;
                    if (MoveBack == "Y")
                    {
                        Console.WriteLine("На сколько ходов? ");
                        int value1 = Convert.ToInt32(Console.ReadLine());
                        game.MoveBack(value1);
                        funcOut(game);
                        ChekBack = true;
                    }


                    if (ChekBack == true)
                    {
                        Console.WriteLine("Вернуться в перед???? ");
                        string MoveForward = Console.ReadLine();
                        if (MoveForward == "Y")
                        {
                            Console.WriteLine("На сколько ходов? ");
                            int value1 = Convert.ToInt32(Console.ReadLine());
                            game.MoveForward(value1);
                            funcOut(game);

                        }
                    }
                }
                //Console.Clear();

                int value = Convert.ToInt32(Console.ReadLine());

                game.ShiftValue(value, game);

                if (game.CheckingTheEndOfTheGame())
                {
                    funcOut(game);
                    break;
                }
                Console.WriteLine("Ход номер: " + (scoreGame + 1));
                funcOut(game);


                ++scoreGame;
            }
            Console.WriteLine("Game over");
            Console.WriteLine("Число ходов: " + scoreGame);


        }

        public static List<int> FromSCV(List<int> areaChikDinam)
        {
            int integer = 0;
            string file1 = @"C:\Users\Home\Desktop\ПЯТНАШКИ2-3 ЛАСТ ЕДИТИОН\Game2-3\Game\Game\File.csv";
            try
            {
                string[] file = File.ReadAllLines(file1);
                Char ch = ';';

                for (int i = 0; i < file.Length; ++i)
                {
                    string[] chfile = file[i].Split(ch);
                    foreach (var substring in chfile)
                    {
                        areaChikDinam.Add(Convert.ToInt32(substring));

                        ++integer;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);

            }

            return areaChikDinam;
        }


        static void funcOut(Game game)
        {
            for (int x = 0; x < game.IntSize; ++x)
            {
                for (int y = 0; y < game.IntSize; ++y)
                {
                    Console.Write(game.GameArea[x, y] + " ");
                }
                Console.WriteLine();
            }

        }



    }
}