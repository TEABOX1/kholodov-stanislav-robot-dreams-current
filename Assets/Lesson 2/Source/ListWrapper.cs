using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

namespace Lesson_2.Source
{
    public class ListWrapper<T> : IList<T>
    {
        [SerializeField] private List<T> m_list;
        public ListWrapper()
        {
            m_list = new List<T>();
            Debug.Log("List Wrapper Constructor");
        }

        ~ListWrapper()
        {
            Debug.Log("List Wrapper Destructor");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return m_list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            m_list.Add(item);
        }

        public void Clear()
        {
            m_list.Clear();
        }

        public bool Contains(T item)
        {
            return m_list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            m_list.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return m_list.Remove(item);
        }

        public void RemoveAt(int a)
        {
            m_list.RemoveAt(a);
        }

        public void Insert(int a, T item)
        {
            m_list[a] = item;
        }

        public int IndexOf(T item)
        {
            return m_list.IndexOf(item);
        }

        public void Sort()
        {
            m_list.Sort();
        }

        public void Sort( Comparison<T> comparison )
        {
            m_list.Sort( comparison );
        }

        public int Count => m_list.Count;
        public bool IsReadOnly => false;

        public bool IsSynchronized => false;
        public object SyncRoot => this;

        public T this[int index]
        {
            get => m_list[index];
            set => m_list[index] = value;
        }
    }
}
