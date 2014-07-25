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
    public class PhoneNumberDisplayConvention_matches_Tester
    {
        private PhoneNumberDisplayConvention builder;

        [SetUp]
        public void SetUp()
        {
            builder = new PhoneNumberDisplayConvention();
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
            PickupOrder order = new PickupOrder { Id = new Guid(), PhoneNumber = new PhoneNumber { AreaCode = 123, Prefix = 456, Suffix = 7890 } };
            ElementRequest request = new ElementRequest(order, ReflectionHelper.GetAccessor<PickupOrder>(m => m.PhoneNumber), services);
            builder.Build(request).ShouldNotBeNull();
        }
    }
}