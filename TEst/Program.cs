using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Service;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;
using System;

namespace TEst
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<User> user = new GenericDataService<User>(new SimpleTraderDbContext());
            user.Create(new User { UserName="Test"}).Wait();

        }
    }
}
