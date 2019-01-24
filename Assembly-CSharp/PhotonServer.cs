using System;
using Cmune.Core.Models;
using Cmune.Core.Models.Views;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x0200035D RID: 861
public class PhotonServer
{
	// Token: 0x060017D5 RID: 6101 RVA: 0x0008133C File Offset: 0x0007F53C
	private PhotonServer()
	{
		this._view = new PhotonView();
		this.Region = "Default";
		this.Flag = new DynamicTexture(string.Empty, false);
	}

	// Token: 0x060017D6 RID: 6102 RVA: 0x0008138C File Offset: 0x0007F58C
	public PhotonServer(string address, PhotonUsageType type)
	{
		this._address = new ConnectionAddress(address);
		this._view = new PhotonView
		{
			Name = "No Name",
			IP = this._address.IpAddress,
			Port = (int)this._address.Port,
			UsageType = type
		};
		this.Region = "Default";
		this.Flag = new DynamicTexture(ApplicationDataManager.ImagePath + "flags/" + this.Region + ".png", this.Region != "Default");
	}

	// Token: 0x060017D7 RID: 6103 RVA: 0x00081444 File Offset: 0x0007F644
	public PhotonServer(PhotonView view)
	{
		this._address.Ipv4 = ConnectionAddress.ToInteger(view.IP);
		this._address.Port = (ushort)view.Port;
		this._view = view;
		int num = (!string.IsNullOrEmpty(this._view.Name)) ? this._view.Name.IndexOf('[') : 0;
		int num2 = (!string.IsNullOrEmpty(this._view.Name)) ? this._view.Name.IndexOf(']') : 0;
		if (num >= 0 && num2 > 1 && num2 > num)
		{
			this.Region = this._view.Name.Substring(num + 1, num2 - num - 1);
		}
		else
		{
			this.Region = "Default";
		}
		this.Flag = new DynamicTexture(ApplicationDataManager.ImagePath + "flags/" + this.Region + ".png", this.Region != "Default");
	}

	// Token: 0x17000570 RID: 1392
	// (get) Token: 0x060017D8 RID: 6104 RVA: 0x000100C5 File Offset: 0x0000E2C5
	// (set) Token: 0x060017D9 RID: 6105 RVA: 0x000100CD File Offset: 0x0000E2CD
	public DynamicTexture Flag { get; set; }

	// Token: 0x17000571 RID: 1393
	// (get) Token: 0x060017DA RID: 6106 RVA: 0x000100D6 File Offset: 0x0000E2D6
	public static PhotonServer Empty
	{
		get
		{
			return new PhotonServer();
		}
	}

	// Token: 0x17000572 RID: 1394
	// (get) Token: 0x060017DB RID: 6107 RVA: 0x000100DD File Offset: 0x0000E2DD
	public int Id
	{
		get
		{
			return this._view.PhotonId;
		}
	}

	// Token: 0x17000573 RID: 1395
	// (get) Token: 0x060017DC RID: 6108 RVA: 0x000100EA File Offset: 0x0000E2EA
	// (set) Token: 0x060017DD RID: 6109 RVA: 0x000100F7 File Offset: 0x0000E2F7
	public string ConnectionString
	{
		get
		{
			return this._address.ConnectionString;
		}
		set
		{
			this._address = new ConnectionAddress(value);
		}
	}

	// Token: 0x17000574 RID: 1396
	// (get) Token: 0x060017DE RID: 6110 RVA: 0x00010105 File Offset: 0x0000E305
	public float ServerLoad
	{
		get
		{
			return (float)Mathf.Min(this.Data.PlayersConnected + this.Data.RoomsCreated, 100) / 100f;
		}
	}

	// Token: 0x17000575 RID: 1397
	// (get) Token: 0x060017DF RID: 6111 RVA: 0x0001012C File Offset: 0x0000E32C
	public int Latency
	{
		get
		{
			return this.Data.Latency;
		}
	}

	// Token: 0x17000576 RID: 1398
	// (get) Token: 0x060017E0 RID: 6112 RVA: 0x00010139 File Offset: 0x0000E339
	public int MinLatency
	{
		get
		{
			return this._view.MinLatency;
		}
	}

	// Token: 0x17000577 RID: 1399
	// (get) Token: 0x060017E1 RID: 6113 RVA: 0x00010146 File Offset: 0x0000E346
	public bool IsValid
	{
		get
		{
			return this.UsageType != PhotonUsageType.None;
		}
	}

	// Token: 0x17000578 RID: 1400
	// (get) Token: 0x060017E2 RID: 6114 RVA: 0x00010154 File Offset: 0x0000E354
	public PhotonUsageType UsageType
	{
		get
		{
			return this._view.UsageType;
		}
	}

	// Token: 0x17000579 RID: 1401
	// (get) Token: 0x060017E3 RID: 6115 RVA: 0x00010161 File Offset: 0x0000E361
	public string Name
	{
		get
		{
			return this._view.Name;
		}
	}

	// Token: 0x1700057A RID: 1402
	// (get) Token: 0x060017E4 RID: 6116 RVA: 0x0001016E File Offset: 0x0000E36E
	// (set) Token: 0x060017E5 RID: 6117 RVA: 0x00010176 File Offset: 0x0000E376
	public string Region { get; private set; }

	// Token: 0x060017E6 RID: 6118 RVA: 0x00081570 File Offset: 0x0007F770
	public override string ToString()
	{
		return string.Format("Address: {0}\nLatency: {1}\nType: {2}\n{3}", new object[]
		{
			this._address.ConnectionString,
			this.Latency,
			this.UsageType,
			this.Data.ToString()
		});
	}

	// Token: 0x060017E7 RID: 6119 RVA: 0x0001017F File Offset: 0x0000E37F
	internal bool CheckLatency()
	{
		return this.MinLatency <= 0 || this.MinLatency > this.Latency;
	}

	// Token: 0x040016BA RID: 5818
	public PhotonServerLoad Data = new PhotonServerLoad();

	// Token: 0x040016BB RID: 5819
	private ConnectionAddress _address = new ConnectionAddress();

	// Token: 0x040016BC RID: 5820
	private PhotonView _view;
}
