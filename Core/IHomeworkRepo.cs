using System;
using System.Collections.Generic;

namespace Submitotron.Core
{
    public interface IHomeworkRepo
    {
        void TryAdd(Homework item, out bool isSuccessful);
        void TryUpdate(Homework item, out bool isSuccessful);
        void TryDelete(Homework item, out bool isSuccessful);
        List<Homework> GetItems();
        List<Homework> GetItems(Func<Homework, bool> predicate);
        Homework GetItemById(string id);
    }
}