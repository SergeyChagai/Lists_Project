using System;
using System.Reflection;
using System.Text;

namespace ArrayList
{
    public class ArrayList
    {
        private int[] _array;                       //поле массива
        public int Length { get; private set; }     //свойство объекта - полезная длина

        public ArrayList()                          //конструктор1
        {
            _array = new int[3];
            Length = 0;
        }

        public ArrayList(int n)                     //конструктор2
        {
            _array = new int[3];
            _array[0] = n;
            Length = 1;
        }

        public ArrayList(int[] arr)                 //конструктор3
        {
            _array = new int[arr.Length];
            Array.Copy(arr, _array, arr.Length);
            Length = arr.Length;
        }

        public override bool Equals(Object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Length != arrayList.Length)
                return false;

            for (int i = 0; i < Length; i++)
            {
                if (_array[i] != arrayList._array[i])
                    return false;
            }
            return true;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < Length; i++)
                s = s + _array[i] + ";";
            return s;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int this[int index]                  //переопределение индексатора
        {
            get
            {
                if (index > Length || index < 0)
                    throw new IndexOutOfRangeException();
                return _array[index];
            }
            set
            {
                if (index > Length || index < 0)
                    throw new IndexOutOfRangeException();
                _array[index] = value;
            }
        }

        public void Add(int n)                      //добавление числа в конец списка
        {
            if (Length >= _array.Length)
            {
                RizeSize();
            }
            this[Length] = n;
            Length++;
        }

        public void Add(int[] arr)                  //добавление нескольких чисел в конец списка
        {
            if (Length + arr.Length >= _array.Length)
                RizeSize(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                _array[Length + i] = arr[i];
            }
            Length += arr.Length;
        }


        public void AddToOrigin(int n)              //добавление числа в начало списка
        {
            while (Length >= _array.Length)
            {
                RizeSize();
            }
            for (int i = Length - 1; i >= 0; i--)
            {
                _array[i + 1] = _array[i];
            }
            _array[0] = n;
            Length++;
        }

        public void AddToOrigin(int[] arr)          //добавление нескольких чисел в начало списка
        {
            int add_length = arr.Length;
            while (Length + add_length >= _array.Length)
            {
                RizeSize(add_length);
            }
            for (int i = Length - 1; i >= 0; i--)
            {
                _array[i + add_length] = _array[i];
            }
            for (int i = 0; i < add_length; i++)
            {
                _array[i] = arr[i];
            }
            Length += add_length;
        }

        public void AddToIndex(int index, int n)
        {
            if (index < 0)
                throw new IndexOutOfRangeException("Index can not be negative");
            if (index > Length)
                throw new IndexOutOfRangeException("List does not contain an element with this index");
            while (Length >= _array.Length)
            {
                RizeSize();
            }
           for (int i = Length - 1; i >= index; i--)
            {
                _array[i + 1] = _array[i];
            }
            _array[index] = n;
            Length++;
        }

