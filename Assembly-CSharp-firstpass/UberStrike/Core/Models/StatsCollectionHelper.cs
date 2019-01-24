using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace UberStrike.Core.Models
{
	// Token: 0x02000229 RID: 553
	public static class StatsCollectionHelper
	{
		// Token: 0x06000EB9 RID: 3769 RVA: 0x00011B3C File Offset: 0x0000FD3C
		static StatsCollectionHelper()
		{
			PropertyInfo[] array = typeof(StatsCollection).GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo propertyInfo in array)
			{
				if (propertyInfo.PropertyType == typeof(int) && propertyInfo.CanRead && propertyInfo.CanWrite)
				{
					StatsCollectionHelper.properties.Add(propertyInfo);
				}
			}
		}

		// Token: 0x06000EBA RID: 3770 RVA: 0x00011BB8 File Offset: 0x0000FDB8
		public static string ToString(StatsCollection instance)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (PropertyInfo propertyInfo in StatsCollectionHelper.properties)
			{
				stringBuilder.AppendFormat("{0}:{1}\n", propertyInfo.Name, propertyInfo.GetValue(instance, null));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000EBB RID: 3771 RVA: 0x00011C30 File Offset: 0x0000FE30
		public static void Reset(StatsCollection instance)
		{
			foreach (PropertyInfo propertyInfo in StatsCollectionHelper.properties)
			{
				propertyInfo.SetValue(instance, 0, null);
			}
		}

		// Token: 0x06000EBC RID: 3772 RVA: 0x00011C90 File Offset: 0x0000FE90
		public static void TakeBestValues(StatsCollection instance, StatsCollection that)
		{
			foreach (PropertyInfo propertyInfo in StatsCollectionHelper.properties)
			{
				int num = (int)propertyInfo.GetValue(instance, null);
				int num2 = (int)propertyInfo.GetValue(that, null);
				if (num < num2)
				{
					propertyInfo.SetValue(instance, num2, null);
				}
			}
		}

		// Token: 0x06000EBD RID: 3773 RVA: 0x00011D14 File Offset: 0x0000FF14
		public static void AddAllValues(StatsCollection instance, StatsCollection that)
		{
			foreach (PropertyInfo propertyInfo in StatsCollectionHelper.properties)
			{
				int num = (int)propertyInfo.GetValue(instance, null);
				int num2 = (int)propertyInfo.GetValue(that, null);
				propertyInfo.SetValue(instance, num + num2, null);
			}
		}

		// Token: 0x04000BD7 RID: 3031
		private static List<PropertyInfo> properties = new List<PropertyInfo>();
	}
}
