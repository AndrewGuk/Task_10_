using System;
using Type;

namespace Task_10_Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            var myList = new MyList();
            var item1 = new MyItem() { Name = "test1", Age = random.Next(0,100) };
            var item2 = new MyItem() { Name = "test2", Age = random.Next(0, 100) };
            var item3 = new MyItem() { Name = "test3", Age = random.Next(0, 100) };
            var item4 = new MyItem() { Name = "test4", Age = random.Next(0, 100) };
            var item5 = new MyItem() { Name = "test5", Age = random.Next(0, 100) };
            var item6 = new MyItem() { Name = "test6", Age = random.Next(0, 100) };
            var item7 = new MyItem();

            myList.Add(item1);
            myList.Add(item2);
            myList.Add(item3);
            myList.Add(item4);
            myList.Add(item5);
            myList.Add(item6);
            myList.Add(item7);

            foreach (MyItem item in myList)
            {
                Console.WriteLine($"{item.Name}\t{item.Age}");
            }
        }
    }
}