using System;
namespace EncryptionProject
{
    public interface IEncryptionParameters
    {

        string GetDecryptedFileName();
        string GetEncryptedFileName();
        string GetEncryptionKey();

    }
}