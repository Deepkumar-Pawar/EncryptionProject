using System;
namespace EncryptionProject
{
    public class EncryptionParametersConsole : IEncryptionParameters
    {
        public EncryptionParametersConsole()
        {
        }

        public string GetDecryptedFileName()
        {
            return Console.ReadLine();
        }

        public string GetEncryptedFileName()
        {
            return Console.ReadLine();
        }

        public string GetEncryptionKey()
        {
            return Console.ReadLine();
        }
    }
}