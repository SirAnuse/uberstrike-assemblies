using System;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;

// Token: 0x020003B9 RID: 953
public class UberstrikeMap
{
	// Token: 0x06001BE9 RID: 7145 RVA: 0x0008EAE4 File Offset: 0x0008CCE4
	public UberstrikeMap(MapView view)
	{
		this.View = view;
		this.IsVisible = true;
		this.MapIconUrl = ApplicationDataManager.ImagePath + "maps/" + this.View.SceneName + ".jpg";
		bool loadNow = this.View.SceneName != "Menu";
		this.Icon = new DynamicTexture(this.MapIconUrl, loadNow);
	}

	// Token: 0x1700062C RID: 1580
	// (get) Token: 0x06001BEA RID: 7146 RVA: 0x000128B7 File Offset: 0x00010AB7
	// (set) Token: 0x06001BEB RID: 7147 RVA: 0x000128BF File Offset: 0x00010ABF
	public bool IsVisible { get; set; }

	// Token: 0x1700062D RID: 1581
	// (get) Token: 0x06001BEC RID: 7148 RVA: 0x000128C8 File Offset: 0x00010AC8
	// (set) Token: 0x06001BED RID: 7149 RVA: 0x000128D0 File Offset: 0x00010AD0
	public MapView View { get; private set; }

	// Token: 0x1700062E RID: 1582
	// (get) Token: 0x06001BEE RID: 7150 RVA: 0x000128D9 File Offset: 0x00010AD9
	// (set) Token: 0x06001BEF RID: 7151 RVA: 0x000128E1 File Offset: 0x00010AE1
	public DynamicTexture Icon { get; private set; }

	// Token: 0x1700062F RID: 1583
	// (get) Token: 0x06001BF0 RID: 7152 RVA: 0x000128EA File Offset: 0x00010AEA
	// (set) Token: 0x06001BF1 RID: 7153 RVA: 0x000128F2 File Offset: 0x00010AF2
	public bool IsBuiltIn { get; set; }

	// Token: 0x17000630 RID: 1584
	// (get) Token: 0x06001BF2 RID: 7154 RVA: 0x000128FB File Offset: 0x00010AFB
	public int Id
	{
		get
		{
			return this.View.MapId;
		}
	}

	// Token: 0x17000631 RID: 1585
	// (get) Token: 0x06001BF3 RID: 7155 RVA: 0x00012908 File Offset: 0x00010B08
	public string Name
	{
		get
		{
			return this.View.DisplayName;
		}
	}

	// Token: 0x17000632 RID: 1586
	// (get) Token: 0x06001BF4 RID: 7156 RVA: 0x00012915 File Offset: 0x00010B15
	public string Description
	{
		get
		{
			return this.View.Description;
		}
	}

	// Token: 0x17000633 RID: 1587
	// (get) Token: 0x06001BF5 RID: 7157 RVA: 0x00012922 File Offset: 0x00010B22
	public string SceneName
	{
		get
		{
			return this.View.SceneName;
		}
	}

	// Token: 0x17000634 RID: 1588
	// (get) Token: 0x06001BF6 RID: 7158 RVA: 0x0001292F File Offset: 0x00010B2F
	// (set) Token: 0x06001BF7 RID: 7159 RVA: 0x00012937 File Offset: 0x00010B37
	public string MapIconUrl { get; private set; }

	// Token: 0x06001BF8 RID: 7160 RVA: 0x00012940 File Offset: 0x00010B40
	public bool IsGameModeSupported(GameModeType mode)
	{
		return this.View.Settings != null && this.View.Settings.ContainsKey(mode);
	}
}
