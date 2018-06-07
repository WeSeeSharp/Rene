using NUnit.Framework;

namespace LearningAboutMockTests
{
    class Box
    {
        int Height { get; set; }
        int Width { get; set; }
        int Length { get; set; }

        public Box(int x, int y, int z)
        {
            Height = x;
            Width = y;
            Length = z;
        }

        public int GetVolume()
        {
            return Height * Width * Length;
        }
    }

    class Box2
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }

        public Box2()
        {}

        public Box2(int x, int y, int z)
        {
            Height = x;
            Width = y;
            Length = z;
        }

        public int GetVolume()
        {
            return Height * Width * Length;
        }

        public static Box2 operator +(Box2 b, Box2 c)
        {
            Box2 box = new Box2();
            box.Length = b.Length + c.Length;
            box.Width = b.Width + c.Width;
            box.Height = b.Height + c.Height;
            return box;
        }

        //Lets do a subtract operator
        //public static Box2 operator -(Box2 b, Box2 c)
        //{
        //    Box2 box = new Box2();
        //    return box;
        //}

        //Lets do a multiply operator
        //public static Box2 operator *(Box2 b, Box2 c)
        //{
        //    Box2 box = new Box2();
        //    return box;
        //}

        //Lets do a ++ operator
        //public static Box2 operator -(Box2 b, Box2 c)
        //{
        //    Box2 box = new Box2();
        //    return box;
        //}

        //Lets do a == operator
//        public static bool operator ==(Box2 b, Box2 c)
//        {
//            return ((b.Length == c.Length) && (b.Width == c.Width) && (b.Height == c.Height));
//        }

        //public static bool operator !=(Box2 b, Box2 c)
        //{
        //    return ((b.Length == c.Length) && (b.Width == c.Width) && (b.Height == c.Height));
        //}

        public static Box2 operator -(Box2 firstBox, Box2 secondBox)
        {
            var subtractedBox = new Box2();
            subtractedBox.Height = firstBox.Height - secondBox.Height;
            subtractedBox.Width = firstBox.Width - secondBox.Width;
            subtractedBox.Length = firstBox.Length - secondBox.Length;
            return subtractedBox;
        }
        
        
        
        
        
        
    }

    class TestingOperatorOverloader
    {
        [Test]
        public void TestCantAddComplexObjects()
        {
            var box1 = new Box(1, 2, 3);
            var box2 = new Box(4, 5, 6);

//            var box3 = box1 + box2;
        }

        [Test]
        public void TestCanAddComplexObjectsWhenYouOverloadTheOperatorInAComplexObject()
        {
            var box1 = new Box2(1, 2, 3);
            var box2 = new Box2(4, 5, 6);

            var box3 = box1 + box2;

            var expectedValue = (1 + 4) * (2 + 5) * (3 + 6);

            Assert.AreEqual(expectedValue, box3.GetVolume());
        }
        
        [Test]
        public void TestCanSubtractComplexObjectsWhenYouOverloadTheOperatorInAComplexObject()
        {
            var box1 = new Box2(1, 2, 3);
            var box2 = new Box2(4, 5, 6);

            var box3 = box2 - box1;

            var expectedValue = (4 - 1) * (5 - 2) * (6 - 3);

            Assert.AreEqual(expectedValue, box3.GetVolume());
        }

        [Test]
        public void TestCanHaveEqualToComparison()
        {
            var box1 = new Box2(1, 2, 3);
            var box3 = new Box2(1, 2, 3);

            var expected = box1 == box3;

            Assert.True(expected);
        }

        [Test]
        public void TestCanHaveNotEqualToComparison()
        {
            var box1 = new Box2(1, 2, 3);
            var box2 = new Box2(4, 5, 6);

            var expected = box1 == box2;

            Assert.False(expected);
        }
    }
}
