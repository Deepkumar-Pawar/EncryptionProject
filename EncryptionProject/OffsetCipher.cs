using System;
namespace EncryptionProject
{
    public class OffsetCipher : ICipher
    {
        public OffsetCipher()
        {

        }

        public void Encrypt(IEncryptionParameters encParams)
        {
            Console.WriteLine("Enter file location and name for text to be encrypted:");

            string fileName = encParams.GetDecryptedFileName();       //to take in and store input for file name

            string text = System.IO.File.ReadAllText(fileName);
            //load the text contents to be encrypted

            string key = GenerateKey();
            //generate an 8 character key

            Console.WriteLine();
            Console.WriteLine("Key:");

            Console.WriteLine();
            Console.WriteLine(key);

            int offsetFactor = CalculateOffsetFactor(key);
            //use the key generated earlier to get an offset factor

            string cipherText = "";
            int charNum = 0;        //to store the ascii values of each character
            char charVal = ' ';     //to store each of the characters themselves constituting the actual string of ciphered text
            //initialize values to be used

            for (int i = 0; i < text.Length; i++)       //looping through each character in the text to be encrypted
            {
                charNum = (int)text[i];
                //store the ASCII value of the current character

                if (charNum != 32)      //check if it is a space character, which is to be ignored while encrypting
                {
                    charNum += offsetFactor;
                    //add offset factor

                    if (charNum > 126)
                    {
                        charNum -= 94;
                    }       //making sure the ASCII code does not go out of the given bounds for english characters
                }

                charVal = (char)charNum;
                //convert the offset ASCII value to a character

                cipherText += charVal;
                //append this character to a string containing the encypted text
            }

            Console.WriteLine();
            Console.WriteLine("Enter a file name and location for a new text file to store encrypted text:");

            string newFileName = encParams.GetEncryptedFileName();

            System.IO.File.WriteAllText(newFileName, cipherText);
            //write the encrypted text to the given file location

            Console.WriteLine();
            Console.WriteLine("File encrypted and stored.");
        }

        public string Decrypt(IEncryptionParameters encParams)
        {
            Console.WriteLine("Enter file location and name of text file containing encrypted text:");

            string cipherTextFileName = encParams.GetEncryptedFileName();      //to take in and store input for file name

            string cipherText = System.IO.File.ReadAllText(cipherTextFileName);
            //Load the text contents to be decrypted

            Console.WriteLine();
            Console.WriteLine("Enter key for decryption:");

            string key = encParams.GetEncryptionKey();

            int offsetFactor = CalculateOffsetFactor(key);
            //enter the key as 8 character string via user input and then calculate the offset value using it

            string text = "";
            int charNum = 0;        //to store the ascii values of each character
            char charVal = ' ';     //to store each of the characters themselves constituting the actual string of deciphered text
            //initialize values

            for (int i = 0; i < cipherText.Length; i++)     //looping through each character in the text to be encrypted
            {
                charNum = (int)cipherText[i];
                //store the ASCII value of the current character

                if (charNum != 32)      //check if it is a space character, which is to be ignored while encrypting
                {
                    charNum -= offsetFactor;
                    //minus offset factor

                    if (charNum < 33)
                    {
                        charNum += 94;
                    }       //making sure the ASCII code does not go out of the given bounds for english characters
                }

                charVal = (char)charNum;
                //convert the offset ASCII value to a character

                text += charVal;
                //append this character to a string containing the encrypted text
            }

            return text;
        }

        public void EncryptFurther(IEncryptionParameters encParams)
        {
            Console.WriteLine("Enter file location and name for text to be encrypted:");

            string fileName = encParams.GetDecryptedFileName();      //to take in and store input for file name

            string text = System.IO.File.ReadAllText(fileName);
            //Load the text contents to be encrypted

            string key = GenerateKey();
            //generate an 8 character key

            Console.WriteLine();
            Console.WriteLine("Key:");

            Console.WriteLine();
            Console.WriteLine(key);

            int offsetFactor = CalculateOffsetFactor(key);
            //use the key generated earlier to get an offset factor

            string cipherText = "";
            int charNum = 0;        //to store the ascii values of each character
            char charVal = ' ';     //to store each of the characters themselves constituting the actual string of ciphered text
            //initialize values to be used

            for (int i = 0; i < text.Length; i++)       //looping through each character in the text to be encrypted
            {
                charNum = (int)text[i];
                //store the ASCII value of the current character

                if (charNum != 32)      //check if it is a space character, which is to be ignored while encrypting
                {
                    charNum += offsetFactor;
                    //add offset factor

                    if (charNum > 126)
                    {
                        charNum -= 94;
                    }       //making sure the ASCII code does not go out of the given bounds for english characters

                    charVal = (char)charNum;
                    //convert the offset ASCII value to a character

                    if (((cipherText.Length - 5) % 6 == 0) && (cipherText.Length > 0))      //check if the current character is the first character after a group of 5 characters
                    {
                        cipherText += " ";
                        //add a space to divide the characters into groups of 5
                    }

                    cipherText += charVal;
                    //here, since the appendation occurs in the same block that ignores the spaces, none of the original spaces are there in the encrypted text
                    //the only spaces are the ones that divide it into groups of 5 characters
                }
            }

            Console.WriteLine();
            Console.WriteLine("Enter a file name and location for a new text file to store encrypted text:");

            string newFileName = encParams.GetEncryptedFileName();

            System.IO.File.WriteAllText(newFileName, cipherText);
            //write the encrypted text to the given file location

            Console.WriteLine();
            Console.WriteLine("File encrypted and stored.");
        }

        private string GenerateKey()        //function to randomly generate a key for encryption
        {
            string key = "";
            int num = 0;
            char numChar = ' ';
            //initialize variables

            for (int i = 0; i < 8; i++)     //looping 8 times because the length of the key is 8 characters
            {
                num = GetRandom(33, 126);       //get a random value between 33 and 126
                numChar = (char)num;        //store the character conversion of the int as an ASCII code

                key += numChar;
                //append the character to the key
            }

            return key;
        }

        private int CalculateOffsetFactor(string key)       //function to calculate the offset value for encryption based on a key
        {
            double offsetFactor = 0;
            //initializing

            for (int i = 0; i < 8; i++)     //looping through each character in the key
            {
                offsetFactor += (int)key[i];        //adding the ASCII values of each character in the key
            }

            offsetFactor = Math.Round(offsetFactor / 8) - 32;       //performing operations on the factor

            return (int)offsetFactor;       //returning the final offset factor as an integer
        }

        private int GetRandom(int min, int max)     //function that takes a maximum and minimum and returns a random number in that range
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }
    }
}