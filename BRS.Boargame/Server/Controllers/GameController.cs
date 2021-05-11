using BRS.Boargame.Shared;
using BRS.Boargame.Shared.Messages;
using MediatR;
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
        IMediator mediator;
        public GameController(ILogger<GameController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpGet]
        public List<GameItem> GetAll()
        {
            return new List<GameItem>() {
                new GameItem()
                {
                    Id = "b5679382-cc5f-4662-a6e0-93f6772242f6",
                    Name = "Game number 42"
                },
                new GameItem()
                {
                    Id = "b5679382-cc5f-4662-a6e0-93f6772242f6",
                    Name = "Game number 43"
                },
                new GameItem(){
                    Id = "b5679382-cc5f-4662-a6e0-93f6772242f6",
                    Name = "Game number 44"
                },

            };
        }


        [HttpGet("{gameId}")]
        public async Task<GameDetail> GetOne(string gameId)
        {
            var response = await mediator.Send(GetGame.With(gameId));

            return response;

            return new GameDetail()
            {
                Description = "TempDesc",
                ItemName = Guid.NewGuid().ToString(),
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
        public async Task<string> Save([FromBody] GameDetail newGame)
        {
            var response = await mediator.Send(SaveGame.With(newGame));

            return response;
        }

        [HttpPut]
        public int Update([FromBody] GameDetail updateGame)
        {
            var tempGameToSave = updateGame;

            return 4200;

        }

    }
}





