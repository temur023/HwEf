using EfHw.Data.Entities;

namespace EfHw.Dtos;

public class PlayerCreateDto
{
    public string Id { get; set; }
    public string FullName { get; set; }
    public int Number { get; set; }
    public string Position { get; set; }
    public string Club { get; set; }
    public string Nationality { get; set; }
    public IFormFile ProfilePhoto { get; set; }

    public Player ConverToPlayer()
    {
        return new Player()
        {
            Id = Guid.NewGuid().ToString(),
            FullName = this.FullName,
            Number = this.Number,
            Position = this.Position,
            Club = this.Club,
            Nationality = this.Nationality,
            ProfilePhoto = ProfilePhoto.Name
        };
    }

}