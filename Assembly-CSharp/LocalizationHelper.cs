using System;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000294 RID: 660
public static class LocalizationHelper
{
	// Token: 0x06001226 RID: 4646 RVA: 0x0006AF48 File Offset: 0x00069148
	public static bool ValidateMemberName(string name, LocaleType locale = LocaleType.en_US)
	{
		if (locale != LocaleType.ko_KR)
		{
			return ValidationUtilities.IsValidMemberName(name);
		}
		return ValidationUtilities.IsValidMemberName(name, "ko-KR");
	}

	// Token: 0x06001227 RID: 4647 RVA: 0x0000C928 File Offset: 0x0000AB28
	public static GUIStyle GetLocalizedStyle(GUIStyle style)
	{
		return style;
	}
}
