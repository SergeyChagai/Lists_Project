using DataStructures;
using NUnit.Framework;
using System;

namespace DataStructures.Tests
{
    public class Tests
    {
       
        [TestCase(1, 2, 3)]
        [TestCase(1, 3, 4)]
        [TestCase(1, 0, 1)]
        [TestCase(1, 4, 5)]
        public void GetByIndex(int case_of_list, int index, int expected)
        {
            DoubleLinkedList list = DoubleLinkedListMock(case_of_list);
            int actual = list[index];
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2, 3)]
        [TestCase(1, 3, 4)]
        [TestCase(1, 0, 1)]
        [TestCase(1, 4, 5)]
        public void GetNodeTest(int case_of_list, int index, int expected)
        {
            DoubleLinkedList doubleLinkedList = DoubleLinkedListMock(case_of_list);
            Node actual = doubleLinkedList.GetNode(index);
            Assert.AreEqual(expected, actual.Value);
            
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1)]
        [TestCase(new int[] { 5, 4, 3, 2, 1 }, 2)]
        [TestCase(new int[] { }, 3)]
        [TestCase(new int[] { 1 }, 4)]
        [TestCase(new int[] { 10, 5, 10, 20, 40, 30 }, 5)]
        public void ConstructorTest(int[] array, int case_of_list)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = DoubleLinkedListMock(case_of_list);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 0, 1)]
        [TestCase(2, 10, 2)]
        [TestCase(3, -10, 3)]
        [TestCase(4, int.MaxValue, 4)]
        [TestCase(5, int.MinValue, 5)]
        public void AddTest(int case_of_list, int value, int case_of_exp_list)
        {
            DoubleLinkedList expected = AddExpectedMock(case_of_exp_list);
            DoubleLinkedList actual = DoubleLinkedListMock(case_of_list);
            actual.Add(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 10, 20, 30 }, 1)]
        [TestCase(2, new int[] { -10, -20, -30 }, 2)]
        [TestCase(3, new int[] { 0 }, 3)]
        [TestCase(4, new int[] { int.MaxValue }, 4)]
        [TestCase(5, new int[] { int.MinValue }, 5)]
        public void AddArrayTest(int case_of_list, int[] arr, int case_of_exp_list)
        {
            DoubleLinkedList expected = AddArrayExpectedMock(case_of_exp_list);
            DoubleLinkedList actual = DoubleLinkedListMock(case_of_list);
            actual.Add(arr);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 10, 1)]
        [TestCase(2, 0, 2)]
        [TestCase(3, -10, 3)]
        [TestCase(4, int.MaxValue, 4)]
        [TestCase(5, int.MinValue, 5)]
        public void AddToOrigin(int case_of_list, int value, int case_of_expected)
        {
            DoubleLinkedList expected = AddToOriginExpectedMock(case_of_expected);
            DoubleLinkedList actual = DoubleLinkedListMock(case_of_list);
            actual.AddToOrigin(value);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(1, new int[] { 10, 20, 30 }, 1)]
        [TestCase(2, new int[] { -10, -20, -30 }, 2)]
        [TestCase(3, new int[] { 0 }, 3)]
        [TestCase(4, new int[] { int.MaxValue }, 4)]
        [TestCase(5, new int[] { int.MinValue }, 5)]
        public void AddArrayToOriginTest(int case_of_list, int[] arr, int case_of_exp_list)
        {
            DoubleLinkedList expected = AddArrayToOriginExpectedMock(case_of_exp_list);
            DoubleLinkedList actual = DoubleLinkedListMock(case_of_list);
            actual.AddToOrigin(arr);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2, 10, 1)]
        [TestCase(1, 0, 10, 6)]
        [TestCase(1, 5, 10, 7)]
        [TestCase(2, 2, -10, 2)]
        [TestCase(2, 0, -10, 8)]
        [TestCase(2, 5, -10, 9)]
        [TestCase(3, 0, 5, 3)]
        [TestCase(4, 0, int.MaxValue, 4)]
        [TestCase(5, 6, int.MinValue, 5)]
        public void AddToIndexTest(int case_of_list, int index, int value, int case_of_exp_list)
        {
            DoubleLinkedList expected = AddToIndexExpectedMock(case_of_exp_list);
            DoubleLinkedList actual = DoubleLinkedListMock(case_of_list);
            actual.AddToIndex(index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-10)]
        [TestCase(20)]
        public void AddToIndexNegativeTest(int index)
        {
            DoubleLinkedList doubleLinkedList = DoubleLinkedListMock(5);
            Assert.Throws<IndexOutOfRangeException>(() => doubleLinkedList.AddToIndex(index, 10));
        }

        [TestCase(1, 2, new int[] { 10, 20, 30 }, 1)]
        [TestCase(1, 0, new int[] { 10, 20, 30 }, 6)]
        [TestCase(1, 5, new int[] { 10, 20, 30 }, 7)]
        [TestCase(2, 2, new int[] { -10, -20, -30 }, 2)]
        [TestCase(2, 0, new int[] { -10 }, 8)]
        [TestCase(2, 5, new int[] { -10, -20, -30, -40, -50 }, 9)]
        [TestCase(3, 0, new int[] { 5, 10, 15 }, 3)]
        [TestCase(4, 0, new int[] { int.MaxValue, int.MaxValue }, 4)]
        [TestCase(4, 1, new int[] { int.MaxValue, int.MaxValue }, 10)]
        [TestCase(5, 6, new int[] { int.MaxValue, int.MaxValue }, 5)]
        public void AddArrayToIndexTest(int case_of_list, int index, int[] arr, int case_of_exp_list)
        {
            DoubleLinkedList expected = AddArrayToIndexExpectedMock(case_of_exp_list);
            DoubleLinkedList actual = DoubleLinkedListMock(case_of_list);
            actual.AddToIndex(index, arr);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1,1)]
        [TestCase(2,2)]
        [TestCase(4,4)]
        [TestCase(5,5)]
        public void DeleteTest(int case_of_list, int case_of_expected_list)
        {
            DoubleLinkedList expected = DeleteExpectedMock(case_of_expected_list);
            DoubleLinkedList actual = DoubleLinkedListMock(case_of_list);
            actual.Delete();
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(1,1)]
        [TestCase(2,2)]
        [TestCase(4,4)]
        [TestCase(5,5)]
        public void DeleteArrayTest(int case_of_list, int case_of_expected_list)
        {
            DoubleLinkedList expected = DeleteExpectedMock(case_of_expected_list);
            DoubleLinkedList actual = DoubleLinkedListMock(case_of_list);
            actual.Delete();
            Assert.AreEqual(expected, actual);
        }
        DoubleLinkedList DoubleLinkedListMock(int a)
        {
            DoubleLinkedList doubleLinkedList;
            switch (a)
            {
                case 1:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 1, 2, 3, 4, 5 });
                    return doubleLinkedList;
                case 2:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 5, 4, 3, 2, 1 });
                    return doubleLinkedList;
                case 3:
                    doubleLinkedList = new DoubleLinkedList(new int[] { });
                    return doubleLinkedList;
                case 4:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 1 });
                    return doubleLinkedList;
                case 5:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 10, 5, 10, 20, 40, 30 });
                    return doubleLinkedList;
                default:
                    throw new ArgumentException();
            }
        }
        DoubleLinkedList DeleteExpectedMock(int a)
        {
            DoubleLinkedList doubleLinkedList;
            switch (a)
            {
                case 1:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 1, 2, 3, 4});
                    return doubleLinkedList;
                case 2:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 5, 4, 3, 2 });
                    return doubleLinkedList;
                case 4:
                    doubleLinkedList = new DoubleLinkedList(new int[] { });
                    return doubleLinkedList;
                case 5:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 10, 5, 10, 20, 40});
                    return doubleLinkedList;
                default:
                    throw new ArgumentException();
            }
        }

        DoubleLinkedList AddArrayToIndexExpectedMock(int a)
        {
            DoubleLinkedList doubleLinkedList;
            switch (a)
            {
                case 1:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 1, 2, 10, 20, 30, 3, 4, 5 });
                    return doubleLinkedList;
                case 2:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 5, 4, -10, -20, -30, 3, 2, 1 });
                    return doubleLinkedList;
                case 3:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 5, 10, 15 });
                    return doubleLinkedList;
                case 4:
                    doubleLinkedList = new DoubleLinkedList(new int[] { int.MaxValue, int.MaxValue, 1 });
                    return doubleLinkedList;
                case 5:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 10, 5, 10, 20, 40, 30, int.MaxValue, int.MaxValue });
                    return doubleLinkedList;
                case 6:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 10, 20, 30, 1, 2, 3, 4, 5 });
                    return doubleLinkedList;
                case 7:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 1, 2, 3, 4, 5, 10, 20, 30 });
                    return doubleLinkedList;
                case 8:
                    doubleLinkedList = new DoubleLinkedList(new int[] { -10, 5, 4, 3, 2, 1 });
                    return doubleLinkedList;
                case 9:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 5, 4, 3, 2, 1, -10, -20, -30, -40, -50 });
                    return doubleLinkedList;
                case 10:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 1, int.MaxValue, int.MaxValue });
                    return doubleLinkedList;
                default:
                    throw new ArgumentException();
            }
        }
        DoubleLinkedList AddToIndexExpectedMock(int a)
        {
            DoubleLinkedList doubleLinkedList;
            switch (a)
            {
                case 1:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 1, 2, 10, 3, 4, 5 });
                    return doubleLinkedList;
                case 2:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 5, 4, -10, 3, 2, 1 });
                    return doubleLinkedList;
                case 3:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 5 });
                    return doubleLinkedList;
                case 4:
                    doubleLinkedList = new DoubleLinkedList(new int[] { int.MaxValue, 1 });
                    return doubleLinkedList;
                case 5:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 10, 5, 10, 20, 40, 30, int.MinValue });
                    return doubleLinkedList;
                case 6:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 10, 1, 2, 3, 4, 5 });
                    return doubleLinkedList;
                case 7:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 1, 2, 3, 4, 5, 10 });
                    return doubleLinkedList;
                case 8:
                    doubleLinkedList = new DoubleLinkedList(new int[] { -10, 5, 4, 3, 2, 1 });
                    return doubleLinkedList;
                case 9:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 5, 4, 3, 2, 1, -10 });
                    return doubleLinkedList;
                default:
                    throw new ArgumentException();
            }
        }

        DoubleLinkedList AddArrayToOriginExpectedMock(int a)
        {
            DoubleLinkedList doubleLinkedList;
            switch (a)
            {
                case 1:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 10, 20, 30, 1, 2, 3, 4, 5 });
                    return doubleLinkedList;
                case 2:
                    doubleLinkedList = new DoubleLinkedList(new int[] { -10, -20, -30, 5, 4, 3, 2, 1 });
                    return doubleLinkedList;
                case 3:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 0 });
                    return doubleLinkedList;
                case 4:
                    doubleLinkedList = new DoubleLinkedList(new int[] { int.MaxValue, 1  });
                    return doubleLinkedList;
                case 5:
                    doubleLinkedList = new DoubleLinkedList(new int[] { int.MinValue, 10, 5, 10, 20, 40, 30 });
                    return doubleLinkedList;
                default:
                    throw new ArgumentException();
            }
        }

        DoubleLinkedList AddToOriginExpectedMock(int a)
        {
            DoubleLinkedList doubleLinkedList;
            switch (a)
            {
                case 1:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 10, 1, 2, 3, 4, 5 });
                    return doubleLinkedList;
                case 2:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 0, 5, 4, 3, 2, 1 });
                    return doubleLinkedList;
                case 3:
                    doubleLinkedList = new DoubleLinkedList(new int[] { -10 });
                    return doubleLinkedList;
                case 4:
                    doubleLinkedList = new DoubleLinkedList(new int[] { int.MaxValue, 1 });
                    return doubleLinkedList;
                case 5:
                    doubleLinkedList = new DoubleLinkedList(new int[] { int.MinValue, 10, 5, 10, 20, 40, 30 });
                    return doubleLinkedList;
                default:
                    throw new ArgumentException();
            }
        }
        DoubleLinkedList AddArrayExpectedMock(int a)
        {
            DoubleLinkedList doubleLinkedList;
            switch (a)
            {
                case 1:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 1, 2, 3, 4, 5, 10, 20, 30 });
                    return doubleLinkedList;
                case 2:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 5, 4, 3, 2, 1, -10, -20, -30 });
                    return doubleLinkedList;
                case 3:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 0 });
                    return doubleLinkedList;
                case 4:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 1, int.MaxValue });
                    return doubleLinkedList;
                case 5:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 10, 5, 10, 20, 40, 30, int.MinValue });
                    return doubleLinkedList;
                default:
                    throw new ArgumentException();
            }
        }
        DoubleLinkedList AddExpectedMock(int a)
        {
            DoubleLinkedList doubleLinkedList;
            switch (a)
            {
                case 1:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 1, 2, 3, 4, 5, 0});
                    return doubleLinkedList;
                case 2:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 5, 4, 3, 2, 1, 10});
                    return doubleLinkedList;
                case 3:
                    doubleLinkedList = new DoubleLinkedList(new int[] { -10 });
                    return doubleLinkedList;
                case 4:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 1, int.MaxValue });
                    return doubleLinkedList;
                case 5:
                    doubleLinkedList = new DoubleLinkedList(new int[] { 10, 5, 10, 20, 40, 30, int.MinValue });
                    return doubleLinkedList;
                default:
                    throw new ArgumentException();
            }
        }
    }
}