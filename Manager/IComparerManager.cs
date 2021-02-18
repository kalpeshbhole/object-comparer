using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{
    public interface IComparerManager
    {
        bool Compare<T>(T first, T second);
    }
}
