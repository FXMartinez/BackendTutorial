using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace YoutubeTutorial.Models
{
    public partial class Character
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? BagId { get; set; }
    }
}