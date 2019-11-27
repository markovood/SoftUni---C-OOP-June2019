namespace HotelReservation
{
    using System;
    using System.Diagnostics;

    public class StartUp
    {
        public static void Main()
        {
            string[] reservationInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            decimal pricePerDay = decimal.Parse(reservationInfo[0]);
            int numberOfDays = int.Parse(reservationInfo[1]);
            var season = Season.Spring;
            switch (reservationInfo[2])
            {
                case "Spring":
                    season = Season.Spring;
                    break;
                case "Summer":
                    season = Season.Summer;
                    break;
                case "Autumn":
                    season = Season.Autumn;
                    break;
                case "Winter":
                    season = Season.Winter;
                    break;
            }

            var discount = DiscountType.None;
            if (reservationInfo.Length == 4)
            {
                switch (reservationInfo[3])
                {
                    case "VIP":
                        discount = DiscountType.VIP;
                        break;
                    case "SecondVisit":
                        discount = DiscountType.SecondVisit;
                        break;
                }
            }

            var totalPrice = PriceCalculator.GetTotalPrice(pricePerDay, numberOfDays, season, discount);
            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}