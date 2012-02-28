using System;
using FubuCore.Binding;
using FubuCore.Binding.InMemory;
using FubuCore.Conversion;
using FubuCore.Reflection;
using FubuTestingSupport;
using NUnit.Framework;
using PizzaWeb.Conventions;
using PizzaWeb.Data;

namespace PizzaWeb.Test.Conventions
{
    [TestFixture]
    public class EntityPropertyConverter_matches_Tester
    {
        private EntityPropertyConverter converter;

        [SetUp]
        public void SetUp()
        {
            converter = new EntityPropertyConverter();
        }

        [Test]
        public void should_not_match_non_entity_type()
        {
            converter.Matches(ReflectionHelper.GetProperty<Model>(m => m.NonEntity)).ShouldBeFalse();
        }

        [Test]
        public void should_match_on_entity_type()
        {
            converter.Matches(ReflectionHelper.GetProperty<Model>(m => m.Entity)).ShouldBeTrue();
        }
    }

    [TestFixture]
    public class EntityPropertyConverter_convert_Tester
    {
        private StandardModelBinder binder;

        [SetUp]
        public void SetUp()
        {
            var converterRegistry = new ValueConverterRegistry(new IConverterFamily[]{new EntityPropertyConverter()}, new ConverterLibrary());
            binder = new StandardModelBinder(
                    new PropertyBinderCache(new IPropertyBinder[0], converterRegistry,
                                            new DefaultCollectionTypeProvider()),
                    new TypeDescriptorCache());
        }

        [Test]
        public void should_return_null_if_id_is_null()
        {
            var scenario = BindingScenario<Model>.For(d => d.BindWith(binder));
            scenario.Problems.ShouldHaveCount(0);
            scenario.Model.Entity.ShouldBeNull();
        }

        [Test]
        public void should_return_null_if_entity_does_not_exist()
        {
            var scenario = BindingScenario<Model>.For(d =>
                                           {
                                               d.Service<IRepository>(new DataRepository());
                                               d.BindWith(binder);
                                               d.Data(m => m.Entity, Guid.NewGuid());
                                           });
            scenario.Problems.ShouldHaveCount(0);
            scenario.Model.Entity.ShouldBeNull();
        }
        
        [Test]
        public void should_return_entity_if_found()
        {
            var dataRepository = new DataRepository();
            var entity = new EntityClass();
            dataRepository.Save(entity);
            var scenario = BindingScenario<Model>.For(d =>
            {
                d.Service<IRepository>(dataRepository);
                d.BindWith(binder);
                d.Data(m => m.Entity, entity.Id.ToString());
            });
            scenario.Problems.ShouldHaveCount(0);
            scenario.Model.Entity.ShouldBeTheSameAs(entity);
        }
    }

    public class Model
    {
        public NonEntityClass NonEntity { get; set; }
        public EntityClass Entity { get; set; }
    }

    public class NonEntityClass { }
    public class EntityClass : Entity { }
}