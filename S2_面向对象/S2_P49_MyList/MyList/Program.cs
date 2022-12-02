using System;
using System.Collections.Generic;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> ls = new MyList<int>(10);
            ls.Add(1);
            ls.Insert(3, 6);
            ls.Insert(6, 6);
            ls.Sort();
            ShowList(ls);
            Console.ReadLine();
        }

        static void ShowList(MyList<int> ls)
        {
            for (int i = 0; i < ls.Count; i++)
            {
                Console.WriteLine(ls[i]);
            }

        }
    }

    //利用数组实现的泛型列表类
    class MyList<T>
    {
        private int count;
        private int capacity = 4;
        private T[] ls;

        public int Count { get; }
        public int Capacity { get; }

        private void Initialize()
        {
            this.count = 0;
            this.ls = new T[this.capacity];
        }

        public MyList()
        {
            Initialize();
        }

        public MyList(int capacity)
        {
            this.capacity = capacity;
            Initialize();
        }

        public MyList(IEnumerable<T> collection)
        {
            Initialize();
            foreach (T item in collection)
            {
                this.Add(item);
            }
        }

        private void IsOutofRange(int index)
        {
            if (index < 0 || index > this.count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        //增加元素
        public void Add(T item)
        {
            if (this.count < this.capacity)
            {
                ls[this.count++] = item;
            }
            else
            {
                this.capacity *= 2;
                T[] lsNew = new T[this.capacity];
                for (int i = 0; i < this.count; i++)
                {
                    lsNew[i] = ls[i];
                }
                lsNew[count++] = item;
                this.ls = lsNew;
            }
        }

        //插入元素至
        public void Insert(int index, T item)
        {
            this.IsOutofRange(index);

            if (index == count)
            {
                this.Add(item);
                return;
            }

            T[] lsNew = new T[this.capacity];
            for (int i = 0; i < this.count; i++)
            {
                if (index > i)
                {
                    lsNew[i] = this.ls[i];
                }
                else if (index == i)
                {
                    lsNew[i] = item;
                    lsNew[i+1] = this.ls[i];
                }
                else
                {
                    lsNew[i+1] = this.ls[i]; 
                }
            }
            this.ls = lsNew;
            this.count++;
        }
        
        //索引器
        public T this[int index]
        {
            get
            {

                this.IsOutofRange(index);
                return this.ls[index];
            }
            set
            {

                this.IsOutofRange(index);
                this.ls[index] = value;
            }
        }

        //移除指定位置元素
        public void RemoveAt(int index)
        {
            this.IsOutofRange(index);
            T[] lsNew = new T[this.capacity];
            for (int i = 0; i < this.count; i++)
            {
                if (index > i)
                {
                    lsNew[i] = this.ls[i];
                }
                else if (index == i)
                {
                    continue;
                }
                else
                {
                    lsNew[i-1] = this.ls[i];
                }
            }
            this.ls = lsNew;
            this.count--;
        }

        //匹配到的第一个元素的索引
        public int IndexOf(T item)
        {
            for (int i = 0; i < this.count; i++)
            {
                dynamic var1 = item;
                dynamic var2 = this.ls[i];
                if (var1 == var2)
                {
                    return i;
                }
            }
            return -1;
        }

        //匹配到的最后一个元素的索引
        public int LastIndexOf(T item)
        {
            for (int i = this.count; i > 0; i--)
            {
                dynamic var1 = item;
                dynamic var2 = this.ls[i];
                if (var1 == var2)
                {
                    return i;
                }
            }
            return -1;
        }

        //从小到大排序
        public void Sort()
        {
            for (int i = 0; i < this.count; i++)
            {
                dynamic item = this.ls[i];
                for (int j = i+1; j < this.count; j++)
                {
                    dynamic var = this.ls[j];
                    if (var < item)
                    {
                        this.ls[i] = var;
                        this.ls[j] = item;
                        item = this.ls[i];
                    }
                }
            }
        }
    }
}
