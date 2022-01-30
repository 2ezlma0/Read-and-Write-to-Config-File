using System;
using System.IO;

namespace Read_and_write_to_a_config_file
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            bool firsttime = true;
            string configFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ConfigTest");
            string configFile = Path.Combine(configFolder, "config.cfg");
            string noYN = "Please enter either 'Y' or 'N' (case sensitive)";
            bool check = File.Exists(configFile);

            if (!check)
            {
                Console.WriteLine("Creating first time use file, will crash afterwards. Press enter to continue");
                Console.ReadLine();
                Directory.CreateDirectory(configFolder);
                File.Create(configFile);
            }

            string configContents = File.ReadAllText(configFile);
            string createContents = "";
            bool updateConfig = false;

            while (loop)
            {
                if (configContents == "")
                {
                    bool createBool = false;
                    if (firsttime)
                    {
                        Console.WriteLine("No config file found, want to create a config file? Y/N");
                        while (!createBool)
                        {
                            string a = Console.ReadLine();
                            if (a == "Y")
                            {
                                File.WriteAllText(configFile, createContents);
                                Console.WriteLine("Created a config file at " + configFile);
                                Console.WriteLine("Press enter to continue");
                                Console.ReadLine();
                                createBool = true;
                                updateConfig = true;

                            }
                            else if (a == "N")
                            {
                                Console.WriteLine("Closing application");
                                createBool = true;
                            }
                            else
                            {
                                Console.WriteLine(noYN);
                            }
                        }
                    }
                    else
                    {
                        updateConfig = true;
                    }
                    if (updateConfig)
                    {
                        Console.WriteLine("Now we will update your config contents");
                        bool correctLoop = true;
                        while (correctLoop)
                        {
                            Console.WriteLine("Please enter your name:");
                            string name = Console.ReadLine();
                            createContents += "NAME: " + name + "\n";
                            Console.WriteLine("Now enter your age");
                            string age = Console.ReadLine();
                            createContents += "AGE: " + age + "\n";
                            Console.WriteLine("Finally enter your favourite game");
                            string game = Console.ReadLine();
                            createContents += "GAME: " + game + "\n";
                            Console.WriteLine("Are these details correct? Y/N");
                            Console.WriteLine(createContents);
                            string correct = Console.ReadLine();
                            bool ynLoop = true;
                            while (ynLoop)
                            {
                                if (correct == "Y")
                                {
                                    correctLoop = false;
                                    ynLoop = false;
                                }
                                else if (correct != "N")
                                {
                                    Console.WriteLine(noYN);
                                    ynLoop = true;
                                    correct = Console.ReadLine();
                                }
                            }
                        }
                        Console.WriteLine("Updating config file, press enter to continue");
                        Console.ReadLine();
                        File.WriteAllText(configFile, createContents);
                        Console.WriteLine("Config file updated, press enter to exit");
                        Console.ReadLine();
                        loop = false;
                    }
                }
                else
                {
                    Console.WriteLine("Your current config settings are:\n" + configContents);
                    Console.WriteLine("\nWould you like to update these settings? Y/N");
                    string b = Console.ReadLine();
                    bool z = true;
                    while (z)
                    {
                        if (b == "Y")
                        {
                            configContents = "";
                            File.Delete(configFile);
                            z = false;
                            firsttime = false;
                        }
                        else if (b == "N")
                        {
                            Console.WriteLine("Program closing, press enter to continue");
                            Console.ReadLine();
                            loop = false;
                            z = false;
                        }
                        else
                        {
                            Console.WriteLine(noYN);
                            b = Console.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
