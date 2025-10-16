using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands
{
    public class UpdateNewCommand : IRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = "Id must be a positive integer.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "MenuId is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "MenuId must be a positive integer.")]
        public int MenuId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = null!;

        [StringLength(500, ErrorMessage = "Content cannot exceed 500 characters.")]
        public string? Content { get; set; }
    }
}