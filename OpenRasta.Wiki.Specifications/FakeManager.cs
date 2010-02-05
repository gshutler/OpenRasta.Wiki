using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Rhino.Mocks;

namespace OpenRasta.Wiki.Specifications
{
    public class FakeManager
    {
        readonly IDictionary<Type, object> dependencies = new Dictionary<Type, object>();
        readonly IDictionary<Type, object> injectedObjects = new Dictionary<Type, object>();

        public T Dependency<T>()
        {
            return (T) Dependency(typeof(T));
        }

        public object Dependency(Type fakeType)
        {
            if (!dependencies.ContainsKey(fakeType))
            {
                dependencies.Add(fakeType, MockRepository.GenerateStub(fakeType));
            }

            return dependencies[fakeType];
        }

        public T ConstructedObject<T>()
        {
            var objectType = typeof(T);

            if (!injectedObjects.ContainsKey(objectType))
            {
                injectedObjects.Add(objectType, GenerateInjectedObject<T>());
            }

            return (T) injectedObjects[objectType];
        }

        private T GenerateInjectedObject<T>()
        {
            var constructor = GreediestConstructor<T>();
            var constructorParameters = new List<object>();

            foreach (var parameterInfo in constructor.GetParameters())
            {
                constructorParameters.Add(Dependency(parameterInfo.ParameterType));
            }

            return (T) constructor.Invoke(constructorParameters.ToArray());
        }

        private static ConstructorInfo GreediestConstructor<T>()
        {
            return typeof(T).GetConstructors()
                .OrderByDescending(x => x.GetParameters().Length)
                .First();
        }

        public void InjectDependency<T>(T dependency)
        {
            dependencies.Add(typeof(T), dependency);
        }
    }
}