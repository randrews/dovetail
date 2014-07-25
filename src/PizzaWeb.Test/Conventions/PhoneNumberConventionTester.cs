using System;
using System.Collections.Generic;
using System.Linq;
using FubuCore;
using FubuCore.Reflection;
using FubuMVC.Core.UI.Configuration;
using FubuTestingSupport;
using HtmlTags;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;
using PizzaWeb.Conventions;
using PizzaWeb.Data;
using Rhino.Mocks;

namespace PizzaWeb.Test.Conventions
{
    [TestFixture]
    public class PhoneNumberConvention_matches_Tester
    {
        private PhoneNumberConvention builder;

        [SetUp]
        public void SetUp()
        {
            builder = new PhoneNumberConvention();
        }

        [Test]
        public void should_not_match_things_other_than_PhoneNumber()
        {
            var def = AccessorDef.For<PickupOrder>(x => x.FirstName);
            builder.CreateInitial(def).ShouldBeNull();
        }

        [Test]
        public void should_match_PhoneNumber()
        {
            var def = AccessorDef.For<PickupOrder>(x => x.PhoneNumber);
            builder.CreateInitial(def).ShouldNotBeNull();
        }

        [Test]
        public void should_Build_properly()
        {
            var def = AccessorDef.For<PickupOrder>(x => x.PhoneNumber);
            var services = MockRepository.GenerateStub<IServiceLocator>();
            ElementRequest request = new ElementRequest(new PickupOrder(), ReflectionHelper.GetAccessor<PickupOrder>(m => m.PhoneNumber), services);
            builder.Build(request).ShouldNotBeNull();
        }
    }
}