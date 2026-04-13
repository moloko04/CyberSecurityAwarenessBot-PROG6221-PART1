using System;
using System.Media;
using System.Threading;

namespace CybersecurityAwarenessBot
{
    public class CybersecurityBot
    {
        private User currentUser = new User();
        private SoundPlayer voicePlayer;   

        public CybersecurityBot()
        {
            try
            {
                voicePlayer = new SoundPlayer("greetings.wav");
            }
            catch
            {
                Console.WriteLine("Warning: greetings.wav file not found.");
            }
        }


        public void Start()
        {
            DisplayHeader();
            PlayVoiceGreeting();
            GreetUser();
            RunChatbot();
        }



        private void DisplayHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(@"
             ██████╗██╗   ██╗██████╗ ███████╗██████╗     ██████╗  ██████╗ ████████╗
    ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗    ██╔══██╗██╔═══██╗╚══██╔══╝
    ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝    ██████╔╝██║   ██║   ██║   
    ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗    ██╔══██╗██║   ██║   ██║   
    ╚██████╗   ██║   ██████╔╝███████╗██║  ██║    ██████╔╝╚██████╔╝   ██║   
     ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝    ╚═════╝  ╚═════╝    ╚═╝   
                                                                           
                               C Y B E R B O T
            ");

            Console.WriteLine(@"
          ┌───                                      ───┐
                     CYBERSECURITY AWARENESS BOT   
                       Protecting You OnlinE
          └───                                      ───┘
    ");

            Console.WriteLine("==================================================");
            Console.ResetColor();
            Console.WriteLine();
        }

        private void PlayVoiceGreeting()
        {
            if (voicePlayer != null)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Playing greeting voice message...");
                    Console.ResetColor();

                    voicePlayer.Play();
                    Thread.Sleep(4500);        
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Could not play voice: {ex.Message}");
                }
            }
        }

        private void GreetUser()
        {
            Thread.Sleep(800);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hello! Welcome to the Cybersecurity Awareness Bot.");
            Thread.Sleep(600);
            Console.WriteLine("I’m your friendly guide here to help you stay safe online.");
            Thread.Sleep(600);
            Console.WriteLine("With so many scams and dodgy links going around, it’s great that you’re here.");
            Thread.Sleep(700);
            Console.WriteLine("what would you like to know about today?\n");
            Console.ResetColor();

            Console.Write("What is your name? ");
            string nameInput = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(nameInput) || nameInput.Length < 2)
            {
                currentUser.Name = "Friend";
                Console.WriteLine("Name not provided properly. I'll call you Friend!");
            }
            else
            {
                currentUser.Name = nameInput;
                Console.WriteLine($"\nNice to meet you, {currentUser.Name}! Ready to learn how to stay safe online.");
            }

            Console.WriteLine("==================================================\n");
        }

        private void RunChatbot()
        {
            bool running = true;

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nWhat would you like to know about today? Choose an option:");
                Console.WriteLine("1. Phishing Scams");
                Console.WriteLine("2. Strong Passwords");
                Console.WriteLine("3. Suspicious Links");
                Console.WriteLine("4. Quick Quiz");
                Console.WriteLine("5. Exit");
                Console.ResetColor();

                Console.Write("\nEnter your choice (1-5): ");
                string input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I didn’t quite understand that. Please enter a number between 1 and 5.");
                    Console.ResetColor();
                    continue;
                }

                if (!int.TryParse(input, out int choice) || choice < 1 || choice > 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    Console.ResetColor();
                    continue;
                }

                Thread.Sleep(800);

                switch (choice)
                {
                    case 1:
                        ShowResponse("Phishing Scams", "Never click links in emails or SMS that create urgency. Always check the sender and hover over the link before clicking. Report suspicious messages to 0800 171 100.");
                        break;

                    case 2:
                        ShowResponse("Strong Passwords", "Use passwords with at least 12 characters, mixing upper and lower case, numbers and symbols. Enable two-factor authentication (2FA) wherever possible!");
                        break;

                    case 3:
                        ShowResponse("Suspicious Links", "If a link looks strange or promises something too good to be true, it’s probably a scam. Type the website address manually instead of clicking.");
                        break;

                    case 4:
                        SimpleQuiz();
                        break;

                    case 5:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nThank you, {currentUser.Name}! Stay safe online and remember: Think before you click!");
                        Console.ResetColor();
                        running = false;
                        break;
                }

                if (running)
                {
                    Thread.Sleep(600);
                    Console.WriteLine("\n" + new string('-', 60));
                }
            }
        }

