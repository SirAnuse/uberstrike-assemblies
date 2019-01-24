using System;
using Cmune.DataCenter.Common.Entities;
using UnityEngine;

// Token: 0x02000110 RID: 272
public class ClientConfiguration
{
	// Token: 0x060007FC RID: 2044 RVA: 0x00036A50 File Offset: 0x00034C50
	public ClientConfiguration()
	{
		this.WebServiceBaseUrl = string.Empty;
		this.ItemAssetBundlePath = string.Empty;
		this.MapAssetBundlePath = string.Empty;
		this.ImagePath = string.Empty;
		this.ContentRouterBaseUrl = string.Empty;
		this.FacebookAppId = string.Empty;
		this.ChannelType = ChannelType.WebPortal;
		this.PaymentBundleUrl = string.Empty;
		this.CmuneBootstrapUrl = string.Empty;
		this.IsDebug = true;
	}

	// Token: 0x17000253 RID: 595
	// (get) Token: 0x060007FD RID: 2045 RVA: 0x00007104 File Offset: 0x00005304
	// (set) Token: 0x060007FE RID: 2046 RVA: 0x0000710C File Offset: 0x0000530C
	public string WebServiceBaseUrl { get; set; }

	// Token: 0x17000254 RID: 596
	// (get) Token: 0x060007FF RID: 2047 RVA: 0x00007115 File Offset: 0x00005315
	// (set) Token: 0x06000800 RID: 2048 RVA: 0x0000711D File Offset: 0x0000531D
	public string ItemAssetBundlePath { get; set; }

	// Token: 0x17000255 RID: 597
	// (get) Token: 0x06000801 RID: 2049 RVA: 0x00007126 File Offset: 0x00005326
	// (set) Token: 0x06000802 RID: 2050 RVA: 0x0000712E File Offset: 0x0000532E
	public string MapAssetBundlePath { get; set; }

	// Token: 0x17000256 RID: 598
	// (get) Token: 0x06000803 RID: 2051 RVA: 0x00007137 File Offset: 0x00005337
	// (set) Token: 0x06000804 RID: 2052 RVA: 0x0000713F File Offset: 0x0000533F
	public string ImagePath { get; set; }

	// Token: 0x17000257 RID: 599
	// (get) Token: 0x06000805 RID: 2053 RVA: 0x00007148 File Offset: 0x00005348
	// (set) Token: 0x06000806 RID: 2054 RVA: 0x00007150 File Offset: 0x00005350
	public string ContentRouterBaseUrl { get; set; }

	// Token: 0x17000258 RID: 600
	// (get) Token: 0x06000807 RID: 2055 RVA: 0x00007159 File Offset: 0x00005359
	// (set) Token: 0x06000808 RID: 2056 RVA: 0x00007161 File Offset: 0x00005361
	public string FacebookAppId { get; set; }

	// Token: 0x17000259 RID: 601
	// (get) Token: 0x06000809 RID: 2057 RVA: 0x0000716A File Offset: 0x0000536A
	// (set) Token: 0x0600080A RID: 2058 RVA: 0x00007172 File Offset: 0x00005372
	public string CmuneBootstrapUrl { get; set; }

	// Token: 0x1700025A RID: 602
	// (get) Token: 0x0600080B RID: 2059 RVA: 0x0000717B File Offset: 0x0000537B
	// (set) Token: 0x0600080C RID: 2060 RVA: 0x00007183 File Offset: 0x00005383
	public ChannelType ChannelType { get; set; }

	// Token: 0x1700025B RID: 603
	// (get) Token: 0x0600080D RID: 2061 RVA: 0x0000718C File Offset: 0x0000538C
	// (set) Token: 0x0600080E RID: 2062 RVA: 0x00007194 File Offset: 0x00005394
	public string PaymentBundleUrl { get; set; }

	// Token: 0x1700025C RID: 604
	// (get) Token: 0x0600080F RID: 2063 RVA: 0x0000719D File Offset: 0x0000539D
	// (set) Token: 0x06000810 RID: 2064 RVA: 0x000071A5 File Offset: 0x000053A5
	public bool IsDebug { get; set; }

	// Token: 0x06000811 RID: 2065 RVA: 0x00036ACC File Offset: 0x00034CCC
	public void SetChannelType(string value)
	{
		try
		{
			this.ChannelType = (ChannelType)((int)Enum.Parse(typeof(ChannelType), value));
		}
		catch
		{
			Debug.LogError("Unsupported ChannelType!");
		}
	}
}
