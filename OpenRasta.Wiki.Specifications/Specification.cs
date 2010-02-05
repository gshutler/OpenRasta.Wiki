using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Rhino.Mocks;

namespace OpenRasta.Wiki.Specifications
{
    [TestFixture]
    public abstract class Specification
    {
        readonly FakeManager fakeManager = new FakeManager();

        [TestFixtureSetUp]
        public void Setup()
        {
            CommonContext();
            Given();
            When();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            TidyUp();
        }

        protected virtual void CommonContext() {}
        protected abstract void Given();
        protected abstract void When();
        protected virtual void TidyUp() {}

        protected T Dependency<T>()
        {
            return fakeManager.Dependency<T>();
        }

        protected void InjectDependency<T>(T dependency)
        {
            fakeManager.InjectDependency(dependency);
        }

        protected T Subject<T>()
        {
            return fakeManager.ConstructedObject<T>();
        }

        protected void Verify<T>(T actual, IResolveConstraint assertion)
        {
            Assert.That(actual, assertion);
        }
    }
}