using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Dos_App.Core.Entities
{
    public class ToDoTask
    {
        public Guid Id { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string TaskMessage { get; set; }
        public bool Completed { get; set; }
        public DateTime? FinishDate { get; set; }

    }
}
