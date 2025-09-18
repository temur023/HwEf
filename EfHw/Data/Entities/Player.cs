using System.ComponentModel.DataAnnotations;

namespace EfHw.Data.Entities;

public class Player
{
    [Key]
    public string Id { get; set; }
    [MaxLength(60)]
    public string FullName { get; set; }
    [Range(1,99)]
    public int Number { get; set; }
    [MaxLength(10)]
    public string Position { get; set; }
    [MaxLength(30)]
    public string Club { get; set; }
    [MaxLength(20)] 
    public string Nationality { get; set; }
    [MaxLength(40)]
    public string ProfilePhoto { get; set; }
}