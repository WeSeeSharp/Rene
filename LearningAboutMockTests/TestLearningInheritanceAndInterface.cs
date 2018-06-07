using System;
using System.Collections;
using NUnit.Framework;

namespace LearningAboutMockTests
{
    public class ClassThatUsesObject
    {
        public TheParent1 parent;

        public ClassThatUsesObject(TheParent1 parent)
        {
            this.parent = parent;
        }
    }

    public class ClassThatUsesObjectWithInterface
    {
        public IParent parent;

        public ClassThatUsesObjectWithInterface(IParent parent)
        {
            this.parent = parent;
        }
    }

    public interface IParent
    {
        string name { get; set; }
        int ReachTen(int startingPoint);
    }

    public class ParentWithInterface : IParent
    {
        private string _name;
        public string name { get { return this._name; } set { this._name = value; } }

        public ParentWithInterface(string name)
        {
            this._name = name;
        }


        public int ReachTen(int startingPoint)
        {
            int finalPoint = 0;
            int loops = 0;
            for (var i = 0; i <= 10; i++)
            {
                finalPoint = i;
                loops++;
            }

            return finalPoint;
        }
    }

    public class ParentWithInterfaceV2 : IParent, IEnumerable
    {
        private string _name;
        public string name { get { return this._name; } set { this._name = value; } }

        public ParentWithInterfaceV2(string name)
        {
            this._name = name;
        }

        public int ReachTen(int startingPoint)
        {
            int finalPoint = 0;
            int loops = 0;
            for (var i = 0; i <= 10; i = i + 2)
            {
                finalPoint = i;
                loops++;
            }

            return finalPoint;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class TheParent1
    {
        string name;

        public TheParent1(string name)
        {
            this.name = name;
        }

        public int ReachTen(int startingPoint)
        {
            int finalPoint = 0;
            int loops = 0;
            for (var i = 0; i <= 10; i++)
            {
                finalPoint = i;
                loops++;
            }

            return finalPoint;
        }
    }

    public class TheParent2
    {
        string name;

        public TheParent2(string name)
        {
            this.name = name;
        }

        public int ReachTen(int startingPoint)
        {
            int finalPoint = 0;
            int loops = 0;
            for (var i = 0; i <= 10; i = i + 2)
            {
                finalPoint = i;
                loops++;
            }

            return finalPoint;
        }

        public string JakeIsAwesome()
        {
            return "Yay!";
        }
    }

    class TestLearningInheritanceAndInterface
    {
        [Test]
        public void TestProblemWithUsingConcreteObjects()
        {
            var parent1 = new TheParent1("Brian");
            var parent2 = new TheParent2("Jeff");

//            var theClient = new ClassThatUsesObject(parent1);
//            Assert.AreEqual(theClient.parent.ReachTen(1), 10);

//            var theClientV2 = new ClassThatUsesObject(parent2);
//            Assert.AreEqual(theClientV2.parent.ReachTen(1), 10);
        }

        [Test]
        public void TestUsingInterfaces()
        {
            var parent1 = new ParentWithInterface("Brian");
            var parent2 = new ParentWithInterfaceV2("Jeff");

            var theClient = new ClassThatUsesObjectWithInterface(parent1);
            var theClient2 = new ClassThatUsesObjectWithInterface(parent2);

            Assert.AreEqual(theClient.parent.ReachTen(1), 10);
            Assert.AreEqual(theClient2.parent.ReachTen(1), 10);

            var a = theClient2.parent.name;

            string b = theClient.parent.name;
            theClient.parent.name = "Dan";

            Assert.AreEqual("Dan", theClient.parent.name);
            Assert.AreNotEqual("Dan", b);
            
            var dc = theClient;

            dc.parent.name = "Milo";
            Assert.AreEqual("Milo", theClient.parent.name);

            var marvel = theClient.parent;
            marvel.name = "Jake";
            
            Assert.AreEqual("Jake", marvel.name);
            Assert.AreEqual("Jake", dc.parent.name);
        }

        //Interfaces define the what
        //Classes define the how

        //Interfaces can define properties, methods, events
        //Simlar to Abstract Class but remember, class can only inherit one other class, while they can have as many interfaces as you want.
        //Also note, interfaces really deal with ability. IDisposABLE, IWritEBLE, IReadABLE, etc.
        //We didn't describe interfaces as such. We just wanted to show the power of them. And how to use them.
    }
}
