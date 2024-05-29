using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_KR
{
    class Program
    {
        public static List<IExcursion> excursions = new List<IExcursion>
    {
        new Excursion(1, "Castle Tour", "Explore the ancient castle."),
        new Excursion(2, "City Tour", "Discover the city's hidden gems."),
        new Excursion(3, "Museum Tour", "Visit the best museums.")
    };

        public static List<ILoginUser> users = new List<ILoginUser>
    {
        new Admin(1, "admin", "admin123")
    };

        static IUser currentUser;

        static void Main(string[] args)
        {
            foreach (var excursion in excursions)
            {
                excursion.BookingCreated += Events.OnBookingCreated;
                excursion.BookingCanceled += Events.OnBookingCanceled;
            }

            while (true)
            {
                ShowStartMenu();
                var userTypeChoice = Console.ReadLine();
                switch (userTypeChoice)
                {
                    case "1":
                        LoginAsAdmin();
                        break;
                    case "2":
                        LoginAsRegisteredUser();
                        break;
                    case "3":
                        RegisterUser();
                        break;
                    case "4":
                        ContinueAsGuest();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void ShowStartMenu()
        {
            Console.WriteLine("Select option:");
            Console.WriteLine("1. Login as Admin");
            Console.WriteLine("2. Login as Registered User");
            Console.WriteLine("3. Register");
            Console.WriteLine("4. Continue as Guest");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
        }

        static void LoginAsAdmin()
        {
            try
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                    throw new InvalidInputException("Username and password cannot be empty.");

                currentUser = users.OfType<Admin>().FirstOrDefault(u => u.Username == username && u.Password == password);
                if (currentUser == null)
                    throw new InvalidUserException("Invalid credentials.");

                Console.WriteLine("Login successful.");
                AdminMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void LoginAsRegisteredUser()
        {
            try
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                    throw new InvalidInputException("Username and password cannot be empty.");

                currentUser = users.OfType<RegisteredUser>().FirstOrDefault(u => u.Username == username && u.Password == password);
                if (currentUser == null)
                    throw new InvalidUserException("Invalid credentials.");

                Console.WriteLine("Login successful.");
                UserMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void RegisterUser()
        {
            try
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                    throw new InvalidInputException("Username and password cannot be empty.");

                if (users.Any(u => u.Username == username))
                    throw new UserAlreadyExistsException("Username already exists.");

                int newId = users.Max(u => u.Id) + 1;
                var newUser = new RegisteredUser(newId, username, password);
                users.Add(newUser);
                Console.WriteLine("Registration successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ContinueAsGuest()
        {
            currentUser = new Guest();
            UserMenu();
        }

        static void AdminMenu()
        {
            while (true)
            {
                ShowAdminMenu();
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ViewExcursions();
                        break;
                    case "2":
                        AddExcursion();
                        break;
                    case "3":
                        RemoveExcursion();
                        break;
                    case "4":
                        ViewBookings();
                        break;
                    case "5":
                        SerializeExcursions();
                        break;
                    case "6":
                        DeserializeExcursions();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void UserMenu()
        {
            while (true)
            {
                if (currentUser is Guest)
                {
                    ShowGuestMenu();
                    var choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            ViewExcursions();
                            break;
                        case "2":
                            ((Guest)currentUser).Register();
                            break;
                        case "3":
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    ShowUserMenu();
                    var choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            ViewExcursions();
                            break;
                        case "2":
                            BookExcursion();
                            break;
                        case "3":
                            CancelBooking();
                            break;
                        case "4":
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }

        static void ShowGuestMenu()
        {
            Console.WriteLine("Guest Menu:");
            Console.WriteLine("1. View excursions");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Back to user selection");
            Console.Write("Enter your choice: ");
        }


        static void ShowAdminMenu()
        {
            Console.WriteLine("Admin Menu:");
            Console.WriteLine("1. View excursions");
            Console.WriteLine("2. Add an excursion");
            Console.WriteLine("3. Remove an excursion");
            Console.WriteLine("4. View bookings");
            Console.WriteLine("5. Serialize excursions");
            Console.WriteLine("6. Deserialize excursions");
            Console.WriteLine("7. Back to user selection");
            Console.Write("Enter your choice: ");
        }

        static void ShowUserMenu()
        {
            Console.WriteLine("User Menu:");
            Console.WriteLine("1. View excursions");
            Console.WriteLine("2. Book an excursion");
            Console.WriteLine("3. Cancel booking");
            Console.WriteLine("4. Back to user selection");
            Console.Write("Enter your choice: ");
        }

        static void ViewExcursions()
        {
            currentUser.ViewExcursions(excursions);
        }

        static void BookExcursion()
        {
            try
            {
                Console.Write("Enter excursion ID to book: ");
                if (!int.TryParse(Console.ReadLine(), out int excursionId))
                    throw new InvalidInputException("Invalid excursion ID.");

                var excursion = excursions.FirstOrDefault(e => e.Id == excursionId);
                if (excursion == null)
                    throw new ExcursionNotFoundException("Excursion not found.");

                Console.Write("Enter number of participants: ");
                if (!int.TryParse(Console.ReadLine(), out int participants))
                    throw new InvalidInputException("Invalid number of participants.");

                currentUser.BookExcursion(excursion, participants);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        static void CancelBooking()
        {
            try
            {
                Console.Write("Enter excursion ID to cancel booking: ");
                if (!int.TryParse(Console.ReadLine(), out int excursionId))
                    throw new InvalidInputException("Invalid excursion ID.");

                var excursion = excursions.FirstOrDefault(e => e.Id == excursionId);
                if (excursion == null)
                    throw new ExcursionNotFoundException("Excursion not found.");

                currentUser.CancelExcursion(excursion);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void AddExcursion()
        {
            try
            {
                Console.Write("Enter excursion name: ");
                string name = Console.ReadLine();
                Console.Write("Enter excursion description: ");
                string description = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
                    throw new InvalidInputException("Name and description cannot be empty.");

                int newId = excursions.Max(e => e.Id) + 1;
                var newExcursion = new Excursion(newId, name, description);
                ((Admin)currentUser).AddExcursion(newExcursion);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void RemoveExcursion()
        {
            try
            {
                Console.Write("Enter excursion ID to remove: ");
                if (!int.TryParse(Console.ReadLine(), out int excursionId))
                    throw new InvalidInputException("Invalid excursion ID.");

                ((Admin)currentUser).RemoveExcursion(excursionId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ViewBookings()
        {
            ((Admin)currentUser).ViewBookings(excursions);
        }

        static void SerializeExcursions()
        {
            Console.Write("Enter the filename to serialize to: ");
            string filename = Console.ReadLine();

            string json = SerializationHelper.Serialize(excursions);
            System.IO.File.WriteAllText(filename, json);
            Console.WriteLine($"Serialized excursions to {filename}");
        }

        static void DeserializeExcursions()
        {
            Console.Write("Enter the filename to deserialize from: ");
            string filename = Console.ReadLine();

            if (System.IO.File.Exists(filename))
            {
                string json = System.IO.File.ReadAllText(filename);
                excursions = SerializationHelper.DeserializeExcursions(json);
                Console.WriteLine("Deserialized excursions successfully.");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }


    }
}