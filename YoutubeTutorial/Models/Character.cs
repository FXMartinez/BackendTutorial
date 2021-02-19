using System;
using System.Collections.Generic;

#nullable disable

namespace YoutubeTutorial.Models
{
    public partial class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? BagId { get; set; }
    }
}
