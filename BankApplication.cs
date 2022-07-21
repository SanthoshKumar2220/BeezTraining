using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{

    class Customer
    {
        public string CustomerName;
        public string CustomerID;
        public int Age;
        public string Gender;
        public string Password;
        public int amount;
    }
    class Bank
    {
        public static void Main(String[] args)
        {
            
           

            int Next = 0;
            do
            {
                List<Customer> customerList = new List<Customer>();
                

                Console.WriteLine(" Press 1 for Create Account");
                Console.WriteLine(" Press 2 for Withdraw Amount");
                Console.WriteLine(" Press 3 for Deposit Amount");
                Console.WriteLine(" Press 4 for Change Password");
                int App = Convert.ToInt32(Console.ReadLine());
                switch (App)
                {
                    case 1:
                        //Calling CreateCustomer function
                        CreateCustomer(customerList);
                        break;
                    case 2:
                        //Calling WithdrawAmount function
                        WithdrawAmount(customerList);
                        break;
                    case 3:
                        //Calling DepositAmount function
                        DepositAmount(customerList);
                        break;
                    case 4:
                        //Calling ChangePassoword function
                        ChangePassword(customerList);
                        break;
                }
                Console.WriteLine("Do you want to continue this program...Press 5");
                Next = Convert.ToInt32(Console.ReadLine());
            } while (Next == 5);
        }
        //This is a CreateCustomer function
        public static void CreateCustomer(List<Customer> customerList)
        {
            Customer NewCustomer = new Customer();
            Console.WriteLine("Enter Your Name : ");
            NewCustomer.CustomerName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter Your ID : ");
            NewCustomer.CustomerID = Console.ReadLine();
            Console.WriteLine("Enter Your Age : ");
            NewCustomer.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is Your Gender : ");
            NewCustomer.Gender = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter Your Password : ");
            NewCustomer.Password = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Your Available Balance");
            NewCustomer.amount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Customer Name : " + NewCustomer.CustomerName);
            Console.WriteLine("Customer ID : " + NewCustomer.CustomerID);
            Console.WriteLine("Age : " + NewCustomer.Age);
            Console.WriteLine("Gender : " + NewCustomer.Gender);
            Console.WriteLine("Password : " + NewCustomer.Password);
            customerList.Add(NewCustomer);
            Console.WriteLine("The List Of Customer : " + customerList.Count);
        }
        //This is a WithdrawAmount function
        public static void WithdrawAmount(List<Customer> customerList)
        {
            
            int withdraw = 0;
            string custid = " ";
            Console.WriteLine("Enter Withdraw Your Amount");
            withdraw = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Your Customer ID ");
            custid = Convert.ToString(Console.ReadLine());
            for (int i = 0; i < customerList.Count; i++)
            {
                if (customerList[i].CustomerID == custid)
                    if (withdraw > 500 && withdraw < customerList[i].amount)
                    {

                       customerList[i]. amount = customerList[i].amount - withdraw;
                        Console.WriteLine("Your Current Balance Is : " + customerList[i].amount);
                        Console.WriteLine("Thank You visit again ");
                      
                    }
               
                else
                {
                        Console.WriteLine("Insufficient Amount");
                }
            }
        }
        //This is a DepositAmount function
        public static void DepositAmount(List<Customer> customerList)
        {
           
            int deposit;
            string custid = "";
            Console.WriteLine("Enter You Deposit Amount");
            deposit = Convert.ToInt32(Console.ReadLine()); 
            Console.WriteLine("Enter Your Customer ID ");
            custid = Convert.ToString(Console.ReadLine());
            for (int i = 0; i < customerList.Count; i++)
            {
                if (customerList[i].CustomerID == custid)
                {
                    customerList[i].amount = customerList[i].amount + deposit;
                    Console.WriteLine("Your Amount Has Been Deposited Successfully and Your Availabe balance is: " + customerList[i].amount+"Rs");
                }
                else
                {
                    Console.WriteLine("Enter the valid ID");
                }
            }

        }

        public static void ChangePassword(List<Customer> customerList)
        {

            string oldpassword = "";
            string newpassword = "";

            string custid="";
            bool isValid = false;

            Console.WriteLine("Change Your Password ");
            Console.WriteLine("Enter Your Customer ID ");

            custid = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter the Password");
            oldpassword = Console.ReadLine();
            
            for (int i = 0; i < customerList.Count; i++)
            {
                if (customerList[i].CustomerID == custid && customerList[i].Password == oldpassword) 
                
                {
                   
                    Console.WriteLine("Enter Your New Password "+newpassword);
                    newpassword = Convert.ToString(Console.ReadLine());
                    isValid = validatePassword(customerList[i], newpassword);
                  //  if (isValid)
                    //{
                       
                      //  customerList[i].Password = newpassword;
                        //Console.WriteLine("Your Password Successfully Changed ");
                    //}
                }
              else  if (customerList[i].CustomerID !=custid && customerList[i].Password == oldpassword)
                {

                    Console.WriteLine("Enter the Valid Mail"); 
                }
              else if (customerList[i].CustomerID == custid && customerList[i].Password != oldpassword)
                {

                    Console.WriteLine("Enter the Valid Password");
                }
               else
                {
                    Console.WriteLine("Server TimeOut");
                }



            }
          

        }

        private static bool validatePassword(Customer customer, string newpassword)
        {

            if (customer.Password != newpassword)
            {
                Console.WriteLine("Your Password has been changed successfully");
                
                return true ;
            }
            else
            {
                Console.WriteLine("Your new Password is same as old Password try again");
                return false;
            }
        }
    }




}


