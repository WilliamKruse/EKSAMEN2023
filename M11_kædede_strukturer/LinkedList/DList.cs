namespace DList
{
    class Node
    {
        public Node(User data, Node next, Node prev)
        {
            this.Data = data;
            this.Next = next;
            this.Prev = prev;
        }
        public User Data;
        public Node Next;
        public Node Prev;
    }

    class Dlist
    {
        private Node first = null!;
        private Node last = null!;


        public void AddFirst(User user)
        {
            if (first == null)
            {
                Node insert = new Node(user, null!, null!);
                first = insert;
                last = insert;
            }
            else
            {
                Node temp = first;
                Node insert = new Node(user, temp, null!);
                temp.Prev = insert;
                first = insert;
                
                
            }
            
        }
        public void AddLast(User user)
        {
            if (first == null)
            {

                Node insert = new Node(user, null!, null!);
                first = insert;
                last = insert;
            }
            else
            {
                Node temp = last;
                Node insert = new Node(user, null!, temp);
                temp.Next = insert;
                last = insert;

            }
        }

        public User RemoveFirst()
        {
            Node temp = first;
            first = first.Next;
            first.Prev = null!;

            return temp.Data;
        }
        public User RemoveLast()
        {
            Node temp = last;
            last = last.Prev;
            last.Next = null!;

            return temp.Data;
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
            if (last == null)
            {
                return null!;
            }
            return last.Data;
        }
        public string GetIt(int index)
        {
            
            
                Node current = first;
                int count = 0;
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