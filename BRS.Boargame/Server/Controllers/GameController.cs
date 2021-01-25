using BRS.Boargame.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BRS.Boargame.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> logger;

        public GameController(ILogger<GameController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public GameDetail Get(int gameId)
        {

            return new GameDetail()
            {
                Description = "TempDesc",
                Id = 1,
                LastWinnerId = 42,
                LastWinnerRemarks = "HAHAHAHAH I WON",
                MaxPlayerCount = 5,
                MinPlayerCount = 1,
                MaxPlayTime = 115,
                MinPlayTime = 95,
                Name = "Sythe-Temp",
                Plays = new List<PlayedCount>()
                {
                    new PlayedCount()
                    {
                        PlayedAt = 3,
                        Total = 55
                    },
                    new PlayedCount()
                    {
                        PlayedAt = 4,
                        Total = 5
                    }
                }
            };
        }

        [HttpPost]
        public int Save([FromBody]GameDetail newGame)
        {
            var tempGameToSave = newGame;

            return 4200;
            
        }

        [HttpPut]
        public int Update([FromBody]GameDetail updateGame)
        {
            var tempGameToSave = updateGame;

            return 4200;

        }

    }
}
            



            
