using Core.Module.Shared.Domain;

namespace Core.Module.Users.Domain
{
    public sealed class User : AggregateRoot
    {
        public UserId id { get;}
        public UserName userName { get; }
        public UserEmail email { get; }
        private UserPassword password { get; set; }

        public User(UserId userId, UserName userName, UserEmail email, UserPassword userPassword)
        {
            this.id = userId;
            this.userName = userName;
            this.email = email;
            this.password = userPassword;
        }

        public static User Create(UserId userId, UserName userName, UserEmail email, UserPassword userPassword)
        {
            User user = new User(userId, userName, email, userPassword);
            user.AddDomainEvent(new UserCreatedDomainEvent(userId.value.ToString(), userName.value, email.value));

            return user;
        }
    }
}
