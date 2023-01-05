using System;
namespace ef_sjov.Model
{
	public class User
	{
		public User(string name)
		{
            this.Name = name;
		}

        public string Name { get; set; }
		public long UserId { get; set; }
    }

 
}


