using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue values with varying priorities, then dequeue repeatedly.
    // Expected Result: Items dequeued in priority order, ties resolved in enqueue order.
    // Defect(s) Found: Dequeue did not include last item in comparison and did not remove dequeued node.
    // Test Results: Passed (high, high2, mid, low returned in correct order, no exceptions)
    public void TestPriorityQueue_DequeueHighestPriorityAndTieBreaking()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 5);
        priorityQueue.Enqueue("mid", 3);
        priorityQueue.Enqueue("high2", 5);

        Assert.AreEqual("high", priorityQueue.Dequeue());
        Assert.AreEqual("high2", priorityQueue.Dequeue());
        Assert.AreEqual("mid", priorityQueue.Dequeue());
        Assert.AreEqual("low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: InvalidOperationException thrown with message "The queue is empty."
    // Defect(s) Found: The method should guard against empty queue cases.
    // Test Results: Passed (error thrown and message matches expected)
    public void TestPriorityQueue_DequeueEmptyThrows()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
}
