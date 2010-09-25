using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;

namespace Experiments.Object2ObjectMapper
{
    public class DynamicCodeMapper : ObjectCopyBase
    {
        private readonly Dictionary<string, Type> _comp = new Dictionary<string, Type>();

        public override void MapTypes<T, TU>()
        {
            var source = typeof(T);
            var target = typeof(TU);

            var key = GetMapKey<T, TU>();
            if (_comp.ContainsKey(key))
                return;

            var builder = new StringBuilder();
            builder.Append("namespace Copy {\r\n");
            builder.Append("    public class ");
            builder.Append(key);
            builder.Append(" {\r\n");
            builder.Append("        public static void CopyProps(");
            builder.Append(source.FullName);
            builder.Append(" source, ");
            builder.Append(target.FullName);
            builder.Append(" target) {\r\n");

            var map = GetMatchingProperties<T, TU>();
            foreach (var item in map)
            {
                builder.Append("            target.");
                builder.Append(item.TargetProperty.Name);
                builder.Append(" = ");
                builder.Append("source.");
                builder.Append(item.SourceProperty.Name);
                builder.Append(";\r\n");
            }

            builder.Append("        }\r\n   }\r\n}");
            
            var myCodeProvider = new CSharpCodeProvider();
            var myCodeCompiler = myCodeProvider.CreateCompiler();
            var myCompilerParameters = new CompilerParameters();
            //myCompilerParameters.ReferencedAssemblies.Add(typeof(LinqReflectionPerf).Assembly.Location);
            myCompilerParameters.ReferencedAssemblies.Add(typeof(ObjectCopyBase).Assembly.Location);
            myCompilerParameters.GenerateInMemory = true;

            var results = myCodeCompiler.CompileAssemblyFromSource(myCompilerParameters, builder.ToString());
            var copierType = results.CompiledAssembly.GetType("Copy." + key);
            _comp.Add(key, copierType);
        }

        public override void Copy<T, TU>(T source, TU target)
        {
            var key = GetMapKey<T, TU>();
            if (!_comp.ContainsKey(key))
                MapTypes<T, TU>();

            const BindingFlags flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod;
            var args = new object[] { source, target };
            _comp[key].InvokeMember("CopyProps", flags, null, null,args);
        }
    }
}
