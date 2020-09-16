using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigGameSurvey.Api.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Platform { get; set; }
        public int GenreId { get; set; }

        public Genre Genre { get; set; }
        public IEnumerable<Record> Records { get; set; }
    }
}
