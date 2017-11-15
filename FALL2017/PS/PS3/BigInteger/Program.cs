using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace BigInteger
{
	public class BigInteger
	{
		private bool _sign;

		private readonly List<byte> _digits =  new List<byte>();
		
        #region Constructors

        public BigInteger(string s)
		{
			var output = new BigInteger(new List<byte> { 0 });

			bool check = false;

			int add = 0;

			if (s[0] == '-')
			{
				check = true;
				add++;
			}
			
			for (int i = add; i < s.Length; i++)
			{
				output *= 10;
				output += new BigInteger(new List<byte> { (byte)(s[i] - '0') });
			}
			
			_digits = output._digits;

			_sign = check;
		}
		
		public BigInteger(IEnumerable<byte> bytes)
		{
			_digits.AddRange(bytes);
		}

		public BigInteger(IEnumerable<byte> bytes, bool sign)
		{
			_digits.AddRange(bytes);
			_sign = sign;
		}

		public BigInteger()
		{
		}

        #endregion

        #region Addition

        public static BigInteger Addition(BigInteger first, BigInteger second)
        {

            var sum = new BigInteger(first._digits);
            var isCarry = false;
            for (int i = 0; i < second._digits.Count; i++)
            {
                var add = sum._digits[i] + second._digits[i] + (isCarry ? 1 : 0);
                isCarry = (add >> 8) > 0;
                sum._digits[i] = (byte)add;
            }
            var carryIndex = second._digits.Count;
            while (isCarry)
            {
                if (sum._digits.Count > carryIndex)
                {
                    sum._digits[carryIndex] += 1;
                    if (sum._digits[carryIndex] != 0) isCarry = false;
                    carryIndex++;
                }
                else
                {
                    sum._digits.Add(1);
                    isCarry = false;
                }
            }
            return sum;
        }
        public static BigInteger operator +(BigInteger first, BigInteger second)
        {
            if (AbsCompare(first, second) == -1)
            {
                var temp = second;
                second = first;
                first = temp;
            }
            var result = first._sign == second._sign ? Addition(first, second) : Substraction(first, second);
            result._sign = first._sign;
            return result;
        }

        #endregion

        #region Substraction

        public static BigInteger Substraction(BigInteger first, BigInteger second)
        {
            var sum = new BigInteger(first._digits);
            var isCarry = false;
            for (int i = 0; i < second._digits.Count; i++)
            {
                var isCarryNext = sum._digits[i] < second._digits[i];
                sum._digits[i] -= (byte)(second._digits[i] + (isCarry ? 1 : 0));
                isCarry = isCarryNext;
            }
            var carryIndex = second._digits.Count;
            while (isCarry)
            {
                if (sum._digits[carryIndex] != 0) isCarry = false;
                sum._digits[carryIndex] -= 1;
                carryIndex++;
            }
            var lastIndex = sum._digits.Count;
			while (lastIndex != 0 && sum._digits[--lastIndex] == 0) ;
            sum._digits.RemoveRange(lastIndex + 1, sum._digits.Count - lastIndex - 1);

            return sum;
        }

        public static BigInteger operator -(BigInteger first, BigInteger second)
        {
            if (first.Equals(second))
                second = new BigInteger(second._digits) { _sign = !first._sign };
            else
                second._sign = !second._sign;

            var result = first + second;

            second._sign = !second._sign;

            return result;
        }

        #endregion

        #region Multiplication

        public static BigInteger operator *(BigInteger number, byte b)
        {
            var result = new BigInteger(number._digits);

            byte carry = 0;

            for (int i = 0; i < result._digits.Count; i++)
            {
                int intermediate = result._digits[i] * b;
                var addCarry = ((intermediate & 255) + carry) >> 8;
                result._digits[i] = (byte)((intermediate & 255) + carry);
                carry = (byte)((intermediate >> 8) + addCarry);
            }

            if (carry > 0)
                result._digits.Add(carry);

            return result;
        }

        public static BigInteger operator *(BigInteger first, BigInteger second)
        {
            var result = new BigInteger();
            if (AbsCompare(first, second) == -1)
            {
                var temp = second;
                second = first;
                first = temp;
            }

            for (int i = 0; i < second._digits.Count; i++)
                MultiplicationAdd(result, first * second._digits[i], i);
            var lastIndex = result._digits.Count;
            while (lastIndex != 0 && result._digits[--lastIndex] == 0) ;
            result._digits.RemoveRange(lastIndex + 1, result._digits.Count - lastIndex - 1);
            result._sign = first._sign != second._sign;
            return result;
        }

        private static void MultiplicationAdd(BigInteger result, BigInteger longNumber, int index)
        {

            var isCarry = false;
            for (int i = 0; i < longNumber._digits.Count; i++)
            {
                if (result._digits.Count == i + index) result._digits.Add(0);
                var add = result._digits[i + index] + longNumber._digits[i] + (isCarry ? 1 : 0);

                isCarry = (add >> 8) > 0;
                result._digits[i + index] = (byte)add;

            }
            var carryIndex = longNumber._digits.Count + index;
            while (isCarry)
            {
                if (result._digits.Count > carryIndex)
                {
                    result._digits[carryIndex] += 1;
                    if (result._digits[carryIndex] != 0) isCarry = false;
                    carryIndex++;
                }
                else
                {
                    result._digits.Add(1);
                    isCarry = false;
                }
            }

        }

        #endregion

        #region Division

        public static Tuple<BigInteger, BigInteger> Divide(BigInteger dividend, BigInteger divider)
		{
			var result = new BigInteger();
			var residue = new BigInteger(dividend._digits, dividend._sign);

			if (AbsCompare(dividend, divider) == -1)
			{
				result._digits.Add(0);
				return new Tuple<BigInteger, BigInteger>(result, residue);
			}
			var discharge = residue._digits.Count - divider._digits.Count;

			for (int i = 0; i < discharge; i++) divider._digits.Insert(0, 0);

			for (int i = 0; i < discharge; i++)
			{
				if (AbsCompare(residue, divider) == -1)
					result._digits.Insert(0, 0);
				else
				{
					var cont = GetDivider(residue, divider);
					result._digits.Insert(0, cont.Item1);
					residue = cont.Item2;

				}
				divider._digits.RemoveAt(0);
			}
			if (AbsCompare(residue, divider) == -1)
				result._digits.Insert(0, 0);
			else
			{
				var cont = GetDivider(residue, divider);
				result._digits.Insert(0, cont.Item1);
				residue = cont.Item2;

			}


			var lastIndex = result._digits.Count;
			while (lastIndex != 0 && result._digits[--lastIndex] == 0) ;
			result._digits.RemoveRange(lastIndex + 1, result._digits.Count - lastIndex - 1);
			result._sign = dividend._sign != divider._sign;
			return new Tuple<BigInteger, BigInteger>(result, residue);
		}

		private static Tuple<Byte, BigInteger> GetDivider(BigInteger residue, BigInteger second)
		{
			var down = 0;
			var up = 256;
			while (down + 1 < up)
			{
				var newValue = second * (byte)((down + up) / 2);

				if (AbsCompare(residue, newValue) == -1)
				{
					up = (down + up) / 2;
				}
				else
				{
					down = (down + up) / 2;
				}
			}

			var residueOut = Substraction(residue, second * (byte)down);
			residueOut._sign = residue._sign;

			return new Tuple<Byte, BigInteger>((byte)down, residueOut);
		}
        
		public static BigInteger operator /(BigInteger first, BigInteger second)
		{
			return Divide(first, second).Item1;
		}
		public static BigInteger operator %(BigInteger first, BigInteger second)
		{
			return Divide(first, second).Item2;
		}


        #endregion

        #region Comparison

        public static bool operator >(BigInteger first, BigInteger second)
		{
			if (first._sign)
			{
				if (second._sign)
					return AbsCompare(first, second) == -1;

				return false;
			}

			if (second._sign)
				return true;

			return AbsCompare(first, second) == 1;
		}

		public static bool operator <(BigInteger first, BigInteger second)
		{
			return second > first;
		}

		public static bool operator <=(BigInteger first, BigInteger second)
		{
			return (first == second) || (first < second);
		}

		public static bool operator >=(BigInteger first, BigInteger second)
		{
			return (first == second) || (first > second);
		}

		public static bool operator ==(BigInteger first, BigInteger second)
		{
			if (first._sign != second._sign) return false;

			return AbsCompare(first, second) == 0;
		}

		public static bool operator !=(BigInteger first, BigInteger second)
		{
			return !(first == second);
		}

        public static int AbsCompare(BigInteger first, BigInteger second)
        {
            if (first._digits.Count < second._digits.Count)
                return -1;

            if (first._digits.Count > second._digits.Count)
                return 1;

            for (int i = first._digits.Count - 1; i >= 0; i--)
            {
                if (first._digits[i] < second._digits[i])
                    return -1;

                if (first._digits[i] > second._digits[i])
                    return 1;
            }
            return 0;
        }

        #endregion

        #region Convertors

        public override string ToString()
        {
            var sb = new StringBuilder();
            var add = 0;
            if (_sign)
            {
                sb.Append('-');
                add++;
            }
            int counter = 0;
            var forOut = new BigInteger(_digits);
            while (forOut._digits.Count > 1 || forOut._digits[0] > 9)
            {
                var div = forOut / 10;
                var mod = forOut % 10;
                forOut = div;
                sb.Insert(add, (char)('0' + mod._digits[0]));
                counter++;
                if (counter == 3)
                {
                    sb.Insert(0, " ");
                    counter = 0;
                }
            }
            sb.Insert(add, (char)('0' + forOut._digits[0]));
            return sb.ToString().TrimStart(' ');
        }

        public static string ConverToBinary(BigInteger number)
        {
			var counter = 0;
            var sb = new StringBuilder();
            while (number > 0)
            {
				sb.Insert(0, number % 2);
				number = number / 2;
                counter++;
                if (counter == 4)
                {
                    sb.Insert(0, " ");
                    counter = 0;
                }
            }
            for (int i = 0; i < 4 - counter; i++)
                sb.Insert(0, "0");
            return sb.ToString().TrimStart(' ');
        }

        public static string ConverToOct(BigInteger number)
        {
            var counter = 0;
            var sb = new StringBuilder();
            while (number > 0)
            {
				sb.Insert(0, number % 8); 
                number = number / 8;
                counter++;
                if (counter == 3)
                {
                    sb.Insert(0, " ");
                    counter = 0;
                }
            }
            return sb.ToString().TrimStart(' ');
        }

        public static string ConverToHex(BigInteger number)
        {
			var counter = 0;
            var sb = new StringBuilder();
            while (number > 0)
            {
                var residue = number % 16;
                number = number / 16;
                if (residue >= 10)
                    sb.Insert(0, (char)(residue._digits[0] + 55));
                else
                    sb.Insert(0, residue);
                counter++;
                if (counter == 4)
                {
                    sb.Insert(0, " ");
                    counter = 0;
                }
            }
            return sb.ToString().TrimStart(' ');
        }

		#endregion

		public static implicit operator BigInteger(int value)
		{
			return new BigInteger(value.ToString());
		}

		public static implicit operator BigInteger(string value)
		{
			return new BigInteger(value);
		}

		public static BigInteger Factorial(BigInteger number, out double time)
		{
            var sw = new Stopwatch();
			BigInteger result = 1;
			
			sw.Start();
			for (int i = 2; i <= number; ++i)
				result *= i;
			sw.Stop();
			
			time = sw.ElapsedMilliseconds;
			return result;
			
		}
		
        public static BigInteger FactTree(BigInteger number, out double time)
        {
            time = 0;
            if (number < 0)
                return 0;
            var sw = new Stopwatch();
            sw.Start();
            var result = ProdTree(2, number);
            sw.Stop();
            time = sw.ElapsedMilliseconds;
            return result;
        }
        public static BigInteger ProdTree(BigInteger left, BigInteger right)
        {
            if (left > right)
                return 1;
            if (left == right)
                return left;
            if (right - left == 1)
                return left * right;
            BigInteger m = (left + right) / 2;
            return ProdTree(left, m) * ProdTree(m+1, right);
        }
    }

	class Program
	{
		
		static void Main()
		{
			BigInteger a = "1232365734534536";
			Console.WriteLine(a);
        }
	}
}