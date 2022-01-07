namespace Core.Module.Users.Application
{
    public class CreateUserRequest
    {
        public string id { get; }
        public string userName { get; }
        public string email { get; }
        public string password { get; set; }

        public CreateUserRequest(string id, string userName, string email, string password)
        {
            this.id = id;
            this.userName = userName;
            this.email = email;
            this.password = password;
        }
    }
}
