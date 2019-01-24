using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UberStrike.Realtime.UnitySdk;

// Token: 0x0200041C RID: 1052
public static class ValidationUtilities
{
	// Token: 0x06001DC4 RID: 7620 RVA: 0x00093818 File Offset: 0x00091A18
	public static bool IsValidEmailAddress(string email)
	{
		if (TextUtilities.IsNullOrEmpty(email) || email.Length > 100)
		{
			return false;
		}
		int num = email.IndexOf('@');
		int num2 = email.LastIndexOf('@');
		return num > 0 && num2 == num && num < email.Length - 1 && Regex.IsMatch(email, "^([a-zA-Z0-9_'+*$%\\^&!\\.\\-])+\\@(([a-zA-Z0-9\\-])+\\.)+([a-zA-Z0-9:]{2,4})+$");
	}

	// Token: 0x06001DC5 RID: 7621 RVA: 0x0009387C File Offset: 0x00091A7C
	public static bool IsValidPassword(string password)
	{
		bool result = false;
		if (!TextUtilities.IsNullOrEmpty(password) && password.Length > 3 && password.Length < 64)
		{
			result = true;
		}
		return result;
	}

	// Token: 0x06001DC6 RID: 7622 RVA: 0x00013C40 File Offset: 0x00011E40
	public static bool IsValidMemberName(string memberName)
	{
		return ValidationUtilities.IsValidMemberName(memberName, "en-US");
	}

	// Token: 0x06001DC7 RID: 7623 RVA: 0x000938B4 File Offset: 0x00091AB4
	public static bool IsValidMemberName(string memberName, string locale)
	{
		bool result = false;
		if (!string.IsNullOrEmpty(memberName))
		{
			memberName = memberName.Trim();
			int num;
			if (memberName.Equals(TextUtilities.CompleteTrim(memberName)))
			{
				string text = string.Empty;
				if (locale != null)
				{
					/*if (ValidationUtilities. == null)
					{
						ValidationUtilities.f__switch$map2 = new Dictionary<string, int>(1)
						{
							{
								"ko-KR",
								0
							}
						};
					}
					if (ValidationUtilities.f__switch$map2.TryGetValue(locale, out num))
					{
						if (num == 0)
						{
							text = "\\p{IsHangulSyllables}";
							goto IL_8B;
						}
					}*/
				}
				text = string.Empty;
				IL_8B:
				result = Regex.IsMatch(memberName, string.Concat(new object[]
				{
					"^[a-zA-Z0-9 .!_\\-<>{}~@#$%^&*()=+|:?",
					text,
					"]{",
					3,
					",",
					18,
					"}$"
				}));
			}
			num = memberName.ToLower().IndexOf("admin");
			if (!num.Equals(-1) || !memberName.ToLower().IndexOf("cmune").Equals(-1))
			{
				result = false;
			}
		}
		return result;
	}
}
