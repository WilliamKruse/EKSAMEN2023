// TaskContext.cs
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ef_sjov.Model
{ 

    public class TodoTask
    {

        //To construtors - en med user og uden user.
        //Vi er nødt til at have en uden user da vi har indsat data uden users tidligere - ellers vil man få en fejl.
        public TodoTask(string text, bool done, string category, User user)
        {
            this.Text = text;
            this.Done = done;
            this.Category = category;
            this.User = user;
        }

        public TodoTask(string text, bool done, string category)
        {
            this.Text = text;
            this.Done = done;
            this.Category = category;
            
        }

        public long TodoTaskId { get; set; }
        public string? Text { get; set; }
        public bool Done { get; set; }
        public string Category { get; set; }
        public User? User { get; set; }
    }
}

