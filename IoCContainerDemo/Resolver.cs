using System;
using System.Collections.Generic;
using System.Linq;

namespace IoCContainerDemo
{
    public class Resolver
    {
        //public ICreditCard ResolvCreditCard()
        //{
        //    if(new Random().Next(2)==1)
        //        return new Visa();

        //    return new MasterCard();
        //}

        private readonly Dictionary<Type, Type> _dependencyMap = 
            new Dictionary<Type, Type>();

        public T Resolve<T>()
        {
            return (T) Resolve(typeof (T));
        }

        private object Resolve(Type typeToResolve)
        {
            Type resolvedType;
            try
            {
                resolvedType = _dependencyMap[typeToResolve];
            }
            catch
            {
                throw new Exception(string.Format("Can not resolve type {0}", typeToResolve.FullName));
            }
            var firstConstructor = resolvedType.GetConstructors().First();
            var constructorParameters = firstConstructor.GetParameters();

            return !constructorParameters.Any() ? 
                                                    Activator.CreateInstance(resolvedType) 
                       : firstConstructor.Invoke(constructorParameters.Select(parameterToResolve => Resolve(parameterToResolve.ParameterType)).ToArray());
        }

        public void Register<TFrom, TTo>()
        {
            _dependencyMap.Add(typeof (TFrom), typeof (TTo));
        }
    }
}