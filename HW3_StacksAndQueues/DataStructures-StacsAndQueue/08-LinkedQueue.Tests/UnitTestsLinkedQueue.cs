using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _07_LinkedQueue;

namespace _08_LinkedQueue.Tests
{
    [TestClass]
    public class UnitTestsLinkedQueue
    {
        [TestMethod]
        public void EnqueueShouldAddElement()
        {
            //Arrange
            var linkedQueue = new LinkedQueue<int>();
            Assert.AreEqual(0, linkedQueue.Count);

            //Act
            linkedQueue.Enqueue(1);

            //Assert
            Assert.AreEqual(1, linkedQueue.Count);
        }

        [TestMethod]
        public void EnqueuAndDequeueShouldAddAndRemoveElement()
        {
            //Arrange
            var linkedQueue = new LinkedQueue<int>();

            //Act
            linkedQueue.Enqueue(5);
            var dequeuedElement = linkedQueue.Dequeue();

            //Assert
            Assert.AreEqual(5, dequeuedElement);
            Assert.AreEqual(0, linkedQueue.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DequeueAnEmptyQueueShouldThrowException()
        {
            //Arrange
            var queue = new LinkedQueue<int>();

            //Act
            var dequeuedElement = queue.Dequeue();

            //Assert
            // - method expects exception.
        }

        [TestMethod]
        public void Enqueue1000ElementsShouldAddElements()
        {
            //Arrange
            var queue = new LinkedQueue<string>();

            //Act
            for (int i = 0; i < 1000; i++)
            {
                queue.Enqueue(i.ToString());
                //Assert
                Assert.AreEqual(i + 1, queue.Count);
            }
            //Assert
            Assert.AreEqual(1000, queue.Count);
        }

        [TestMethod]
        public void EnqueueAndDequeueSeveralElements1ShouldWorkCorrectly()
        {
            //Arrange
            var queue = new LinkedQueue<int>();
            //Assert
            Assert.AreEqual(0, queue.Count);

            //Act
            queue.Enqueue(5);
            //Assert
            Assert.AreEqual(1, queue.Count);
            //Act
            queue.Enqueue(6);
            //Assert
            Assert.AreEqual(2, queue.Count);
            //Act
            var element = queue.Dequeue();
            //Assert
            Assert.AreEqual(5, element);
            Assert.AreEqual(1, queue.Count);
            //Act
            element = queue.Dequeue();
            //Assert
            Assert.AreEqual(6, element);
            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        public void ToArrayShouldWorkCorrectly()
        {
            //Arrange
            var queue = new LinkedQueue<int>();

            //Act
            queue.Enqueue(1);
            queue.Enqueue(-5);
            queue.Enqueue(4);
            queue.Enqueue(66);
            var array = queue.ToArray();

            //Assert
            CollectionAssert.AreEqual(new int[4] { 1, -5, 4, 66 }, array);
        }

        [TestMethod]
        public void EmptyQueueToArrayShouldReturnEmptyArray()
        {
            //Arrange
            var queue = new LinkedQueue<int>();

            //Act
            var array = queue.ToArray();

            //Assert
            CollectionAssert.AreEqual(new int[0] { }, array);
        }
    }
}
