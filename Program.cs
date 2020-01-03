using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XO
{
    class Program
    {
        static void Main()
        {          
            string player1, player2;
            Welcome(out player1, out player2);
            Play(player1, player2);
        }

        private static void Welcome(out string p1, out string p2)
        {
            Console.WriteLine("Введите имя первого игрока:");          
            p1 = Console.ReadLine();
            if (string.IsNullOrEmpty(p1))
                p1 = "Игрок 1";
           
            Console.WriteLine("Введите имя второго игрока:");
            p2 = Console.ReadLine();
            if (string.IsNullOrEmpty(p1))
                p2 = "Игрок 2";
            Console.Clear();          
        }

        private static void Play(string p1, string p2)
        {
            char[] field = new char[9] { '-', '-', '-', '-', '-', '-', '-', '-', '-' };
            char firstTurn = 'X';
            char secondTurn = '0';
            int num1 = 0;
            int num2 = 0;

            while (true)
            {

                Show(field);
            TryP1:
                //ход первого игрока
                Console.WriteLine($"Ход игрока {p1}, вы ставите '{firstTurn}'. Поставьте цифру (от 1 до 9).");
                bool result = Int32.TryParse(Console.ReadLine(), out num1);
                if (result)
                {
                    if (num1 > field.Length || num1 <= 0)
                    {
                        Console.WriteLine("Такой позиции не существует! Введите цифру (от 1 до 9)\n");
                        goto TryP1;
                    }

                    if (num1 <= field.Length)
                    {
                        if (field[num1 - 1] != '-')
                        {
                            Console.WriteLine("Ход в данное место невозможен! \n");
                            goto TryP1;
                        }
                        else
                            field[num1 - 1] = firstTurn;
                    }

                }
                else if (!result)
                {
                    Console.WriteLine("Убедитесь в правильности ввода!\n");
                    goto TryP1;
                }

                if (field[0].Equals(firstTurn) && field[1].Equals(firstTurn) && field[2].Equals(firstTurn) ||
                   field[0].Equals(firstTurn) && field[3].Equals(firstTurn) && field[6].Equals(firstTurn) ||
                   field[0].Equals(firstTurn) && field[4].Equals(firstTurn) && field[8].Equals(firstTurn) ||
                   field[3].Equals(firstTurn) && field[4].Equals(firstTurn) && field[5].Equals(firstTurn) ||
                   field[6].Equals(firstTurn) && field[7].Equals(firstTurn) && field[8].Equals(firstTurn) ||
                   field[6].Equals(firstTurn) && field[4].Equals(firstTurn) && field[2].Equals(firstTurn) ||
                   field[1].Equals(firstTurn) && field[4].Equals(firstTurn) && field[7].Equals(firstTurn) ||
                   field[2].Equals(firstTurn) && field[5].Equals(firstTurn) && field[8].Equals(firstTurn))
                {
                    Console.WriteLine($"Победил игрок {p1}!");
                    Console.ReadLine();
                    break;
                }
                Console.Clear();

                Show(field);
            TryP2:
                //ход второго игрока
                Console.WriteLine($"Ход игрока {p2}, за вами '{secondTurn}'. Поставьте цифру (от 1 до 9).");
                bool result1 = Int32.TryParse(Console.ReadLine(), out num2);
                if (result1)
                {
                    if (num2 > field.Length || num2 <= 0)
                    {
                        Console.WriteLine("Такой позиции не существует! Введите цифру (от 1 до 9)\n");
                        goto TryP2;
                    }

                    if (num2 <= field.Length)
                    {
                        if (field[num2 - 1] != '-')
                        {
                            Console.WriteLine("Ход в данное место невозможен!\n");
                            goto TryP2;
                        }
                        else
                            field[num2 - 1] = secondTurn;
                    }

                }
                else if (!result1)
                {
                    Console.WriteLine("Убедитесь в правильности ввода!\n");
                    goto TryP2;
                }

                if (field[0].Equals(secondTurn) && field[1].Equals(secondTurn) && field[2].Equals(secondTurn) ||
                 field[0].Equals(secondTurn) && field[3].Equals(secondTurn) && field[6].Equals(secondTurn) ||
                 field[0].Equals(secondTurn) && field[4].Equals(secondTurn) && field[8].Equals(secondTurn) ||
                 field[3].Equals(secondTurn) && field[4].Equals(secondTurn) && field[5].Equals(secondTurn) ||
                 field[6].Equals(secondTurn) && field[7].Equals(secondTurn) && field[8].Equals(secondTurn) ||
                 field[6].Equals(secondTurn) && field[4].Equals(secondTurn) && field[2].Equals(secondTurn) ||
                 field[1].Equals(secondTurn) && field[4].Equals(secondTurn) && field[7].Equals(secondTurn) ||
                 field[2].Equals(secondTurn) && field[5].Equals(secondTurn) && field[8].Equals(secondTurn))
                {                    
                    Console.WriteLine($"Победил игрок {p2}!\n");
                    Console.ReadLine();
                    break; 
                }
               

                Console.Clear();

            }
        }

        private static void Show(char[] field)
        {
            Console.WriteLine("***************");
            Console.WriteLine($"== {field[0]} | {field[1]} | {field[2]} ==");
            Console.WriteLine($"== {field[3]} | {field[4]} | {field[5]} ==");
            Console.WriteLine($"== {field[6]} | {field[7]} | {field[8]} ==");
            Console.WriteLine("***************");
        }
    }
}
