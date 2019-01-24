using System;
using System.Collections.Generic;
using System.Reflection;

namespace UberStrike.Realtime.UnitySdk
{
	// Token: 0x02000346 RID: 838
	public static class ReflectionHelper
	{
		// Token: 0x060013C1 RID: 5057 RVA: 0x00023164 File Offset: 0x00021364
		public static List<FieldInfo> GetAllFields(Type type, bool inherited)
		{
			List<FieldInfo> list = new List<FieldInfo>();
			while (type != typeof(object))
			{
				FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				list.AddRange(fields);
				if (!inherited)
				{
					break;
				}
				type = type.BaseType;
			}
			list.Sort((FieldInfo p, FieldInfo q) => p.Name.CompareTo(q.Name));
			return list;
		}

		// Token: 0x060013C2 RID: 5058 RVA: 0x000231D4 File Offset: 0x000213D4
		public static List<PropertyInfo> GetAllProperties(Type type, bool inherited)
		{
			List<PropertyInfo> list = new List<PropertyInfo>();
			while (type != typeof(object))
			{
				PropertyInfo[] properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				list.AddRange(properties);
				if (!inherited)
				{
					break;
				}
				type = type.BaseType;
			}
			list.Sort((PropertyInfo p, PropertyInfo q) => p.Name.CompareTo(q.Name));
			return list;
		}

		// Token: 0x060013C3 RID: 5059 RVA: 0x00023244 File Offset: 0x00021444
		public static List<MethodInfo> GetAllMethods(Type type, bool inherited)
		{
			List<MethodInfo> list = new List<MethodInfo>();
			while (type != typeof(object))
			{
				MethodInfo[] methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				list.AddRange(methods);
				if (!inherited)
				{
					break;
				}
				type = type.BaseType;
			}
			list.Sort((MethodInfo p, MethodInfo q) => p.Name.CompareTo(q.Name));
			return list;
		}

		// Token: 0x060013C4 RID: 5060 RVA: 0x000232B4 File Offset: 0x000214B4
		public static void FilterByAttribute<T>(Type attribute, List<T> members) where T : MemberInfo
		{
			members.RemoveAll((T m) => m.GetCustomAttributes(attribute, false).Length == 0);
		}

		// Token: 0x060013C5 RID: 5061 RVA: 0x000232E4 File Offset: 0x000214E4
		public static MethodInfo GetMethodWithParameters(List<MethodInfo> members, string name, params Type[] args)
		{
			MethodInfo result = null;
			foreach (MethodInfo methodInfo in members.FindAll((MethodInfo m) => m.Name == name))
			{
				bool flag = true;
				ParameterInfo[] parameters = methodInfo.GetParameters();
				if (parameters.Length == args.Length)
				{
					for (int i = 0; i < parameters.Length; i++)
					{
						flag &= (parameters[i].ParameterType == args[i]);
					}
				}
				if (flag)
				{
					result = methodInfo;
				}
			}
			return result;
		}

		// Token: 0x04000E1A RID: 3610
		public const BindingFlags FieldBinder = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy;

		// Token: 0x04000E1B RID: 3611
		public const BindingFlags InvokeBinder = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod;
	}
}
