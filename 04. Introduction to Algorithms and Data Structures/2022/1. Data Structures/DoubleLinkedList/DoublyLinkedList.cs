﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
    /// <summary>
    /// Двойно свързан списък
    /// </summary>
    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Един възел
        /// </summary>
        public class ListNode<T>
        {
            /// <summary>
            /// Стойност на възела
            /// </summary>
            public T Value { get; private set; }

            /// <summary>
            /// Предишен възел
            /// </summary>
            public ListNode<T> Prev { get; set; }

            /// <summary>
            /// Следващ възел
            /// </summary>
            public ListNode<T> Next { get; set; }

            /// <summary>
            /// Конструктор
            /// </summary>
            public ListNode(T value)
            {
                this.Value = value;
            }
        }

        // Глава
        private ListNode<T> Head { get; set; }

        // Опашка
        private ListNode<T> Tail { get; set; }

        // Брой елементи
        public int Count { get; private set; }

        /// <summary>
        /// Добавяне на първи елемент
        /// </summary>
        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                this.Head = this.Tail = new ListNode<T>(element);
            }
            else 
            {
                var newone = new ListNode<T>(element);
                newone.Next = this.Head;
                newone.Prev = newone;
                this.Head = newone;
            }
            this.Count++;
        }

        /// <summary>
        /// Добавяне на последен елемент
        /// </summary>
        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.Head = this.Tail = new ListNode<T>(element);
            }
            else
            {
                var newone = new ListNode<T>(element);
                newone.Prev = this.Tail;
                this.Tail.Next = newone;
                this.Tail = newone;
            }
            this.Count++;
        }

        /// <summary>
        /// Прмахване на първи елемент
        /// </summary>
        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Empty List!");
            }
            var first = this.Head.Value;
            this.Head = this.Head.Next;
            if (this.Head != null)
            {
                this.Head.Prev = null;
            }
            else 
            {
                this.Tail = null;
            }
            this.Count--;
            return first;
        }

        /// <summary>
        /// Премахване на последен елемент
        /// </summary>
        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Empty List!");
            }
            T last = this.Tail.Value;
            this.Tail = this.Tail.Prev;
            this.Tail.Next = null;
            this.Count--;
            return last;
        }

        /// <summary>
        /// Масив
        /// </summary>
        public T[] ToArray()
        {
            var array = new T[this.Count];
            int index = 0;
            var current = this.Head;
            while (current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }
            return array;
        }

        // Нумератор
        public IEnumerator<T> GetEnumerator()
        {
            var current = this.Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
