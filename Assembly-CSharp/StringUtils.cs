using System;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x02000412 RID: 1042
public static class StringUtils
{
	// Token: 0x06001D9B RID: 7579 RVA: 0x00092F58 File Offset: 0x00091158
	public static T ParseValue<T>(string value)
	{
		Type typeFromHandle = typeof(T);
		T result = default(T);
		try
		{
			if (typeFromHandle.IsEnum)
			{
				result = (T)((object)Enum.Parse(typeFromHandle, value));
			}
			else if (typeFromHandle == typeof(int))
			{
				result = (T)((object)int.Parse(value));
			}
			else if (typeFromHandle == typeof(string))
			{
				result = (T)((object)value);
			}
			else if (typeFromHandle == typeof(DateTime))
			{
				result = (T)((object)DateTime.Parse(TextUtilities.Base64Decode(value)));
			}
			else
			{
				Debug.LogError(string.Concat(new string[]
				{
					"ParseValue couldn't find a conversion of value '",
					value,
					"' into type '",
					typeFromHandle.Name,
					"'"
				}));
			}
		}
		catch (Exception ex)
		{
			Debug.LogError(string.Concat(new string[]
			{
				"ParseValue failed converting value '",
				value,
				"' into type '",
				typeFromHandle.Name,
				"': ",
				ex.Message
			}));
		}
		return result;
	}
}
