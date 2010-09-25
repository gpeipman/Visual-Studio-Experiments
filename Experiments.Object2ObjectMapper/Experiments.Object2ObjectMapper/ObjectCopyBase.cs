using System.Collections.Generic;
using System.Linq;

namespace Experiments.Object2ObjectMapper
{
    public abstract class ObjectCopyBase
    {
        public abstract void MapTypes<T, TU>();
        public abstract void Copy<T, TU>(T source, TU target);

        protected virtual IList<PropertyMap>GetMatchingProperties<T, TU>()
        {
            var sourceProperties = typeof(T).GetProperties();
            var targetProperties = typeof(TU).GetProperties();

            var properties = (from s in sourceProperties
                              from t in targetProperties
                              where s.Name == t.Name &&
                                    s.CanRead &&
                                    t.CanWrite &&
                                    s.PropertyType == t.PropertyType
                              select new PropertyMap
                              {
                                  SourceProperty = s,
                                  TargetProperty = t
                              }).ToList();
            return properties;
        }

        protected virtual string GetMapKey<T, TU>()
        {
            var className = "Copy_";
            className += typeof(T).FullName.Replace(".", "_");
            className += "_";
            className += typeof(TU).FullName.Replace(".", "_");

            return className;
        }
    }
}
