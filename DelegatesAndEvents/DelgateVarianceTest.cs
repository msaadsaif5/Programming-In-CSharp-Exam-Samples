using System;
using System.Collections.Generic;
using Xunit;

namespace DelegatesAndEvents
{
    public class DelgateVarianceTest
    {
        class Animal
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        class Dog : Animal
        {
            public int Age { get; set; }
            public int ColorCode { get; set; }
        }

        delegate void UpdateNameDelegate(Dog animal, string name);
        delegate Animal GetAnimalDelegate(int id);

        UpdateNameDelegate updateNameMethod;
        GetAnimalDelegate getAnimalMethod;

        public DelgateVarianceTest()
        {
            updateNameMethod = UpdateName;
            getAnimalMethod = GetDog;
        }

        void UpdateName(Animal dog, string name)
        {
            dog.Name = name;
        }

        Dog GetDog(int id)
        {
            return new Dog { Id = id, Name = "Gen", Age = 7, ColorCode = 0xfff };
        }

        [Fact]
        public void TestCovariance()
        {
            var delegateVariance = new DelgateVarianceTest();
            Animal animal = delegateVariance.getAnimalMethod(1);
            Assert.IsType<Dog>(animal);
        }

        [Fact]
        public void TestContravariance()
        {
            Dog dog = new Dog { Id = 1, Name = "Tom", Age = 5, ColorCode = 0x564 };
            updateNameMethod(dog, "Tomy");
            Assert.True(dog.Name == "Tomy");
        }
    }
}
