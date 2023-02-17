using System;
using System.Collections.Generic;

namespace Bank
{
    class main
    {
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();

            accounts.Add(new Account("Marzena", "Kul", 10000));
            accounts.Add(new Account("Tomasz", "Pies", 4000));
            accounts.Add(new Account("Marek", "Kot", 1500));

            Console.WriteLine("Witaj w banku!");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Co chciałbyś zrobić?");
                Console.WriteLine("1. Sprawdź saldo konta");
                Console.WriteLine("2. Wpłata środków");
                Console.WriteLine("3. Wypłata srodków");
                Console.WriteLine("4. Wyjscie");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Błędna wartość, podaj liczbę.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Podaj nazwisko:");
                        string lastName = Console.ReadLine();

                        Account account = accounts.FirstOrDefault(acc => acc.LastName == lastName);
                        if (account != null)
                        {
                            Console.WriteLine($"Saldo konta wynosi {account.Balance} zł");
                        }
                        else
                        {
                            Console.WriteLine("Konto nie zostało odnalezione.");
                        }

                        break;
                    case 2:
                        Console.WriteLine("Podaj nazwisko:");
                        lastName = Console.ReadLine();

                        account = accounts.FirstOrDefault(acc => acc.LastName == lastName);
                        if (account != null)
                        {
                            Console.WriteLine("Podaj kwotę do wpłaty:");
                            double amount;
                            if (double.TryParse(Console.ReadLine(), out amount))
                            {
                                account.Deposit(amount);
                                Console.WriteLine($"Saldo konta wynosi teraz {account.Balance} zł");
                            }
                            else
                            {
                                Console.WriteLine("Błędna wartość, podaj liczbę.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Konto nie zostało odnalezione.");
                        }

                        break;
                    case 3:
                        Console.WriteLine("Podaj nazwisko:");
                        lastName = Console.ReadLine();

                        account = accounts.FirstOrDefault(acc => acc.LastName == lastName);
                        if (account != null)
                        {
                            Console.WriteLine("Podaj kwotę do wypłaty:");
                            double amount;
                            if (double.TryParse(Console.ReadLine(), out amount))
                            {
                                if (account.Withdraw(amount))
                                {
                                    Console.WriteLine($"Saldo konta wynosi teraz {account.Balance} zł");
                                }
                                else
                                {
                                    Console.WriteLine("Niewystarczajaca ilość środków na koncie.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Błędna wartość, podaj liczbę.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Konto nie zostało odnalezione.");
                        }

                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Podana opcja nie istnieje, sprobuj którąś z podanych na ekranie.");
                        break;
                }
            }
        }
    }

    class Account
    {
        public string FirstName { get; }
        public string LastName { get; }
        public double Balance { get; private set; }

        public Account(string firstName, string lastName, double balance)
        {
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public bool Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
