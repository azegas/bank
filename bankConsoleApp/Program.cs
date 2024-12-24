// TODO constructor
// TODO encapsulation
// TODO inheritance
// TODO polymorphism
// TODO abstraction
// TODO interface
// TOOD logging
// TODO history
// TODO transfer funds to another account
// TODO serialization
// TODO unit tests
// TODO validation
// TODO error handling
// TODO custom exceptiosn (e.g., InsufficientFundsException)
// TODO Use LINQ and collections for managing transactions or generating reports (e.g., total deposits in a given period).


using System;

public class Program {
    public static void Main() {

        // Example of initializing with initial balance
        BankAccount account = new BankAccount();

        void DisplayActions() {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1 - Deposit");
            Console.WriteLine("2 - Withdraw");
            Console.WriteLine("3 - View Balance");
            Console.WriteLine("4 - Exit");
        }

        bool running = true;

        while (running) {
            DisplayActions();

            if (!int.TryParse(Console.ReadLine(), out int action)) {
                Console.WriteLine("Invalid action. Please enter a number between 1 and 4.");
                continue;
            }

            switch (action) {
                case 1:
                    Console.Write("Enter the amount to deposit: ");
                    if (!int.TryParse(Console.ReadLine(), out int depositAmount) || depositAmount < 0) {
                        Console.WriteLine("Invalid amount. Please enter a positive number.");
                        break;
                    }
                    account.Deposit(depositAmount);
                    break;

                case 2:
                    Console.Write("Enter the amount to withdraw: ");
                    if (!int.TryParse(Console.ReadLine(), out int withdrawAmount) || withdrawAmount < 0) {
                        Console.WriteLine("Invalid amount. Please enter a positive number.");
                        break;
                    }
                    account.Withdraw(withdrawAmount);
                    break;

                case 3:
                    account.ViewBalance();
                    break;

                case 4:
                    Console.WriteLine("Are you sure you want to exit? (y/n)");
                    string exit = Console.ReadLine()?.ToLower();
                    if (exit == "y") {
                        Console.WriteLine("Exiting...");
                        running = false;
                    } else if (exit == "n") {
                        Console.WriteLine("Continuing...");
                    } else {
                        Console.WriteLine("Invalid input. Continuing...");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid action. Please choose between 1 and 4.");
                    break;
            }
        }
    }
}


class BankAccount {
    private int Balance { get; set; } // Private balance for encapsulation

    public void ViewBalance() {
        Console.WriteLine("Current Balance: " + Balance);
    }

    public void Deposit(int amount) {
        if (amount > 2000) {
            Console.WriteLine("Cannot deposit more than 2000 at a time.");
            return;
        } else if (amount < 0) {
            Console.WriteLine("Cannot deposit a negative amount.");
            return;
        } else {
            Balance += amount;
            Console.WriteLine("Deposited: " + amount);
        }
    }

    public void Withdraw(int amount) {
        if (amount > 1000) {
            Console.WriteLine("Cannot withdraw more than 1000 at a time.");
        } else if (amount > Balance) {
            Console.WriteLine($"Insufficient funds - can't take {amount} from {Balance}.");
        } else {
            Balance -= amount;
            Console.WriteLine("Withdrawn: " + amount);
        }
    }
}

 
