using System;
namespace EncryptionProject
{
    public class Program
    {
        public Program()
        {
        }

        public static void Main(string[] args)
        {
            Program obj = new Program();

            obj.Menu();
        }

        public void Menu()      //function to control the menu part and act as the centre of control and program flow
        {
            OffsetCipher cipher = new OffsetCipher();
            //create an object of the cipher which will be used throughout the program for all encryption and decryption purposes

            EncryptionParametersConsole encParams = new EncryptionParametersConsole();

            bool toContinue = true;     //to store if the user wishes to continue the program or not
            string choice = "";
            //initializing

            do     //to loop through the menu multiple times as per the user
            {
                Console.WriteLine("**********************************************");      //these are to distinctify separate menu blocks and for decoration
                Console.WriteLine();

                Console.WriteLine("Choose from the following options:");
                Console.WriteLine();

                Console.WriteLine("1: Encrypt message");
                Console.WriteLine("2: Encrypt message further");
                Console.WriteLine("3: Decrypt message");
                Console.WriteLine("4: Exit program");
                Console.WriteLine();

                choice = Console.ReadLine();

                //display the options and allow the user to select from them

                Console.WriteLine();

                switch (choice)     //selecting from the options
                {
                    case "1":
                        cipher.Encrypt(encParams);       //this will invoke the Encrypt function
                        break;
                    case "2":
                        cipher.EncryptFurther(encParams);        //this will invoke the EncryptFurther function
                        break;
                    case "3":

                        string text = cipher.Decrypt(encParams);        //this will invoke the Decrypt function

                        Console.WriteLine();
                        Console.WriteLine("Decrypted Text:");
                        Console.WriteLine();
                        Console.WriteLine(text);
                        Console.WriteLine();
                        //output the decrypted text

                        break;
                    case "4":
                        toContinue = false;     //this will flag thayt the user wants to exit the program
                        break;
                    default:        //if no valid option is chosen the program will simply loop back to the menu
                        break;
                }

                Console.WriteLine();

            } while (toContinue);       //check if the usr wishes to continue or exit the program

            Console.WriteLine("**********************************************");
        }
    }
}
