using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Test the priority queue when adding and dequeuing a single item.
    // Expected Result: The item added is returned when dequeued.
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);
        
        var result = priorityQueue.Dequeue();
        
        Assert.AreEqual("Item1", result, "The dequeued item should be 'Item1'.");
    }

    [TestMethod]
    // Scenario: Test the priority queue with multiple items having different priorities.
    // Expected Result: The item with the highest priority should be dequeued first.
    public void TestPriorityQueue_MultipleItemsDifferentPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);  // Low priority
        priorityQueue.Enqueue("Item2", 3);  // High priority
        priorityQueue.Enqueue("Item3", 2);  // Medium priority
        
        var result = priorityQueue.Dequeue();
        
        // The highest priority item should be "Item2"
        Assert.AreEqual("Item2", result, "The dequeued item should be 'Item2'.");
    }

    [TestMethod]
    // Scenario: Test the priority queue when there are multiple items with the same priority.
    // Expected Result: Items with the same priority should be dequeued in FIFO order.
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 2);
        priorityQueue.Enqueue("Item2", 2); // Same priority as Item1
        priorityQueue.Enqueue("Item3", 2); // Same priority as Item1 and Item2
        
        // First dequeued item should be "Item1" because it was enqueued first (FIFO)
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Item1", result, "The dequeued item should be 'Item1' (FIFO).");
        
        // Second dequeued item should be "Item2"
        result = priorityQueue.Dequeue();
        Assert.AreEqual("Item2", result, "The dequeued item should be 'Item2' (FIFO).");
        
        // Third dequeued item should be "Item3"
        result = priorityQueue.Dequeue();
        Assert.AreEqual("Item3", result, "The dequeued item should be 'Item3' (FIFO).");
    }

    [TestMethod]
    // Scenario: Test the priority queue with a case where the queue is empty.
    // Expected Result: An InvalidOperationException should be thrown when attempting to dequeue.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        
        try
        {
            priorityQueue.Dequeue(); // Should throw an exception
            Assert.Fail("Expected InvalidOperationException, but no exception was thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message, "The exception message should indicate the queue is empty.");
        }
    }

    [TestMethod]
    // Scenario: Test when adding multiple items with different priorities and dequeuing them all.
    // Expected Result: Items should be dequeued in the order of their priority, highest priority first.
    public void TestPriorityQueue_AllItemsDequeuedInOrder()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 5);  // Highest priority
        priorityQueue.Enqueue("Item2", 1);  // Lowest priority
        priorityQueue.Enqueue("Item3", 3);  // Medium priority
        
        // Dequeueing in order of highest priority first
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Item1", result, "The dequeued item should be 'Item1' with priority 5.");
        
        result = priorityQueue.Dequeue();
        Assert.AreEqual("Item3", result, "The dequeued item should be 'Item3' with priority 3.");
        
        result = priorityQueue.Dequeue();
        Assert.AreEqual("Item2", result, "The dequeued item should be 'Item2' with priority 1.");
    }

    [TestMethod]
    // Scenario: Test adding items with the same priority but dequeuing them in FIFO order.
    // Expected Result: Items with equal priority should be dequeued in the order they were added (FIFO).
    public void TestPriorityQueue_FifoWhenSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 10);
        priorityQueue.Enqueue("Item2", 10);  // Same priority
        priorityQueue.Enqueue("Item3", 10);  // Same priority
        
        // Should follow FIFO order: Item1, Item2, Item3
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Item1", result, "The dequeued item should be 'Item1' (FIFO order).");
        
        result = priorityQueue.Dequeue();
        Assert.AreEqual("Item2", result, "The dequeued item should be 'Item2' (FIFO order).");
        
        result = priorityQueue.Dequeue();
        Assert.AreEqual("Item3", result, "The dequeued item should be 'Item3' (FIFO order).");
    }
    
    [TestMethod]
    // Scenario: Test adding items with increasing priority.
    // Expected Result: Items should be dequeued in the order of decreasing priority.
    public void TestPriorityQueue_IncreasingPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);
        priorityQueue.Enqueue("Item2", 2);
        priorityQueue.Enqueue("Item3", 3);
        
        // The first dequeued item should have the highest priority
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Item3", result, "The dequeued item should be 'Item3' with priority 3.");
        
        result = priorityQueue.Dequeue();
        Assert.AreEqual("Item2", result, "The dequeued item should be 'Item2' with priority 2.");
        
        result = priorityQueue.Dequeue();
        Assert.AreEqual("Item1", result, "The dequeued item should be 'Item1' with priority 1.");
    }
}
