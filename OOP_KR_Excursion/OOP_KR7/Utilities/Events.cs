namespace OOP_KR
{
    public static class Events
    {
        public static void OnBookingCreated(int userId, int participants)
        {
            Console.WriteLine($"User {userId} booked {participants} participants.");
        }

        public static void OnBookingCanceled(int userId)
        {
            Console.WriteLine($"User {userId} canceled their booking.");
        }
    }
}