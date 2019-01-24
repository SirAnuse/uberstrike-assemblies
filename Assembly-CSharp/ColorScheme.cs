using System;
using Cmune.DataCenter.Common.Entities;
using UnityEngine;

// Token: 0x0200014D RID: 333
public static class ColorScheme
{
	// Token: 0x060008B6 RID: 2230 RVA: 0x000387DC File Offset: 0x000369DC
	public static Color GetNameColorByAccessLevel(MemberAccessLevel accessLevel)
	{
		switch (accessLevel)
		{
		case MemberAccessLevel.QA:
			return ColorScheme.ChatNameQAUser;
		case MemberAccessLevel.Moderator:
			return ColorScheme.ChatNameModeratorUser;
		case MemberAccessLevel.SeniorQA:
			return ColorScheme.ChatNameSeniorQAUser;
		case MemberAccessLevel.SeniorModerator:
			return ColorScheme.ChatNameSeniorModeratorUser;
		case MemberAccessLevel.Admin:
			return ColorScheme.ChatNameAdminUser;
		}
		return ColorScheme.ChatNameOtherUser;
	}

	// Token: 0x04000907 RID: 2311
	public static readonly Color ProgressBar = new Color(0f, 0.607f, 0.662f);

	// Token: 0x04000908 RID: 2312
	public static readonly Color HudTeamRed = ColorConverter.RgbToColor(206f, 87f, 87f);

	// Token: 0x04000909 RID: 2313
	public static readonly Color HudTeamBlue = ColorConverter.RgbToColor(76f, 127f, 216f);

	// Token: 0x0400090A RID: 2314
	public static readonly Color GuiTeamRed = new Color(0.929f, 0.27f, 0.27f);

	// Token: 0x0400090B RID: 2315
	public static readonly Color GuiTeamBlue = new Color(0.176f, 0.643f, 0.792f);

	// Token: 0x0400090C RID: 2316
	public static readonly Color ChatNameCurrentUser = ColorConverter.RgbToColor(0f, 217f, 255f);

	// Token: 0x0400090D RID: 2317
	public static readonly Color ChatNameFriendsUser = ColorConverter.RgbToColor(0f, 204f, 0f);

	// Token: 0x0400090E RID: 2318
	public static readonly Color ChatNameFacebookFriendUser = ColorConverter.RgbToColor(0f, 184f, 158f);

	// Token: 0x0400090F RID: 2319
	public static readonly Color ChatNameAdminUser = ColorConverter.RgbToColor(204f, 0f, 0f);

	// Token: 0x04000910 RID: 2320
	public static readonly Color ChatNameModeratorUser = ColorConverter.RgbToColor(242f, 101f, 34f);

	// Token: 0x04000911 RID: 2321
	public static readonly Color ChatNameSeniorModeratorUser = ColorConverter.RgbToColor(255f, 255f, 0f);

	// Token: 0x04000912 RID: 2322
	public static readonly Color ChatNameQAUser = ColorConverter.RgbToColor(79f, 48f, 235f);

	// Token: 0x04000913 RID: 2323
	public static readonly Color ChatNameSeniorQAUser = ColorConverter.RgbToColor(223f, 0f, 255f);

	// Token: 0x04000914 RID: 2324
	public static readonly Color ChatNameOtherUser = ColorConverter.RgbToColor(153f, 153f, 153f);

	// Token: 0x04000915 RID: 2325
	public static readonly Color UberStrikeYellow = new Color(0.87f, 0.64f, 0.035f);

	// Token: 0x04000916 RID: 2326
	public static readonly Color UberStrikeBlue = new Color(0.176f, 0.643f, 0.792f);

	// Token: 0x04000917 RID: 2327
	public static readonly Color UberStrikeRed = new Color(0.929f, 0.27f, 0.27f);

	// Token: 0x04000918 RID: 2328
	public static readonly Color UberStrikeGreen = new Color(0f, 0.62f, 0.07f);

	// Token: 0x04000919 RID: 2329
	public static readonly Color CheatWarningRed = ColorConverter.RgbToColor(183f, 48f, 48f);

	// Token: 0x0400091A RID: 2330
	public static readonly Color XPColor = ColorConverter.RgbToColor(255f, 127f, 0f);

	// Token: 0x0400091B RID: 2331
	public static readonly Color TeamOutline = Color.white;
}
