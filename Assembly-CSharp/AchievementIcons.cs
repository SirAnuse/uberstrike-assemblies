using System;
using UnityEngine;

// Token: 0x020000AD RID: 173
public static class AchievementIcons
{
	// Token: 0x06000472 RID: 1138 RVA: 0x0002E0E4 File Offset: 0x0002C2E4
	static AchievementIcons()
	{
		Texture2DConfigurator component = GameObject.Find("AchievementIcons").GetComponent<Texture2DConfigurator>();
		if (component == null)
		{
			throw new Exception("Missing instance of the prefab with name: AchievementIcons!");
		}
		AchievementIcons.Achievement1MostValuablePlayer = component.Assets[0];
		AchievementIcons.Achievement2MostAggressive = component.Assets[1];
		AchievementIcons.Achievement3SharpestShooter = component.Assets[2];
		AchievementIcons.Achievement4TriggerHappy = component.Assets[3];
		AchievementIcons.Achievement5HardestHitter = component.Assets[4];
		AchievementIcons.Achievement6CostEffective = component.Assets[5];
		AchievementIcons.AchievementDefault = component.Assets[6];
		AchievementIcons.RecommendationGear = component.Assets[7];
		AchievementIcons.RecommendationMostEfficientWeapon = component.Assets[8];
		AchievementIcons.RecommendationSale = component.Assets[9];
		AchievementIcons.RecommendationWeapon = component.Assets[10];
	}

	// Token: 0x170000D6 RID: 214
	// (get) Token: 0x06000473 RID: 1139 RVA: 0x000053A1 File Offset: 0x000035A1
	// (set) Token: 0x06000474 RID: 1140 RVA: 0x000053A8 File Offset: 0x000035A8
	public static Texture2D Achievement1MostValuablePlayer { get; private set; }

	// Token: 0x170000D7 RID: 215
	// (get) Token: 0x06000475 RID: 1141 RVA: 0x000053B0 File Offset: 0x000035B0
	// (set) Token: 0x06000476 RID: 1142 RVA: 0x000053B7 File Offset: 0x000035B7
	public static Texture2D Achievement2MostAggressive { get; private set; }

	// Token: 0x170000D8 RID: 216
	// (get) Token: 0x06000477 RID: 1143 RVA: 0x000053BF File Offset: 0x000035BF
	// (set) Token: 0x06000478 RID: 1144 RVA: 0x000053C6 File Offset: 0x000035C6
	public static Texture2D Achievement3SharpestShooter { get; private set; }

	// Token: 0x170000D9 RID: 217
	// (get) Token: 0x06000479 RID: 1145 RVA: 0x000053CE File Offset: 0x000035CE
	// (set) Token: 0x0600047A RID: 1146 RVA: 0x000053D5 File Offset: 0x000035D5
	public static Texture2D Achievement4TriggerHappy { get; private set; }

	// Token: 0x170000DA RID: 218
	// (get) Token: 0x0600047B RID: 1147 RVA: 0x000053DD File Offset: 0x000035DD
	// (set) Token: 0x0600047C RID: 1148 RVA: 0x000053E4 File Offset: 0x000035E4
	public static Texture2D Achievement5HardestHitter { get; private set; }

	// Token: 0x170000DB RID: 219
	// (get) Token: 0x0600047D RID: 1149 RVA: 0x000053EC File Offset: 0x000035EC
	// (set) Token: 0x0600047E RID: 1150 RVA: 0x000053F3 File Offset: 0x000035F3
	public static Texture2D Achievement6CostEffective { get; private set; }

	// Token: 0x170000DC RID: 220
	// (get) Token: 0x0600047F RID: 1151 RVA: 0x000053FB File Offset: 0x000035FB
	// (set) Token: 0x06000480 RID: 1152 RVA: 0x00005402 File Offset: 0x00003602
	public static Texture2D AchievementDefault { get; private set; }

	// Token: 0x170000DD RID: 221
	// (get) Token: 0x06000481 RID: 1153 RVA: 0x0000540A File Offset: 0x0000360A
	// (set) Token: 0x06000482 RID: 1154 RVA: 0x00005411 File Offset: 0x00003611
	public static Texture2D RecommendationGear { get; private set; }

	// Token: 0x170000DE RID: 222
	// (get) Token: 0x06000483 RID: 1155 RVA: 0x00005419 File Offset: 0x00003619
	// (set) Token: 0x06000484 RID: 1156 RVA: 0x00005420 File Offset: 0x00003620
	public static Texture2D RecommendationMostEfficientWeapon { get; private set; }

	// Token: 0x170000DF RID: 223
	// (get) Token: 0x06000485 RID: 1157 RVA: 0x00005428 File Offset: 0x00003628
	// (set) Token: 0x06000486 RID: 1158 RVA: 0x0000542F File Offset: 0x0000362F
	public static Texture2D RecommendationSale { get; private set; }

	// Token: 0x170000E0 RID: 224
	// (get) Token: 0x06000487 RID: 1159 RVA: 0x00005437 File Offset: 0x00003637
	// (set) Token: 0x06000488 RID: 1160 RVA: 0x0000543E File Offset: 0x0000363E
	public static Texture2D RecommendationWeapon { get; private set; }
}
