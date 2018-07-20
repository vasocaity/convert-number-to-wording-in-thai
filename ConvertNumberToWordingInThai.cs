using System;
using Xunit;

namespace PrimeService.Tests
{
    public class NumberThai
    {
        string[] digit_1 = { "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ" };
        string[] digit_2 = { "เอ็ด", "ยี่", "" };
        public string convertToThai(int number)
        {
            return convertUnit(number) + convertDigit2(number);
        }

        public string convertUnit(int number)
        {
            string thai_number = "";
            if (number == 1)
            {
                return digit_1[0];
            }
            if ((number / 10) == 0)
            {
                thai_number = digit_1[number - 1];
            }
            return thai_number;
        }
        public string convertDigit2(int number)
        {
            string result = "";
            int temp = number % 10;
            int d2 = number / 10;
            if (number == 10) return digit_1[9];
            if (number == 20) return "ยี่สิบ";
            if (number % 10 == 0 && number != 10)
            {
                result = number != 20 ? digit_1[d2 - 1] : digit_2[1];
                return result + digit_1[9];
            }
            return result;
        }
    }
    public class ConvertNumberToWordingInThai
    {

        [Fact]
        public void Test1()
        {
            var result = new NumberThai();
            Assert.Equal(result.convertToThai(1), "หนึ่ง");
            Assert.Equal(result.convertToThai(2), "สอง");
            Assert.Equal(result.convertToThai(3), "สาม");
            Assert.Equal(result.convertToThai(5), "ห้า");
            Assert.Equal(result.convertToThai(9), "เก้า");
            Assert.Equal(result.convertToThai(10), "สิบ");
            //Assert.Equal(result.convertToThai(11), "สิบเอ็ด");
            // Assert.Equal(result.convertToThai(15), "สิบห้า");
            // Assert.Equal(result.convertToThai(18), "สิบแปด");
            Assert.Equal(result.convertToThai(20), "ยี่สิบ");
            // Assert.Equal(result.convertToThai(21), "ยี่สิบเอ็ด");
            // Assert.Equal(result.convertToThai(25), "ยี่สิบห้า");
            Assert.Equal(result.convertToThai(50), "ห้าสิบ");
            // Assert.Equal(result.convertToThai(55), "ห้าสิบห้า");
            // Assert.Equal(result.convertToThai(71), "เจ็ดสิบเอ็ด");
            // Assert.Equal(result.convertToThai(99), "เก้าสิบเก้า");
            // Assert.Equal(result.convertToThai(100), "หนึ่งร้อย");
        }
    }
}
