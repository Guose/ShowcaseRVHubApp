using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace ShowcaseRVHub.WebApi.Extensions
{
    public class ContractResolverExtension : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            // Ignore circular references for all properties
            property.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            return property;
        }
    }
}
