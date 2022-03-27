using System;

namespace PromoCodeManagementSystem.Common
{
    public class PromocodeGenerate
    {
        public static string Generate()
        {
            Random randomNumber = new Random();
            string promocode = randomNumber.Next(1, 100000).ToString("D6");

            Random random = new Random();
            for (int r = 1; r <= 5; r++)
            {
                int randomAlphabet = random.Next(65, 91);
                promocode += Convert.ToChar(randomAlphabet);
            }
            return promocode;
        }
    }
}
