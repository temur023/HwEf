using EfHw.Data.Entities;

namespace EfHw.Dtos;

public class PlayerGetDto
{
    public string Id { get; set; }
    public string FullName { get; set; }
    public int Number { get; set; }
    public string Position { get; set; }
    public string Club { get; set; }
    public string Nationality { get; set; }
    public string ProfilePhoto { get; set; }
    
    public PlayerGetDto(){}

    public PlayerGetDto(Player player)
    {
        Id = player.Id;
        FullName = player.FullName;
        Number = player.Number;
        Position = player.Position;
        Club = player.Club;
        Nationality = player.Nationality;
        ProfilePhoto = Path.Combine("https://localhost:5085", "players", player.ProfilePhoto);
    }
}