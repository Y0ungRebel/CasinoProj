using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество игроков: ");
            int countOfPlayers = Convert.ToInt32(Console.ReadLine());

            int[] chips = new int[countOfPlayers];
            int sumOfChips = 0;
            for (int i = 0; i < countOfPlayers; i++)
            {
                Console.Write($"Введите количество фишек у {i + 1} игрока: ");
                chips[i] = Convert.ToInt32(Console.ReadLine());
                sumOfChips+=chips[i];
            }

            int chipsOfPlayer = sumOfChips / countOfPlayers;
            Console.WriteLine($"Всего {countOfPlayers} игроков. У каждого должно оказаться по {chipsOfPlayer} фишек.");


            int countOfSteps = 0;

            while (chips.Any(x => x != chipsOfPlayer))
            {
                for (int i = 0; i < chips.Length; i++)
                {
                    int difference = chips[i] - chipsOfPlayer;

                    if (difference != 0 && difference > 0)
                    {
                        chips[i] -= difference;

                        if (i == 0)
                        {
                            if (chips[i + 1] >= chipsOfPlayer) chips[chips.Length - 1] += difference;
                        }

                        else if (i == chips.Length - 1)
                        {
                            if (chips[i - 1] >= chipsOfPlayer) chips[0] += difference;
                        }

                        else
                        {
                            if (chips[i + 1] >= chipsOfPlayer) chips[i - 1] += difference;
                            else if (chips[i - 1] >= chipsOfPlayer) chips[i + 1] += difference;
                        }

                        countOfSteps += difference;
                    }
                }
            }

            Console.Write("Количество фишек у каждого игрока после передач: ");
            for (int i = 0; i < countOfPlayers; i++)
            {                
                Console.Write(chips[i] + " ");
            }
            Console.WriteLine($"\nКоличество передач: {countOfSteps}");
        }
    }
}
