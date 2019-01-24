using System;
using System.Text;
using UberStrike.Core.Types;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001DF RID: 479
	[Serializable]
	public class LoadoutView
	{
		// Token: 0x06000BCC RID: 3020 RVA: 0x00008810 File Offset: 0x00006A10
		public LoadoutView()
		{
			this.Type = AvatarType.LutzRavinoff;
			this.SkinColor = string.Empty;
		}

		// Token: 0x06000BCD RID: 3021 RVA: 0x0000FEE8 File Offset: 0x0000E0E8
		public LoadoutView(int loadoutId, int backpack, int boots, int cmid, int face, int functionalItem1, int functionalItem2, int functionalItem3, int gloves, int head, int lowerBody, int meleeWeapon, int quickItem1, int quickItem2, int quickItem3, AvatarType type, int upperBody, int weapon1, int weapon1Mod1, int weapon1Mod2, int weapon1Mod3, int weapon2, int weapon2Mod1, int weapon2Mod2, int weapon2Mod3, int weapon3, int weapon3Mod1, int weapon3Mod2, int weapon3Mod3, int webbing, string skinColor)
		{
			this.Backpack = backpack;
			this.Boots = boots;
			this.Cmid = cmid;
			this.Face = face;
			this.FunctionalItem1 = functionalItem1;
			this.FunctionalItem2 = functionalItem2;
			this.FunctionalItem3 = functionalItem3;
			this.Gloves = gloves;
			this.Head = head;
			this.LoadoutId = loadoutId;
			this.LowerBody = lowerBody;
			this.MeleeWeapon = meleeWeapon;
			this.QuickItem1 = quickItem1;
			this.QuickItem2 = quickItem2;
			this.QuickItem3 = quickItem3;
			this.Type = type;
			this.UpperBody = upperBody;
			this.Weapon1 = weapon1;
			this.Weapon1Mod1 = weapon1Mod1;
			this.Weapon1Mod2 = weapon1Mod2;
			this.Weapon1Mod3 = weapon1Mod3;
			this.Weapon2 = weapon2;
			this.Weapon2Mod1 = weapon2Mod1;
			this.Weapon2Mod2 = weapon2Mod2;
			this.Weapon2Mod3 = weapon2Mod3;
			this.Weapon3 = weapon3;
			this.Weapon3Mod1 = weapon3Mod1;
			this.Weapon3Mod2 = weapon3Mod2;
			this.Weapon3Mod3 = weapon3Mod3;
			this.Webbing = webbing;
			this.SkinColor = skinColor;
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000BCE RID: 3022 RVA: 0x0000882A File Offset: 0x00006A2A
		// (set) Token: 0x06000BCF RID: 3023 RVA: 0x00008832 File Offset: 0x00006A32
		public int LoadoutId { get; set; }

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000BD0 RID: 3024 RVA: 0x0000883B File Offset: 0x00006A3B
		// (set) Token: 0x06000BD1 RID: 3025 RVA: 0x00008843 File Offset: 0x00006A43
		public int Backpack { get; set; }

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000BD2 RID: 3026 RVA: 0x0000884C File Offset: 0x00006A4C
		// (set) Token: 0x06000BD3 RID: 3027 RVA: 0x00008854 File Offset: 0x00006A54
		public int Boots { get; set; }

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000BD4 RID: 3028 RVA: 0x0000885D File Offset: 0x00006A5D
		// (set) Token: 0x06000BD5 RID: 3029 RVA: 0x00008865 File Offset: 0x00006A65
		public int Cmid { get; set; }

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000BD6 RID: 3030 RVA: 0x0000886E File Offset: 0x00006A6E
		// (set) Token: 0x06000BD7 RID: 3031 RVA: 0x00008876 File Offset: 0x00006A76
		public int Face { get; set; }

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000BD8 RID: 3032 RVA: 0x0000887F File Offset: 0x00006A7F
		// (set) Token: 0x06000BD9 RID: 3033 RVA: 0x00008887 File Offset: 0x00006A87
		public int FunctionalItem1 { get; set; }

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x06000BDA RID: 3034 RVA: 0x00008890 File Offset: 0x00006A90
		// (set) Token: 0x06000BDB RID: 3035 RVA: 0x00008898 File Offset: 0x00006A98
		public int FunctionalItem2 { get; set; }

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06000BDC RID: 3036 RVA: 0x000088A1 File Offset: 0x00006AA1
		// (set) Token: 0x06000BDD RID: 3037 RVA: 0x000088A9 File Offset: 0x00006AA9
		public int FunctionalItem3 { get; set; }

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000BDE RID: 3038 RVA: 0x000088B2 File Offset: 0x00006AB2
		// (set) Token: 0x06000BDF RID: 3039 RVA: 0x000088BA File Offset: 0x00006ABA
		public int Gloves { get; set; }

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000BE0 RID: 3040 RVA: 0x000088C3 File Offset: 0x00006AC3
		// (set) Token: 0x06000BE1 RID: 3041 RVA: 0x000088CB File Offset: 0x00006ACB
		public int Head { get; set; }

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06000BE2 RID: 3042 RVA: 0x000088D4 File Offset: 0x00006AD4
		// (set) Token: 0x06000BE3 RID: 3043 RVA: 0x000088DC File Offset: 0x00006ADC
		public int LowerBody { get; set; }

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000BE4 RID: 3044 RVA: 0x000088E5 File Offset: 0x00006AE5
		// (set) Token: 0x06000BE5 RID: 3045 RVA: 0x000088ED File Offset: 0x00006AED
		public int MeleeWeapon { get; set; }

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000BE6 RID: 3046 RVA: 0x000088F6 File Offset: 0x00006AF6
		// (set) Token: 0x06000BE7 RID: 3047 RVA: 0x000088FE File Offset: 0x00006AFE
		public int QuickItem1 { get; set; }

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000BE8 RID: 3048 RVA: 0x00008907 File Offset: 0x00006B07
		// (set) Token: 0x06000BE9 RID: 3049 RVA: 0x0000890F File Offset: 0x00006B0F
		public int QuickItem2 { get; set; }

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000BEA RID: 3050 RVA: 0x00008918 File Offset: 0x00006B18
		// (set) Token: 0x06000BEB RID: 3051 RVA: 0x00008920 File Offset: 0x00006B20
		public int QuickItem3 { get; set; }

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000BEC RID: 3052 RVA: 0x00008929 File Offset: 0x00006B29
		// (set) Token: 0x06000BED RID: 3053 RVA: 0x00008931 File Offset: 0x00006B31
		public AvatarType Type { get; set; }

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000BEE RID: 3054 RVA: 0x0000893A File Offset: 0x00006B3A
		// (set) Token: 0x06000BEF RID: 3055 RVA: 0x00008942 File Offset: 0x00006B42
		public int UpperBody { get; set; }

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06000BF0 RID: 3056 RVA: 0x0000894B File Offset: 0x00006B4B
		// (set) Token: 0x06000BF1 RID: 3057 RVA: 0x00008953 File Offset: 0x00006B53
		public int Weapon1 { get; set; }

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000BF2 RID: 3058 RVA: 0x0000895C File Offset: 0x00006B5C
		// (set) Token: 0x06000BF3 RID: 3059 RVA: 0x00008964 File Offset: 0x00006B64
		public int Weapon1Mod1 { get; set; }

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06000BF4 RID: 3060 RVA: 0x0000896D File Offset: 0x00006B6D
		// (set) Token: 0x06000BF5 RID: 3061 RVA: 0x00008975 File Offset: 0x00006B75
		public int Weapon1Mod2 { get; set; }

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000BF6 RID: 3062 RVA: 0x0000897E File Offset: 0x00006B7E
		// (set) Token: 0x06000BF7 RID: 3063 RVA: 0x00008986 File Offset: 0x00006B86
		public int Weapon1Mod3 { get; set; }

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000BF8 RID: 3064 RVA: 0x0000898F File Offset: 0x00006B8F
		// (set) Token: 0x06000BF9 RID: 3065 RVA: 0x00008997 File Offset: 0x00006B97
		public int Weapon2 { get; set; }

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000BFA RID: 3066 RVA: 0x000089A0 File Offset: 0x00006BA0
		// (set) Token: 0x06000BFB RID: 3067 RVA: 0x000089A8 File Offset: 0x00006BA8
		public int Weapon2Mod1 { get; set; }

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000BFC RID: 3068 RVA: 0x000089B1 File Offset: 0x00006BB1
		// (set) Token: 0x06000BFD RID: 3069 RVA: 0x000089B9 File Offset: 0x00006BB9
		public int Weapon2Mod2 { get; set; }

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000BFE RID: 3070 RVA: 0x000089C2 File Offset: 0x00006BC2
		// (set) Token: 0x06000BFF RID: 3071 RVA: 0x000089CA File Offset: 0x00006BCA
		public int Weapon2Mod3 { get; set; }

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06000C00 RID: 3072 RVA: 0x000089D3 File Offset: 0x00006BD3
		// (set) Token: 0x06000C01 RID: 3073 RVA: 0x000089DB File Offset: 0x00006BDB
		public int Weapon3 { get; set; }

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000C02 RID: 3074 RVA: 0x000089E4 File Offset: 0x00006BE4
		// (set) Token: 0x06000C03 RID: 3075 RVA: 0x000089EC File Offset: 0x00006BEC
		public int Weapon3Mod1 { get; set; }

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000C04 RID: 3076 RVA: 0x000089F5 File Offset: 0x00006BF5
		// (set) Token: 0x06000C05 RID: 3077 RVA: 0x000089FD File Offset: 0x00006BFD
		public int Weapon3Mod2 { get; set; }

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06000C06 RID: 3078 RVA: 0x00008A06 File Offset: 0x00006C06
		// (set) Token: 0x06000C07 RID: 3079 RVA: 0x00008A0E File Offset: 0x00006C0E
		public int Weapon3Mod3 { get; set; }

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x06000C08 RID: 3080 RVA: 0x00008A17 File Offset: 0x00006C17
		// (set) Token: 0x06000C09 RID: 3081 RVA: 0x00008A1F File Offset: 0x00006C1F
		public int Webbing { get; set; }

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x06000C0A RID: 3082 RVA: 0x00008A28 File Offset: 0x00006C28
		// (set) Token: 0x06000C0B RID: 3083 RVA: 0x00008A30 File Offset: 0x00006C30
		public string SkinColor { get; set; }

		// Token: 0x06000C0C RID: 3084 RVA: 0x0000FFF0 File Offset: 0x0000E1F0
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[LoadoutView: [Backpack: ");
			stringBuilder.Append(this.Backpack);
			stringBuilder.Append("][Boots: ");
			stringBuilder.Append(this.Boots);
			stringBuilder.Append("][Cmid: ");
			stringBuilder.Append(this.Cmid);
			stringBuilder.Append("][Face: ");
			stringBuilder.Append(this.Face);
			stringBuilder.Append("][FunctionalItem1: ");
			stringBuilder.Append(this.FunctionalItem1);
			stringBuilder.Append("][FunctionalItem2: ");
			stringBuilder.Append(this.FunctionalItem2);
			stringBuilder.Append("][FunctionalItem3: ");
			stringBuilder.Append(this.FunctionalItem3);
			stringBuilder.Append("][Gloves: ");
			stringBuilder.Append(this.Gloves);
			stringBuilder.Append("][Head: ");
			stringBuilder.Append(this.Head);
			stringBuilder.Append("][LoadoutId: ");
			stringBuilder.Append(this.LoadoutId);
			stringBuilder.Append("][LowerBody: ");
			stringBuilder.Append(this.LowerBody);
			stringBuilder.Append("][MeleeWeapon: ");
			stringBuilder.Append(this.MeleeWeapon);
			stringBuilder.Append("][QuickItem1: ");
			stringBuilder.Append(this.QuickItem1);
			stringBuilder.Append("][QuickItem2: ");
			stringBuilder.Append(this.QuickItem2);
			stringBuilder.Append("][QuickItem3: ");
			stringBuilder.Append(this.QuickItem3);
			stringBuilder.Append("][Type: ");
			stringBuilder.Append(this.Type);
			stringBuilder.Append("][UpperBody: ");
			stringBuilder.Append(this.UpperBody);
			stringBuilder.Append("][Weapon1: ");
			stringBuilder.Append(this.Weapon1);
			stringBuilder.Append("][Weapon1Mod1: ");
			stringBuilder.Append(this.Weapon1Mod1);
			stringBuilder.Append("][Weapon1Mod2: ");
			stringBuilder.Append(this.Weapon1Mod2);
			stringBuilder.Append("][Weapon1Mod3: ");
			stringBuilder.Append(this.Weapon1Mod3);
			stringBuilder.Append("][Weapon2: ");
			stringBuilder.Append(this.Weapon2);
			stringBuilder.Append("][Weapon2Mod1: ");
			stringBuilder.Append(this.Weapon2Mod1);
			stringBuilder.Append("][Weapon2Mod2: ");
			stringBuilder.Append(this.Weapon2Mod2);
			stringBuilder.Append("][Weapon2Mod3: ");
			stringBuilder.Append(this.Weapon2Mod3);
			stringBuilder.Append("][Weapon3: ");
			stringBuilder.Append(this.Weapon3);
			stringBuilder.Append("][Weapon3Mod1: ");
			stringBuilder.Append(this.Weapon3Mod1);
			stringBuilder.Append("][Weapon3Mod2: ");
			stringBuilder.Append(this.Weapon3Mod2);
			stringBuilder.Append("][Weapon3Mod3: ");
			stringBuilder.Append(this.Weapon3Mod3);
			stringBuilder.Append("][Webbing: ");
			stringBuilder.Append(this.Webbing);
			stringBuilder.Append("][SkinColor: ");
			stringBuilder.Append(this.SkinColor);
			stringBuilder.Append("]]");
			return stringBuilder.ToString();
		}
	}
}
