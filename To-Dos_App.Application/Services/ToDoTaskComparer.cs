using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Dos_App.Core.Entities;

namespace To_Dos_App.Application.Services
{
    public class ToDoTaskComparer : IComparer<ToDoTask>
    {
        public int Compare(ToDoTask? x, ToDoTask? y)
        {
            if (y.Completed && !x.Completed)
                return -1;
            else if (x.Completed && !y.Completed)
                return 1;
            else if (x.Completed && y.Completed)
                return DateTime.Compare((DateTime)y.FinishDate, (DateTime)x.FinishDate);
            else
                return DateTime.Compare(x.CreationDateTime, y.CreationDateTime);
        }
    }
}
