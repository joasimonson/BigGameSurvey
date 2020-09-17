using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigGameSurvey.Api.DTO
{
    public class RecordDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime InsertedAt { get; set; }
        public GameDTO Game { get; set; }
        public GenreDTO Genre { get; set; }

        public class GameDTO
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Platform { get; set; }
        }

        public class GenreDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
