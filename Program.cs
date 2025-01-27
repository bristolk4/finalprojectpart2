using System;
class Program
{
    static void Main(string[] args)
    {
        int score = 0;
        bool gameOn = true;
        ConsoleKey? lastKey = null;

        Console.WriteLine("Get ready to type your fingers off with the typing game.");
        Console.WriteLine("Press the spacebar for 2 points, the right arrow key for 5 points, the letter P for 10 points, and the letter O for 15 points.");
        Console.WriteLine("Be careful though because P and O are inaccessible until you reach 50 points :O!!");
        Console.WriteLine("If you press the letter J or the left arrow key you will lose 3 points so WATCH IT");
        Console.WriteLine("To exit, press the letter X.");
        Console.WriteLine("If you get 200 points you win :-)");

        while (gameOn)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if(keyInfo.Key == ConsoleKey.Spacebar)
            {
                score = score + 2;
                Console.WriteLine($"Score: {score}");
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                score = score + 5;
                Console.WriteLine($"Score: {score}");
            }
            else if (keyInfo.Key == ConsoleKey.P)
            {
                if (score < 50 && lastKey == ConsoleKey.P)
                {
                    Console.WriteLine("Stop");
                }
                else if (score >= 50)
                {
                    score = score + 10;
                    Console.WriteLine($"Score: {score}");
                }
                else
                {
                    Console.WriteLine($"I just said you need 50 points to use {keyInfo.KeyChar}");
                }
            }
            else if (keyInfo.Key == ConsoleKey.O)
            {
                if (score < 50 && lastKey == ConsoleKey.O)
                {
                    Console.WriteLine("Stop");
                }
                else if (score >= 50)
                {
                    score = score + 15;
                    Console.WriteLine($"Score: {score}");
                }
                else
                {
                    Console.WriteLine($"I just said you need 50 points to use {keyInfo.KeyChar}");
                }
            }
            else if (keyInfo.Key == ConsoleKey.J)
            {
                score = score - 3;
                if (score < 0) score = 0;
                Console.WriteLine($"YOU LOSE 3 POINTS (Score: {score})");
            }
            else if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                score = score - 3;
                if (score < 0) score = 0;
                Console.WriteLine($"YOU LOSE 3 POINTS (Score: {score})");
            }
            else if (keyInfo.Key == ConsoleKey.X)
            {
                gameOn = false;
                Console.WriteLine("Thank you for playing the typing game NOW GET OUTTA HEEYUH");
                Console.WriteLine($"Final Score: {score}");
            }
            else 
            {
                Console.WriteLine($"Did I say you could use '{keyInfo.KeyChar}'?? Try again pal");
            }


            if (score >= 200)
            {
                Console.WriteLine("You won :O good bye");
                gameOn = false;
            }

            lastKey = keyInfo.Key;
        }
    }
}