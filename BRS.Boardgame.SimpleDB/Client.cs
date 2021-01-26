using System;
using System.Collections.Generic;
using Amazon.SimpleDB;
using Amazon.SimpleDB.Model;
using BRS.Boargame.Shared;
using MediatR;
using BRS.Boardgame.SimpleDB.Extentions;
using BRS.Boargame.Shared.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace BRS.Boardgame.SimpleDB
{
    public class Client : IRequestHandler<SaveGame, GameAdded>
    {

        private IAmazonSimpleDB simpleDBClient;

        public Client(IAmazonSimpleDB simpleDBClient)
        {
            this.simpleDBClient = simpleDBClient;
        }

        public Task<GameAdded> Handle(SaveGame request, CancellationToken cancellationToken)
        {


            var attributes = request.GameToSave.ToReplaceableAttributes();



            var result = simpleDBClient.PutAttributesAsync(new PutAttributesRequest()
            {
                DomainName = "Boardgames",
                Attributes = attributes,
                ItemName = Guid.NewGuid().ToString()
            });

            result.Wait();

            return Task.FromResult(new GameAdded() { Id = 123456789 });
        }
    }
}
