using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalisburyUniversity
{
    internal class Program
    {
        public class Question
        {
            public string Text { get; set; }
            public string[] Options { get; set; }
            public int CorrectOption { get; set; }

            public Question(string text, string[] options, int correctOption)
            {
                Text = text;
                Options = options;
                CorrectOption = correctOption;
            }

            public bool Ask()
            {
                Console.WriteLine(Text);
                for (int i = 0; i < Options.Length; i++)
                    Console.WriteLine($"{i + 1}. {Options[i]}");

                Console.Write("Your answer (1-4): ");
                if (int.TryParse(Console.ReadLine(), out int answer))
                    return answer == CorrectOption;
                return false;

            }
        }
        static void Main(string[] args)
        {
            List<Question> questions = new List<Question> {
                new Question("Aptitude: What comes next in 2, 4, 6, ?", new[] {"7", "8", "9", "10"}, 2),
                new Question("English: Synonym of 'Happy'?", new[]{"Sad", "Joyful", "Angry", "Tired"}, 2),
                new Question("General Knowledge: Capital of France?", new[]{"Berlin", "Madrid", "Paris", "Rome"}, 3),
                new Question("Mathematics: What is 5 + 7?", new[]{"10", "11", "12", "13"}, 3),
                new Question("General Knowledge: Largest Ocean?", new[]{"Atlantic", "Indian", "Arctic", "Pacific"}, 4)
            };

            string choice;
            do
            {
                Console.Write("Enter your name: ");
                string name = Console.ReadLine();
                Console.Write("Enter your ID: ");
                string id = Console.ReadLine();

                int score = 0;
                foreach (var q in questions)
                {
                    if (q.Ask()) score += 5;
                }

                int bonus = score switch
                {
                    10 => 0,
                    20 => 2,
                    30 => 5,
                    40 => 10,
                    _ => 0
                };

                int finalScore = score + bonus;

                Console.WriteLine($"\nBonus Points: {bonus}");
                Console.WriteLine($"Total Score: {finalScore}");

                string iqMessage = finalScore switch
                {
                    0 => "You need to reappear for the test. ",
                    10 => "Your IQ level is below average.",
                    22 => "Your IQ level is average.",
                    35 => "You are intelligent.",
                    40 => "You are a genius!",
                    _ => "IQ level not classified."
                };

                Console.WriteLine(iqMessage);

                Console.Write("\nDo you want to continue? (yes/no): ");
                choice = Console.ReadLine()?.ToLower();
            } while (choice == "yes"); 
        }
    }
}
