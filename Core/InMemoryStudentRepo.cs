using System;
using System.Collections.Generic;

namespace Submitotron.Core
{
    public class InMemoryStudentRepo : IStudentRepo
    {
        public Student GetItemById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetItems()
        {
            throw new NotImplementedException();
        }

        public List<Student> GetItems(Func<Student, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void TryAdd(Student item, out bool isSuccessful)
        {
            throw new NotImplementedException();
        }

        public void TryDelete(Student item, out bool isSuccessful)
        {
            throw new NotImplementedException();
        }

        public void TryUpdate(Student item, out bool isSuccessful)
        {
            throw new NotImplementedException();
        }
    }
}