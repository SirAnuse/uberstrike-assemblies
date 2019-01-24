using System;
using System.Reflection;
using UberStrike.Realtime.UnitySdk;

// Token: 0x020003C2 RID: 962
public static class CloneUtil
{
	// Token: 0x06001C26 RID: 7206 RVA: 0x0008F1C0 File Offset: 0x0008D3C0
	public static T Clone<T>(T instance) where T : class
	{
		Type type = instance.GetType();
		ConstructorInfo constructor = type.GetConstructor(new Type[0]);
		if (constructor != null)
		{
			T t = constructor.Invoke(new object[0]) as T;
			CloneUtil.CopyAllFields<T>(t, instance);
			return t;
		}
		return (T)((object)null);
	}

	// Token: 0x06001C27 RID: 7207 RVA: 0x0008F214 File Offset: 0x0008D414
	public static void CopyAllFields<T>(T destination, T source) where T : class
	{
		foreach (FieldInfo fieldInfo in ReflectionHelper.GetAllFields(source.GetType(), true))
		{
			fieldInfo.SetValue(destination, fieldInfo.GetValue(source));
		}
	}

	// Token: 0x06001C28 RID: 7208 RVA: 0x0008F28C File Offset: 0x0008D48C
	public static void CopyFields(object dst, object src)
	{
		foreach (PropertyInfo propertyInfo in src.GetType().GetProperties())
		{
			if (propertyInfo.CanWrite)
			{
				dst.GetType().GetProperty(propertyInfo.Name).SetValue(dst, propertyInfo.GetValue(src, null), null);
			}
		}
	}
}
