using System;
using System.Collections.Immutable;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Schema;

namespace Projektas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,string> users = new Dictionary<int, string>();
            string currentUser = "";
            List<int> scores = new List<int>();
            LogIn(users, currentUser, scores);
            
            
        }

        public static void LogIn(Dictionary<int, string> users, string currentUser, List<int> scores)
        {
            Console.WriteLine("Sveiki atvyke i protmusi");
            Console.WriteLine("Prisijunkite ivesdami varda ir pavarde");
            string firstName = "";
            string lastName = "";

            while (string.IsNullOrEmpty(firstName))
            {
                Console.WriteLine("Vardas:");
                firstName = Console.ReadLine();
                if (string.IsNullOrEmpty(firstName))
                {
                    Console.WriteLine("Vardas negali buti tuscias, bandykite is naujo");
                }
            }
            while (string.IsNullOrEmpty(lastName))
            {
                Console.WriteLine("Pavarde:");
                lastName = Console.ReadLine();
                if (string.IsNullOrEmpty(lastName))
                {
                    Console.WriteLine("Pavarde negali buti tuscia, bandykite is naujo");
                }
            }


            string fullName = $"{firstName} {lastName}";
            Console.WriteLine($"Sveiki, {fullName}");
            Console.ReadKey();
            int userId = users.Count + 1;

            if (users.ContainsValue(fullName))
            {
                Console.WriteLine("Sekmingai prisijungete su egzistuojanciu vartotoju");
            }
            else 
            {           
              users[userId] = fullName;
                scores.Add(0);
              Console.WriteLine("Sekmingai susikurete paskyra ir prisijungete");     
            }
            currentUser = fullName;       
            Menu(users,currentUser, scores);
        }

        public static void Menu(Dictionary<int, string> users, string currentUser, List<int>scores)
        {
            Console.Clear();
            Console.WriteLine($"Vartotojas: {currentUser} ");
            Console.WriteLine("Meniu");
            Console.WriteLine("Pasirinkite veiksma");
            Console.WriteLine("1. Atsijungti");
            Console.WriteLine("2. Zaidimo taisykles");
            Console.WriteLine("3. Zaidimo resultatai ir dalyviai");
            Console.WriteLine("4. Dalyvavimas");
            Console.WriteLine("5. Iseiti is zaidimo");
            
            while (true)
            {
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Logout(users,currentUser, scores);
                        break;
                    case "2":
                        Rules(users, currentUser, scores);
                        break;
                    case "3":
                        ResultsAndParticipants(users, currentUser, scores);
                        break;
                    case "4":
                        StartGame(users, currentUser, scores);
                        break;
                    case "5":
                        CloseGame();
                        break;
                    default:
                        Console.WriteLine("Bloga ivestis pasirinkite dar karta00000");
                        break;

                }

            }
        }

        public static void Logout(Dictionary<int, string> users, string currentUser,List<int> scores)
        {
            Console.Clear();
            Console.WriteLine($"Atsijungta nuo {currentUser}");
            currentUser = "";
            Console.WriteLine("Noredami vel prisijungti iveskite varda ir pavarde");
            string firstName = "";
            string lastName = "";

            while (string.IsNullOrEmpty(firstName))
            {
                Console.WriteLine("Vardas:");
                firstName = Console.ReadLine();
                if (string.IsNullOrEmpty(firstName))
                {
                    Console.WriteLine("Vardas negali buti tuscias, bandykite is naujo");
                }
            }
            while (string.IsNullOrEmpty(lastName))
            {
                Console.WriteLine("Pavarde:");
                lastName = Console.ReadLine();
                if (string.IsNullOrEmpty(lastName))
                {
                    Console.WriteLine("Pavarde negali buti tuscia, bandykite is naujo");
                }
            }


            string fullName = $"{firstName} {lastName}";

            int userId = users.Count + 1;

            if (users.ContainsValue(fullName))
            {
                Console.WriteLine("Sekmingai prisijungete su egzistuojanciu vartotoju");
            }
            else
            {                
                users[userId] = fullName;
                scores.Add(0);
                Console.WriteLine("Sekmingai susikurete paskyra ir prisijungete");
                
            }
            currentUser = fullName;
            Console.WriteLine($"Prisijungta kaip {currentUser}");
            Console.ReadKey();
            Menu(users,currentUser, scores);
        }

        public static void Rules(Dictionary<int, string> users, string currentUser,List<int> scores)
        {
            Console.Clear();
            Console.WriteLine($"Vartotojas: {currentUser} ");
            Console.WriteLine("Sveikiname prisijungus prie X protmūšio programos.");
            Console.WriteLine("Zaidimui prasidejus turėsite pasirinkti iš 4 galimų variantų, kuris yra jūsų klausimui teisingas atsakymas");
            Console.WriteLine("Noredami grizti i meniu spauskite q");                      
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower().Trim() == "q")
                {
                    Menu(users, currentUser, scores);

                }
                else
                {
                    Console.WriteLine("Bloga ivestis. Spauskite q noredami grizti i meniu");
                }
            }
        }

        public static void ResultsAndParticipants(Dictionary<int, string> users, string currentUser,List<int> scores)
        {
            Console.Clear ();
            Console.WriteLine($"Vartotojas: {currentUser} ");
            Console.WriteLine("1.Dalyviai");
            Console.WriteLine("2.Resultatai");
            Console.WriteLine("Pasirinkite veiksma");
            while (true)
            {
                string input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "1":
                        Console.WriteLine($"Vartotojas: {currentUser} ");
                        foreach (var user in users)
                            Console.WriteLine($"Dalyvis: {user.Value}");
                        break;
                    case "2":
                        Console.WriteLine($"Vartotojas: {currentUser} ");
                        Console.WriteLine("Zaidimo resultatai");
                        var userList = users.Values.ToList();
                        var scoreList = new List<int>(scores);
                        var combinedList = new List<(string user, int score)>();

                        for (int i = 0; i < userList.Count; i++)
                        {
                            combinedList.Add((userList[i], scoreList[i]));
                        }

                        combinedList.Sort((x, y) => y.score.CompareTo(x.score));
                        for (int i = 0; i < combinedList.Count; i++)
                        {
                            string stars;
                            if (i == 0)
                            {
                                stars = " ***";
                            }
                            else if (i == 1)
                            {
                                stars = " **";
                            }
                            else if (i == 2)
                            {
                                stars = " *";
                            }
                            else
                            {
                                stars = "";
                            }
                            Console.WriteLine($"{combinedList[i].user} - {combinedList[i].score} taskai{stars}");
                        }
                        
                        break;
                    default:
                        Console.WriteLine("Bloga ivestis pasirinkite dar karta");
                        break;

                }
                Console.WriteLine("Noredami grizti i meniu spauskite q");
                if (input.ToLower().Trim() == "q")
                {
                    Menu(users, currentUser, scores);

                }
            }             
        }
        
        public static void StartGame(Dictionary<int, string> users, string currentUser,List<int> scores)
        {
                Console.Clear();
            string[] questions = 
                { 
                "Kas yra kintamasis programavime?",
                "Kokia funkcija naudojama C# kalboje, kad atspausdintumėte tekstą į konsolę?",
                "Kas yra „for“ ciklas?",
                "Kokia yra pagrindinė C# kalbos ypatybė, kuri skiria ją nuo kitų kalbų?",
                "Koks duomenų tipas naudojamas, kad laikytų „true“ arba „false“ reikšmes C# kalboje?"
                };

            string[] answers =
            {
                "1.Duomenų tipas, kuris saugo reikšmes \n2.Funkcija, kuri atlieka skaičiavimus \n3.Programos struktūra \n4.Atminties vieta, kurioje saugoma informacija",// teisingas 1
                "1.print() \n2.echo() \n3.Console.WriteLine(); \n4.output()",// teisingas 3
                "1.Ciklas, kuris vykdomas tik kartą \n2.Ciklas, kuris kartoja nurodytas komandas tol, kol sąlyga yra tiesa \n3.Ciklas, kuris vykdo komandą, kol vartotojas įveda duomenis \n4.Ciklas, kuris niekada nesibaigia", //teisingas 2
                "1.Ji yra skriptų kalba \n2.Ji yra orientuota į objektus \n3.Ji neturi funkcijų \n4.Ji naudojama tik žaidimų kūrimui",//teisingas 2
                "1.int \n2.string \n3.char \n4.bool" //teisignas 4
            };
            int[] correctAnswers = { 0, 2, 1, 1, 3 };
            int score = 0;
            string[]results = new string[questions.Length];
            for (int i = 0; i < questions.Length; i++)
            {
                Console.Clear();
                Console.WriteLine($"Vartotojas: {currentUser} ");
                Console.WriteLine("Klausimas " + (i + 1) + "/5");
                Console.WriteLine(questions[i]);
                Console.WriteLine(answers[i]);
                Console.WriteLine("Iveskite atsakyma:(1 ,2 ,3 ,4)");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int inputIndex) && inputIndex - 1  == correctAnswers[i])
                {
                    score++;
                    results[i] = "Atsakyta teisingai";
                    Console.WriteLine($"Teisingai!, \nJusu taskai:{score}");
                    Console.ReadKey();
                }

                else
                {
                    results[i] = "Atsakyta neteisingai";
                    Console.WriteLine($"Neteisingai, Teisingas atsakymas {correctAnswers[i] + 1} \nJusu taskai:{score}");
                    Console.ReadKey();
                }
             }
            int userId = users.Count;
            if (userId - 1 < scores.Count)
            {
                scores[userId - 1] = score;
            }
            else
            {
                scores.Add(score);
            }

            Console.Clear();
            Console.WriteLine($"Vartotojas: {currentUser} ");
            Console.WriteLine("Zaidimo pabaiga! Jusu rezultatai:");
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"Klausimas {i + 1}: {questions[i]}");
                Console.WriteLine(results[i]);              
            }

            int rank = 1;
            foreach (int s in scores)
            {
                if (s > score)
                {
                    rank++;
                }
            }

            Console.WriteLine($"\nGalutiniai taškai: {score}");
            Console.WriteLine($"Jusu pozicija tarp zaideju: {rank} vieta is {scores.Count}");



            Console.WriteLine("Noredami grizti i meniu spauskite q");

            while (true)
            {
                string input1 = Console.ReadLine();
                if (input1.ToLower().Trim() == "q")
                {
                    Menu(users, currentUser, scores);

                }
                else
                {
                    Console.WriteLine("Bloga ivestis. Spauskite q noredami grizti i meniu");


                }
            }  
        }
        public static void CloseGame()
        {
            System.Environment.Exit(0);
        }

    }
}
