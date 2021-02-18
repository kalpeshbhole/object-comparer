using System;

namespace Manager
{
    public class Comparer2Manager : IComparerManager
    {
        bool IComparerManager.Compare<T>(T first, T second)
        {
            throw new NotImplementedException();
        }
    }
}
