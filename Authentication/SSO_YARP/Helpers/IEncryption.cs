namespace Helpers
{
    public interface IEncryption
    {
        string Encrypt(string cipherText, string key);
        string Decrypt(string plainText, string key);
    }
}
