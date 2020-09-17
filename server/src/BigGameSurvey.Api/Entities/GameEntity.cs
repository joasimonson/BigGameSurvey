using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigGameSurvey.Api.Entities
{
    public class GameEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Platform { get; set; }
        public int GenreId { get; set; }

        public GenreEntity Genre { get; set; }
        public IEnumerable<RecordEntity> Records { get; set; }
    }
}
