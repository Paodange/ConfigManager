//using Mgi.Apl.Model;
//using Mgi.Framework.Util.Extention;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;

//namespace Mgi.Apl.Web.Data
//{
//    public class AutoMapperConfig
//    {
//        public static void Configure()
//        {
//            var dict = GetMapperInfo();
//            AutoMapper.Mapper.Initialize(x =>
//            {
//                foreach (var item in dict)
//                {
//                    x.CreateMap(item.Key, item.Value);
//                    x.CreateMap(item.Value, item.Key);
//                }
//            });
//        }

//        private static Dictionary<Type, Type> GetMapperInfo()
//        {
//            Dictionary<Type, Type> dict = new Dictionary<Type, Type>();
//            var assembly = Assembly.Load("Mgi.Apl.Model");
//            var types = assembly.GetExportedTypes().Where(x => x.IsSubClassOfGeneric(typeof(AbstractBO<,>)) && !x.IsAbstract);
//            foreach (var boType in types)
//            {
//                var modelType = boType.BaseType.GetGenericArguments()[0];
//                dict.Add(boType, modelType);
//            }
//            return dict;
//        }
//    }
//}
