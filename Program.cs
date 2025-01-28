class Program
{
    static void Main()
    // static: Main method (kind of like a function) belongs to Program class, not an instance of it
    // void: Main doesn't return a value it just runs
    // Main: name of the method that's the starting point of the app
    {
        int score = 0;
        // Initial score set to 0
        bool gameOn = true;
        // Initial state of game loop set to true, stops game if turned to false
        ConsoleKey? lastKey = null;
        // Tracks the last key user typed. The ? makes ConsoleKey a nullable type which means it can either take the value of a key or have no value. It is ititially null because the user hasn't typed anything when the game starts

        Console.WriteLine("Get ready to type your fingers off with the typing game.");
        Console.WriteLine("Press the spacebar for 2 points, the right arrow key for 5 points, the letter P for 10 points, and the letter O for 15 points.");
        Console.WriteLine("Be careful though because P and O are inaccessible until you reach 50 points :O!!");
        Console.WriteLine("If you press the letter J or the left arrow key you will lose 3 points so WATCH IT");
        Console.WriteLine("To exit, press the letter X.");
        Console.WriteLine("If you get 200 points you win :-)");

        while (gameOn)
        // All of this is only if the gameOn loop is true
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            // Saves the key the user types in variable keyInfo. Console.ReadKey reads the key and (true) means it is not displayed

            if(keyInfo.Key == ConsoleKey.Spacebar)
            // If the user presses the spacebar, add 2 points and display score
            {
                score = score + 2;
                Console.WriteLine($"Score: {score}");
                // $tring interpolation
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            // If user presses right arrow, add 5 and display score
            {
                score = score + 5;
                Console.WriteLine($"Score: {score}");
            }
            else if (keyInfo.Key == ConsoleKey.P)
            {
                if (score < 50 && lastKey == ConsoleKey.P)
                // If the score is under 50 and the user presses P 2+ times, the console will say stop >:(
                {
                    Console.WriteLine("Stop");
                }
                else if (score >= 50)
                // If the score is >= 50 it was increase by 10 and display
                {
                    score = score + 10;
                    Console.WriteLine($"Score: {score}");
                }
                else
                // If user presses P once this will display
                {
                    Console.WriteLine($"I just said you need 50 points to use {keyInfo.KeyChar}");
                    // keyInfo.KeyChar displays the key that the user just typed
                }
            }
            else if (keyInfo.Key == ConsoleKey.O)
            // Same thing as P but it addss 15 points if >= 50
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
                    // keyInfo.KeyChar saves the key the user just typed and in this case displays it
                }
            }
            else if (keyInfo.Key == ConsoleKey.J)
            // If user types J, subtract 3 from score. If this makes the score go negative it will stay at 0
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
            // If user types X gameOn loop is turned too false and it stops. Also displays silly little good bye message and final score
            {
                gameOn = false;
                Console.WriteLine("Thank you for playing the typing game NOW GET OUTTA HEEYUH");
                Console.WriteLine($"Final Score: {score}");
            }
            else 
            // If user types an unspecified key, display another silly little message. keyInfo used again to display key that user just typed
            {
                Console.WriteLine($"Did I say you could use '{keyInfo.KeyChar}'?? Try again pal");
            }


            if (score >= 200)
            // When user reaches 200 points, gomeOn loop turns to false and stops. Display good bye message
            {
                Console.WriteLine("You won :O good bye");
                gameOn = false;
            }

            lastKey = keyInfo.Key;
            // Update the lastKey variable to save the key the user just typed
        }
    }
}