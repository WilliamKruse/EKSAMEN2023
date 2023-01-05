namespace SortedLinkedList
{
    class Node
    {
        public Node(User data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
        public User Data;
        public Node Next;
    }

    class SortedUserLinkedList
    {
        private Node first = null!;

        public void BadAdd(User user)
        {
            if (first == null)
            {
                Node temp = new Node(user, null!);
                first = temp;
            }

        
            else
            {
                Node current = first;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                Node newitem = new Node(user, null!);
                current.Next = newitem;
            }
        }
        public void Add(User user)
        {
            if (first == null)
            {
                Node temp = new Node(user, null!);
                first = temp;
                return;
            }
            Node current = first;
            Node prev = null!;
     

                while (current != null && string.Compare(current.Data.Name.ToLower(), user.Name.ToLower()) < 0)
                {
           
                    prev = current;
                    current = current.Next;
                if (current == null)
                {
                    break;
                }
                }
            

            Node node = new Node(user, current);
            prev.Next = node;
            
        }

        public User RemoveFirst()
        {
            Node temp = first;
            first = first.Next;
            return temp.Data;
        }

        public void RemoveUser(User user)
        {
            Node node = first;
            Node previous = null!;
            bool found = false;

            while (!found && node != null)
            {
                if (node.Data.Name == user.Name)
                {
                    found = true;
                    if (node == first)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        previous.Next = node.Next;
                    }
                }
                else
                {
                    previous = node;
                    node = node.Next;
                }
            }
        }

        public User GetFirst()
        {
            if (first == null)
            {
                return null!;
            }
            return first.Data;
        }

        public User GetLast()
        {
            if (first == null)
            {
                return null!;
            }
            Node current = first;
            while (current.Next != null)
            {
                current = current.Next;
            }
            return current.Data;
        }
        public string GetIt(int index)
        {
            if (index == 0)
            {
                return first.Data.Name;
            }
            Node current = first;
            int count = 1;

            while (count < index)
            {
                current = current.Next;
                count++;
            }

            return current.Data.Name;
        }

        public int CountUsers()
        {
            if (first == null)
            {
                return -1;
            }
            int count = 1;
            Node current = first;
            while (current.Next != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
        public bool Contains(User user)
        {
            Node current = first;
            while (current != null)
            {
                if (current.Data == user)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public override String ToString()
        {
            Node node = first;
            String result = "";
            while (node != null)
            {
                result += node.Data.Name + ", ";
                node = node.Next;
            }
            return result.Trim();
        }
    }
}
