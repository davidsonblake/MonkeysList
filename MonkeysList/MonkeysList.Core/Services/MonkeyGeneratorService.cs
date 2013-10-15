using System;
using MonkeysList.Core.Models;

namespace MonkeysList.Core.Services
{
    public class MonkeyGeneratorService : IMonkeyGenerator
    {
        public Monkey GenerateMonkey()
        {
            return new Monkey {ImageUrl = string.Format("http://placemonkey.heroku.com/{0}/{0}", Random(20) + 500)};
        }

        private readonly Random _random = new Random();
        protected int Random(int count)
        {
            return _random.Next(count);
        }

    }
}
