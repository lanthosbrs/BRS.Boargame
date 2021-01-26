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
    [Route("/api/game")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> logger;

        public GameController(ILogger<GameController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public List<GameItem> GetAll()
        {
            return new List<GameItem>() {
                new GameItem()
                {
                    Id = 42,
                    Name = "Game number 42"
                },
                new GameItem()
                {
                    Id = 43,
                    Name = "Game number 43"
                },
                new GameItem(){
                    Id = 44,
                    Name = "Game number 44"
                },

            };
        }


        [HttpGet("{gameId:int}")]
        public GameDetail GetOne(int gameId)
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
        public int Save([FromBody] GameDetail newGame)
        {
            var tempGameToSave = newGame;

            return 4200;

        }

        [HttpPut]
        public int Update([FromBody] GameDetail updateGame)
        {
            var tempGameToSave = updateGame;

            return 4200;

        }

    }
}





