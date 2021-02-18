using Manager;

namespace ObjectComparer
{
    public class Comparer
    {
        private readonly IComparerManager _comparerManager;
        public Comparer(IComparerManager comparerManager)
        {
            _comparerManager = comparerManager;
        }

        public bool AreSimilar<T>(T first, T second)
        {
            return _comparerManager.Compare(first, second);
        }
    }
}
