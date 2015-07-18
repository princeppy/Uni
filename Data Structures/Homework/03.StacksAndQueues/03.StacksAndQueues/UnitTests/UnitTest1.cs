using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests;
using _03.ArrayBasedStack;

namespace ArrayStackTests
{
    [TestClass]
    public class ArrayStackTests
    {
        [TestMethod]
        public void PushAndPopElementAndCheckIfTheyAreEqualAndCheckTheArrayCount()
        {
            ArrayStack<int> arrayStack = new ArrayStack<int>();
            
            Assert.AreEqual(0, arrayStack.Count, string.Format(Messages.IncorrectArrayStackCount, arrayStack.Count, 0));

            int element = 10;

            arrayStack.Push(element);

            Assert.AreEqual(1, arrayStack.Count, string.Format(Messages.IncorrectArrayStackCount, arrayStack.Count, 1));

            var poppedElement = arrayStack.Pop();

            Assert.AreEqual(element, poppedElement, string.Format("{0} != {1}. Should be equal", element, poppedElement));

            Assert.AreEqual(0, arrayStack.Count, string.Format(Messages.IncorrectArrayStackCount, arrayStack.Count, 0));
        }

        [TestMethod]
        public void PushPop1000ElementsAndTestTheAutoGrow()
        {
            ArrayStack<string> arrayStack = new ArrayStack<string>();

            Assert.AreEqual(0, arrayStack.Count, string.Format(Messages.IncorrectArrayStackCount, arrayStack.Count, 0));

            int count = 1000;
            for (int i = 1; i <= count; i++)
            {
                arrayStack.Push(i.ToString());
                Assert.AreEqual(i, arrayStack.Count, string.Format(Messages.IncorrectArrayStackCount, arrayStack.Count, i));
            }

            for (int i = count - 1; i >= 0; i--)
            {
                var poppedElement = arrayStack.Pop();
                Assert.AreEqual(i, arrayStack.Count, string.Format(Messages.IncorrectArrayStackCount, arrayStack.Count, i));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
        "The stack is empty and you cannot pop an element!")]
        public void TryToPopFromEmptyStack()
        {
            ArrayStack<int> emptyArrayStack = new ArrayStack<int>();

            var poppedElement = emptyArrayStack.Pop();
        }

        [TestMethod]
        public void InitialCapacityOneAndPushAndPopAnElementAndCheckCount()
        {
            ArrayStack<int> arrayStack = new ArrayStack<int>(1);

            Assert.AreEqual(0, arrayStack.Count, string.Format(Messages.IncorrectArrayStackCount, arrayStack.Count, 0));


            int count = 2;

            for (int i = 1; i <= count; i++)
            {
                arrayStack.Push(i);
                Assert.AreEqual(i, arrayStack.Count, string.Format(Messages.IncorrectArrayStackCount, arrayStack.Count, i));
            }

            for (int i = count - 1; i >= 0; i--)
            {
                var poppedElement = arrayStack.Pop();
                Assert.AreEqual(i + 1, poppedElement, string.Format("{0} != {1}. Should be equal", i + 1, poppedElement));
            }

            Assert.AreEqual(0, arrayStack.Count, string.Format(Messages.IncorrectArrayStackCount, arrayStack.Count, 0));
        }

        [TestMethod]
        public void TestToArrayFunctionallity()
        {
            ArrayStack<int> stack = new ArrayStack<int>();

            int[] arrayInts = new int[] { 3, 5, -2, 7 };

            for (int i = 0; i < arrayInts.Length; i++)
            {
                stack.Push(arrayInts[i]);
            }

            var arrayFromStack = stack.ToArray();

            for (int i = 0; i < arrayFromStack.Length; i++)
            {
                Assert.AreEqual(arrayInts[arrayInts.Length-i-1], arrayFromStack[i], string.Format("{0}!={1}. Should be equal!",arrayInts[arrayInts.Length-i-1],arrayFromStack[i]));
            }
        }

        [TestMethod]
        public void EmptyStackToArray()
        {
            ArrayStack<int> stack = new ArrayStack<int>();

            var arrayFromStack = stack.ToArray();

            Assert.AreEqual(0, arrayFromStack.Length, "Should return empty array!" );
        }
    }
}
