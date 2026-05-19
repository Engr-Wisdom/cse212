using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();

        pq.Enqueue("Low", 1);
        pq.Enqueue("High", 5);

        var result = pq.Dequeue();

        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
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

    // Add more test cases as needed below.

    [TestMethod]
    public void TestPriorityQueue_EmptyThrows()
    {
        var pq = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() =>
        {
            pq.Dequeue();
        });
    }
}