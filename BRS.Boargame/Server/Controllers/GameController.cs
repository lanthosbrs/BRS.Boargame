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
        public async Task<List<GameItem>> GetAll()
        {
            var response = await mediator.Send(new GetGames());

            return response;
        }


        [HttpGet("{gameId}")]
        public async Task<GameDetail> GetOne(string gameId)
        {
            var response = await mediator.Send(GetGame.With(gameId));

            return response;
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





