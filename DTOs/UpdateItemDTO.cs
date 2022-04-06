using System.ComponentModel.DataAnnotations;

namespace Glamdring.DTOs
{
    public record UpdateItemDTO
    {
        [Required]
        public string Name { get; init; }
        public string Race { get; init; }
        public int ResistanceToTheRing { get; init; }
        public int Age { get; init; }
        public int Resilience { get; init; }
        public int Ferocity { get; init; }
        public int Magic { get; init; }
    }
}