using System;
using System.Diagnostics.Metrics;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static string[] allNum = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static int num = 0, count1 = 0, count2 = 0;
        static  string player1, player2, X_or_O_1, X_or_O_2, X_or_O_Net = null;
        static bool flag, player1_is_X;
       

        static void Main(string[] args)
        {
            Console.WriteLine("Hello , Please enter the name of the first player!");
            player1 = Console.ReadLine();
            Console.WriteLine("Please enter the name of the second player!");
            player2 = Console.ReadLine();
            
            
            while (true)
            {
               
                Console.WriteLine($"{player1} choose if you want to bi X or O?");
                X_or_O_1 = Console.ReadLine();
                choose_X_or_O();
                mat();
                Console.WriteLine($"The score is:\n {player1}: {count1}\n {player2}: {count2}\n ");
                for (int i = 0; i < allNum.Length - 1; i++)
                {
                   
                    if (i == 0)
                    {
                       
                        if (flag)
                        {
                            whoIsTheWiner();
                            Console.WriteLine($"{player1} choose a num betwin 1-9: ");
                            int.TryParse(Console.ReadLine(), out num);

                            while (num < 1 || num > 9)
                            {
                                Console.WriteLine($"{player1} you can only choose a num betwin 1-9: ");
                                int.TryParse(Console.ReadLine(), out num);
                            }

                            X_or_O_Net = X_or_O_1;

                        }
                        else
                        {
                            Console.WriteLine($"{player2} choose a num  betwin 1-9: ");
                            int.TryParse(Console.ReadLine(), out num);
                            while (num < 1 || num > 9)
                            {
                                Console.WriteLine($"{player2} you can only choose a num betwin 1-9: ");
                                int.TryParse(Console.ReadLine(), out num);
                            }
                            X_or_O_Net = X_or_O_2;
                        }
                    }
                    switch (num)
                    {
                        case 1:
                            allNum[0] = X_or_O_Net;
                            break;
                        case 2:
                            allNum[1] = X_or_O_Net;
                            break;
                        case 3:
                            allNum[2] = X_or_O_Net;
                            break;
                        case 4:
                            allNum[3] = X_or_O_Net;
                            break;
                        case 5:
                            allNum[4] = X_or_O_Net;
                            break;
                        case 6:
                            allNum[5] = X_or_O_Net;
                            break;
                        case 7:
                            allNum[6] = X_or_O_Net;
                            break;
                        case 8:
                            allNum[7] = X_or_O_Net;
                            break;
                        case 9:
                            allNum[8] = X_or_O_Net;
                            break;
                    }
                    Console.Clear();
                    mat();
                    if (condition_2() || condition_1())
                    {
                        goto AfterLoop;
                    }
                    if (flag)
                    {
                        X_or_O_Net = X_or_O_2;
                        flag = false;
                        Console.WriteLine($"{player2} choose a num  betwin 1-9: ");
                        int.TryParse(Console.ReadLine(), out num);
                        while (num < 1 || num > 9 || allNum[num - 1] == X_or_O_2 || allNum[num - 1] == X_or_O_1)
                        {
                            Console.WriteLine($"{player2} you can only choose a num betwin 1-9: ");
                            int.TryParse(Console.ReadLine(), out num);
                        }
                    }
                    else
                    {
                        X_or_O_Net = X_or_O_1;
                        flag = true;
                        Console.WriteLine($"{player1} choose a num  betwin 1-9: ");
                        int.TryParse(Console.ReadLine(), out num);
                        while (num < 1 || num > 9 || allNum[num - 1] == X_or_O_2 || allNum[num - 1] == X_or_O_1)
                        {
                            Console.WriteLine($"{player1} you can only choose a num betwin 1-9: ");
                            int.TryParse(Console.ReadLine(), out num);
                        }
                    }

                }
                AfterLoop:
                whoIsTheWiner();
                allNum = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            }
        }
       static void mat()
        {
            Console.WriteLine("|-----------|----------|-----------|");
            Console.WriteLine($"|     {allNum[0]}     |    {allNum[1]}     |     {allNum[2]}     |");
            Console.WriteLine("|-----------|----------|-----------|");
            Console.WriteLine($"|     {allNum[3]}     |    {allNum[4]}     |     {allNum[5]}     |");
            Console.WriteLine("|-----------|----------|-----------|");
            Console.WriteLine($"|     {allNum[6]}     |    {allNum[7]}     |     {allNum[8]}     |");
            Console.WriteLine("|-----------|----------|-----------|");
        }
        static void choose_X_or_O()
        {
            while (X_or_O_1 != "X" && X_or_O_1 != "x" && X_or_O_1 != "o" && X_or_O_1 != "O")
            {
                Console.WriteLine($"{player1} choose if you want to bi X or O?");
                X_or_O_1 = Console.ReadLine();
            }
            if (X_or_O_1 == "x" || X_or_O_1 == "X")
            {
                X_or_O_2 = "O";
                Console.WriteLine($"{player1} you are: {X_or_O_1} ");
                Console.WriteLine($"{player2} you are: {X_or_O_2} ");
                flag = true;
                player1_is_X = true;

            }
            else
            {
                X_or_O_1 = "X";
                X_or_O_2 = "O";
                Console.WriteLine($"{player2} you are: {X_or_O_1} ");
                Console.WriteLine($"{player1} you are: {X_or_O_2} ");
                flag = false;
                player1_is_X = false;

            }
        }
        static void whoIsTheWiner()
        {
            if ((condition_1()) && player1_is_X)
            {
                Console.WriteLine($"The winer is: {player1}");
                count1++;
            }
            else if ((condition_1()) && player1_is_X == false)
            {
                Console.WriteLine($"The winer is: {player2}");
                count2++;
                
            }
            else if (condition_2() && player1_is_X)
            {
                Console.WriteLine($"The winer is: {player1}");
                count1++;
            }
            else if (condition_2() && player1_is_X == false)
            {
                Console.WriteLine($"The winer is: {player2}");
                count2++;
            }
            else if ((!condition_2() || !condition_1()))
            {
                Console.WriteLine("No one won");
            }
        }
       static bool condition_1()
        {
            if ((allNum[0] == X_or_O_1 && allNum[1] == X_or_O_1 && allNum[2] == X_or_O_1)
                               || (allNum[3] == X_or_O_1 && allNum[4] == X_or_O_1 && allNum[5] == X_or_O_1)
                               || (allNum[6] == X_or_O_1 && allNum[7] == X_or_O_1 && allNum[8] == X_or_O_1)
                               || (allNum[0] == X_or_O_1 && allNum[3] == X_or_O_1 && allNum[6] == X_or_O_1)
                               || (allNum[1] == X_or_O_1 && allNum[4] == X_or_O_1 && allNum[7] == X_or_O_1)
                               || (allNum[2] == X_or_O_1 && allNum[5] == X_or_O_1 && allNum[8] == X_or_O_1)
                               || (allNum[0] == X_or_O_1 && allNum[4] == X_or_O_1 && allNum[8] == X_or_O_1)
                               || (allNum[2] == X_or_O_1 && allNum[4] == X_or_O_1 && allNum[6] == X_or_O_1))
            {
                return true;
            }

            return false;
        }
        static bool condition_2()
        {
            if ((allNum[0] == X_or_O_2 && allNum[1] == X_or_O_2 && allNum[2] == X_or_O_2)
                                || (allNum[3] == X_or_O_2 && allNum[4] == X_or_O_2 && allNum[5] == X_or_O_2)
                                || (allNum[6] == X_or_O_2 && allNum[7] == X_or_O_2 && allNum[8] == X_or_O_2)
                                || (allNum[0] == X_or_O_2 && allNum[3] == X_or_O_2 && allNum[6] == X_or_O_2)
                                || (allNum[1] == X_or_O_2 && allNum[4] == X_or_O_2 && allNum[7] == X_or_O_2)
                                || (allNum[2] == X_or_O_2 && allNum[5] == X_or_O_2 && allNum[8] == X_or_O_2)
                                || (allNum[0] == X_or_O_2 && allNum[4] == X_or_O_2 && allNum[8] == X_or_O_2)
                                || (allNum[2] == X_or_O_2 && allNum[4] == X_or_O_2 && allNum[6] == X_or_O_2))
            {
                return true;
            }

            return false;
        }
    }
}