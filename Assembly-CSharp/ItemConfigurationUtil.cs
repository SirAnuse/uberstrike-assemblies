using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using UberStrike.Core.Models.Views;
using UberStrike.Realtime.UnitySdk;

// Token: 0x0200023F RID: 575
public static class ItemConfigurationUtil
{
	// Token: 0x06000FDF RID: 4063 RVA: 0x000657D8 File Offset: 0x000639D8
	private static List<FieldInfo> GetAllFields(Type type)
	{
		List<FieldInfo> allFields;
		if (!ItemConfigurationUtil.fields.TryGetValue(type, out allFields))
		{
			allFields = ReflectionHelper.GetAllFields(type, true);
			ItemConfigurationUtil.fields[type] = allFields;
		}
		return allFields;
	}

	// Token: 0x06000FE0 RID: 4064 RVA: 0x0006580C File Offset: 0x00063A0C
	public static void CopyProperties<T>(T config, BaseUberStrikeItemView item) where T : BaseUberStrikeItemView
	{
		CloneUtil.CopyAllFields<BaseUberStrikeItemView>(config, item);
		foreach (FieldInfo fieldInfo in ItemConfigurationUtil.GetAllFields(config.GetType()))
		{
			string customPropertyName = ItemConfigurationUtil.GetCustomPropertyName(fieldInfo);
			if (!string.IsNullOrEmpty(customPropertyName) && item.CustomProperties != null && item.CustomProperties.ContainsKey(customPropertyName))
			{
				fieldInfo.SetValue(config, ItemConfigurationUtil.Convert(item.CustomProperties[customPropertyName], fieldInfo.FieldType));
			}
		}
	}

	// Token: 0x06000FE1 RID: 4065 RVA: 0x000658C8 File Offset: 0x00063AC8
	public static void CopyCustomProperties(BaseUberStrikeItemView src, object dst)
	{
		foreach (FieldInfo fieldInfo in ItemConfigurationUtil.GetAllFields(dst.GetType()))
		{
			string customPropertyName = ItemConfigurationUtil.GetCustomPropertyName(fieldInfo);
			if (!string.IsNullOrEmpty(customPropertyName) && src.CustomProperties != null && src.CustomProperties.ContainsKey(customPropertyName))
			{
				object value = ItemConfigurationUtil.Convert(src.CustomProperties[customPropertyName], fieldInfo.FieldType);
				fieldInfo.SetValue(dst, value);
			}
		}
	}

	// Token: 0x06000FE2 RID: 4066 RVA: 0x00065970 File Offset: 0x00063B70
	private static string GetCustomPropertyName(FieldInfo info)
	{
		object[] customAttributes = info.GetCustomAttributes(typeof(CustomPropertyAttribute), true);
		return (customAttributes.Length <= 0) ? string.Empty : ((CustomPropertyAttribute)customAttributes[0]).Name;
	}

	// Token: 0x06000FE3 RID: 4067 RVA: 0x000659B0 File Offset: 0x00063BB0
	private static object Convert(string value, Type type)
	{
		if (type == typeof(string))
		{
			return value;
		}
		if (type.IsEnum || type == typeof(int))
		{
			return int.Parse(value, CultureInfo.InvariantCulture);
		}
		if (type == typeof(float))
		{
			return float.Parse(value, CultureInfo.InvariantCulture);
		}
		if (type == typeof(bool))
		{
			return bool.Parse(value);
		}
		throw new NotSupportedException("ConfigurableItem has unsupported property of type: " + type);
	}

	// Token: 0x04000DD7 RID: 3543
	private static Dictionary<Type, List<FieldInfo>> fields = new Dictionary<Type, List<FieldInfo>>();
}
