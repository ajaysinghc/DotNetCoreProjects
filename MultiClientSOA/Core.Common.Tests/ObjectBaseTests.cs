using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;

namespace Core.Common.Tests
{
    [TestClass]
    public class ObjectBaseTests
    {
        [TestMethod]
        public void Test_clean_property_Change()
        {
            TestClass obj = new TestClass();
            bool isPropertyChanged = false;
            obj.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Clean")
                    isPropertyChanged = true;

            };

            obj.Clean = "Changing";

            Assert.IsTrue(isPropertyChanged, "Property is not clean");
        }

        [TestMethod]
        public void Test_IsDirty_Set()
        {
            TestClass obj = new TestClass();

            Assert.IsFalse(obj.IsDirty, "IsDirty should be false as no change in property");
            obj.Clean = "Changed to set Dirty";
            Assert.IsTrue(obj.IsDirty, "IsDirty should be true as change in property");
        }

        [TestMethod]
        public void Test_Multiple_Addition_Of_Events()
        {
            int counter = 0;
            PropertyChangedEventHandler handler1 = new PropertyChangedEventHandler((s, e) =>
            {
                counter++;
            });
            PropertyChangedEventHandler handler2 = new PropertyChangedEventHandler((s, e) =>
            {
                counter++;
            });

            TestClass obj = new TestClass();
            obj.PropertyChanged += handler1;
            obj.PropertyChanged += handler1;
            obj.PropertyChanged += handler1;
            obj.PropertyChanged += handler2;
            obj.PropertyChanged += handler2;

            obj.Clean = "Test change property";

            Assert.IsTrue(counter == 2, "Single addition of Delegate is not working");
        }
        [TestMethod]
        public void Test_Object_Validation()
        {
            TestClass obj = new TestClass();
            Assert.IsFalse(obj.IsValid, "Object should be in invalid state");
            obj.Clean = "Test change";

            Assert.IsTrue(obj.IsValid, "Object should be in valid state");
        }
    }
}
