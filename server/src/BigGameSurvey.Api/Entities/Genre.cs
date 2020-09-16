using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigGameSurvey.Api.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Game> Games { get; set; }
    }
}
