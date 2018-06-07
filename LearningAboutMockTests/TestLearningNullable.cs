using NUnit.Framework;

namespace LearningAboutMockTests
{
    class NullingObject
    {
        int? x = 32;
        int? y = null;
        //int z = null;
        int a = 5;

        public NullingObject() { } /*Well, Reference Objects can be Nulled by default and don't need anything new. However, Value Types need a little more help.*/
    }

    class TestLearningNullable
    {
        [Test]
        public void TestValueTypesMustBeInitialized()
        {
            //int b = null;
            int c = 5;
            
            var d = new NullingObject();

            Assert.False(d == null);

            d = null;

            Assert.True(d == null);
        }

        [Test]
        public void TestNullCoallesing()
        {
            int? b = null;

            Assert.IsNull(b);

            if (b == null) {
                var k = 3;
            }

            var c = b ?? 3;

            Assert.IsNotNull(c);
            Assert.AreEqual(c, 3);

            b = 6;
            Assert.IsNotNull(b);
            Assert.AreEqual(b, 6);
        }
    }
}
