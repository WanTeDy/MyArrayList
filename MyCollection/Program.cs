using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            MyArrayList<int> mArr = new MyArrayList<int>();
            mArr.Add(15);
            mArr.Add(16);
            mArr.Add(2);
            mArr.Add(-5);
            mArr.Add(0);
            mArr.Add(34);
            mArr.Add(152);            
            Console.WriteLine("Length = " + mArr.Length);
            foreach(var m in mArr)
                Console.WriteLine(m);
            mArr.Add(153);
            mArr.Add(154);
            mArr.Add(155);
            mArr.Add(156);
            mArr.Add(157);
            mArr.Add(1528);
            Console.WriteLine("Length = " + mArr.Length);
            foreach (var m in mArr)
                Console.WriteLine(m);
            mArr.Remove(6);
            Console.WriteLine("Length = " + mArr.Length);
            foreach (var m in mArr)
                Console.WriteLine(m);
            Console.WriteLine(mArr.Get(5));
        }
    }

    class MyArrayList<T> : IEnumerable<T>
    {
        private T[] array = new T[10];
        private int length = 0;

        public int Length
        {
            get
            {
                return length;
            }
            private set
            {
                length = value;
            }
        }
        public void Add(T el)
        {
            if (!(Length < array.Length))
            {
                T[] temp = new T[array.Length * 2];
                for (int i = 0; i < array.Length; i++)
                {
                    temp[i] = array[i];
                }
                array = temp;
            }
            array[Length] = el;
            Length++;
        }
        public void Remove(int index)
        {
            if(index < 0 || index > Length-1)
            {
                throw new ArgumentOutOfRangeException();
            }
            for(int i=index; i <Length-1;i++)
            {
                array[i] = array[i + 1];
            }
            Length--;
            array[Length] = default(T);
        }
        public T Get(int index)
        {
            if (index < 0 || index > Length - 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            return array[index];
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new MyArrayListEnumerator(array, Length);
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }        
        public class MyArrayListEnumerator : IEnumerator<T>
        {
            private int position = -1;
            private T[] arr;
            private int count;

            public MyArrayListEnumerator(T[] array, int size)
            {
                arr = array;
                count = size;
            }
            public T Current
            {
                get
                {
                    try
                    {
                        return arr[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
            public void Dispose() {}
            object System.Collections.IEnumerator.Current
            {
                get { return Current; }
            }
            public bool MoveNext()
            {
                position++;
                return (position < count);
            }
            public void Reset()
            {
                position = -1;
            }
        }
    }
}
