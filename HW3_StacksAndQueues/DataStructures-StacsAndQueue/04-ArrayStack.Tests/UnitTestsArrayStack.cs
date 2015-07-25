using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _03_StackDataStructure;

namespace _04_ArrayStack.Tests
{
    [TestClass]
    public class UnitTestsArrayStack
    {
        [TestMethod]
        public void PushShouldAddElement()
        {
            //Arrange
            var stack = new ArrayStack<int>();
            Assert.AreEqual(0, stack.Count);

            //Act
            stack.Push(8);
            
            //Assert
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        public void PushAndPopShouldAddAndRemoveElement()
        {
            //Arrange
            var stack = new ArrayStack<int>();

            //Act
            stack.Push(8);
            var poppedElement = stack.Pop();

            //Assert
            Assert.AreEqual(8, poppedElement);
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopAnEmptyStackShouldThrowException()
        {
            //Arrange
            var stack = new ArrayStack<int>();

            //Act
            var poppedElement = stack.Pop();

            //Assert
            // - method expects exception.
        }

        [TestMethod]
        public void Push1000ElementsShouldAddElements()
        {
            //Arrange
            var stack = new ArrayStack<string>();

            //Act
            for (int i = 0; i < 1000; i++)
            {
                stack.Push(i.ToString());
                //Assert
                Assert.AreEqual(i + 1, stack.Count);
            }
            //Assert
            Assert.AreEqual(1000, stack.Count);
        }

        [TestMethod]
        public void PushAndPopWithInitialCapacity1ShouldWorkCorrectly()
        {
            //Arrange
            var stack = new ArrayStack<int>(1);
            //Assert
            Assert.AreEqual(0, stack.Count);

            //Act
            stack.Push(1);
            //Assert
            Assert.AreEqual(1, stack.Count);
            //Act
            stack.Push(2);
            //Assert
            Assert.AreEqual(2, stack.Count);
            //Act
            var element = stack.Pop();
            //Assert
            Assert.AreEqual(2, element);
            Assert.AreEqual(1, stack.Count);
            //Act
            element = stack.Pop();
            //Assert
            Assert.AreEqual(1, element);
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void ToArrayShouldWorkCorrectly()
        {
            //Arrange
            var stack = new ArrayStack<int>(1);

            //Act
            stack.Push(8);
            stack.Push(-5);
            stack.Push(4);
            stack.Push(66);
            var array = stack.ToArray();

            //Assert
            CollectionAssert.AreEqual(new int[4]{66,4,-5,8}, array);
        }

        [TestMethod]
        public void EmptyStackToArrayShouldReturnEmptyArray()
        {
            //Arrange
            var stack = new ArrayStack<int>(1);

            //Act
            var array = stack.ToArray();

            //Assert
            CollectionAssert.AreEqual(new int[0] {}, array);
        }
    }
}
