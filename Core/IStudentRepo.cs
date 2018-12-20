using System;
using System.Collections.Generic;

namespace Submitotron.Core
{
    public interface IStudentRepo
    {
        void TryAdd(Student item, out bool isSuccessful);
        void TryUpdate(Student item, out bool isSuccessful);
        void TryDelete(Student item, out bool isSuccessful);
        List<Student> GetItems();
        List<Student> GetItems(Func<Student, bool> predicate);
        Student GetItemById(string id);
    }
}