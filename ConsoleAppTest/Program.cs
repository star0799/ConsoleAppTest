using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ConsoleAppTest
{
    public class Program
    {
        protected static readonly int[] SpecialRuleId = { 65, 66, 67 };
        static void Main(string[] args)
        {
            //List<string> ids = new List<string>();
            //ids.Add("1111");
            //ids.Add("2222");
            //ids.Add("3333");
            //ids.Add("4444"); 
            //ids.Add  ("5555");
            //string     UserName = "star";
            //string id = "";
            //string requestBody = @"[{ 'UserName':'{0}','ids':'{1}'}]";
            //string jsonStr  ing = "";
            //foreach (var i in ids)
            //{
            //    id += i + ",";
            //}
            //id = id.Substring(0, id.Length - 1);
            //requestBody = requestBody.Replace("{0}", UserName).Replace("{1}", id);
            //jsonString = JsonConvert.SerializeObject(requestBody);
            //Console.WriteLine(requestBody);
            //Console.WriteLine(jsonString);




            //foreach(var s in dic)
            //{
            //    Console.WriteLine(s.Key);
            //    Console.WriteLine(s.Value);
            //}
            //var remainTime = 12;
            //remainTime = (int)(remainTime/1000);

            //int id = 66;
            //bool result = false;
            //if (SpecialRuleId.Contains(id))
            //    result = true;
            //else
            //    result = false;
            //Console.WriteLine(result);
            //Console.Read();

            // DoSomeThing();


            //string temp = "";
            //var result = temp == null ? 1 : 2;
            //if (ConfigurationManager.AppSettings["a"].ToString() != null)
            //{
            //    Console.WriteLine(1);
            //}
            //else
            //    Console.WriteLine(2);
            //Console.Read();
            // Original request parameters
            var requestParams = new
            {
                loginName = "j7l6testuser",
                timestamp = "1578662499442"
            };

            // Convert original request parameters to JSON string
            var requestParamsJson = JsonConvert.SerializeObject(requestParams);

            // Encrypt the JSON string
            var encryptedParams = Encrypt(requestParamsJson);

            // Calculate the MD5 hash of the encrypted JSON string
            var md5Hash = CalculateMD5Hash(encryptedParams);

            // Create the final JSON object to be sent in the request
            var finalJson = new
            {
                merchantCode = "J7L6",
                @params = encryptedParams,
                signature = md5Hash
            };

            // Convert the final JSON object to a string
            var finalJsonString = JsonConvert.SerializeObject(finalJson);

            Console.WriteLine(finalJsonString);
        }
        private static string Encrypt(string plainText)
        {
            // Add your encryption logic here
            return "";
        }
        private static string CalculateMD5Hash(string input)
        {
            // Use MD5 hash algorithm
            using (MD5 md5 = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Operator(int a, int b, Func<int, int, int> handle)
        {
            return handle(a, b);
        }

        public static void DoSomeThing()
        {
            var a = 1;
            var b = 2;
            var c = Operator(a, b, Add);
        }
    }
}
