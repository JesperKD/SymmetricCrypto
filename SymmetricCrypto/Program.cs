using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricCrypto
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            Console.WriteLine("Choose your preferred Symmetric Encryption: ");
            Console.WriteLine("1. AES \n2. DES \n3. Tripple DES");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("That that is not a number...");
                Console.ReadKey();
            }

            switch (choice)
            {
                case 1:
                    Process.AESProcess();
                    break;

                case 2:
                    Process.DESProcess();
                    break;

                case 3:
                    Process.TripleDESProcess();
                    break;
            }
            Console.ReadKey();
        }
    }

    public static class Generator
    {
        public static byte[] AesKey()
        {
            return Randomer.GenerateRandomNumber(32);
        }

        public static byte[] AesIV()
        {
            return Randomer.GenerateRandomNumber(16);
        }

        public static byte[] DESKeyAndIV()
        {
            return Randomer.GenerateRandomNumber(8);
        }

        public static byte[] TripleDESKey()
        {
            return Randomer.GenerateRandomNumber(16);
        }

        public static byte[] TripleDESIV()
        {
            return Randomer.GenerateRandomNumber(8);
        }
    }

    public static class Process
    {
        public static void AESProcess()
        {
            Stopwatch esw = new Stopwatch();
            Stopwatch dsw = new Stopwatch();
            Console.Clear();
            Console.WriteLine("Press any key to generate key and iv");
            Console.ReadKey();

            var aesKey = Generator.AesKey();
            var aesIV = Generator.AesIV();

            Console.WriteLine("Key = " + Convert.ToBase64String(aesKey));
            Console.WriteLine("IV = " + Convert.ToBase64String(aesIV));
            Console.WriteLine();

            Console.WriteLine("Type out your string for AES encryption:");
            string aesOriginal = Console.ReadLine();

            esw.Start();
            var aesEncrypted = AesEncryption.Encrypt(Encoding.UTF8.GetBytes(aesOriginal), aesKey, aesIV);
            esw.Stop();

            dsw.Start();
            var aesDecrypted = AesEncryption.Decrypt(aesEncrypted, aesKey, aesIV);
            dsw.Stop();

            var aesDecryptedMessage = Encoding.UTF8.GetString(aesDecrypted);

            Console.WriteLine();
            Console.WriteLine("Original Text = " + aesOriginal);
            Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(aesEncrypted) + " (" + esw.ElapsedMilliseconds + "ms elapsed)");
            Console.WriteLine("Encrypted Text as hex = " + BitConverter.ToString(aesEncrypted).Replace("-", string.Empty));
            Console.WriteLine();
            Console.WriteLine("Decrypted Text = " + aesDecryptedMessage + " (" + dsw.ElapsedMilliseconds + "ms elapsed)");
            Console.WriteLine("Decrypted text as hex = " + BitConverter.ToString(aesDecrypted).Replace("-", string.Empty));
            Console.WriteLine();
        }

        public static void DESProcess()
        {
            Stopwatch esw = new Stopwatch();
            Stopwatch dsw = new Stopwatch();
            Console.Clear();
            Console.WriteLine("Press any key to generate key and iv");
            Console.ReadKey();

            var desKey = Generator.DESKeyAndIV();
            var desIV = Generator.DESKeyAndIV();

            Console.WriteLine("Key = " + Convert.ToBase64String(desKey));
            Console.WriteLine("IV = " + Convert.ToBase64String(desIV));
            Console.WriteLine();

            Console.WriteLine("Type out your string for DES encryption:");
            string desOriginal = Console.ReadLine();

            esw.Start();
            var desEncrypted = DesEncryption.Encrypt(Encoding.UTF8.GetBytes(desOriginal), desKey, desIV);
            esw.Stop();

            dsw.Start();
            var desDecrypted = DesEncryption.Decrypt(desEncrypted, desKey, desIV);
            dsw.Stop();

            var desDecryptedMessage = Encoding.UTF8.GetString(desDecrypted);

            Console.WriteLine();
            Console.WriteLine("Original Text = " + desOriginal);
            Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(desEncrypted) + " (" + esw.ElapsedMilliseconds + "ms elapsed)");
            Console.WriteLine("Encrypted Text as Hex = " + BitConverter.ToString(desEncrypted).Replace("-", string.Empty));
            Console.WriteLine();
            Console.WriteLine("Decrypted Text = " + desDecryptedMessage + " (" + dsw.ElapsedMilliseconds + "ms elapsed)");
            Console.WriteLine("Decrypted Text as Hex = " + BitConverter.ToString(desDecrypted).Replace("-", string.Empty));
            Console.WriteLine();
        }

        public static void TripleDESProcess()
        {
            Stopwatch esw = new Stopwatch();
            Stopwatch dsw = new Stopwatch();
            Console.Clear();
            Console.WriteLine("Press any key to generate key and iv");
            Console.ReadKey();

            var tripleDesKey = Generator.TripleDESKey();
            var tripleDesIV = Generator.TripleDESIV();

            Console.WriteLine("Key = " + Convert.ToBase64String(tripleDesKey));
            Console.WriteLine("IV = " + Convert.ToBase64String(tripleDesIV));
            Console.WriteLine();

            Console.WriteLine("Type out your string for Triple DES encryption:");
            string tripleDesOriginal = Console.ReadLine();

            esw.Start();
            var tripleDesEncrypted = TripleDesEncryption.Encrypt(Encoding.UTF8.GetBytes(tripleDesOriginal), tripleDesKey, tripleDesIV);
            esw.Stop();

            dsw.Start();
            var tripleDesDecrypted = TripleDesEncryption.Decrypt(tripleDesEncrypted, tripleDesKey, tripleDesIV);
            dsw.Stop();

            var tripleDesDecryptedMessage = Encoding.UTF8.GetString(tripleDesDecrypted);

            Console.WriteLine();
            Console.WriteLine("Original Text = " + tripleDesOriginal);
            Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(tripleDesEncrypted) + " ( " + esw.ElapsedMilliseconds + "ms elapsed)");
            Console.WriteLine("Encrypted Text as hex = " + BitConverter.ToString(tripleDesEncrypted).Replace("-", string.Empty));
            Console.WriteLine();
            Console.WriteLine("Decrypted Text = " + tripleDesDecryptedMessage + " (" + dsw.ElapsedMilliseconds + "ms elapsed)");
            Console.WriteLine("Decrypted Text = " + BitConverter.ToString(tripleDesDecrypted).Replace("-", string.Empty));

            Console.WriteLine();
        }

    }

}
