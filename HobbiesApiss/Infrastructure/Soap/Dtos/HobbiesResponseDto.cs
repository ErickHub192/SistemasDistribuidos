namespace HobbiesApi.Infrastructure.Soap.Dtos
{
    public class HobbiesResponseDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required int Top { get; set; }
         
    }
}