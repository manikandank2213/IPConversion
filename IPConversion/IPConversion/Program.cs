using System;
using System.Text.RegularExpressions;

namespace IPConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter IPV4 Adsress : ");
            string ipAddr = Console.ReadLine();
            Console.WriteLine("Enter SubNet Mask Adsress : ");
            string subnetMask = Console.ReadLine();
            String exp = @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}";
            Regex reg = new Regex(exp);

            //Inuput Purpose
            string[] ipSplit = ipAddr.Split('.');
            string[] subNetSplit = subnetMask.Split('.');

            //Output Purpose
            string ipv6 = "";
            string[] inputBinary = new string[4];
            string[] subNetBinary = new string[4];
            string[] maskIP = new string[4];


            if (ipSplit.Length == 4 && subNetBinary.Length == 4 && reg.Match(ipAddr).Success == true && reg.Match(subnetMask).Success == true)
            {
                int i = 0;
                //Converting given ip into binary 
                foreach (var input in ipSplit)
                {
                    inputBinary[i] = decToBinary(Convert.ToInt32(input));
                    i++;
                }

                string ipBinary = String.Join('.', inputBinary);
                Console.WriteLine("IPv4 Binary : " + ipBinary);

                //Converting subnet ip into binary 
                i = 0;
                foreach (var input in subNetSplit)
                {
                    subNetBinary[i] = decToBinary(Convert.ToInt32(input));
                    i++;
                }

                string subBinary = String.Join('.', subNetBinary);
                Console.WriteLine("Subnet Mask Binary : " + subBinary);

                foreach (var input in ipBinary.Split('.'))
                {
                    var input1 = input.Substring(0, 4);
                    var input2 = input.Substring(4, 4);

                    ipv6 += Convert.ToInt32(input1, 2).ToString("x");
                    ipv6 += Convert.ToInt32(input2, 2).ToString("x");
                }
                Console.WriteLine("ipv4 -> ipv6(Compression) : " + "::2001:" + ipv6.Substring(0, 4) + ":" + ipv6.Substring(4, 4));
                Console.WriteLine("ipv4 -> ipv6(Expand) : " + "0000:0000:0000:0000:0000:2001:" + ipv6.Substring(0, 4) + ":" + ipv6.Substring(4, 4));

                //Processor "AND" condition for inputbinary and subnet mask binary values for network address
                for (i = 0; i < 4; i++)
                {
                    maskIP[i] = (Convert.ToInt32(ipSplit[i]) & Convert.ToInt32(subNetSplit[i])).ToString();
                }
                Console.WriteLine("Network Address : " + String.Join('.', maskIP));

                //Find occurence of '1' in subnet mask binary value
                i = 0;
                foreach (char c in subBinary)
                {
                    if (c == '1')
                        i++;
                }
                Console.WriteLine("CIDR Notation : " + ipAddr + "/" + i.ToString());
            }
            else
            {
                Console.WriteLine("Enter valid ipv4 address");
            }
            
        }

        static string decToBinary(int n)
        {
            // array to store binary number 
            String res = "";

            // counter for binary array 
            int i = 0;
            while (n > 0)
            {

                // storing remainder in binary array 
                res += n % 2;
                n = n / 2;
                i++;
            }

            if (res.Length < 8)
            {
                int diff = 8 - res.Length;
                while (diff != 0)
                {
                    res += '0';
                    diff--;
                }
            }

            char[] a = res.ToCharArray();
            Array.Reverse(a);
            return new String(a);
        }
    }
}
