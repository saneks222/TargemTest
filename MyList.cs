using System;
using System.Collections;
using System.Collections.Generic;

namespace IListTargemGames
{
    class MyList<T> : IList<T>
    {
        //поле для массива элементов списка
        private T[] contents;
        int ICollection<T>.Count => contents.Length;

        //список достцпен для редактирования 
        public bool IsReadOnly { get { return false; } }

        public T this[int index] { get { return contents[index]; } set { contents[index] = value; } }


        public void Add(T item)
        {   //если массив пустой
            if (contents == null) 
            {
                contents = new T[1];
                contents[0] = item;
            }
            else
            {
                Array.Resize(ref contents, contents.Length + 1);
                contents[contents.Length - 1] = item;
            }
        }

        public void Clear()
        {
            //если не пустой то отчищаем
            if (contents != null) 
            {
                contents = null;
            }
        }

        public bool Contains(T item)
        {
            bool exists = false;
            //если не пустой проверяем 
            if (contents != null) 
            {
                foreach (T t in contents)
                {
                    if (t.Equals(item))
                    {
                        exists = true;
                        break;
                    }
                }
            }    
            return exists;
        }

        //копирование в одномерный совместимый массив начиная с указанного индекса
        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(contents,0,array,arrayIndex,contents.Length);
        }

        public int IndexOf(T item)
        {
            int index = -1;
            //если не пустой то ищем
            if (contents != null) 
            {
                for (int i = 0; i < contents.Length; i++)
                {
                    if (contents[i].Equals(item))
                    {
                        index = i;
                        break;
                    }
                }
            }
            return index;
        }

        public void Insert(int index, T item)
        {
            //если не выходим за граници списка то операция имеет смысл
            if (index < contents.Length  && index >= 0) 
            {
                //увеличиваем массив и смещаем все на один
                Array.Resize(ref contents, contents.Length + 1);
                for (int i = contents.Length - 1; i > index; i--) 
                {
                    contents[i] = contents[i - 1];
                }
                contents[index] = item;
            }
        }

        public bool Remove(T item)
        {
            //если такой элемент существует то удоляем его первое вхождение 
            if (IndexOf(item) != -1)
            {
                RemoveAt(IndexOf(item));
                return true;
            }
            else 
            {
                return false;
            }
            
        }

        public void RemoveAt(int index)
        {
            //если не выходим за граници списка то операция имеет смысл
            if (index < contents.Length && index >= 0) 
            {
                //-1 что бы не выйти за границу на последней итерации 
                for (int i = index; i < contents.Length-1; i++) 
                {
                    contents[i] = contents[i + 1];
                }
                Array.Resize(ref contents, contents.Length - 1);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < contents.Length; i++) 
            {
                yield return contents[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}
