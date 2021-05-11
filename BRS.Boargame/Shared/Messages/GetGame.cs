using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRS.Boargame.Shared.Messages
{
    public class GetGame : IRequest<GameDetail>
    {


        public GetGame(string id)
        {
            Id = id;
        }

        public static GetGame With(string id)
        {
            return new GetGame(id);
        }

        public string Id { get; } = default!;

    }
}
