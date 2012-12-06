using Moq;
using Moq.Contrib.Indy;

namespace Blog.Core.Tests
{
    public class TestContext<T> where T : class
    {
        private readonly IMockContainer _mockContainer;
        private readonly MockRepository _mockRepository;
        readonly T _classUnderTest;

        public TestContext()
        {
            _mockRepository = new MockRepository(MockBehavior.Default);
            _mockContainer = new AutoMockContainer(_mockRepository);
            _classUnderTest = _mockContainer.Create<T>();
            Given();
        }

        /// <summary>
        /// Ran before each test
        /// </summary>
        protected virtual void Given()
        {
        }

        protected T ClassUnderTest
        {
            get { return _classUnderTest; }
        }

        protected IMockContainer Container
        {
            get { return _mockContainer; }
        }

    }
}