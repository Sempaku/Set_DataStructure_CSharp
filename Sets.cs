using System.Collections;

namespace Set_DataStructure
{
    internal class Sets<T> : IEnumerable<T>
    {
        private List<T> elements = new List<T>();
        public uint Length { get; private set; } = 0;

        #region Передача элементов в множество

        public Sets(params T[] elems)
        {
            foreach (T item in elems)
            {
                elements.Add(item);
            }
            Length = (uint)elems.Length;
        }

        public Sets(T elem)
        {
            elements.Add(elem);
            Length = 1;
        }

        public Sets(List<T> elems)
        {
            elements = elems;
            Length = (uint)elems.Count;
        }

        #endregion Передача элементов в множество

        #region Добавление элемента в множество

        public void Add(T value)
        {
            if (!elements.Contains(value))
            {
                elements.Add(value);
                Length++;
            }
        }

        #endregion Добавление элемента в множество

        #region Операции со множествами

        public Sets<T> Union(Sets<T> secondSet)
        {
            Sets<T> result = elements;

            foreach (T item in secondSet)
            {
                result.Add(item);
            }

            return result;
        }

        public Sets<T> Intersection(Sets<T> secondSet)
        {
            Sets<T> result = new Sets<T>();

            foreach (T item in secondSet)
            {
                if (elements.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public Sets<T> Addition(Sets<T> secondSet)
        {
            Sets<T> results = new Sets<T>();

            foreach (T item in elements)
            {
                if (!secondSet.Contains(item))
                {
                    results.Add(item);
                }
            }

            return results;
        }

        #endregion Операции со множествами

        #region Вывод множества

        public void Print()
        {
            Console.Write("{ ");
            elements.ForEach((T x) => Console.Write($"[{x}] "));
            Console.Write(" }\n");
        }

        #endregion Вывод множества

        #region Реализация неявного преобразования из List<T> в Sets<T>

        public static implicit operator Sets<T>(List<T> v)
        {
            Sets<T> result = new Sets<T>();
            foreach (var i in v)
            {
                result.Add(i);
            }
            return result;
        }

        #endregion Реализация неявного преобразования из List<T> в Sets<T>

        #region Реализация интерфейса IEnumerable

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)elements).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)elements).GetEnumerator();
        }

        #endregion Реализация интерфейса IEnumerable

        #region Реализация индексации во множестве

        public T this[int index]
        {
            get => elements[index];
            set => elements[index] = value;
        }

        #endregion Реализация индексации во множестве
    }
}