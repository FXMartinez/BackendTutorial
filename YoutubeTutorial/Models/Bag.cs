using System;
using System.Collections.Generic;

#nullable disable

namespace YoutubeTutorial.Models
{
    public partial class Bag
    {
        public int Id { get; set; }
        public int? CharacterId { get; set; }
        public int? ItemId { get; set; }
        public int? WeaponId { get; set; }
    }
}
