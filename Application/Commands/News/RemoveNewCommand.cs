using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction.Commands;

namespace Application.Commands.News
{
    public class RemoveNewCommand : ICommand
    {
        public int Id { get; set; }

        public RemoveNewCommand(int id)
        {
            Id = id;
        }
    }
}
