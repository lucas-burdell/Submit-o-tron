using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Submitotron.Core
{
    public class InMemoryHomeworkRepo : IHomeworkRepo
    {

        private readonly List<Homework> _homeworks = new List<Homework>();
        private readonly IConfiguration _configuration;
        public InMemoryHomeworkRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public InMemoryHomeworkRepo(IConfiguration configuration, List<Homework> homeworks)
        {
            _configuration = configuration;
            _homeworks = homeworks;
        }

        public Homework GetItemById(string id)
        {
            return _homeworks.FirstOrDefault(x => x.ID == id);
        }

        public List<Homework> GetItems()
        {
            throw new NotImplementedException();
        }

        public List<Homework> GetItems(Func<Homework, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void TryAdd(Homework item, out bool isSuccessful)
        {
            throw new NotImplementedException();
        }

        public void TryDelete(Homework item, out bool isSuccessful)
        {
            throw new NotImplementedException();
        }

        public void TryUpdate(Homework item, out bool isSuccessful)
        {
            throw new NotImplementedException();
        }
    }
}