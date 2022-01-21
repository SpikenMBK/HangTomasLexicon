using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HangTomasLexicon
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string[] wordsList = { "fotboll", "buss", "jordglob", "förkyld" };
            string wordToGuess = wordsList[rnd.Next(0, wordsList.Length)];
            char[] showToPlayer = wordToGuess.ToCharArray();   // visa _ _ b _ typ rätt gissade bokstäver
            char[] wordToGuessArray = wordToGuess.ToCharArray();
            StringBuilder wrongLetter = new StringBuilder(10);   // visar lista med fel gissade bokstäver

            foreach (char ch in wordToGuessArray)            // skriva ut ordet som ska gissas, fär skoj skull
            {
                Console.Write(ch);

            }
            Console.WriteLine();

            for (int x = 0; x < showToPlayer.Length; x++) 
            {
                showToPlayer[x] = '_';
            }
            Console.WriteLine(showToPlayer);
           
            int life = 10;
            bool won = false;
            string guess;
            int z = 0;
            while (!won && life > 0)
            {
                Console.WriteLine("Gissa ordet eller en bokstav och tryck enter");
                guess = Console.ReadLine();
                char[] guessArray = guess.ToCharArray();
               
                if (guessArray.Length == 1)
                {
                    
                    for (int i = 0; i < wordToGuessArray.Length; i++)
                    {
                        for (int y = 0; y < guessArray.Length; y++)
                        {
                            if (guessArray[y] == wordToGuessArray[i])
                            {
                                showToPlayer[i] = guessArray[y];
                                z++;
                            }
                         
                        }
                       
                    }
                    if (z == wordToGuessArray.Length)
                    {
                        won = true;
                        

                    }

                    if (z == 0)
                    {
                        wrongLetter.Append(guessArray[0]);
                        Console.WriteLine("Fel bokstav " + guessArray[0]);
                        Console.WriteLine("######################");
                        Console.WriteLine("Lista på fel bokstäver du gissat: " + wrongLetter);
                        life -= 1;
                        
                    }
                }

                if (guess == wordToGuess)
                {
                    Console.WriteLine(" du gissade rätt or som va " + wordToGuess);
                    won = true;
                    
                }
                else if (guessArray.Length != 1)
                {
                    Console.WriteLine("Du gissade fel ord");
                    life -= 1;
                    
                }


                foreach (char ch in showToPlayer)
                {
                    Console.Write(ch);

                }
                Console.WriteLine();
                Console.WriteLine("Antal liv kvar " + life);
                
            }

            if (won)
                Console.WriteLine("du klarade det, rätt ord va " + wordToGuess);
            else
            
                Console.WriteLine("Du klarade det inte uta förlorade...... ordet som skulle gissas va " + wordToGuess);
                Console.WriteLine("tryck enter för att avsluta");
                Console.ReadLine();            

        }
    }
}
