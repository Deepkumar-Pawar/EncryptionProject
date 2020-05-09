using System;
namespace EncryptionProject
{
    public interface ICipher
    {
        void Encrypt(IEncryptionParameters encParams);
        string Decrypt(IEncryptionParameters encParams);
    }
}
