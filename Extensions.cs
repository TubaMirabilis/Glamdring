using Glamdring.DTOs;
using Glamdring.Models;

namespace Glamdring
{
    public static class Extensions
    {
        public static CharDTO AsDTO(this Character c) => new CharDTO {
            Id = c.Id,
            Name = c.Name,
            Race = c.Race,
            ResistanceToTheRing = c.ResistanceToTheRing,
            Age = c.Age,
            Resilience = c.Resilience,
            Ferocity = c.Ferocity,
            Magic = c.Magic,
            CreatedDate = c.CreatedDate
        };
    }
}