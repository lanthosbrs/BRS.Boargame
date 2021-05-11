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
    public class Client : IRequestHandler<SaveGame, string>, IRequestHandler<GetGame, GameDetail>
    {

        private IAmazonSimpleDB simpleDBClient;

        public Client(IAmazonSimpleDB simpleDBClient)
        {
            this.simpleDBClient = simpleDBClient;
        }

        public Task<string> Handle(SaveGame request, CancellationToken cancellationToken)
        {
            var attributes = request.GameToSave.ToReplaceableAttributes();


            var id = Guid.NewGuid().ToString();

            var result = simpleDBClient.PutAttributesAsync(new PutAttributesRequest()
            {
                DomainName = "Boardgames",
                Attributes = attributes,
                ItemName = id
            });

            result.Wait();

            return Task.FromResult(id);
        }

        public Task<GameDetail> Handle(GetGame request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var result = simpleDBClient.SelectAsync(new SelectRequest()
            {
                SelectExpression = $"SELECT * FROM `Boardgames` where itemName() = '{id}' LIMIT 1"
            });

            result.Wait();
            
            return Task.FromResult(new GameDetail() );
        }
    }
}
