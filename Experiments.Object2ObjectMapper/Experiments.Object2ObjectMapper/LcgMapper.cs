using System.Collections.Generic;
using System.Reflection.Emit;

namespace Experiments.Object2ObjectMapper
{
    public class LcgMapper : ObjectCopyBase
    {
        private delegate void CopyPublicPropertiesDelegate<T, TU>
        (T source, TU target);

        private readonly Dictionary<string, object> _del =
            new Dictionary<string, object>();

        public override void MapTypes<T, TU>()
        {
            var key = GetMapKey<T, TU>();
            if (_del.ContainsKey(key))
                return;

            var source = typeof(T);
            var target = typeof(TU);

            var args = new[] { source, target };
            var mod = typeof(ObjectCopyBase).Module;

            var dm = new DynamicMethod(key, null, args, mod);
            var il = dm.GetILGenerator();
            var maps = GetMatchingProperties<T, TU>();

            foreach (var map in maps)
            {
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Ldarg_0);
                il.EmitCall(OpCodes.Callvirt,
                            map.SourceProperty.GetGetMethod(), null);
                il.EmitCall(OpCodes.Callvirt,
                            map.TargetProperty.GetSetMethod(), null);
            }
            il.Emit(OpCodes.Ret);
            var del = dm.CreateDelegate(
                      typeof(CopyPublicPropertiesDelegate<T, TU>));
            _del.Add(key, del);
        }

        public override void Copy<T, TU>(T source, TU target)
        {
            var key = GetMapKey<T, TU>();
            var del = (CopyPublicPropertiesDelegate<T, TU>)_del[key];
            del.Invoke(source, target);
        }
    }
}
