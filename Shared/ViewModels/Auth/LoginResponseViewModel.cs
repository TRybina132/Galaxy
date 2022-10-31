namespace Data.ViewModels.Auth
{
    public class LoginResponseViewModel
    {
        public bool IsSuccess { get; set; }
        public string? Token { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
