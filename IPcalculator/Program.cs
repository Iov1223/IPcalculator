using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace IPcalculator
{
    /// <summary>
    /// Класс работающий с массивом инициализированным как IP
    /// </summary>
    class ipADDR
    {
        /// <summary>
        /// ОбЪявление массива
        /// </summary>
        public int[] ip;

        public ipADDR()
        {
            ip = new int[4] { 0, 0, 0, 0 };
        }

        /// <summary>
        /// Метод запрашивающий IP адрес. Метод разбивает адрес на октеты, переводит
        /// из string в int и осуществляет проверку.
        /// </summary>
        public void RequestIPaddress(string text)
        {
            bool Flag = false;
            Console.WriteLine("Введиете {0}:", text);
            do
            {
                string str = Console.ReadLine();
                string[] tokens = str.Split('.');
                ip[0] = Int32.Parse(tokens[0]);
                ip[1] = Int32.Parse(tokens[1]);
                ip[2] = Int32.Parse(tokens[2]);
                ip[3] = Int32.Parse(tokens[3]);
                if (ip[0] < 0 || ip[1] < 0 || ip[2] < 0 || ip[3] < 0 || ip[0] > 255 || ip[1] > 255 || ip[2] > 255 || ip[3] > 255)
                {
                    Console.WriteLine("Неверно введённый(ая) {0}. Попробуйте снова: ", text);
                }
                else
                {
                    Flag = true;
                }
            } while (Flag == false);
            
        }
        /// <summary>
        /// Метод переводящий из десятичной ситемы счисления в двоичную
        /// </summary>
        public void ConvertTo()
        { 
            double bin = 0;
            for (int i = 0; ip[0] > 0; i++)
            {
                bin += (ip[0] % 2) * Math.Pow(10, i);
                ip[0] /= 2;

            }
            ip[0] = Convert.ToInt32(bin);

            bin = 0;
            for (int i = 0; ip[1] > 0; i++)
            {
                bin += (ip[1] % 2) * Math.Pow(10, i);
                ip[1] /= 2;

            }
            ip[1] = Convert.ToInt32(bin);

            bin = 0;
            for (int i = 0; ip[2] > 0; i++)
            {
                bin += (ip[2] % 2) * Math.Pow(10, i);
                ip[2] /= 2;

            }
            ip[2] = Convert.ToInt32(bin);

            bin = 0;
            for (int i = 0; ip[3] > 0; i++)
            {
                bin += (ip[3] % 2) * Math.Pow(10, i);
                ip[3] /= 2;

            }
            ip[3] = Convert.ToInt32(bin);
        }
        public void Print()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.Write(ip[i]);
                if (i < 3)
                {
                    Console.Write(".");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }

    }
    
    /// <summary>
    /// Класс работающий с массивом инициализированным как MASK 
    /// наследующий методы IP
    /// </summary>
    class ipMASK : ipADDR
    {
        public ipMASK()
        {
            ip = new int[4] { 255, 255, 255, 0 };
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string IP = "IP адрес", MASK = "Mask";
            ipADDR myIP = new ipADDR();
            myIP.RequestIPaddress(IP);
            myIP.ConvertTo();
            myIP.Print();
            ipMASK myMask = new ipMASK();
            myMask.RequestIPaddress(MASK);
            myIP.ConvertTo();
            myMask.Print();

        }
    }
}
