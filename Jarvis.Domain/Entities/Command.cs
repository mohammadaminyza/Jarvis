using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Jarvis.Domain.Entities
{
    public class Command
    {
        [Key]
        public Guid CommandId { get; set; } = new Guid();

        [Required]
        public string CommandSentence { get; set; }

        [Required]
        public string ResultSentence { get; set; }
    }
}
