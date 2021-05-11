using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRS.Boargame.Shared.Messages
{
    public class SaveGame : IRequest<string>
    {


        public SaveGame(GameDetail gameDetail)
        {
            GameToSave = gameDetail;
        }

        public static SaveGame With(GameDetail gameDetail)
        {
            return new SaveGame(gameDetail);
        }

        public GameDetail GameToSave { get; } = default!;

    }
}
