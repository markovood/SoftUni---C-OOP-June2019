using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    public static class PriceCalculator
    {
        public static decimal GetTotalPrice(decimal pricePerDay, int numbOfDays, Season season, DiscountType discount)
        {
            decimal price = pricePerDay * numbOfDays * (int)season;
            decimal reducedPrice = price  * ((int)discount / 100m);
            return price - reducedPrice;
        }
    }
}
