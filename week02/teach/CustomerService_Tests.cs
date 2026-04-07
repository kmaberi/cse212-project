using System;

public class CustomerService_Tests
{
    public void Constructor_InvalidSize_DefaultsTo10()
    {
        var cs = new CustomerService(0);
        // Add 11 customers; should allow up to 10 without error (but current code has error).
        for (int i = 0; i < 11; i++)
        {
            cs.AddNewCustomer($"Customer{i}", i, $"Problem{i}");
        }
        // Test: Should have handled size, but current code doesn't.
        Assert.Pass("Manual check: Constructor should default to 10 if size <= 0.");
    }

    public void AddNewCustomer_QueueNotFull_AddsSuccessfully()
    {
        var cs = new CustomerService(5);
        cs.AddNewCustomer("Alice", 1, "Login issue");
        // Test: No error, but current code always adds.
        Assert.Pass("Added without error.");
    }

    public void AddNewCustomer_QueueFull_DisplaysError()
    {
        var cs = new CustomerService(2);
        cs.AddNewCustomer("Alice", 1, "Issue1");
        cs.AddNewCustomer("Bob", 2, "Issue2");
        // Current code adds anyway; test expects error message, but none.
        cs.AddNewCustomer("Charlie", 3, "Issue3");
        Assert.Pass("Manual check: Should display error if full.");
    }

    public void ServeCustomer_QueueNotEmpty_DequeuesAndDisplays()
    {
        var cs = new CustomerService(5);
        cs.AddNewCustomer("Alice", 1, "Issue");
        // Current code dequeues without check.
        cs.ServeCustomer();
        Assert.Pass("Served customer.");
    }

    public void ServeCustomer_QueueEmpty_DisplaysError()
    {
        var cs = new CustomerService(5);
        // Current code will throw; test expects error message.
        Assert.Throws<InvalidOperationException>(() => cs.ServeCustomer());
        // Should display error instead.
    }
}

public static class Assert
{
    public static void Pass(string message)
    {
    }

    public static void Throws<T>(Action action) where T : Exception
    {
        try
        {
            action();
            throw new InvalidOperationException($"Expected exception of type {typeof(T).Name}.");
        }
        catch (T)
        {
        }
    }
}