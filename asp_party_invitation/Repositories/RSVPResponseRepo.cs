using asp_party_invitation.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace asp_party_invitation.Repositories
{
    public class RSVPResponseRepo
    {
        private readonly IMongoDatabase _db;

        public RSVPResponseRepo(string connectionString)
        {
            var client = new MongoClient(connectionString);
            _db = client.GetDatabase("PartyInvitation");
        }

        public async Task AddAsync(RSVPResponse response)
        {
            var collection = _db.GetCollection<RSVPResponse>("Responses");
            await collection.InsertOneAsync(response);
        }

        public async Task<List<RSVPResponse>> GetAllAsync()
        {
            var collection = _db.GetCollection<RSVPResponse>("Responses");
      
            return (await collection.FindAsync<RSVPResponse>(_ => true)).ToList();
        }
    }
}
