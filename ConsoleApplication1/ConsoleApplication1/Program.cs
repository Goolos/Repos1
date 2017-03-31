using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
           
             int[] mas = Read.ReadFromCSV("text.csv");
             Game game = new Game(mas);
             if (game.CorrectArray(mas) && game.CorrectIntSize(mas.Length))
             {
               Console.WriteLine("Игровое поле:");
                for (int i = 0; i < mas.Length; i++)
                 {
                     Console.Write(mas[i] + " ");
                 }
             }
             else throw new ArgumentException("Массив некорректен или размер поля с данными аргументами не может существовать");
             Console.WriteLine();
             Print.PrintInfo(game.Numbers);
             int point = 5;
             if (game.GetLocation(point) != null)
             {
                 Console.WriteLine("Позиция числа 5:x = {0},y = {1}", game.GetLocation(5).x, game.GetLocation(5).y);
             }
             else throw new ArgumentException("Данное число не удалось найти");
             int pyatnashka1 = 2;
             if (game.ShiftOrImpossible(pyatnashka1))
             {
                 Print.PrintInfo(game.Numbers);
             }
             else throw new ArgumentException("Данное число не удалось найти или невозможно поменять местами с нулём");

            Game game = new Game(mas);
            int[] mas2 = { 1, 2, 3, 4, 5, 6, 7, 0, 8 };
            Game2 game2 = Game2.Randomize(game);
            Console.WriteLine("Game2 Random");
            Print.PrintInfo(game2.Numbers);
            Game3 game3 = new Game3(mas2);
            Console.WriteLine("Game3 Исходно");
            Print.PrintInfo(game3.Numbers);
            game3.ShiftOrImpossible(7);
            game3.ShiftOrImpossible(4);
            Print.PrintInfo(game3.Numbers);
            game3.ShiftOrImpossible(1);
            Print.PrintInfo(game3.Numbers);
            game3.GetHistory();
            game3.DeleteLastStep();
            Print.PrintInfo(game3.Numbers);
            Console.ReadLine();
        }
    }
}