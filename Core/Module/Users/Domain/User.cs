using Core.Module.Shared.Domain;

namespace Core.Module.Users.Domain
{
    public sealed class User : AggregateRoot
    {
        public UserId userId { get;}
        public UserName userName { get; }
        public UserEmail userEmail { get; }
        public UserPassword userPassword { get; set; }

        public User(UserId userId, UserName userName, UserEmail userEmail, UserPassword userPassword)
        {
            this.userId = userId;
            this.userName = userName;
            this.userEmail = userEmail;
            this.userPassword = userPassword;
        }

        public static User Create(UserId userId, UserName userName, UserEmail userEmail, UserPassword userPassword)
        {
            User user = new User(userId, userName, userEmail, userPassword);
            user.AddDomainEvent(new UserWasCreatedDomainEvent(userId.value.ToString(), userName.value, userEmail.value));

            return user;
        }
    }
}
