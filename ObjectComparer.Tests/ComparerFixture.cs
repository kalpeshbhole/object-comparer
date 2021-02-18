using Manager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;

namespace ObjectComparer.Tests
{
    [TestClass]
    public class ComparerFixture
    {

        private readonly Comparer _comparer;

        public ComparerFixture()
        {
            //Mock<ComparerManager> _comparerManager = new Mock<ComparerManager>();
            //_comparerManager.Setup(x => x.Compare(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            //_comparer = new Comparer(_comparerManager.Object);

            _comparer = new Comparer(new ComparerManager());
        }

        [TestMethod]
        public void Null_values_are_similar_test()
        {
            string first = null, second = null;
            Assert.IsTrue(_comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void Objects_are_similar_test()
        {
            Student first = new Student
            {
                Id = 100,
                Name = "John",
                Marks = new[] { 80, 90, 100 }
            },
            second = new Student
            {
                Id = 100,
                Name = "John",
                Marks = new[] { 80, 90, 100 }
            };
            Assert.IsTrue(_comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void Objects_all_are_similar_test()
        {
            Student first = new Student
            {
                Id = 100,
                Name = "John",
                Marks = new[] { 80, 90, 100 },
                Percentage = 55.5
            },
            second = new Student
            {
                Id = 100,
                Name = "John",
                Marks = new[] { 80, 90, 100 },
                Percentage = 55.5
            };
            Assert.IsTrue(_comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void Objects_array_property_similar_test()
        {
            Student first = new Student
            {
                Id = 100,
                Name = "John",
                Marks = new[] { 80, 90, 100 }
            },
            second = new Student
            {
                Id = 100,
                Name = "John",
                Marks = new[] { 100, 80, 90 }
            };
            Assert.IsTrue(_comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void Objects_are_not_similar_test()
        {
            Student first = new Student
            {
                Id = 100,
                Name = "John",
                Marks = new[] { 80, 90, 100 }
            },
            second = new Student
            {
                Id = 100,
                Name = "John",
                Marks = new[] { 80, 90 }
            };
            Assert.IsFalse(_comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void Objects_property_not_similar_test()
        {
            Student first = new Student
            {
                Id = 100,
                Name = "John",
                Marks = new[] { 80, 90, 100 }
            },
            second = new Student
            {
                Id = 101,
                Name = "John",
                Marks = new[] { 80, 90, 100 }
            };
            Assert.IsFalse(_comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void Dynamic_objects_are_similar_test()
        {
            dynamic first = new
            {
                Id = 100,
                Name = "John",
                Marks = new[] { 80, 90, 100 }
            };

            dynamic second = new
            {
                Id = 100,
                Name = "John",
                Marks = new[] { 80, 90, 100 }
            };
            Assert.IsTrue(_comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void Dynamic_objects_are_not_similar_test()
        {
            dynamic first = new
            {
                Id = 100,
                Name = "John",
                Marks = new[] { 80, 90, 100 }
            };

            dynamic second = new
            {
                Id = 101,
                Name = "John",
                Marks = new[] { 80, 90, 100 }
            };
            Assert.IsFalse(_comparer.AreSimilar(first, second));
        }
    }
}
