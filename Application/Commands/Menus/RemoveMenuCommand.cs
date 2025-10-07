using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction.Commands;

namespace Application.Commands.Menus
{
    public class RemoveMenuCommand : ICommand
    {
        public int Id { get; set; }
    }
}
