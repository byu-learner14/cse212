using Microsoft.VisualStudio.TestTools.UnitTesting;
// TODO Problem 2 - Write and run test cases and fix the code to match requirements.
[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add multiple items with different priorities
    // Expected Result: Highest priority dequeued first, then next highest, etc.
    // Defect(s) Found: Dequeue was not correctly selecting highest priority
    public void TestPriorityQueue_DequeueHighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Multiple items with same highest priority
    // Expected Result: FIFO order for same priority
    // Defect(s) Found: Dequeue was not preserving FIFO for same priority
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("X", 5);
        priorityQueue.Enqueue("Y", 5);
        priorityQueue.Enqueue("Z", 5);

        Assert.AreEqual("X", priorityQueue.Dequeue());
        Assert.AreEqual("Y", priorityQueue.Dequeue());
        Assert.AreEqual("Z", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: InvalidOperationException with correct message
    // Defect(s) Found: Wrong exception type or message
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}