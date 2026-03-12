dotnet rundotnet runusing System;
using System.Collections.Generic;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    private Queue<(string Name, int AccountId, string Problem)> queue;
    private int maxSize;

    public CustomerService(int size)
    {
        maxSize = size <= 0 ? 10 : size;
        queue = new Queue<(string, int, string)>();
    }

    public void AddNewCustomer(string name, int accountId, string problem)
    {
        if (queue.Count >= maxSize)
        {
            Console.WriteLine("Error: Queue is full.");
            return;
        }
        queue.Enqueue((name, accountId, problem));
    }

    public void ServeCustomer()
    {
        if (queue.Count == 0)
        {
            Console.WriteLine("Error: Queue is empty.");
            return;
        }
        var customer = queue.Dequeue();
        Console.WriteLine($"Serving: {customer.Name}, ID: {customer.AccountId}, Problem: {customer.Problem}");
    }
}

dotnet run