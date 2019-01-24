using System;
using UnityEngine;

// Token: 0x020000B0 RID: 176
public static class ConsumableHudTextures
{
	// Token: 0x060004AA RID: 1194 RVA: 0x0002F520 File Offset: 0x0002D720
	static ConsumableHudTextures()
	{
		Texture2DConfigurator component;
		try
		{
			component = GameObject.Find("ConsumableHudTextures").GetComponent<Texture2DConfigurator>();
		}
		catch
		{
			Debug.LogError("Missing instance of the prefab with name: ConsumableHudTextures!");
			return;
		}
		ConsumableHudTextures.TooltipDown = component.Assets[0];
		ConsumableHudTextures.TooltipLeft = component.Assets[1];
		ConsumableHudTextures.TooltipRight = component.Assets[2];
		ConsumableHudTextures.TooltipUp = component.Assets[3];
		ConsumableHudTextures.AmmoBlue = component.Assets[4];
		ConsumableHudTextures.AmmoRed = component.Assets[5];
		ConsumableHudTextures.ArmorBlue = component.Assets[6];
		ConsumableHudTextures.ArmorRed = component.Assets[7];
		ConsumableHudTextures.HealthBlue = component.Assets[8];
		ConsumableHudTextures.HealthRed = component.Assets[9];
		ConsumableHudTextures.OffensiveGrenadeBlue = component.Assets[10];
		ConsumableHudTextures.OffensiveGrenadeRed = component.Assets[11];
		ConsumableHudTextures.SpringGrenadeBlue = component.Assets[12];
		ConsumableHudTextures.SpringGrenadeRed = component.Assets[13];
		ConsumableHudTextures.CircleBlue = component.Assets[14];
		ConsumableHudTextures.CircleRed = component.Assets[15];
		ConsumableHudTextures.CircleWhite = component.Assets[16];
	}

	// Token: 0x170000F0 RID: 240
	// (get) Token: 0x060004AB RID: 1195 RVA: 0x00005527 File Offset: 0x00003727
	// (set) Token: 0x060004AC RID: 1196 RVA: 0x0000552E File Offset: 0x0000372E
	public static Texture2D TooltipDown { get; private set; }

	// Token: 0x170000F1 RID: 241
	// (get) Token: 0x060004AD RID: 1197 RVA: 0x00005536 File Offset: 0x00003736
	// (set) Token: 0x060004AE RID: 1198 RVA: 0x0000553D File Offset: 0x0000373D
	public static Texture2D TooltipLeft { get; private set; }

	// Token: 0x170000F2 RID: 242
	// (get) Token: 0x060004AF RID: 1199 RVA: 0x00005545 File Offset: 0x00003745
	// (set) Token: 0x060004B0 RID: 1200 RVA: 0x0000554C File Offset: 0x0000374C
	public static Texture2D TooltipRight { get; private set; }

	// Token: 0x170000F3 RID: 243
	// (get) Token: 0x060004B1 RID: 1201 RVA: 0x00005554 File Offset: 0x00003754
	// (set) Token: 0x060004B2 RID: 1202 RVA: 0x0000555B File Offset: 0x0000375B
	public static Texture2D TooltipUp { get; private set; }

	// Token: 0x170000F4 RID: 244
	// (get) Token: 0x060004B3 RID: 1203 RVA: 0x00005563 File Offset: 0x00003763
	// (set) Token: 0x060004B4 RID: 1204 RVA: 0x0000556A File Offset: 0x0000376A
	public static Texture2D AmmoBlue { get; private set; }

	// Token: 0x170000F5 RID: 245
	// (get) Token: 0x060004B5 RID: 1205 RVA: 0x00005572 File Offset: 0x00003772
	// (set) Token: 0x060004B6 RID: 1206 RVA: 0x00005579 File Offset: 0x00003779
	public static Texture2D AmmoRed { get; private set; }

	// Token: 0x170000F6 RID: 246
	// (get) Token: 0x060004B7 RID: 1207 RVA: 0x00005581 File Offset: 0x00003781
	// (set) Token: 0x060004B8 RID: 1208 RVA: 0x00005588 File Offset: 0x00003788
	public static Texture2D ArmorBlue { get; private set; }

	// Token: 0x170000F7 RID: 247
	// (get) Token: 0x060004B9 RID: 1209 RVA: 0x00005590 File Offset: 0x00003790
	// (set) Token: 0x060004BA RID: 1210 RVA: 0x00005597 File Offset: 0x00003797
	public static Texture2D ArmorRed { get; private set; }

	// Token: 0x170000F8 RID: 248
	// (get) Token: 0x060004BB RID: 1211 RVA: 0x0000559F File Offset: 0x0000379F
	// (set) Token: 0x060004BC RID: 1212 RVA: 0x000055A6 File Offset: 0x000037A6
	public static Texture2D HealthBlue { get; private set; }

	// Token: 0x170000F9 RID: 249
	// (get) Token: 0x060004BD RID: 1213 RVA: 0x000055AE File Offset: 0x000037AE
	// (set) Token: 0x060004BE RID: 1214 RVA: 0x000055B5 File Offset: 0x000037B5
	public static Texture2D HealthRed { get; private set; }

	// Token: 0x170000FA RID: 250
	// (get) Token: 0x060004BF RID: 1215 RVA: 0x000055BD File Offset: 0x000037BD
	// (set) Token: 0x060004C0 RID: 1216 RVA: 0x000055C4 File Offset: 0x000037C4
	public static Texture2D OffensiveGrenadeBlue { get; private set; }

	// Token: 0x170000FB RID: 251
	// (get) Token: 0x060004C1 RID: 1217 RVA: 0x000055CC File Offset: 0x000037CC
	// (set) Token: 0x060004C2 RID: 1218 RVA: 0x000055D3 File Offset: 0x000037D3
	public static Texture2D OffensiveGrenadeRed { get; private set; }

	// Token: 0x170000FC RID: 252
	// (get) Token: 0x060004C3 RID: 1219 RVA: 0x000055DB File Offset: 0x000037DB
	// (set) Token: 0x060004C4 RID: 1220 RVA: 0x000055E2 File Offset: 0x000037E2
	public static Texture2D SpringGrenadeBlue { get; private set; }

	// Token: 0x170000FD RID: 253
	// (get) Token: 0x060004C5 RID: 1221 RVA: 0x000055EA File Offset: 0x000037EA
	// (set) Token: 0x060004C6 RID: 1222 RVA: 0x000055F1 File Offset: 0x000037F1
	public static Texture2D SpringGrenadeRed { get; private set; }

	// Token: 0x170000FE RID: 254
	// (get) Token: 0x060004C7 RID: 1223 RVA: 0x000055F9 File Offset: 0x000037F9
	// (set) Token: 0x060004C8 RID: 1224 RVA: 0x00005600 File Offset: 0x00003800
	public static Texture2D CircleBlue { get; private set; }

	// Token: 0x170000FF RID: 255
	// (get) Token: 0x060004C9 RID: 1225 RVA: 0x00005608 File Offset: 0x00003808
	// (set) Token: 0x060004CA RID: 1226 RVA: 0x0000560F File Offset: 0x0000380F
	public static Texture2D CircleRed { get; private set; }

	// Token: 0x17000100 RID: 256
	// (get) Token: 0x060004CB RID: 1227 RVA: 0x00005617 File Offset: 0x00003817
	// (set) Token: 0x060004CC RID: 1228 RVA: 0x0000561E File Offset: 0x0000381E
	public static Texture2D CircleWhite { get; private set; }
}
