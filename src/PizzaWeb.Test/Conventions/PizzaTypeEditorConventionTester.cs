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
    public class PizzaTypeEditorConvention_matches_Tester
    {
        private PizzaTypeEditorConvention builder;
        private IServiceLocator services;
        private IRepository repository;
        private PizzaType pizzaType;
        private PickupOrder order;

        [SetUp]
        public void SetUp()
        {
            builder = new PizzaTypeEditorConvention();
            pizzaType = new PizzaType { Id = new Guid(), Name = "Test", Description = "Test description" };
            order = new PickupOrder { Id = new Guid(), PizzaType = pizzaType };
            services = MockRepository.GenerateStub<IServiceLocator>();
            repository = MockRepository.GenerateStub<IRepository>();
            repository.Stub(r => r.GetAll<PizzaType>()).Return(new List<PizzaType> { pizzaType });
            services.Stub(l => l.GetInstance<IRepository>()).Return(repository);
        }

        [Test]
        public void should_not_match_things_other_than_PizzaType()
        {
            var def = AccessorDef.For<PickupOrder>(x => x.FirstName);
            builder.CreateInitial(def).ShouldBeNull();
        }

        [Test]
        public void should_match_PizzaType()
        {
            var def = AccessorDef.For<PickupOrder>(x => x.PizzaType);
            builder.CreateInitial(def).ShouldNotBeNull();
        }

        [Test]
        public void should_Build_properly()
        {
            ElementRequest request = new ElementRequest(new PickupOrder(), ReflectionHelper.GetAccessor<PickupOrder>(m => m.PizzaType), services);
            builder.Build(request).ShouldNotBeNull();
        }
    }
}