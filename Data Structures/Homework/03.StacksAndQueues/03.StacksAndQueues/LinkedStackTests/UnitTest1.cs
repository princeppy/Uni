using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _05.LinkedStack;

namespace LinkedStackTests
{
    [TestClass]
    public class LinkedStackTests
    {
        [TestMethod]
        public void Push_Pop_Elements()
        {
            var nums = new LinkedStack<int>();
            Assert.AreEqual(0, nums.Count);
            nums.Push(15);
            Assert.AreEqual(1, nums.Count);
            nums.Push(12);
            Assert.AreEqual(2, nums.Count);
            Assert.AreEqual(12, nums.Pop());
            Assert.AreEqual(1, nums.Count);
            Assert.AreEqual(15, nums.Pop());
            Assert.AreEqual(0, nums.Count);
        }

        [TestMethod]
        public void Push_Pop_1000_Elements()
        {
            var nums = new LinkedStack<int>();
            Assert.AreEqual(0, nums.Count);

            for (int i = 0; i < 1001; i++)
            {
                nums.Push(i);
                Assert.AreEqual(i + 1, nums.Count);
            }
            for (int i = 0; i < 1001; i++)
            {
                Assert.AreEqual(1000 - i, nums.Pop());
                Assert.AreEqual(1000 - i, nums.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_Empty_Stack()
        {
            var nums = new LinkedStack<int>();
            nums.Pop();
        }

        [TestMethod]
        public void To_Array()
        {
            var nums = new LinkedStack<int>();
            nums.Push(3);
            nums.Push(5);
            nums.Push(-2);
            nums.Push(7);
            int[] arrTest = { 7, -2, 5, 3 };
            CollectionAssert.AreEqual(arrTest, nums.ToArray());
        }

        [TestMethod]
        public void To_Array_Empty()
        {
            var dates = new LinkedStack<DateTime>();
            var arrTest = new DateTime[0];

            CollectionAssert.AreEqual(arrTest, dates.ToArray());
        }
    }
}