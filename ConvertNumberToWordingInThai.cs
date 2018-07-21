using System;
using Xunit;

namespace PrimeService.Tests
{
    public class NumberThai
    {
        string[] digit_1 = { "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ" };
        public string convertToThai(int number)
        {
            string result = "";
            int firstDigit = number / 10;
            int secondDigit = number % 10;

            if (firstDigit == 10) return "หนึ่งร้อย";
            if (firstDigit == 0)
            {
                return digit_1[number - 1];
            }
            else if (firstDigit == 1)
            {
                result = convertSecondDigit(secondDigit);
                return result;
            }
            else if (firstDigit >= 2)
            {
                result = (firstDigit == 2 ? "ยี่" : digit_1[firstDigit - 1]);
                result += convertSecondDigit(secondDigit);
                return result;
            }
            return result;
        }

        public string convertSecondDigit(int secondDigit)
        {
            string result = "";
            if (secondDigit != 0)
            {
                result += "สิบ" + (secondDigit == 1 ? "เอ็ด" : digit_1[secondDigit-1]);
                return result;
            }
            return "สิบ";
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
            Assert.Equal(result.convertToThai(11), "สิบเอ็ด");
            Assert.Equal(result.convertToThai(15), "สิบห้า");
            Assert.Equal(result.convertToThai(18), "สิบแปด");
            Assert.Equal(result.convertToThai(20), "ยี่สิบ");
            Assert.Equal(result.convertToThai(21), "ยี่สิบเอ็ด");
            Assert.Equal(result.convertToThai(22), "ยี่สิบสอง");
            Assert.Equal(result.convertToThai(25), "ยี่สิบห้า");
            Assert.Equal(result.convertToThai(50), "ห้าสิบ");
            Assert.Equal(result.convertToThai(55), "ห้าสิบห้า");
            Assert.Equal(result.convertToThai(71), "เจ็ดสิบเอ็ด");
            Assert.Equal(result.convertToThai(99), "เก้าสิบเก้า");
            Assert.Equal(result.convertToThai(91), "เก้าสิบเอ็ด");
            Assert.Equal(result.convertToThai(100), "หนึ่งร้อย");
        }
    }
}
