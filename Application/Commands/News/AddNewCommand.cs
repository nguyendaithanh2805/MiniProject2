using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction.Commands;

namespace Application.Commands.News
{
    public class AddNewCommand : ICommand
    {
        public int Id { get; set; }

        public int MenuId { get; set; }

        public string Title { get; set; } = null!;

        public string? Content { get; set; }
    }
}
