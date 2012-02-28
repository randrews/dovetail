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
    public class EntityListBuilder_matches_Tester
    {
        private EntityListBuilder builder;

        [SetUp]
        public void SetUp()
        {
            builder = new EntityListBuilder();
        }

        [Test]
        public void should_not_match_things_other_than_entity()
        {
            var def = AccessorDef.For<Model>(x => x.NonEntity);
            builder.CreateInitial(def).ShouldBeNull();
        }

        [Test]
        public void should_match_entity()
        {
            var def = AccessorDef.For<Model>(x => x.Entity);
            builder.CreateInitial(def).ShouldNotBeNull();
        }

        private class Model
        {
            public NonEntityClass NonEntity { get; set; }
            public EntityClass Entity { get; set; }
        }

        private class NonEntityClass
        {
        }

        private class EntityClass : Entity
        {
        }
    }

    [TestFixture]
    public class EntityListBuilder_build_Tester
    {
        private EntityListBuilder builder;
        private ElementRequest request;
        private IServiceLocator services;
        private IRepository repository;
        private Stringifier stringifier;
        private IList<EntityClass> entityList;

        [SetUp]
        public void SetUp()
        {
            entityList = new List<EntityClass>();
            builder = new EntityListBuilder();
            services = MockRepository.GenerateStub<IServiceLocator>();
            repository = MockRepository.GenerateStub<IRepository>();
            stringifier = new Stringifier();
            request = new ElementRequest(new Model(), ReflectionHelper.GetAccessor<Model>(m => m.Entity), services);
            services.Stub(l => l.GetInstance<IRepository>()).Return(repository);
            services.Stub(l => l.GetInstance<Stringifier>()).Return(stringifier);
        }

        public HtmlTag Tag()
        {
            repository.Stub(r => r.GetAll(typeof(EntityClass))).Return(entityList);
            return builder.Build(request);
        }

        [Test]
        public void should_get_all_of_entity_type_from_repository()
        {
            Tag();
            repository.AssertWasCalled(r => r.GetAll(typeof(EntityClass)));
        }

        [Test]
        public void should_return_select_tag()
        {
            Tag().TagName().ShouldEqual("select");
        }

        [Test]
        public void should_add_option_for_each_entity()
        {
            entityList.AddMany(new EntityClass(), new EntityClass(), new EntityClass());

            Tag().Children.ShouldHaveCount(3);
        }

        [Test]
        public void should_stringify_each_entity()
        {
            var strategy = new StringifierStrategy
                               {
                                   Matches = r => true, 
                                   StringFunction = r => ((EntityClass) r.RawValue).Name
                               };

            stringifier.AddStrategy(strategy);

            entityList.AddMany(new EntityClass("a"), new EntityClass("b"), new EntityClass("c"));

            Tag().Children[2].Text().ShouldEqual("c");
        }

        [Test]
        public void should_set_option_values_to_entity_id()
        {
            var expectedId = Guid.NewGuid();
            entityList.AddMany(new EntityClass(), new EntityClass(), new EntityClass{Id = expectedId});

            Tag().Children[2].Attr("value").ShouldEqual(expectedId.ToString());
        }

        private class Model
        {
            public EntityClass Entity { get; set; }
        }

        private class EntityClass : Entity
        {
            public EntityClass()
            {
            }

            public EntityClass(string name)
            {
                Name = name;
            }

            public string Name { get; set; }   
        }
    }
}