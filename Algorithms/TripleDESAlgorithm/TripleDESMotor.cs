using Alghotithms.DESAlgorithm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alghotithms.TripleDESAlgorithm
{
    public class TripleDESMotor
    {
        private DESMotor desMotor;

        public TripleDESMotor()
        {
            desMotor = new DESMotor();
        }

        public string Encrypt(string plainText, string key1, string key2)
        {
            var cipherText1 = desMotor.Encrypt(plainText, key1);
            var cipherText2 = desMotor.Decrypt(cipherText1, key2);
            var finalCipherText = desMotor.Encrypt(cipherText2, key1);

            return finalCipherText;
        }
        public string Decrypt(string cipherText, string key1, string key2)
        {
            var plainText1 = desMotor.Decrypt(cipherText, key1);
            var cipherText2 = desMotor.Encrypt(plainText1, key2);
            var finalPlainText = desMotor.Decrypt(cipherText2, key1);

            return finalPlainText;
        }


    }
}
