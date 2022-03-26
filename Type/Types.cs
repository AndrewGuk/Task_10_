using System.Collections;

namespace Type
{
    public class MyList : IList<MyItem>
    {
        MyItem[] myItems;
        public MyList()
        {
            myItems = new MyItem[0];
        }
        public MyItem this[int index] { get { return myItems[index]; } set { myItems[index] = value; } }
        public int Count { get; private set; }
        public bool IsReadOnly { get { return false; } }
        public void Add(MyItem item)
        {
            MyItem[] newMyItem = new MyItem[myItems.Length+1];
            for (int i = 0; i < myItems.Length; i++)
            {
                newMyItem[i] = myItems[i];
            }
            newMyItem[myItems.Length] = item;
            myItems = newMyItem;
        }
        public void Clear()
        {
            Count = 0;
        }
        public bool Contains(MyItem item)
        {
            for (int i = 0; i < myItems.Length; i++)
            {
                if (myItems[i] == item)
                    return true;
            }
            return false;
        }
        public void CopyTo(MyItem[] array, int arrayIndex)
        {
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(myItems[i], arrayIndex++);
            }
        }
        public IEnumerator<MyItem> GetEnumerator()
        {
            foreach (MyItem item in this.myItems)
            {
                yield return item;
            }
        }
        public int IndexOf(MyItem item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (myItems[i] == item)
                    return i;
            }
            return -1;
        }
        public void Insert(int index, MyItem item)
        {
            if ((Count+1 <= myItems.Length) && (index < Count) && (index >=0))
            {
                Count++;
                for (int i = Count - 1; i > index; i--)
                {
                    myItems[i] = myItems[i - 1];
                }
                myItems[index] = item;
            }
        }
        public bool Remove(MyItem item)
        {
            if (myItems.Contains(item))
                return true;
            return false;
        }
        public void RemoveAt(int index)
        {
            if ((index >=0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                {
                    myItems[i] = myItems[i + 1];
                }
                Count--;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
    public class MyItem : IEnumerator
    {
        private string _Name = "Unknow";
        public string Name
        {
            set
            {
                _Name = value == null ? value = _Name : _Name = value;
            }
            get { return _Name; }
        }
        public int Age { get; set; }
        readonly MyList[] myList;
        int position = -1;
        private MyList Current 
        {
            get
            {
                try
                {
                    return myList[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        object IEnumerator.Current { get { return Current; } }
        public bool MoveNext()
        {
            position++;
            return (position < myList.Length);
        }
        public void Reset()
        {
            position = -1;
        }
    }
}