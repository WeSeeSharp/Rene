using System;
using NUnit.Framework;
using NSubstitute;

using LearningAboutMocks.src.ViewController;
using LearningAboutMocks.src.View;
using LearningAboutMocks.exceptions;
using LearningAboutMocks.src.factory;

namespace LearningAboutMockTests
{
    [TestFixture]
    public class TestViewController
    {
        ViewController sut;

        [SetUp]
        public void SetItUp()
        {
            var view = Substitute.For<IView>();
            var factory = Substitute.For<IWorkerFactory>();
            sut = new ViewController(view, factory);
        }

        [Test]
        public void RaisesCustomExceptions()
        {
            var testStartTime = new DateTime(2018, 2, 3);
            var testEndTime = new DateTime();

            sut.SetStartTime(testStartTime);

            Assert.Throws<ANewException>(() =>sut.Update());
        }
    }
}
