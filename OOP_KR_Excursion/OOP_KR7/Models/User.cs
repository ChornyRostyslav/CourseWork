namespace OOP_KR
{
    public abstract class User : ILoginUser
    {
        public int Id { get; private set; }
        private string username;
        private string password;

        public string Username
        {
            get => username;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidInputException("Username cannot be empty.");
                username = value;
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidInputException("Password cannot be empty.");
                password = value;
            }
        }

        public User(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }

        public virtual void ViewExcursions(List<IExcursion> excursions)
        {
            foreach (var excursion in excursions)
            {
                Console.WriteLine(excursion);
            }
        }

        public virtual void BookExcursion(IExcursion excursion, int participants)
        {
            excursion.Book(Id, participants);
        }

        public virtual void CancelExcursion(IExcursion excursion)
        {
            excursion.CancelBooking(Id);
        }
    }
}