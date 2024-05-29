namespace OOP_KR
{
    public class Admin : User, IAdmin
    {

        public Admin(int id, string username, string password) : base(id, username, password) { }

        public void AddExcursion(IExcursion excursion)
        {

            Program.excursions.Add(excursion);
            Console.WriteLine($"Excursion {excursion.Name} added.");
        }

        public void RemoveExcursion(int excursionId)
        {

            var excursion = Program.excursions.FirstOrDefault(e => e.Id == excursionId);
            if (excursion != null)
            {
                Program.excursions.Remove(excursion);
                Console.WriteLine($"Excursion {excursion.Name} removed.");
            }
            else
            {
                Console.WriteLine("Excursion not found.");
            }
        }

        public void ViewBookings(List<IExcursion> excursions)
        {
            foreach (var excursion in excursions)
            {
                Console.WriteLine($"Bookings for {excursion.Name}:");
                var bookings = (excursion as Excursion)?.GetBookings();
                if (bookings != null)
                {
                    foreach (var booking in bookings)
                    {
                        Console.WriteLine($"User {booking.Key} booked {booking.Value} participants.");
                    }
                }
            }
        }
    }
}