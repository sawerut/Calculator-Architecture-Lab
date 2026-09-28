using System;
using ErrorLibrary;

namespace CalcClassBr
{
    public class CalcClass
    {
        private static string _lastError = "";

        public static string lastError
        {
            get { return _lastError; }
            set { _lastError = value; }
        }

        public static int Add(long a, long b)
        {
            _lastError = "";
            long res;
            if (a <= int.MaxValue && a >= int.MinValue && b <= int.MaxValue && b >= int.MinValue)
                res = a + b;
            else
            {
                _lastError = ErrorsExpression.ERROR_06;
                throw new ArgumentOutOfRangeException(_lastError);
            }

            if (res <= int.MaxValue && res >= int.MinValue)
                return (int)res;
            else
            {
                _lastError = ErrorsExpression.ERROR_06;
                throw new ArgumentOutOfRangeException(_lastError);
            }
        }

        public static int Sub(long a, long b)
        {
            _lastError = "";
            long res;
            if (a <= int.MaxValue && a >= int.MinValue && b <= int.MaxValue && b >= int.MinValue)
                res = a - b;
            else
            {
                _lastError = ErrorsExpression.ERROR_06;
                throw new ArgumentOutOfRangeException(_lastError);
            }

            if (res <= int.MaxValue && res >= int.MinValue)
                return (int)res;
            else
            {
                _lastError = ErrorsExpression.ERROR_06;
                throw new ArgumentOutOfRangeException(_lastError);
            }
        }

        public static int Mult(long a, long b)
        {
            _lastError = "";
            long res;
            if (a <= int.MaxValue && a >= int.MinValue && b <= int.MaxValue && b >= int.MinValue)
                res = a * b;
            else
            {
                _lastError = ErrorsExpression.ERROR_06;
                throw new ArgumentOutOfRangeException(_lastError);
            }

            if (res <= int.MaxValue && res >= int.MinValue)
                return (int)res;
            else
            {
                _lastError = ErrorsExpression.ERROR_06;
                throw new ArgumentOutOfRangeException(_lastError);
            }
        }

        public static int Div(long a, long b)
        {
            _lastError = "";
            try
            {
                if (b == 0)
                {
                    _lastError = "Error 09 — Помилка ділення на 0.";
                    return 0;
                }

                if (a > int.MaxValue || a < int.MinValue || b > int.MaxValue || b < int.MinValue)
                {
                    _lastError = "Error 06 — Дуже мале, або дуже велике значення числа для int.";
                    return 0;
                }

                long res = a / b;

                if (res > int.MaxValue || res < int.MinValue)
                {
                    _lastError = "Error 06 — Дуже мале, або дуже велике значення числа для int.";
                    return 0;
                }

                return (int)res;
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
                return 0;
            }
        }

        public static int Mod(long a, long b)
        {
            _lastError = "";
            long res;
            if (a <= int.MaxValue && a >= int.MinValue && b <= int.MaxValue && b >= int.MinValue)
            {
                if (b != 0)
                    res = a % b;
                else
                {
                    _lastError = ErrorsExpression.ERROR_09;
                    throw new DivideByZeroException(_lastError);
                }
            }
            else
            {
                _lastError = ErrorsExpression.ERROR_06;
                throw new ArgumentOutOfRangeException(_lastError);
            }

            if (res <= int.MaxValue && res >= int.MinValue)
                return (int)res;
            else
            {
                _lastError = ErrorsExpression.ERROR_06;
                throw new ArgumentOutOfRangeException(_lastError);
            }
        }

        public static int ABS(long a)
        {
            _lastError = "";
            long res;
            if (a <= int.MaxValue && a >= int.MinValue)
            {
                res = a;
                return (int)res;
            }
            else
            {
                _lastError = ErrorsExpression.ERROR_06;
                throw new ArgumentOutOfRangeException(_lastError);
            }
        }

        public static int IABS(long a)
        {
            _lastError = "";
            long res;
            if (a <= int.MaxValue && a >= int.MinValue)
            {
                res = a * -1;
                return (int)res;
            }
            else
            {
                _lastError = ErrorsExpression.ERROR_06;
                throw new ArgumentOutOfRangeException(_lastError);
            }
        }
    }
}