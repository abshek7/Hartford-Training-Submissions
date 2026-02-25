namespace RbacAuthJwt.DTOs
{

        public record RegisterDto(string UserName,string Password,string Role);
        public record LoginDto(string UserName,string Password);

        public record AuthResultDto(string Token,string UserName,string Role);
}
