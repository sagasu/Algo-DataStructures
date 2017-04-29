using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace playCoreTests
{
    // Playing with M$ testing framework
    [TestClass]
    public class PropertyChangedTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            // It is interesting that it will show nothing
            Console.WriteLine("Start");

            var propertyChanged = new List<string>();

            var person = new Person();
            person.Name = "foo";
            person.LastName = "last foo";
            person.PropertyChanged += (object sender, PropertyChangedEventArgs e) => propertyChanged.Add(e.PropertyName);

            person.Name = "bar";
            person.LastName = "buz";
            // It is interesting that it will show nothing
            Debug.WriteLine("End debug");
            // It is interesting that it will show nothing
            Trace.WriteLine("End trace");

            Assert.AreEqual("last name", propertyChanged[0]);
            Assert.AreEqual("LastName", propertyChanged[1]);
            Assert.AreEqual("LastName", propertyChanged[2]);
            Assert.AreEqual("LastName", propertyChanged[3]);
        }
        
    }

    class Person :INotifyPropertyChanged {
        public int Age { get; set; }
        
        public string Name { get; set; }

        private string _lastName;
        public string LastName { get { return _lastName; }
            set {
                _lastName = value;
                PropertyChanged.SafeInvoke(this, new PropertyChangedEventArgs("last name"));
                PropertyChanged.SafeInvoke(this, x => x.LastName);
                PropertyChanged.SafeInvoke2(this);
                PropertyChanged.SafeInvoke(this, new PropertyChangedEventArgs(nameof(LastName)));
            } }
        
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public static class NullSafeExtension {
        public static void SafeInvoke(this PropertyChangedEventHandler handler, object sender, PropertyChangedEventArgs args) {
            if (handler != null) {
                handler(sender, args);
            }
        }

        public static void SafeInvoke<TSource, TValue>(this PropertyChangedEventHandler handler, 
            TSource sender, Expression<Func<TSource, TValue>> selector)
        {
            var body = selector.Body;
            var property = (MemberExpression)body;

            if (handler != null)
            {
                handler(sender, new PropertyChangedEventArgs(property.Member.Name));
            }
        }

        public static void SafeInvoke2(this PropertyChangedEventHandler handler,
            object sender, [CallerMemberName] string member = null)
        {
            if (handler != null)
            {
                handler(sender, new PropertyChangedEventArgs(member));
            }
        }
    }
}
