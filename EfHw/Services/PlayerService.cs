using EfHw.Data;
using EfHw.Dtos;

namespace EfHw.Services;

public class PlayerService(DataContext context):IPlayerService
{
    public List<PlayerGetDto> GetAll()
    {
        var players = context.Players.Select(p => new PlayerGetDto(p)).ToList();
        return players;
    }

    public PlayerGetDto GetById(string id)
    {
        var player = context.Players.Find(id);
        if (player == null) throw new Exception("Player Not Found!");
        return new PlayerGetDto(player);
    }

    public PlayerGetDto Add(PlayerCreateDto player)
    {
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(player.ProfilePhoto.FileName);
        var filePath = Path.Combine("wwwroot/players", fileName);
        
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            player.ProfilePhoto.CopyTo(stream);
        }
        var entity = player.ConverToPlayer();
        entity.ProfilePhoto = "/players/" + fileName;
        context.Players.Add(entity);
        context.SaveChanges();

        return new PlayerGetDto()
        {
            Id = entity.Id,
            Club = player.Club,
            FullName = player.FullName,
            Nationality = player.Nationality,
            Number = player.Number,
            Position = player.Position,
            ProfilePhoto = player.ProfilePhoto.Name
        };
    }

    public PlayerGetDto Update(PlayerCreateDto player)
    {
        var existing = context.Players.Find(player.Id);
        if (existing is null)
            throw new Exception("No player Found!");
        
        if (player.ProfilePhoto != null)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(player.ProfilePhoto.FileName);
            var filePath = Path.Combine("wwwroot/players", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                player.ProfilePhoto.CopyTo(stream);
            }

            existing.ProfilePhoto = "/players/" + fileName; // ✅ correct
        }
        
        existing.Club = player.Club;
        existing.Number = player.Number;
        existing.FullName = player.FullName;
        existing.Nationality = player.Nationality;
        existing.Position = player.Position;

        context.SaveChanges();

        return new PlayerGetDto(existing);
    }


    public bool Delete(string id)
    {
        var existing = context.Players.Find(id);
        if (existing is null) throw new Exception("No player found!");
        context.Players.Remove(existing);
        context.SaveChanges();
        return true;
    }
}