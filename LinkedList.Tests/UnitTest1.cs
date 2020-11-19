using DataStructures;
using NUnit.Framework;
using System;

namespace Linked_List.Tests
{
    public class Tests
    {
        [TestCase(1, 0, 1)]
        [TestCase(1, 1, 2)]
        [TestCase(1, 2, 3)]
        [TestCase(1, 3, 4)]
        [TestCase(1, 4, 5)]
        public void GetByIndexTest(int case_of_list, int index, int expected)
        {
            LinkedList list = LinkedListMock(case_of_list);
            int actual = list[index];
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, -1)]
        [TestCase(1, 1000)]
        public void GetByIndexNegativeTest(int case_of_list, int index)
        {
            LinkedList list = LinkedListMock(case_of_list);
            int a;
            Assert.Throws<IndexOutOfRangeException>(() =>  a = list[index]) ;
        }

        [TestCase(1, 0, 10, 1)]
        [TestCase(1, 0, -10, 6)]
        [TestCase(2, 4, 10, 2)]
        [TestCase(3, 0, 10, 3)]
        [TestCase(4, 1, 10, 4)]
        [TestCase(5, 6, 10, 5)]
        public void SetToIndexTest(int case_of_list, int index, int value, int case_of_exp_list)
        {
            LinkedList expected = SetToIndexExpectedMock(case_of_exp_list);
            LinkedList actual = LinkedListMock(case_of_list);

            actual[index] = value;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, -1)]
        [TestCase(1, 1000)]
        public void SetToIndexNegativeTest(int case_of_list, int index)
        {
            LinkedList list = LinkedListMock(case_of_list);
            Assert.Throws<IndexOutOfRangeException>(() => list[index] = 1);
        }


        [TestCase(1, 10, 1)]
        [TestCase(2, 0, 2)]
        [TestCase(3, int.MaxValue, 3)]
        [TestCase(4, int.MinValue, 4)]
        [TestCase(5, -10, 5)]
        public void AddTest(int case_of_list, int value, int case_of_exp_list)
        {
            LinkedList expected = AddExpectedMock(case_of_exp_list);
            LinkedList actual = LinkedListMock(case_of_list);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 10, 20 }, 1)]
        [TestCase(2, new int[] { }, 2)]
        [TestCase(3, new int[] { 10, 20}, 3)]
        [TestCase(4, new int[] { int.MaxValue, int.MinValue }, 4)]
        public void AddTest(int case_of_list, int[] array, int case_of_exp_list)
        {
            LinkedList expected = AddArrayMock(case_of_exp_list);
            LinkedList actual = LinkedListMock(case_of_list);

            actual.Add(array);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 10, 1)]
        [TestCase(2, int.MaxValue, 2)]
        [TestCase(4, int.MinValue, 4)]
        public void AddToOriginTest(int case_of_list, int n, int case_of_exp_list)
        {
            LinkedList expected = AddToOriginExpectedMock(case_of_exp_list);
            LinkedList actual = LinkedListMock(case_of_list);

            actual.AddToOrigin(n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 10, 20, 30}, 1)]
        [TestCase(2, new int[] { 30, 20, 10}, 2)]
        [TestCase(3, new int[] { }, 3)]
        [TestCase(4, new int[] { 10 }, 4)]
        [TestCase(5, new int[] { int.MaxValue, int.MinValue }, 5)]
        public void AddArrayToOriginTest(int case_of_list, int[] arr, int case_of_exp_list)
        {
            LinkedList expected = AddArrayToOriginExpectedMock(case_of_exp_list);
            LinkedList actual = LinkedListMock(case_of_list);

            actual.AddToOrigin(arr);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2, 10, 1)]
        [TestCase(2, 0, 10, 2)]
        [TestCase(5, 6, 100, 5)]
        public void AddToIndexTest(int case_of_list, int index, int n, int case_of_exp_list)
        {
            LinkedList expected = AddToIndexExpectedMock(case_of_exp_list);
            LinkedList actual = LinkedListMock(case_of_list);

            actual.AddToIndex(index, n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2, new int[] { 10, 20, 30 }, 1)]
        [TestCase(1, 5, new int[] { 10, 20, 30 }, 6)]
        [TestCase(1, 4, new int[] { 10, 20, 30 }, 7)]
        [TestCase(1, 0, new int[] { }, 8)]
        [TestCase(2, 0, new int[] { 10, 20, 30 }, 2)]
        [TestCase(3, 0, new int[] { }, 3)]
        [TestCase(4, 1, new int[] { 10, 20, 30 }, 4)]
        [TestCase(5, 2, new int[] { int.MaxValue, int.MinValue, 0 }, 5)]
        public void AddArrayToIndexTest(int case_of_list, int index, int[] arr, int case_of_exp_list)
        {
            LinkedList expected = AddArrayToIndexExpectedMock(case_of_exp_list);
            LinkedList actual = LinkedListMock(case_of_list);

            actual.AddToIndex(index, arr);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(4, 4)]
        [TestCase(3, 3)]
        [TestCase(5, 5)]
        public void DeleteTest(int case_of_list, int case_of_expected_list)
        {
            LinkedList expected = DeleteExpectedMock(case_of_expected_list);
            LinkedList actual =  LinkedListMock(case_of_list);

            actual.Delete();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(1, 3, 1)]
        [TestCase(2, 0, 2)]
        [TestCase(3, 0, 3)]
        [TestCase(4, 1, 4)]
        [TestCase(5, 6, 5)]
        public void DeleteTest(int case_of_list, int num, int case_of_expected_list)
        {
            LinkedList expected = DeleteNElementsExpectedMock(case_of_expected_list);
            LinkedList actual = LinkedListMock(case_of_list);

            actual.Delete(num);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        public void DeleteFromOriginTest(int case_of_list, int case_of_expected_list)
        {
            LinkedList expected = DeleteFromOriginMock(case_of_expected_list);
            LinkedList actual = LinkedListMock(case_of_list);

            actual.DeleteFromOrigin();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2, 1)]
        [TestCase(2, 10, 2)]
        [TestCase(3, 0, 3)]
        [TestCase(4, 1, 4)]
        [TestCase(5, 3, 5)]
        public void DeleteFromOriginTest(int case_of_list, int num, int case_of_expected_list)
        {
            LinkedList expected = DeleteFromOriginNElementsMock(case_of_expected_list);
            LinkedList actual = LinkedListMock(case_of_list);

            actual.DeleteFromOrigin(num);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2, 1)]
        [TestCase(2, 0, 2)]
        [TestCase(2, 4, 6)]
        [TestCase(4, 0, 4)]
        [TestCase(5, 4, 8)]
        [TestCase(5, 0, 5)]
        [TestCase(5, 5, 7)]
        public void DeleteFromIndexTest(int case_of_list, int index, int case_of_expected_list)
        {
            LinkedList expected = DeleteFromIndexMock(case_of_expected_list);
            LinkedList actual = LinkedListMock(case_of_list);

            actual.DeleteFromIndex(index);
            Assert.AreEqual(expected, actual);
        }

        
        [TestCase(1, 1, 2, 1)]
        [TestCase(2, 0, 2, 2)]
        [TestCase(3, 0, 0, 3)]
        [TestCase(4, 0, 1, 4)]
        [TestCase(5, 5, 1, 5)]
        [TestCase(5, 5, 20, 5)]
        public void DeleteNElementsFromIndexTest(int case_of_list, int index, int num, int case_of_expected_list)
        {
            LinkedList expected = DeleteNElementsFromIndexMock(case_of_expected_list);
            LinkedList actual = LinkedListMock(case_of_list);

            actual.DeleteFromIndex(index, num);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 10)]
        [TestCase(1, -10)]
        [TestCase(3, 0)]
        public void DeleteFromIndexNegativeTest(int case_of_list, int index)
        {
            LinkedList list = LinkedListMock(case_of_list);

            Assert.Throws<NullReferenceException>(() => list.DeleteFromIndex(index));
            Assert.Throws<NullReferenceException>(() => list.DeleteFromIndex(index, 20));
        }

        [TestCase(1, 5, 4)]
        [TestCase(1, 1, 0)]
        [TestCase(1, 3, 2)]
        public void IndexOfElementTest(int case_of_list, int element, int expected)
        {
            LinkedList list = LinkedListMock(case_of_list);
            int actual = list.IndexOfElement(element);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 10)]
        [TestCase(1, 0)]
        public void IndexOfElementNegativeTest(int case_of_list, int element)
        {
            LinkedList list = LinkedListMock(case_of_list);
            int actual;

            Assert.Throws<Exception>(() => actual = list.IndexOfElement(element));
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        public void ReverseTest(int case_of_list, int case_of_expected_list)
        {
            LinkedList expected = ReverseExpectedMock(case_of_expected_list);
            LinkedList actual = LinkedListMock(case_of_list);

            actual.Reverse();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        public void ReverseOptimalTest(int case_of_list, int case_of_expected_list)
        {
            LinkedList expected = ReverseExpectedMock(case_of_expected_list);
            LinkedList actual = LinkedListMock(case_of_list);

            actual.ReverseOptimal();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 5)]
        [TestCase(2, 5)]
        [TestCase(4, 1)]
        [TestCase(5, 40)]
        public void FindMaxTest(int case_of_list, int expected)
        {
            LinkedList list = LinkedListMock(case_of_list);
            int actual = list.FindMax();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(4, 1)]
        [TestCase(5, 5)]
        public void FindMinTest(int case_of_list, int expected)
        {
            LinkedList list = LinkedListMock(case_of_list);
            int actual = list.FindMin();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 0)]
        [TestCase(2, 4)]
        [TestCase(4, 0)]
        [TestCase(5, 1)]
        public void IndexOfMinTest(int case_of_list, int expected)
        {
            LinkedList list = LinkedListMock(case_of_list);
            int actual = list.IndexOfMin();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 4)]
        [TestCase(2, 0)]
        [TestCase(4, 0)]
        [TestCase(5, 4)]
        public void IndexOfMaxTest(int case_of_list, int expected)
        {
            LinkedList list = LinkedListMock(case_of_list);
            int actual = list.IndexOfMax();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1, 2, 1)]
        [TestCase(1, 0, 4, 2)]
        [TestCase(2, 1, 2, 3)]
        [TestCase(2, 0, 4, 4)]
        [TestCase(4, 0, 0, 5)]
        public void SwapTest(int case_of_list, int index1, int index2, int case_of_expected_list)
        {
            LinkedList actual = LinkedListMock(case_of_list);
            LinkedList expected = SwapExpectedMock(case_of_expected_list);
            actual.Swap(index1, index2);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 4)]
        [TestCase(5, 5)]

        public void SortIncreaseTest(int case_of_list, int case_of_expected_list)
        {
            LinkedList actual = LinkedListMock(case_of_list);
            LinkedList expected = SortIncreaseExpectedMock(case_of_expected_list);
            actual.SortIncrease();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        public void SortDecreaseTest(int case_of_list, int case_of_expected_list)
        {
            LinkedList actual = LinkedListMock(case_of_list);
            LinkedList expected = SortDecreaseExpectedMock(case_of_expected_list);
            actual.SortDecrease();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 3, 1)]
        [TestCase(2, 2, 2)]
        [TestCase(2, 5, 3)]
        [TestCase(4, 1, 4)]
        [TestCase(5, 10, 5)]
        public void DeleteElementWithValueTest(int case_of_list, int value, int case_of_expected_list)
        {
            LinkedList actual = LinkedListMock(case_of_list);
            LinkedList expected = DeleteElementWithValueExpectedMock(case_of_expected_list);
            actual.DeleteElementWithValue(value);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DeleteElementWithValueNegativeTest()
        {
            LinkedList list = LinkedListMock(3);
            Assert.Throws<Exception>(() => list.DeleteElementWithValue(0));
        }

        [TestCase(1, 3, 1)]
        [TestCase(2, 2, 2)]
        [TestCase(2, 5, 3)]
        [TestCase(4, 1, 4)]
        [TestCase(5, 10, 5)]
        public void DeleteAllElementsWithValueTest(int case_of_list, int value, int case_of_expected_list)
        {
            LinkedList actual = LinkedListMock(case_of_list);
            LinkedList expected = DeleteAllElementsWithValueExpectedMock(case_of_expected_list);
            actual.DeleteAllElementsWithValue(value);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DeleteAllElementsWithValueNegativeTest()
        {
            LinkedList list = LinkedListMock(3);
            Assert.Throws<Exception>(() => list.DeleteAllElementsWithValue(0));
        }

        public LinkedList LinkedListMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 1, 2, 3, 4, 5 });
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 5, 4, 3, 2, 1 });
                    return list;
                case 3:
                    list = new LinkedList(new int[] { });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { 1 });
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 10, 5, 10, 20, 40, 30 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }

        public LinkedList DeleteAllElementsWithValueExpectedMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 1, 2, 4, 5 });
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 5, 4, 3, 1 });
                    return list;
                case 3:
                    list = new LinkedList(new int[] { 4, 3, 2, 1 });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { });
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 5, 20, 40, 30 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }

        public LinkedList DeleteElementWithValueExpectedMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 1, 2, 4, 5 });
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 5, 4, 3, 1 });
                    return list;
                case 3:
                    list = new LinkedList(new int[] { 4, 3, 2, 1 });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { });
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 5, 10, 20, 40, 30 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }

        public LinkedList SortIncreaseExpectedMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 1, 2, 3, 4, 5 });
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 1, 2, 3, 4, 5 });
                    return list;
                case 3:
                    list = new LinkedList(new int[] { });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { 1 });
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 5, 10, 10, 20, 30, 40 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }

        public LinkedList SortDecreaseExpectedMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 5, 4, 3, 2, 1 });
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 5, 4, 3, 2, 1 });
                    return list;
                case 3:
                    list = new LinkedList(new int[] { });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { 1 });
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 40, 30, 20, 10, 10, 5 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }


        public LinkedList SwapExpectedMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 1, 3, 2, 4, 5 });
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 5, 2, 3, 4, 1 });
                    return list;
                case 3:
                    list = new LinkedList(new int[] { 5, 3, 4, 2, 1 });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { 1, 4, 3, 2, 5 });
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 1 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }

        public LinkedList ReverseExpectedMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 5, 4, 3, 2, 1 }); 
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 1, 2, 3, 4, 5 });
                    return list;
                case 3:
                    list = new LinkedList(new int[] { });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { 1 });
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 30, 40, 20, 10, 5, 10 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }


        public LinkedList DeleteNElementsFromIndexMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 1, 4, 5 });
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 3, 2, 1 });
                    return list;
                case 3:
                    list = new LinkedList(new int[] { });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { });
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 10, 5, 10, 20, 40 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }

        public LinkedList DeleteFromIndexMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 1, 2, 4, 5 });
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 4, 3, 2, 1 });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { });
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 5, 10, 20, 40, 30 });
                    return list;
                case 6:
                    list = new LinkedList(new int[] { 5, 4, 3, 2 });
                    return list;
                case 7:
                    list = new LinkedList(new int[] { 10, 5, 10, 20, 40 });
                    return list;
                case 8:
                    list = new LinkedList(new int[] { 10, 5, 10, 20, 30 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }

        public LinkedList DeleteFromOriginNElementsMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 3, 4, 5 });
                    return list;
                case 2:
                    list = new LinkedList(new int[] { });
                    return list;
                case 3:
                    list = new LinkedList(new int[] { });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { });
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 20, 40, 30 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }
        public LinkedList DeleteFromOriginMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 2, 3, 4, 5 });
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 4, 3, 2, 1 });
                    return list;
                case 3:
                    list = new LinkedList(new int[] { });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { });
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 5, 10, 20, 40, 30 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }
        public LinkedList DeleteNElementsExpectedMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 1, 2 });
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 5, 4, 3, 2, 1 });
                    return list;
                case 3:
                    list = new LinkedList(new int[] { });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { });
                    return list;
                case 5:
                    list = new LinkedList(new int[] { });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }
        public LinkedList DeleteExpectedMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 1, 2, 3, 4 });
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 5, 4, 3, 2 });
                    return list;
                case 3:
                    list = new LinkedList(new int[] { });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { });
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 10, 5, 10, 20, 40 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }

        public LinkedList AddArrayToIndexExpectedMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 1, 2, 10, 20, 30, 3, 4, 5 });
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 10, 20, 30, 5, 4, 3, 2, 1 });
                    return list;
                case 3:
                    list = new LinkedList(new int[] { });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { 1, 10, 20, 30 });
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 10, 5, int.MaxValue, int.MinValue, 0, 10, 20, 40, 30 });
                    return list;
                case 6:
                    list = new LinkedList(new int[] { 1, 2, 3, 4, 5, 10, 20, 30 });
                    return list;
                case 7:
                    list = new LinkedList(new int[] { 1, 2, 3, 4, 10, 20, 30, 5});
                    return list;
                case 8:
                    list = new LinkedList(new int[] { 1, 2, 3, 4, 5 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }
        public LinkedList AddToIndexExpectedMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 1, 2, 10, 3, 4, 5 });
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 10, 5, 4, 3, 2, 1 });
                    return list;
                case 3:
                    list = new LinkedList(new int[] { });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { 1 });
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 10, 5, 10, 20, 40, 30, 100 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }
        public LinkedList AddArrayToOriginExpectedMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 10, 20, 30, 1, 2, 3, 4, 5 });
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 30, 20, 10, 5, 4, 3, 2, 1 });
                    return list;
                case 3:
                    list = new LinkedList(new int[] { });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { 10, 1 });
                    return list;
                case 5:
                    list = new LinkedList(new int[] { int.MaxValue, int.MinValue, 10, 5, 10, 20, 40, 30 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }

        public LinkedList AddToOriginExpectedMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 10, 1, 2, 3, 4, 5 });
                    return list;
                case 2:
                    list = new LinkedList(new int[] { int.MaxValue, 5, 4, 3, 2, 1 });
                    return list;
                case 3:
                    list = new LinkedList(new int[] { });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { int.MinValue, 1 });
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 10, 5, 10, 20, 40, 30 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }

        public LinkedList AddArrayMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 1, 2, 3, 4, 5, 10, 20 });
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 5, 4, 3, 2, 1 });
                    return list;
                case 3:
                    list = new LinkedList(new int[] { 10, 20 });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { 1, int.MaxValue, int.MinValue});
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 10, 5, 10, 20, 40, 30 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }

        public LinkedList SetToIndexExpectedMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 10, 2, 3, 4, 5 });
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 5, 4, 3, 2, 10 });
                    return list;
                case 3:
                    list = new LinkedList(new int[] { 10 });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { 1, 10 });
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 10, 5, 10, 20, 40, 30, 10});
                    return list;
                case 6:
                    list = new LinkedList(new int[] { -10, 2, 3, 4, 5 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }

        public LinkedList AddExpectedMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 1, 2, 3, 4, 5, 10});
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 5, 4, 3, 2, 1, 0});
                    return list;
                case 3:
                    list = new LinkedList(new int[] { int.MaxValue });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { 1, int.MinValue});
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 10, 5, 10, 20, 40, 30, -10 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }
    }
}