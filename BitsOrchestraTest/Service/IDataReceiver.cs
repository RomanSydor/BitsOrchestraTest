using BitsOrchestraTest.Models;
using System.Collections.Generic;

namespace BitsOrchestraTest.Service
{
    public interface IDataReceiver
    {
        IEnumerable<User> ParseToUsers(string csvLine);
    }
}