        public void AddToIndex(int index, int[] arr)
        {
            int add_length = arr.Length;
            if (index < 0)
                throw new IndexOutOfRangeException("Index can not be negative");
            if (index > Length)
                throw new IndexOutOfRangeException("List does not contain an element with this index");
            while (Length >= _array.Length || Length + add_length > _array.Length)
            {
                RizeSize(add_length);
            }
            for (int i = Length - 1; i >= index; i--)
            {
                _array[i + add_length] = _array[i];
            }
            for (int i = 0; i < add_length; i++)
            {
                _array[i + index] = arr[i];
            }
            Length += add_length;
        }

       
        public void Delete(int n = 1)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("Argument can't be negative");
            if (n > Length)
                n = Length;
            Length -= n;
            if (Length <= _array.Length / 2)
            {
                ReduceSize(n);
            }
        }


        public void DeleteFromOrigin(int n = 1)
        {
            if (Length == 0)
                return;
            for (int i = 0; i + n < Length; i++)
            {
                _array[i] = _array[i + n];
            }
            if (Length <= _array.Length / 2)
            {
                ReduceSize(n);
            }
            Length-=n;
        }


        public void DeleteFromIndex(int index, int amount = 1)
        {
            if (index < 0)
                throw new IndexOutOfRangeException("Index can't be negative");
            if (index >= Length)
                throw new IndexOutOfRangeException("List does not contain an element with this index");
            if (Length == 0)
                return;
            if (index + amount > Length)
                amount = Length - index;

           for (int i = 0; index + amount + i < Length; i++)
            {
                _array[index + i] = _array[index + i + amount];
            }
            Length -= amount;
        }

        public int IndexOfElement(int n)
        {
            for(int i = 0; i < Length; i++)
            {
                if (_array[i] == n)
                    return i;
            }
            throw new ArgumentException("List does not contain this element");
        }

        public void SetElement(int index, int n)
        {
            if (index < 0 || index > Length)
                throw new ArgumentOutOfRangeException("index can't be negative");
            if (index == Length)
                Add(n);
            else
                this[index] = n;
        }
        

        public void Reverse()
        {
            int[] newArray = new int[_array.Length];
            for(int i = 0; i < Length; i++)
            {
                newArray[i] = _array[Length - i - 1];
            }
            _array = newArray;
        }

        public int FindMax()
        {
            if (Length == 0)
                throw new Exception("List is empty");
            int max = _array[0];
            for (int i = 1; i < Length; i++)
            {
                max = _array[i] > max ? _array[i] : max;
            }
            return max;
        }

        public int FindMin()
        {
            if (Length == 0)
                throw new Exception("List is empty");
            int min = _array[0];
            for (int i = 1; i < Length; i++)
            {
                min = _array[i] < min ? _array[i] : min;
            }
            return min;
        }

        public int IndexOfMax()
        {
            if (Length == 0)
                throw new Exception("List is empty");
            int i_max = 0;
            for (int i = 1; i < Length; i++)
            {
                i_max = _array[i] > _array[i_max] ? i : i_max;
            }
            return i_max;
        }

        public int IndexOfMin()
        {
            if (Length == 0)
                throw new Exception("List is empty");
            int i_min = 0;
            for (int i = 1; i < Length; i++)
            {
                i_min = _array[i] < _array[i_min] ? i : i_min;
            }
            return i_min;
        }

        public void SortIncrease()
        {
           for (int i = 0; i < Length; i++)
            {
                int min = i;
                for (int j = i; j < Length; j++)
                {
                    if (_array[j] < _array[min])
                        min = j;
                }
                int tmp = _array[i];
                _array[i] = _array[min];
                _array[min] = tmp;
            }
        }
        public void SortDecrease()
        {
            int temp;

            for (int i = 1; i < Length; i++)
                for (int j = i; j > 0 && _array[j - 1] < _array[j]; j--)
                {
                    temp = _array[j - 1];
                    _array[j - 1] = _array[j];
                    _array[j] = temp;
                }
        }

        public void DeleteFirstElementWhithValue(int n)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == n)
                {
                    for (int j = i; j + 1 < Length; j++)
                    {
                        _array[j] = _array[j + 1];
                    }
                    Length--;
                    return;
                }
               
            }
        }

        public void DeleteAllElementsWhithValue(int n)
        {
            int step = 0;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == n)
                {
                    step++;
                    for (int j = i; j + 1 < Length; j++)
                    {
                        _array[j] = _array[j + step];
                    }
                    Length--;
                }

            }
        } 
        
       
        private void RizeSize(int size = 1)
        {
            int newLength = _array.Length;
            while(newLength < _array.Length + size)
            {
                newLength = (int)(newLength * 1.33d + 1);
            }
            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, _array.Length);
            _array = newArray;
        }

        private void ReduceSize(int size = 1)
        {
            int newLength = _array.Length;
            if (newLength == 0)
                return;
            while (newLength > _array.Length - size)
            {
                newLength = (_array.Length == 1) ? (int)(newLength * 0.66d) : 0;
            }
            int[] newArray = new int[newLength];
            if (newLength > 0)
                Array.Copy(_array, newArray, _array.Length);
            _array = newArray;
        }

    }
}
