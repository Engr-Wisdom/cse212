using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add two items with different priorities.
    // Expected Result: The item with the highest priority should be dequeued first.
    // Defect(s) Found: None.
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();

        pq.Enqueue("Low", 1);
        pq.Enqueue("High", 5);

        var result = pq.Dequeue();

        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Add three items with different priorities.
    // Expected Result: Items should be dequeued from highest priority to lowest priority.
    // Defect(s) Found: None.
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();

        pq.Enqueue("A", 2);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Add multiple items with same priority.
    // Expected Result: Items should come out in FIFO order.
    // Defect(s) Found: Queue did not preserve insertion order for equal priorities.
    public void TestPriorityQueue_SamePriority()
    {
        var pq = new PriorityQueue();

        pq.Enqueue("First", 3);
        pq.Enqueue("Second", 3);
        pq.Enqueue("Third", 3);

        Assert.AreEqual("First", pq.Dequeue());
        Assert.AreEqual("Second", pq.Dequeue());
        Assert.AreEqual("Third", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items with negative priorities.
    // Expected Result: Highest numerical priority should be dequeued first.
    // Defect(s) Found: Negative priorities were not handled correctly.
    public void TestPriorityQueue_NegativePriorities()
    {
        var pq = new PriorityQueue();

        pq.Enqueue("Low", -5);
        pq.Enqueue("Medium", -2);
        pq.Enqueue("High", -1);

        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("Medium", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Add a single item.
    // Expected Result: That item should be returned.
    // Defect(s) Found: None.
    public void TestPriorityQueue_SingleItem()
    {
        var pq = new PriorityQueue();

        pq.Enqueue("Only", 10);

        Assert.AreEqual("Only", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items with zero priority.
    // Expected Result: Items should still follow insertion order.
    // Defect(s) Found: Zero priority items were not handled correctly.
    public void TestPriorityQueue_ZeroPriority()
    {
        var pq = new PriorityQueue();

        pq.Enqueue("First", 0);
        pq.Enqueue("Second", 0);

        Assert.AreEqual("First", pq.Dequeue());
        Assert.AreEqual("Second", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from empty queue.
    // Expected Result: InvalidOperationException with correct message.
    // Defect(s) Found: Queue did not throw correct exception message.
    public void TestPriorityQueue_EmptyThrows()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}