using System;
using System.Collections.Generic;

#nullable disable

namespace YoutubeTutorial.Models
{
    public partial class Weapon
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int? Weight { get; set; }
    }
}
