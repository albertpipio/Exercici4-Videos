using System;
using System.Collections.Generic;
using Ex4_CSharp.Lib.Models;

namespace Ex4_CSharp
{
    class Program
    {
        enum Player { play, pause, stop }

        static void Main(string[] args)
        {
            //llista d'usuaris
            List<User> UserList = new List<User>();

            //Variables
            User currentUser = null;

            //booleans
            bool MainLoop = true;
            bool UserLoop = true;
            bool TagLoop = true;

            //data init
            User defaultUser = new User("ap", "Albert", "Pipió", "123");
            UserList.Add(defaultUser);

            //Benvinguda al programa
            do
            {
                Console.WriteLine();
                Console.WriteLine("-------------------------");
                Console.WriteLine("BENVINGUT A L'EXERCICI 4!");
                Console.WriteLine("-------------------------");
                Console.WriteLine("Escriu 'login' per entrar, 'register' per crear un usuari o 'exit' per sortir del programa.");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "login":
                        UserLoop = true;
                        TagLoop = true;
                        Console.Write("Usuari: ");
                        var UsrInput = Console.ReadLine();
                        Console.Write("Contrasenya: ");
                        var UsrPassword = Console.ReadLine();

                        foreach (var user in UserList)
                        {
                            if (user.Username == UsrInput && user.Password == UsrPassword)
                            {
                                currentUser = user;
                                break;
                            }
                            else
                            {
                                currentUser = null;
                            }                            
                        }
                        if (currentUser == null)
                        {
                            Console.WriteLine("\nUsuari o contrasenya incorrectes. Siusplau, torna-ho a provar.");
                            break;
                        }

                        Console.WriteLine();
                        Console.WriteLine($"*** BENVINGUD@ AL MENÚ PRINCIPAL {currentUser.Name}! ***");

                        do
                        {
                            Console.WriteLine("- Si vols crear un nou vídeo, prem 'c'.");
                            Console.WriteLine("- Si vols veure una llista dels teus vídeos, prem 'l'.");
                            Console.WriteLine("- Si vols reproduir un vídeo, prem 'p'.");
                            Console.WriteLine("- Si vols veure la teva info, prem 'i'.");
                            Console.WriteLine("- Si vols sortir del programa, prem 'x'.");

                            var selection = true;

                            while (selection == true)
                            {
                                var option = Console.ReadKey().KeyChar;

                                if (option == 'c')
                                {
                                    //Bloc de creació de vídeos
                                    Console.WriteLine();
                                    Console.WriteLine("*** MENÚ DE VÍDEOS ***");
                             
                                    Console.Write("- Nom del nou vídeo: ");
                                    var Title = Console.ReadLine();
                                    Console.Write("- Url del vídeo: ");
                                    var Url = Console.ReadLine();

                                    Video newVideo = new Video(Title, Url);
                                
                                    Console.WriteLine("Escriu els tags que vulguis i 'exit' per sortir.");
                                
                                    do
                                    {
                                        var newTag = Console.ReadLine();
                                        if (newTag == "exit")
                                        {
                                            TagLoop = false;
                                        }
                                        else
                                        {
                                            newVideo.AddTag(newTag);
                                        }

                                    } while (TagLoop);

                                    currentUser.VideoList.Add(newVideo);
                                }
                                else if (option == 'l')
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("*** ELS TEUS VÍDEOS ***");
                                    Console.WriteLine();

                                    currentUser.ShowVideoList();
                                }
                                else if (option == 'p')
                                {
                                    playVideo();
                                }
                                else if (option == 'i')
                                {
                                    Console.WriteLine();
                                    Console.WriteLine(" *** LA TEVA INFO *** ");
                                    Console.WriteLine();

                                    //List<User> UserList = new List<User>();
                                    //User defaultUser = new User("albertpipio", "Albert", "Pipió", "123456");
                                    //UserList.Add(defaultUser);

                                    Console.WriteLine();
                                    Console.WriteLine(currentUser.getUserInfo());
                                }
                                else if (option == 'x')
                                {
                                    currentUser = null;
                                    UserLoop = false;
                                    exitMenu();
                                }
                                else
                                {
                                    Console.WriteLine("Siusplau, escriu una de les lletres");
                                }
                            }
                        } while (UserLoop);
                        break;
                    case "register":
                        var newUser = RegisterMenu();
                        UserList.Add(newUser); 
                        break;
                    case "exit":
                        MainLoop = false;
                        exitMenu();
                        break;
                    default:
                        Console.WriteLine("Siusplau, escriu 'login' per entrar, 'register' per crear un usuari o 'exit' per sortir del programa.");
                        break;
                }
            } while (MainLoop);
        }

        //Menú de registre
        public static User RegisterMenu()
        {
            Console.Write("Escriu el nom d'usuari: ");
            string registerUsername = Console.ReadLine();
            Console.Write("Escriu el teu nom: ");
            string registerName = Console.ReadLine();
            Console.Write("Escriu el teu cognom: ");
            string registerSurname = Console.ReadLine();
            Console.Write("Escriu la teva contrasenya: ");
            string registerPassword = Console.ReadLine();
            Console.Write("Torna a escriure la teva contrasenya: ");
            string registerPassword2 = Console.ReadLine();

            User newUser = new User(registerUsername, registerName, registerSurname, registerPassword);
            return newUser;
        }

        //Bloc de tornada al Menú principal
        private static void showMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine($"*** BENVINGUD@ AL MENÚ PRINCIPAL! ***");
            Console.WriteLine("- Si vols crear un nou vídeo, prem 'c'.");
            Console.WriteLine("- Si vols veure una llista dels teus vídeos, prem 'v'.");
            Console.WriteLine("- Si vols reproduir un vídeo, prem 'p'.");
            Console.WriteLine("- Si vols veure la teva info, prem 'i'.");
            Console.WriteLine("- Si vols sortir del programa, prem 'x'.");

            var selection = true;

            while (selection == true)
            {
                var option = Console.ReadKey().KeyChar;

                if (option == 'v')
                {
                    //ShowVideoList();
                }
                if (option == 'c')
                {
                    //createVideo();
                }
                // else if (option == 'e')
                // {
                //     editVideoTags();
                // }
                else if (option == 'p')
                {
                    playVideo();
                }
                else if (option == 'i')
                {
                    yourInfo();
                }
                else if (option == 'x')
                {
                    exitMenu();
                }
                else
                {
                    Console.WriteLine("Siusplau, escriu una de les lletres");
                }
            }
        }

        //Bloc per veure la llista de vídeos
        // public static void showVideoList()
        // {
        //     // Console.WriteLine();
        //     // Console.WriteLine("*** ELS TEUS VÍDEOS ***");
        //     // Console.WriteLine();

        //     // currentUser.showVideoList();

        // showMainMenu();
        // }

        //Bloc de reproducció
        public static void playVideo()
        {
            Console.WriteLine();
            Console.WriteLine("*** MENÚ DE REPRODUCCIÓ DE VÍDEOS ***");
            Console.Write("- Escriu el nom del vídeo que vulguis reproduir: ");
            string chosenVideo = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine($"Què vols fer amb <{chosenVideo}>? Prem la lletra corresponent:");
            Console.WriteLine("- Reproduir (r)");
            Console.WriteLine("- Pausar (p)");
            Console.WriteLine("- Parar (s)");
            Console.WriteLine("- Tornar al menú principal (x)");
            Console.WriteLine();

            var selection = true;

            while (selection == true)
            {
                var option = Console.ReadKey().KeyChar;

                if (option == 'r')
                {
                    Player myVid = Player.play;
                    Console.WriteLine($"\nEl teu vídeo està en {myVid}...");
                }
                else if (option == 'p')
                {
                    Player myVid = Player.pause;
                    Console.WriteLine($"\nEl teu vídeo està en {myVid}...");
                }
                else if (option == 's')
                {
                    Player myVid = Player.stop;
                    Console.WriteLine($"\nEl teu vídeo està en {myVid}...");
                }
                else if (option == 'x')
                {
                    showMainMenu();
                }
                else
                {
                    Console.WriteLine("\nEscriu 'x' per tornar al menú principal.");
                }
            }
            showMainMenu();
        }

        //Bloc amb la informació personal
        public static void yourInfo()
        {
            // Console.WriteLine();
            // Console.WriteLine(" *** LA TEVA INFO *** ");
            // Console.WriteLine();

            // //List<User> UserList = new List<User>();
            // //User defaultUser = new User("albertpipio", "Albert", "Pipió", "123456");
            // //UserList.Add(defaultUser);

            // Console.WriteLine();
            // Console.WriteLine(currentUser.getUserInfo());

            //showMainMenu();
        }

        //Bloc de sortida del programa
        private static void exitMenu()
        {
            Console.WriteLine();
            Console.Write("Estàs segur que vols sortir? (y/n) ");

            var selection = true;
            while (selection == true)
            {
                var option = Console.ReadKey().KeyChar;
                if (option == 'y')
                {
                    Console.WriteLine("\n\nFins aviat! XDXD\n\n");
                    System.Environment.Exit(0);
                }
                else if (option == 'n')
                {
                    showMainMenu();
                }
                else
                {
                    Console.WriteLine("\nEscriu 'y' per sortir o 'n' per tornar al menú principal.");
                }
            }
        }
    }
}
           