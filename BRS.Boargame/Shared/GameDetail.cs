using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BRS.Boargame.Shared
{
    public class GameDetail
    {
        public string? ItemName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        public string Name { get; set; } = default!;

        public string? Description { get; set; }

        public int? LastWinnerId { get; set; }
        public string? LastWinnerRemarks { get; set; }

        [Required]
        [Range(1, 50, ErrorMessage = "You have to have a min player count between 1 - 50")]
        public int MinPlayerCount { get; set; } = default!;

        [Required]
        [Range(1, 100, ErrorMessage = "You have to have a max player count between 1 - 100")]
        public int MaxPlayerCount { get; set; } = default!;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "You have to have a min playing time of 1 min")]
        public int MinPlayTime { get; set; } = default!;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "You have to have a max playing time of at least 1 min")]
        public int MaxPlayTime { get; set; } = default!;

        public List<PlayedCount>? Plays { get; set; }



    }
}
