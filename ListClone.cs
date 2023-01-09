using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _102210021
{
    internal class ListClone<T>
    {
        
        private T[] _Arr;
        private int _Count;

        public ListClone()
        {
            _Arr = new T[100];
            _Count = 0;
        }

        public void AddIndex(T item, int idx)
        {
            try
            {
                if (idx < 0 || idx > _Count)
                {
                    throw new ArgumentOutOfRangeException("Ngoai pham vi");
                }
                T[] tmp = new T[_Count + 1];
                for (int i = 0; i < _Count; i++)
                {
                    tmp[i] = _Arr[i];
                }
                for (int i = _Count; i > idx; i--)
                {
                    tmp[i] = tmp[i - 1];
                }
                tmp[idx] = item;

                _Arr = new T[_Count + 1];
                for (int i = 0; i < _Count + 1; i++)
                {
                    _Arr[i] = tmp[i];
                }
                _Count = _Count + 1;

            }
            catch (ArgumentOutOfRangeException e) 
            {
                Console.WriteLine(e.Message);
            }
            
        }
        public void AddFirst(T item)
        {
            AddIndex(item, 0);
        }
        public void AddLast(T item)
        {
            AddIndex(item,_Count);
        }
        public void RemoveAt(int index)
        {
            if(index < 0 || index >= _Count)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            int Length = _Count;
            T[] tmp = new T[Length - 1];
            for (int i = 0; i < index; i++)
            {
                tmp[i] = _Arr[i];
            }
            for (int i = index; i < Length-1; i++)
            {
                tmp[i] = _Arr[i + 1];
            }
            _Arr = new T[Length - 1];
            for (int i = 0; i < Length - 1; i++)
            {
                _Arr[i] = tmp[i];
            }
            _Count--;
        }
        public void RemoveFirst()
        {
            RemoveAt(0);
        }
        public void RemoveLast()
        {
            RemoveAt(_Count-1);
        }
        public void Show()
        {
            for(int i = 0; i < _Count; i++)
            {
                Console.WriteLine(_Arr[i].ToString());
            }
        }
        public int Size()
        {
            return _Count;
        }
        public void Update(T nemItem, int idx)
        {
            _Arr[idx] = nemItem;
        }
        public T this[int i]
        {
            get => _Arr[i];
            set => _Arr[i] = value;
        }

    }
    
}
