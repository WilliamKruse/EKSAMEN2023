using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortedLinkedList;
using DList;
namespace LinkedList.Tests
{
    [TestClass]
    public class LinkedList_Tests
    {
        [TestMethod]
        public void TestAddFirst()
        {
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);

            UserLinkedList list = new UserLinkedList();
            list.AddFirst(kristian);
            Assert.AreEqual(kristian, list.GetFirst());
        }
        
        [TestMethod]
        public void TestRemoveFirst()
        {
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);

            UserLinkedList list = new UserLinkedList();
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);
            Assert.AreEqual(torill, list.RemoveFirst());
        }

        [TestMethod]
        public void TestCountUsers()
        {
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);

            UserLinkedList list = new UserLinkedList();
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);
            Assert.AreEqual(3, list.CountUsers());
        }

        [TestMethod]
        public void TestRemoveUser()
        {
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);
            User henrik = new User("Henrik", 5);
            User klaus = new User("Klaus", 6);

            UserLinkedList list = new UserLinkedList();
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);
            list.AddFirst(henrik);
            list.AddFirst(klaus);

            list.RemoveUser(mads);
            Assert.AreEqual(4, list.CountUsers());
            list.RemoveUser(kristian);
            Assert.AreEqual(3, list.CountUsers());
        }

        [TestMethod]
        public void TestGetLast()
        {
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);
            User henrik = new User("Henrik", 5);
            User klaus = new User("Klaus", 6);

            UserLinkedList list = new UserLinkedList();
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);
            list.AddFirst(henrik);
            list.AddFirst(klaus);

            Assert.AreEqual(kristian.Name, list.GetLast().Name);
        }
        
        [TestMethod]
        public void TestContains()
        {
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);
            User henrik = new User("Henrik", 5);
            User klaus = new User("Klaus", 6);

            UserLinkedList list = new UserLinkedList();
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);
            list.AddFirst(henrik);
            

            Assert.AreEqual(true, list.Contains(henrik));
            Assert.AreEqual(true, list.Contains(mads));
            Assert.AreEqual(false, list.Contains(klaus));
        }
        [TestMethod]
        public void TestSortedAdd()
        {
            User Anne = new User("Anne", 1);
            User Ditte = new User("Ditte", 2);
            User Børge = new User("Børge", 3);
            User Cille = new User("Cille", 5);
            User Else = new User("Else", 6);

            SortedUserLinkedList list = new SortedUserLinkedList();
            SortedUserLinkedList list2 = new SortedUserLinkedList();
            list.Add(Anne);
            list.Add(Ditte);
            list.Add(Børge);
            list.Add(Cille);
            list.Add(Else);

            list2.Add(Anne);
            list2.Add(Børge);
            list2.Add(Cille);
            list2.Add(Ditte);
            list2.Add(Else);
            Assert.AreEqual(list2.GetIt(1), list.GetIt(1));
            Assert.AreEqual(list2.GetIt(3), list.GetIt(3));
            Assert.AreEqual(list2.GetIt(4), list.GetIt(4));

        }
        [TestMethod]
        public void TestDList()
        {
            User Anne = new User("Anne", 1);
            User Ditte = new User("Ditte", 2);
            User Børge = new User("Børge", 3);
            User Cille = new User("Cille", 5);
            User Else = new User("Else", 6);

            Dlist list = new Dlist();

            list.AddFirst(Anne);
            list.AddFirst(Ditte);
            list.AddLast(Cille);
            list.AddFirst(Else);
            list.AddLast(Børge);
            //burde blive; else, Ditte, Anne, Cille, Børge
            Console.WriteLine(list.GetIt(2));
            Assert.AreEqual("Else", list.GetIt(0));
            Assert.AreEqual("Cille", list.GetIt(3));

            list.RemoveFirst();
            list.RemoveLast();
            Assert.AreEqual("Ditte", list.GetIt(0));
            Assert.AreEqual("Cille", list.GetIt(2));


        }
    }
}