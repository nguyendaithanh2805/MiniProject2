using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction.Commands;

namespace Application.Commands.Menus
{
    public class AddMenuCommand : ICommand
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
