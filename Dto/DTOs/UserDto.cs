namespace Dto.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string EMail { get; set; } = null!;

    }
}
