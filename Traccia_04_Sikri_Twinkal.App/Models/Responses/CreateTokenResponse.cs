namespace Traccia_04_Sikri_Twinkal.App.Models.Responses
{
    public class CreateTokenResponse
    {
        public CreateTokenResponse(string token)
        {
            Token = token;
        }
        public string Token { get; set; } = string.Empty;
    }
}
