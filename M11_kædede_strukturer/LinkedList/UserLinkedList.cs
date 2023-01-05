namespace LinkedList
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

    class UserLinkedList
    {
        private Node first = null!;

        public void AddFirst(User user)
        {
            Node node = new Node(user, first);
            first = node;
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
            if(first == null)
            {
                return null!;
            }
           Node current = first;
           while(current.Next != null)
            {
                current = current.Next;
            }
            return current.Data;
        }

        public int CountUsers()
        {
            if (first == null)
            {
                return -1;
            }
            int count = 1;
            Node current = first;
            while(current.Next != null)
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
                if(current.Data == user)
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