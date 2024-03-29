﻿using GenericImplementation.Api.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Reflection;

namespace GenericImplementation.Api.Generics
{
    public class GenericTypeControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var currentAssembly = typeof(GenericTypeControllerFeatureProvider).Assembly;
            var candidates = currentAssembly.GetExportedTypes().Where(x => x.GetCustomAttributes<GeneratedControllerAttribute>().Any());

            foreach (var candidate in candidates)
            {
                feature.Controllers.Add(
                    typeof(GenericController<>).MakeGenericType(candidate).GetTypeInfo()
                );
            }
        }
    }
}
