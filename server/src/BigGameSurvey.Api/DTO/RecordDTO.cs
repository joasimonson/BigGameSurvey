using System;

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
    }
}
