using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;

namespace ArrayList.Tests
{
    public class Tests
    {
        [TestCase(1,1)]
        [TestCase(1,1)]
        [TestCase(1,1)]
        [TestCase(1,1)]
        public void Add(int case_arr, int case_expected_arr)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_arr));
            ArrayList expected = new ArrayList(ArrayExpectedMock(case_expected_arr));

            arr.Add(10);

            Assert.AreEqual(expected, arr);
        }

        [TestCase(1, new int[] { 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(1, new int[] { }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public void Add(int case_arr, int[] add, int[] expected)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_arr));
            ArrayList arr2 = new ArrayList(expected);

            arr.Add(add);

            Assert.AreEqual(arr2, arr);
        }

        [TestCase(1, new int[] { 10, 1, 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 10, 5, 4, 3, 2, 1 })]
        [TestCase(3, new int[] { 10, 999, 888, 777, 666, 555, 444, 333, 222, 111 })]
        [TestCase(4, new int[] { 10 })]
        public void AddToOrigin(int case_arr, int[] expected)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_arr));
            ArrayList arr2 = new ArrayList(expected);

            arr.AddToOrigin(10);

            Assert.AreEqual(arr2, arr);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 7 }, new int[] { 6, 7, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 200, 400 }, new int[] { 200, 400, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 8, 9 }, new int[] { 3, 8, 9, 1, 2, 3, 4, 5 })]
        public void AddToOrigin(int[] array, int[] add, int[] expected)
        {
            ArrayList arr = new ArrayList(array);
            ArrayList arr2 = new ArrayList(expected);

            arr.AddToOrigin(add);

            Assert.AreEqual(arr2, arr);
        }

        [TestCase(1, 0, new int[] { 10, 1, 2, 3, 4, 5 })]
        [TestCase(1, 5, new int[] { 1, 2, 3, 4, 5, 10})]
        public void AddToIndex(int case_arr, int index, int[] expected)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_arr));
            ArrayList arr2 = new ArrayList(expected);

            arr.AddToIndex(index, 10);

            Assert.AreEqual(arr2, arr);
        }

        [TestCase(-1, 0)]
        public void AddToIndexNegative( int index, int number)
        {
            ArrayList arr = new ArrayList(ArrayMock(1));

            try { arr.AddToIndex(index, number); }
            catch { Assert.Pass(); }
            Assert.Fail();
        }

        [TestCase(2, new int[] { 6, 7 }, new int[] { 1, 2, 6, 7, 3, 4, 5 })]
        [TestCase(1, new int[] { 200, 400 }, new int[] { 1, 200, 400, 2, 3, 4, 5 })]

        public void AddToIndex(int index, int[] add, int[] expected)
        {
            ArrayList arr = new ArrayList(new int[] { 1, 2, 3, 4, 5 });
            ArrayList arr2 = new ArrayList(expected);

            arr.AddToIndex(index, add);

            Assert.AreEqual(arr2, arr);

        }

        [TestCase(-1, new int[] { 6, 7 })]
        public void AddToIndexNegative(int index, int[] add)
        {
            ArrayList arr1 = new ArrayList(new int[] { 1, 2, 3, 4, 5 });

            try { arr1.AddToIndex(index, add); }
            catch { Assert.Pass(); }
            Assert.Fail();
        }

        [TestCase(1, new int[] { 1, 2, 3, 4})]
        [TestCase(2, new int[] { 5, 4, 3, 2})]
        [TestCase(3, new int[] { 999, 888, 777, 666, 555, 444, 333, 222})]
        [TestCase(5, new int[] { })]
        [TestCase(4, new int[] { })]
        public void Delete(int case_arr, int[] expected)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_arr));
            ArrayList arr2 = new ArrayList(expected);

            arr.Delete();

            Assert.AreEqual(arr2, arr);

        }

        [TestCase(1, 1, new int[] { 1, 2, 3, 4})]
        [TestCase(1, 2, new int[] { 1, 2, 3})]
        [TestCase(2, 0, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(3, 9, new int[] {  })]
        [TestCase(4, 5, new int[] {  })]
        [TestCase(5, 100, new int[] {  })]
        public void Delete(int case_arr, int amount, int[] expected)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_arr));
            ArrayList arr2 = new ArrayList(expected);

            arr.Delete(amount);

            Assert.AreEqual(arr2, arr);

        }


        [TestCase(1, new int[] { 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 4, 3, 2, 1 })]
        [TestCase(3, new int[] { 888, 777, 666, 555, 444, 333, 222, 111 })]
        [TestCase(5, new int[] { })]
        public void DeleteFromOrigin(int case_arr, int[] expected)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_arr));
            ArrayList arr2 = new ArrayList(expected);

            arr.DeleteFromOrigin();

            Assert.AreEqual(arr2, arr);

        }

        [TestCase(1, 2, new int[] { 3, 4, 5 })]
        [TestCase(2, 0, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(3, 9, new int[] { })]
        public void DeleteFromOrigin(int case_arr, int amount, int[] expected)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_arr));
            ArrayList arr2 = new ArrayList(expected);

            arr.DeleteFromOrigin(amount);

            Assert.AreEqual(arr2, arr);

        }

        //[TestCase(1)]
        //[TestCase(2)]
        //public void DeleteFromOriginNegative(int case_of_override)
        //{
        //    if (case_of_override == 1)                                  //тестирование метода DeleteFromOrigin()
        //    {
        //        ArrayList arr = new ArrayList(new int[] { });
        //        try { arr.DeleteFromOrigin(); }
        //        catch { Assert.Pass(); }
        //        Assert.Fail();

        //    }
        //    if (case_of_override == 2)                                  //тестирование метода DeleteFromOrigin(int[] )
        //    {
        //        ArrayList arr = new ArrayList(new int[] { 1, 2, 3 });
        //        try { arr.DeleteFromOrigin(5); }
        //        catch { Assert.Pass(); }
        //        Assert.Fail();

        //    }
        //}


        [TestCase(1, 2, new int[] { 1, 2, 4, 5 })]
        [TestCase(1, 0, new int[] { 2, 3, 4, 5 })]
        [TestCase(1, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(5, 0, new int[] { })]
        public void DeleteFromIndex(int case_arr, int index, int[] expected)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_arr));
            ArrayList arr2 = new ArrayList(expected);

            arr.DeleteFromIndex(index);

            Assert.AreEqual(arr2, arr);

        }

        [TestCase(1, 2, 2, new int[] { 1, 2, 5 })]
        [TestCase(1, 0, 0, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, 4, 1, new int[] { 1, 2, 3, 4 })]
        [TestCase(5, 0, 1, new int[] { })]
        [TestCase(1, 4, 6, new int[] { 1, 2, 3, 4})]
        [TestCase(2, 0, 6, new int[] { })]

        public void DeleteFromIndex(int case_arr, int index, int amount, int[] expected)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_arr));
            ArrayList arr2 = new ArrayList(expected);

            arr.DeleteFromIndex(index, amount);

            Assert.AreEqual(arr2, arr);

        }

        [TestCase(1, -1)]
        [TestCase(1, 1000)]
        [TestCase(2, -1)]
        [TestCase(2, 1000)]
        public void DeleteFromIndexNegative(int case_of_override, int index)
        {
            if (case_of_override == 1)
            {
                ArrayList arr = new ArrayList();

                try { arr.DeleteFromIndex(index); }
                catch (IndexOutOfRangeException){ Assert.Pass(); }
                Assert.Fail();
            }
            if (case_of_override == 2)
            {
                ArrayList arr = new ArrayList();

                try { arr.DeleteFromIndex(index, 1); }
                catch (IndexOutOfRangeException) { Assert.Pass(); }
                Assert.Fail();
            }
        }

        [TestCase(1,5)]
        [TestCase(2,5)]
        [TestCase(3,9)]
        [TestCase(4,0)]
        [TestCase(5,1)]
        public void Length(int case_of_mock, int expected)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_of_mock));

            Assert.AreEqual(expected, arr.Length);
        }

        [TestCase(1, 0, 1)]
        [TestCase(2, 1, 4)]
        [TestCase(3, 5, 444)]
        public void AccessToIndex(int case_of_arr, int index, int expected)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_of_arr));

            Assert.AreEqual(expected, arr[index]);
        }


        [TestCase(1, 6)]
        [TestCase(1, -1)]
        public void AccessToIndexNegative(int case_of_arr, int index)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_of_arr));

            try { arr[index] = 1; }
            catch { Assert.Pass(); }
            Assert.Fail();
        }

        [TestCase(1, 5, 4)]
        [TestCase(1, 1, 0)]
        [TestCase(5, 1, 0)]
        public void IndexOfElement(int case_of_arr, int element, int expected)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_of_arr));
            int actual = arr.IndexOfElement(element);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, -1)]
        [TestCase(1, 6)]
        public void IndexOfElementNegative(int case_of_arr, int element)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_of_arr));

            try { arr.IndexOfElement(element); }
            catch (ArgumentException) { Assert.Pass(); }
            Assert.Fail();
        }

        [TestCase(1, 4, 9, new int[] { 1, 2, 3, 4, 9 })]
        [TestCase(1, 2, 10, new int[] { 1, 2, 10, 4, 5 })]
        [TestCase(1, 0, 10, new int[] { 10, 2, 3, 4, 5 })]
        [TestCase(1, 5, 9, new int[] { 1, 2, 3, 4, 5, 9 })]
        public void SetElement(int case_of_arr, int index, int value, int[] expected_arr)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_of_arr));
            ArrayList expected = new ArrayList(expected_arr);

            arr.SetElement(index, value);

            Assert.AreEqual(expected, arr);
        }

        [TestCase(1, -1)]
        [TestCase(1, 10)]
        public void SetElementNegative(int case_of_arr, int index)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_of_arr));

            try { arr.SetElement(index, 1); }
            catch (ArgumentOutOfRangeException) { Assert.Pass(); }
            Assert.Fail();
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        public void Reverse(int case_of_arr, int case_of_reverse_arr)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_of_arr));
            ArrayList expected = new ArrayList(ReverseMock(case_of_reverse_arr));

            arr.Reverse();

            Assert.AreEqual(expected, arr);
        }

       
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 111)]
        [TestCase(5, 1)]
        public void FindMin(int case_of_arr, int expected)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_of_arr));
            int actual = arr.FindMin();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindMinNegative()
        {
            ArrayList arr = new ArrayList();

            try { arr.FindMin(); }
            catch { Assert.Pass(); }
            Assert.Fail();
        }

        [TestCase(1, 5)]
        [TestCase(2, 5)]
        [TestCase(3, 999)]
        [TestCase(5, 1)]
        public void FindMax(int case_of_arr, int expected)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_of_arr));
            int actual = arr.FindMax();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindMaxNegative()
        {
            ArrayList arr = new ArrayList();

            try { arr.FindMax(); }
            catch { Assert.Pass(); }
            Assert.Fail();
        }

        [TestCase(1, 4)]
        [TestCase(2, 0)]
        [TestCase(3, 0)]
        [TestCase(5, 0)]
        [TestCase(6, 0)]
        public void IndexOfMax(int case_of_arr, int expected)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_of_arr));
            int actual = arr.IndexOfMax();

            Assert.AreEqual(expected, actual);
        }
    
        [Test]
        public void IndexOfMaxNegative()
        {
            ArrayList arr = new ArrayList();
            try { int actual = arr.IndexOfMax(); }
            catch { Assert.Pass(); }
            Assert.Fail();
        }

        [TestCase(1, 0)]
        [TestCase(2, 4)]
        [TestCase(3, 8)]
        [TestCase(5, 0)]
        [TestCase(6, 1)]
        public void IndexOfMin(int case_of_arr, int expected)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_of_arr));
            int actual = arr.IndexOfMin();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IndexOfMinNegative()
        {
            ArrayList arr = new ArrayList();
            try { int actual = arr.IndexOfMin(); }
            catch { Assert.Pass(); }
            Assert.Fail();
        }


        [TestCase(2, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(3, new int[] { 111, 222, 333, 444, 555, 666, 777, 888, 999 })]
        [TestCase(4, new int[] { })]
        [TestCase(5, new int[] { 1 })]
        [TestCase(7, new int[] { 3, 5, 7, 10, 10, 11 })]
        public void SortIncrease(int case_of_arr, int[] expected_arr)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_of_arr));
            ArrayList expected = new ArrayList(expected_arr);

            arr.SortIncrease();

            Assert.AreEqual(expected, arr);

        }

        [TestCase(2, new int[] { 5,4,3,2,1})]
        [TestCase(3, new int[] { 999, 888, 777, 666, 555, 444, 333, 222, 111 })]
        [TestCase(4, new int[] { })]
        [TestCase(5, new int[] { 1 })]
        [TestCase(7, new int[] { 11, 10, 10, 7, 5, 3 })]
        public void SortDecrease(int case_of_arr, int[] expected_arr)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_of_arr));
            ArrayList expected = new ArrayList(expected_arr);

            arr.SortDecrease();

            Assert.AreEqual(expected, arr);
        }

        [TestCase(1, 4, new int[] { 1, 2, 3, 5 })]
        [TestCase(2, 1, new int[] { 5, 4, 3, 2 })]
        [TestCase(3, 222, new int[] { 999, 888, 777, 666, 555, 444, 333, 111 })]
        [TestCase(5, 1, new int[] { })]
        [TestCase(6, 10, new int[] { 5, 10 })]
        [TestCase(6, 20, new int[] { 10, 5, 10 })]

        public void DeleteFirstElementWhithValue(int case_of_arr, int value, int[] expected_arr)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_of_arr));
            ArrayList expected = new ArrayList(expected_arr);

            arr.DeleteFirstElementWhithValue(value);

            Assert.AreEqual(expected, arr);
        }


        [TestCase(1, 4, new int[] { 1, 2, 3, 5 })]
        [TestCase(2, 1, new int[] { 5, 4, 3, 2 })]
        [TestCase(3, 222, new int[] { 999, 888, 777, 666, 555, 444, 333, 111 })]
        [TestCase(6, 10, new int[] { 5 })]
        [TestCase(5, 1, new int[] { })]
        [TestCase(5, 10, new int[] { 1 })]
        public void DeleteAllElementsWhithValue(int case_of_arr, int value, int[] expected_arr)
        {
            ArrayList arr = new ArrayList(ArrayMock(case_of_arr));
            ArrayList expected = new ArrayList(expected_arr);

            arr.DeleteAllElementsWhithValue(value);

            Assert.AreEqual(expected, arr);

        }


        [Test]
        public void Test20()
        {
            ArrayList arr = new ArrayList();
            ArrayList expected = new ArrayList();

            int[] adding_arr = new int[] { 3, 4 };
            arr.Add(1);
            arr.Add(2);
            arr.AddToOrigin(adding_arr);

            expected.Add(3);
            expected.Add(4);
            expected.Add(1);
            expected.Add(2);
            Assert.AreEqual(expected, arr);
        }





        private int[] ArrayMock(int i)
        {
            int[] arr;

            switch(i)
            {
                case 1:
                    arr = new int[] { 1, 2, 3, 4, 5 };
                    return arr;
                case 2:
                    arr = new int[] { 5, 4, 3, 2, 1 };
                    return arr;
                case 3:
                    arr = new int[] { 999, 888, 777, 666, 555, 444, 333, 222, 111 };
                    return arr;
                case 4:
                    arr = new int[] { };
                    return arr;
                case 5:
                    arr = new int[] { 1 };
                    return arr;
                case 6:
                    arr = new int[] { 10, 5, 10 };
                    return arr;
                case 7:
                    arr = new int[] { 11, 7, 3, 10, 5, 10 };
                    return arr;
                default:
                    throw new Exception("Invalid value of parameter");
            }
        }

        private int[] ArrayExpectedMock(int i)
        {
            int[] arr;

            switch (i)
            {
                case 1:
                    arr = new int[] { 1, 2, 3, 4, 5, 10 };
                    return arr;
                case 2:
                    arr = new int[] { 5, 4, 3, 2, 1, 10};
                    return arr;
                case 3:
                    arr = new int[] { 999, 888, 777, 666, 555, 444, 333, 222, 111, 10 };
                    return arr;
                case 4:
                    arr = new int[] { 10 };
                    return arr;
                case 7:
                    arr = new int[] { 3, 5, 7, 10, 10, 11 };
                    return arr;
                default:
                    throw new Exception("Invalid value of parameter");
            }
        }

        private int[] ReverseMock(int i)
        {
            int[] arr;
            switch (i)
            {
                case 1:
                    arr = new int[] { 5, 4, 3, 2, 1 };
                    return arr;
                case 2:
                    arr = new int[] { 1, 2, 3, 4, 5 };
                    return arr;
                case 3:
                    arr = new int[] { 111, 222, 333, 444, 555, 666, 777, 888, 999 };
                    return arr;
                case 4:
                    arr = new int[] { };
                    return arr;
                case 5:
                    arr = new int[] { 1 };
                    return arr;
                default:
                    throw new ArgumentOutOfRangeException("Parameters should be in 1-5");
            }
        }
    }
}