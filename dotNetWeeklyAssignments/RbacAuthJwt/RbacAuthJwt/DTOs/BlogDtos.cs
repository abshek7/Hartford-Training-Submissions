namespace RbacAuthJwt.DTOs
{

        public record BlogCreateDto(string Title,string ?Content,string Author);
        public record BlogUpdateDto(string Title, string? Content);

}
