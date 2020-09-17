using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigGameSurvey.Api.Entities
{
    public class GenreEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<GameEntity> Games { get; set; }
    }
}
