using System;
using System.Collections.Generic;
using System.Text;

namespace BRS.Boargame.Shared
{
    public class GameDetail
    {
        public int Id { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string? Description { get; set; }

        public int? LastWinnerId { get; set; }
        public string? LastWinnerRemarks { get; set; }
        
        public int MinPlayerCount { get; set; } = default!;

        public int MaxPlayerCount { get; set; } = default!;

        public int MinPlayTime { get; set; } = default!;

        public int MaxPlayTime { get; set; } = default!;

        public List<PlayedCount>? Plays { get; set; }



    }
}
