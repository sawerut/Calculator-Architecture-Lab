using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CalcClassBr;

namespace CalculatorTests
{
    [TestClass]
    [DoNotParallelize] // Цей атрибут забороняє тестам виконуватись одночасно і змішувати _lastError
    public class Test1
    {
        public static IEnumerable<object[]> GetDivTestData()
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DivTestsDB;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ParamA, ParamB, ExpectedResult, ExpectedError FROM DivTests";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new object[]
                        {
                            Convert.ToInt64(reader["ParamA"]),
                            Convert.ToInt64(reader["ParamB"]),
                            reader["ExpectedResult"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ExpectedResult"]),
                            reader["ExpectedError"] == DBNull.Value ? null : reader["ExpectedError"].ToString().Trim()
                        };
                    }
                }
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetDivTestData), DynamicDataSourceType.Method)]
        public void Test_DivMethod(long a, long b, int expectedResult, string expectedError)
        {
            CalcClassBr.CalcClass.lastError = "";

            int actualResult = CalcClassBr.CalcClass.Div(a, b);

            if (string.IsNullOrEmpty(expectedError))
            {
                Assert.AreEqual(expectedResult, actualResult, $"Неправильний результат для {a}/{b}.");
                Assert.AreEqual("", CalcClassBr.CalcClass.lastError, $"Для {a}/{b} виявлено несподівану помилку.");
            }
            else
            {
                bool containsError = CalcClassBr.CalcClass.lastError.Contains(expectedError);
                Assert.IsTrue(containsError, $"Очікувалась помилка '{expectedError}', але отримано '{CalcClassBr.CalcClass.lastError}'");
            }
        }
    }
}