using OOP_KR;

public class Guest : IUser
{
    public int Id { get; }

    public Guest()
    {
        Id = 0;
    }

    public void ViewExcursions(List<IExcursion> excursions)
    {
        Console.WriteLine("Available excursions:");
        foreach (var excursion in excursions)
        {
            Console.WriteLine($"ID: {excursion.Id}, Name: {excursion.Name}, Description: {excursion.Description}");
        }
    }

    public void BookExcursion(IExcursion excursion, int participants)
    {
        Console.WriteLine("Booking is only available for registered users.");
    }

    public void CancelExcursion(IExcursion excursion)
    {
        Console.WriteLine("Canceling bookings is only available for registered users.");
    }

    public void Register()
    {
        try
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new InvalidInputException("Username and password cannot be empty.");

            if (Program.users.Any(u => u.Username == username))
                throw new UserAlreadyExistsException("Username already exists.");

            int newId = Program.users.Max(u => u.Id) + 1;
            var newUser = new RegisteredUser(newId, username, password);
            Program.users.Add(newUser);
            Console.WriteLine("Registration successful.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
