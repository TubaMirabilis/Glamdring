using System;

namespace Glamdring.DTOs
{
    public record CharDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Race { get; init; }
        public int ResistanceToTheRing { get; init; }
        public int Age { get; init; }
        public int Resilience { get; init; }
        public int Ferocity { get; init; }
        public int Magic { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}