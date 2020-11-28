using System;

namespace DataStructures
{
    public class DoubleLinkedList
    {
        public int test = 10;
        private Node _headRoot;
        private Node _tailRoot;
        public int Length { get; private set; }
        public DoubleLinkedList()
        {
            _headRoot = null;
            _tailRoot = null;
            Length = 0;
        }
        public DoubleLinkedList(int value)
        {
            Node newNode = new Node(value);
            _headRoot = newNode;
            _tailRoot = newNode;
        }
        public DoubleLinkedList(int[] array)
        {
            if (array.Length == 0)
            {
                _headRoot = null;
                _tailRoot = null;
                Length = 0;
            }
            else
            {
                _headRoot = new Node(array[0]);
                Node crnt = _headRoot;
                for (int i = 1; i < array.Length; i++)
                {
                    crnt.Next = new Node(array[i]);
                    crnt.Next.Previous = crnt;
                    crnt = crnt.Next;
                }
                _tailRoot = crnt;
            }
            Length = array.Length;
        }
    
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                    throw new IndexOutOfRangeException();
                return GetNode(index).Value;
            }
            set
            {
                if (index < 0 || index > Length)
                    throw new IndexOutOfRangeException();
                if (index == Length)
                    Add(value);
                else
                {
                    GetNode(index).Next = new Node(value);
                }
            }
        }
        public void Add(int value)
        {
            if (Length == 0)
            {
                _headRoot = new Node(value);
                _tailRoot = _headRoot;
            }
            else
            {
                Node tmp = new Node(value);
                tmp.Previous = _tailRoot;
                tmp.Previous.Next = tmp;
                _tailRoot = tmp;
            }
            Length++;
        }
        public void Add(int[] arr)
        {
            if (arr.Length == 0)
                return;
            if (Length == 0)
            {
                _headRoot = new Node(arr[0]);
                _tailRoot = _headRoot;
            }

            Node crnt = _tailRoot;
            for (int i = 0; i < arr.Length; i++)
            {
                crnt.Next = new Node(arr[i]);
                crnt.Next.Previous = _tailRoot;
                crnt = crnt.Next;
                _tailRoot = crnt;
            }
            Length += arr.Length;
        }
        public void AddToOrigin(int value)
        {
            if (Length == 0)
                Add(value);
            else
            {
                Node crnt = _headRoot;
                crnt.Previous = new Node(value);
                crnt.Previous.Next = _headRoot;
                _headRoot = crnt.Previous;
                Length++;
            }
        }
        public void AddToOrigin(int[] arr)
        {
            if (arr.Length == 0)
                return;

            if (Length == 0)
            {
                _headRoot = new Node(arr[0]);
                _tailRoot = _headRoot;
            }

            Node crnt = Length != 0 ? new Node(arr[0]) : _headRoot;
            Node tmp = crnt;
            CreateSubList(ref crnt, arr);
            if (Length != 0)
            {
                crnt.Next = _headRoot;
                crnt.Next.Previous = crnt;
            }
            else
                _tailRoot = crnt;
            _headRoot = tmp;
            Length += arr.Length;
        }
        public void AddToIndex(int index, int value)
        {
            IndexCheck(index);
            if (index == Length)
            {
                Add(value);
                return;
            }
            if (index == 0)
                AddToOrigin(value);
            else
            {
                Node crnt = GetNode(index);
                Node tmp = crnt;
                crnt = crnt.Previous;
                crnt.Next = new Node(value);
                crnt.Next.Previous = crnt;
                crnt.Next.Next = tmp;
                Length++;
            }
        }
        public void AddToIndex(int index, int[] arr)
        {
            IndexCheck(index);
            if (DelegationOfArrAddiction(index, arr)) return;
            if (arr.Length == 0) return;

            Node crnt = GetNode(index - 1);
            Node tmp = crnt.Next;

            crnt.Next = new Node(arr[0]);
            crnt = crnt.Next;
            CreateSubList(ref crnt, arr);
            crnt.Next = tmp;
            Length += arr.Length;
        }
        public void Delete(int quantity = 1)
        {
            if (quantity > Length) quantity = Length;

            Node last = GetNode(Length - quantity);
            last = last == _headRoot ? last.Previous : last;
            last.Next = null;
            _tailRoot = last;
            Length -= quantity;
        }
        public override bool Equals(object obj)
        {
            DoubleLinkedList doubleLinkedList = (DoubleLinkedList)obj;
            if (Length != doubleLinkedList.Length)
                return false;
            for (int i = 0; i < Length; i++)
            {
                if (this[i] != doubleLinkedList[i])
                    return false;
            }
            return true;
        }
        public override string ToString()
        {
            string s = "";
            Node crnt = _headRoot;
            for (int i = 0; i < Length; i++)
            {
                s = s + crnt.Value + ";";
                crnt = crnt.Next;
            }
            return s;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public int GetValue(Node node)
        {
            return node.Value;
        }
        /// <summary>
        /// Return the optimal point to start
        /// </summary>
        /// <param name="index"></param>
        private Node StartPoint(int index) { return index <= Length / 2 ? _headRoot : _tailRoot; }
        public Node GetNode(int index)
        {
            Node crnt = StartPoint(index);
            if (StartFromHead(index))
            {
                for (int i = 0; i < index; i++)
                {
                    crnt = crnt.Next;
                }
            }
            else
            {
                for (int i = Length - 1; i > index; i--)
                {
                    crnt = crnt.Previous;
                }
            }
            return crnt;
        }
        private bool StartFromHead(int index) { return index <= Length / 2; }
        private void CreateSubList(ref Node crnt, int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                crnt.Next = new Node(arr[i]);
                crnt.Next.Previous = crnt;
                crnt = crnt.Next;
            }
        }
        private void IndexCheck(int index)
        {
            if (index < 0 || index > Length)
                throw new IndexOutOfRangeException();
        }
        private bool DelegationOfArrAddiction(int index, int[] arr)
        {
            if (index == 0)
            {
                AddToOrigin(arr);
                return true;
            }
            if (index == Length)
            {
                Add(arr);
                return true;
            }
            return false;
        }
    }
}
