using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace Nimezida_clone
{
    class Program
    {
        public static void Main(string[] args)
        {
            int countPers = 8;
            string alfavit = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rnd = new();

            List<string> characters = new();
            List<int> tier = new();
            List<int> stats = new();
            List<string> pominki = new()
            {

                "Ну вот и конец тебе ",
                "Выпил и поплыл ",
                "Жаль тебя, малой ",
                "Эх, будем тебя вспоминать ",
                "Увидимся однажды "

            };
            List<string> oformlenie = new() 
            {
                "\nNEW          NEW           NEW         NEW         NEW \n",
                "\n=)--- x ---(=    =)--- x ---(=    =)--- x ---(=    =)--- x ---(=  \n",
                "\n____RIP_____RIP_____RIP_____RIP_____RIP_____RIP_____RIP____ \n",
                "\n======================================================== \n",
                "----+--------+--------+--------+--------+--------+-------+ \n",
            };

            for (int i = 0; i < countPers; i++) NewChar();

            for (int i = 0; i < 100; i++) CheckToAttack();

            Console.WriteLine(oformlenie[3]);

           for (int i = 0; i < countPers; i++) 
            { 
                Console.WriteLine($"{characters[i]} : {tier[i]} : {stats[i]}\n");
            } 
                
           //////////////////////////////////////////////////////////////////////////////////////////////////////

            void CheckToAttack()
            {
                int attack = rnd.Next(characters.Count);
                int defense = rnd.Next(characters.Count);

                while (tier[attack] > tier[defense] || tier[defense] - tier [attack] >1)
                {
                defense = attack;
                attack = rnd.Next(characters.Count);
                }

                Console.WriteLine($"{oformlenie[1]}атакующий {characters[attack]} , тир {tier[attack]} , сила{stats[attack]}");
                Console.WriteLine($"обороняющийся {characters[defense]} , тир {tier[defense]} , сила{stats[defense]}");

                if (stats[attack] > stats[defense])
                {
                    Upgrade(attack, defense);
                    Remove(defense);
                    NewChar();
                }
                else if (stats[attack] < stats[defense])
                {
                    Upgrade(defense, attack);
                    Remove(attack);
                    NewChar();
                }
                else    Console.WriteLine(oformlenie[4] + $"ОНИ РАВНЫЫЫЫЫ!"); 
            }

            void Remove(int x)                  // удаление проигравшего
            {
                int i = rnd.Next(pominki.Count - 1);
                Console.WriteLine($"{oformlenie[2]} {pominki[i]} {characters[x]} , тир {tier[x]} , сила{stats[x]}");
                characters.RemoveAt(x);
                tier.RemoveAt(x);
                stats.RemoveAt(x);
            }

            void Upgrade(int x, int y)          //улучшение 
            {
                Console.WriteLine($"побеждает {characters[x]} , тир {tier[x]} , сила{stats[x]}");
                characters[x] += characters[y];
                tier[x] += tier[x] <= tier[y] ? 1 : 0;
                if (tier[x]<=tier[y]) stats[x] += stats[y]+1;
             //   else stats[x] += tier[y] - tier[x];   //доработать систему поощерения, если равны по тиру
                Console.WriteLine($"{oformlenie[4]}улучшается до: {characters[x]} , тир {tier[x]} , сила{stats[x]}");
            }

            void NewChar()                       //создание нового перса
            {
                string n = Convert.ToString(alfavit[rnd.Next(alfavit.Length)]);
                characters.Add(n);
                tier.Add(1);
                stats.Add(rnd.Next(1, 5));
                int i = characters.Count - 1;
                Console.WriteLine($"{oformlenie[0]}создан экземпляр {characters[i]} , тир {tier[i]} , сила{stats[i]}");
            }
        }
    }
}
       






























            //    List<int> tier = new();
            //    List<string> nameChar = new();
            //    List<int> persons = new();

            //    for (int lol = 0; lol < countPers; lol++)
            //    {
            //        persons.Add(rnd.Next(1, 6));
            //        Console.WriteLine($"воин: {lol}  сила: {persons[lol]}");
            //    }

            //    Console.WriteLine();

            //    for (int i = 0; i < 10; i++)
            //    {
            //        int rndCheck1 = rnd.Next(0, countPers);
            //        int rndCheck2 = rnd.Next(0, countPers);

            //        while (rndCheck1 == rndCheck2) rndCheck2 = rnd.Next(1, countPers);
            //        if (rndCheck1 == rndCheck2) Console.WriteLine("ОДИНАКОВЫЕ!!!");

            //        switch (persons[rndCheck1] > persons[rndCheck2])

            //        {
            //            case true:
            //                Console.WriteLine($"{rndCheck1} съел {rndCheck2}");
            //                persons[rndCheck1] = persons[rndCheck1] + persons[rndCheck2];
            //                Console.WriteLine($"воин: {rndCheck1}  сила: {persons[rndCheck1]} \n");

            //                break;

            //            case false:
            //                Console.WriteLine($"{rndCheck2} съел {rndCheck1}");
            //                persons[rndCheck2] = persons[rndCheck1] + persons[rndCheck2];
            //                Console.WriteLine($"воин: {rndCheck2}  сила: {persons[rndCheck2]}\n");

            //                break;

            //            default:
            //                Console.WriteLine($"{rndCheck1} и {rndCheck2} равны \n");
            //                break;
            //        }

            //        // Thread.Sleep(100);
            //    }

            //    for (int kek = 0; kek < countPers; kek++)
            //    {
            //        Console.WriteLine($"воин: {kek}  сила: {persons[kek]}");
            //    }
            //}

            //class Rename
            //     {
            //        public class Rename
            //        {

            //        }
            //     }




        //}
        //объекты заполняются. +
        //    сравниваются.
        //перезаполняется слабый

        //сравнение должно затрагивать созданные и заполненные объекты.объекты заполняются цифрами.
        //сравнение заставляет больший объект дополнительно принимать одно из его значений и удалять.

        //удаленный объект пересоздается
        //}





