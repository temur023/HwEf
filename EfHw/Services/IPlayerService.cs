using EfHw.Dtos;

namespace EfHw.Services;

public interface IPlayerService
{
    List<PlayerGetDto> GetAll();
    PlayerGetDto GetById(string id);
    PlayerGetDto Add(PlayerCreateDto player);
    PlayerGetDto Update(PlayerCreateDto player);
    bool Delete(string id);
}