using System;
using UnityEngine;

// Token: 0x020000AF RID: 175
public static class CommunicatorIcons
{
	// Token: 0x0600048D RID: 1165 RVA: 0x0002F3E4 File Offset: 0x0002D5E4
	static CommunicatorIcons()
	{
		Texture2DConfigurator component;
		try
		{
			component = GameObject.Find("CommunicatorIcons").GetComponent<Texture2DConfigurator>();
		}
		catch
		{
			Debug.LogError("Missing instance of the prefab with name: CommunicatorIcons!");
			return;
		}
		CommunicatorIcons.ChannelPortal16x16 = component.Assets[0];
		CommunicatorIcons.ChannelFacebook16x16 = component.Assets[1];
		CommunicatorIcons.ChannelWindows16x16 = component.Assets[2];
		CommunicatorIcons.ChannelApple16x16 = component.Assets[3];
		CommunicatorIcons.ChannelKongregate16x16 = component.Assets[4];
		CommunicatorIcons.ChannelAndroid16x16 = component.Assets[5];
		CommunicatorIcons.ChannelIos16x16 = component.Assets[6];
		CommunicatorIcons.PresenceOffline = component.Assets[7];
		CommunicatorIcons.PresenceOnline = component.Assets[8];
		CommunicatorIcons.PresencePlaying = component.Assets[9];
		CommunicatorIcons.NewInboxMessage = component.Assets[10];
		CommunicatorIcons.TagLightningBolt = component.Assets[11];
		CommunicatorIcons.SkullCrossbonesIcon = component.Assets[12];
		CommunicatorIcons.ChannelSteam16x16 = component.Assets[13];
	}

	// Token: 0x170000E2 RID: 226
	// (get) Token: 0x0600048E RID: 1166 RVA: 0x00005455 File Offset: 0x00003655
	// (set) Token: 0x0600048F RID: 1167 RVA: 0x0000545C File Offset: 0x0000365C
	public static Texture2D ChannelPortal16x16 { get; private set; }

	// Token: 0x170000E3 RID: 227
	// (get) Token: 0x06000490 RID: 1168 RVA: 0x00005464 File Offset: 0x00003664
	// (set) Token: 0x06000491 RID: 1169 RVA: 0x0000546B File Offset: 0x0000366B
	public static Texture2D ChannelFacebook16x16 { get; private set; }

	// Token: 0x170000E4 RID: 228
	// (get) Token: 0x06000492 RID: 1170 RVA: 0x00005473 File Offset: 0x00003673
	// (set) Token: 0x06000493 RID: 1171 RVA: 0x0000547A File Offset: 0x0000367A
	public static Texture2D ChannelWindows16x16 { get; private set; }

	// Token: 0x170000E5 RID: 229
	// (get) Token: 0x06000494 RID: 1172 RVA: 0x00005482 File Offset: 0x00003682
	// (set) Token: 0x06000495 RID: 1173 RVA: 0x00005489 File Offset: 0x00003689
	public static Texture2D ChannelApple16x16 { get; private set; }

	// Token: 0x170000E6 RID: 230
	// (get) Token: 0x06000496 RID: 1174 RVA: 0x00005491 File Offset: 0x00003691
	// (set) Token: 0x06000497 RID: 1175 RVA: 0x00005498 File Offset: 0x00003698
	public static Texture2D ChannelKongregate16x16 { get; private set; }

	// Token: 0x170000E7 RID: 231
	// (get) Token: 0x06000498 RID: 1176 RVA: 0x000054A0 File Offset: 0x000036A0
	// (set) Token: 0x06000499 RID: 1177 RVA: 0x000054A7 File Offset: 0x000036A7
	public static Texture2D ChannelAndroid16x16 { get; private set; }

	// Token: 0x170000E8 RID: 232
	// (get) Token: 0x0600049A RID: 1178 RVA: 0x000054AF File Offset: 0x000036AF
	// (set) Token: 0x0600049B RID: 1179 RVA: 0x000054B6 File Offset: 0x000036B6
	public static Texture2D ChannelIos16x16 { get; private set; }

	// Token: 0x170000E9 RID: 233
	// (get) Token: 0x0600049C RID: 1180 RVA: 0x000054BE File Offset: 0x000036BE
	// (set) Token: 0x0600049D RID: 1181 RVA: 0x000054C5 File Offset: 0x000036C5
	public static Texture2D PresenceOffline { get; private set; }

	// Token: 0x170000EA RID: 234
	// (get) Token: 0x0600049E RID: 1182 RVA: 0x000054CD File Offset: 0x000036CD
	// (set) Token: 0x0600049F RID: 1183 RVA: 0x000054D4 File Offset: 0x000036D4
	public static Texture2D PresenceOnline { get; private set; }

	// Token: 0x170000EB RID: 235
	// (get) Token: 0x060004A0 RID: 1184 RVA: 0x000054DC File Offset: 0x000036DC
	// (set) Token: 0x060004A1 RID: 1185 RVA: 0x000054E3 File Offset: 0x000036E3
	public static Texture2D PresencePlaying { get; private set; }

	// Token: 0x170000EC RID: 236
	// (get) Token: 0x060004A2 RID: 1186 RVA: 0x000054EB File Offset: 0x000036EB
	// (set) Token: 0x060004A3 RID: 1187 RVA: 0x000054F2 File Offset: 0x000036F2
	public static Texture2D NewInboxMessage { get; private set; }

	// Token: 0x170000ED RID: 237
	// (get) Token: 0x060004A4 RID: 1188 RVA: 0x000054FA File Offset: 0x000036FA
	// (set) Token: 0x060004A5 RID: 1189 RVA: 0x00005501 File Offset: 0x00003701
	public static Texture2D TagLightningBolt { get; private set; }

	// Token: 0x170000EE RID: 238
	// (get) Token: 0x060004A6 RID: 1190 RVA: 0x00005509 File Offset: 0x00003709
	// (set) Token: 0x060004A7 RID: 1191 RVA: 0x00005510 File Offset: 0x00003710
	public static Texture2D SkullCrossbonesIcon { get; private set; }

	// Token: 0x170000EF RID: 239
	// (get) Token: 0x060004A8 RID: 1192 RVA: 0x00005518 File Offset: 0x00003718
	// (set) Token: 0x060004A9 RID: 1193 RVA: 0x0000551F File Offset: 0x0000371F
	public static Texture2D ChannelSteam16x16 { get; private set; }
}
