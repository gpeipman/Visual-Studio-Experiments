using System.Collections.Generic;
using System.Linq;

namespace Experiments.Object2ObjectMapper
{
    public class ReflectionBasedMapper : ObjectCopyBase
    {
        private readonly Dictionary<string, PropertyMap[]> _maps =
            new Dictionary<string, PropertyMap[]>();

        public override void MapTypes<T, TU>()
        {
            var key = GetMapKey<T, TU>();
            if (_maps.ContainsKey(key))
                return;

            var props = GetMatchingProperties<T, TU>();
            _maps.Add(key, props.ToArray());
        }

        public override void Copy<T, TU>(T source, TU target)
        {
            var key = GetMapKey<T, TU>();
            if (!_maps.ContainsKey(key))
                MapTypes<T, TU>();

            var propMap = _maps[key];

            foreach (var prop in propMap)
            {
                var sourceValue = prop.SourceProperty.GetValue(source, null);
                prop.TargetProperty.SetValue(target, sourceValue, null);
            }
        }
    }
}
