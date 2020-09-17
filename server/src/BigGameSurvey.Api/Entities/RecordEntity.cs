using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigGameSurvey.Api.Entities
{
    public class RecordEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime InsertedAt { get; set; }
        public int GameId { get; set; }

        public GameEntity Game { get; set; }
    }
}
