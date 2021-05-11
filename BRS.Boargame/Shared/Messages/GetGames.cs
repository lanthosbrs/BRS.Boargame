using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRS.Boargame.Shared.Messages
{
    public class GetGames : IRequest<List<GameItem>>
    {

    }
}
