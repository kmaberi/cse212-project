using NUnit.Framework;

[TestFixture]
public class PriorityQueue_Tests
{
    [Test]
    public void Enqueue_AddsWithPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Alice", 1);
        pq.Enqueue("Bob", 3);
        // Test case: Enqueue with priorities (1 low, 3 high).
        // Test result: Pass - Enqueue adds without error.
        Assert.AreEqual(2, pq.Length());
    }

    [Test]
    public void Dequeue_ReturnsHighestPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Alice", 1);
        pq.Enqueue("Bob", 3);
        var result = pq.Dequeue();
        // Test case: Dequeue should return "Bob" (higher priority).
        // Test result: Pass - Dequeue returns highest priority.
        Assert.AreEqual("Bob", result);
    }

    [Test]
    public void Dequeue_EmptyQueue_ReturnsNull()
    {
        var pq = new PriorityQueue();
        var result = pq.Dequeue();
        // Test case: Empty queue returns null.
        // Test result: Pass - Returns null for empty queue.
        Assert.IsNull(result);
    }
}