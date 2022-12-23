using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// using System.Threading.Tasks;
namespace Asm2._2_Hotel.Models
{
    public class Customer
    {
        public string Fullname { get; set; }
        public int Age { get; set; }
        public string CMTND { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        public Customer()
        {

        }

        public Customer(string cmtnd)
        {
            CMTND = cmtnd;
        }

        public Customer(string fullname, int age, string cmtnd, string gender, string address)
        {
            Fullname = fullname;
            Age = age;
            CMTND = cmtnd;
            Gender = gender;
            Address = address;
        }

        public void Input()
        {
            Console.WriteLine("Enter Customer's ID: ");
            CMTND = Console.ReadLine();

            InputWithoutCMTND();
        }

        public void InputWithoutCMTND()
        {
            Console.WriteLine("Enter Customer's name: ");
            Fullname = Console.ReadLine();

            Console.WriteLine("Enter Customer's Age ");
            Age = int.Parse(Console.ReadLine());

            Console.WriteLine("Gender:  ");
            Gender = Console.ReadLine();

            Console.WriteLine("Address: ");
            Address = Console.ReadLine();
        }

        public void Display()
        {
            Console.WriteLine("Name: {0}, age: {1}, ID: {2}, sex: {3}, address: {4}", Fullname, Age, CMTND, Gender, Address);

        }
    }
}