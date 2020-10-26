using BitsOrchestraTest.Models;
using System;
using System.Collections.Generic;

namespace BitsOrchestraTest.Service
{
    public class DataReceiverCSV : IDataReceiver
    {
        public IEnumerable<User> ParseToUsers(string csvLine)
        {
            DataValidation _validation = new DataValidation();

            string[] rows = csvLine.Split("\n");

            for (int i = 1; i < rows.Length; i++)
            {
                string[] values = rows[i].Split(",");
                User user = new User();

                user.Name = Convert.ToString(values[0]);

                if (_validation.StringToDateTime(values[1]))
                {
                    user.DateOfBirth = Convert.ToDateTime(values[1]);
                }
                else
                {
                    return null;
                }

                if (_validation.StringToBoolean(values[2]))
                {
                    user.Married = Convert.ToBoolean(values[2]);
                }
                else
                {
                    return null;
                }

                user.Phone = Convert.ToString(values[3]);

                if (_validation.StringToDecimal(values[4]))
                {
                    user.Salary = Convert.ToDecimal(values[4]);
                }
                else
                {
                    return null;
                }

                UsersList.Users.Add(user);
            }

            return UsersList.Users;
        }
    }
}
