namespace FinanceTracker.Api.Common.Models
{
    public class UserWebModel
    {
        public UserWebModel(Guid userId, string firstName, string lastName, string userName, string email)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
        }

        public UserWebModel()
        {
        }

        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string RoleName { get; set; }
    }
}
