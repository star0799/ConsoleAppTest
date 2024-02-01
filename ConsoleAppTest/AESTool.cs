using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AESTest
{
    public class AESTool
    {
        private string DefaultKey = "C2C6BAABDB5A51B24017AC7650C64129";
        private string DefaultIV = "99E2093DCA9291E3";
        private readonly Encoding Coding = Encoding.UTF8;
        public AESTool()
        {
        }

        public AESTool(string key)
        {
            DefaultKey = key;
        }

        private byte[] GetKeyByte()
        {
            return Coding.GetBytes(DefaultKey);
        }

        private byte[] GetIVByte()
        {
            return Coding.GetBytes(DefaultIV);
        }

        public string Encrypt(string plainText)
        {
            string result = string.Empty;
            try
            {
                var aes = new AesManaged();
                aes.Key = GetKeyByte();
                aes.IV = GetIVByte();

                byte[] plainTextByte = Coding.GetBytes(plainText);
                using (var tranform = aes.CreateEncryptor())
                {
                    result = Convert.ToBase64String(tranform.TransformFinalBlock(plainTextByte, 0, plainTextByte.Length));
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public string Decrypt(string encryptedText)
        {
            string result = string.Empty;
            try
            {
                byte[] encryptedByte = Convert.FromBase64String(encryptedText);
                var aes = new AesManaged();

                aes.Key = GetKeyByte();
                aes.IV = GetIVByte();

                byte[] dByte = null;
                using (var tranform = aes.CreateDecryptor())
                {
                    dByte = tranform.TransformFinalBlock(encryptedByte, 0, encryptedByte.Length);
                }

                result = Coding.GetString(dByte, 0, dByte.Length);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}

