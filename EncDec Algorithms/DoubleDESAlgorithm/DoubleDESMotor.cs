using Alghotithms.DESAlgorithm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alghotithms.DoubleDESAlgorithm
{
    public class DoubleDESMotor
    {
        private DESMotor desMotor;

        public DoubleDESMotor()
        {
            desMotor = new DESMotor();
        }



        public string Encrypt(string plainText, string key1, string key2) 
        {
            var cipherText1 = desMotor.Encrypt(plainText, key1);
            var finalCipherText = desMotor.Encrypt(cipherText1, key2);

            return finalCipherText; 
        }
        public string Decrypt(string cipherText, string key1, string  key2) 
        {
            var cipherText1 = desMotor.Decrypt(cipherText, key2);
            var finalPlainText = desMotor.Decrypt(cipherText1, key1);

            return finalPlainText;
        }

    }
}
