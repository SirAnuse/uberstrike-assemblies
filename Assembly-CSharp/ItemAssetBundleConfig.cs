using System;
using UnityEngine;

// Token: 0x0200023E RID: 574
public class ItemAssetBundleConfig
{
	// Token: 0x170003B8 RID: 952
	// (get) Token: 0x06000FD6 RID: 4054 RVA: 0x0000B2AF File Offset: 0x000094AF
	// (set) Token: 0x06000FD7 RID: 4055 RVA: 0x0000B2B7 File Offset: 0x000094B7
	public int Id { get; set; }

	// Token: 0x170003B9 RID: 953
	// (get) Token: 0x06000FD8 RID: 4056 RVA: 0x0000B2C0 File Offset: 0x000094C0
	// (set) Token: 0x06000FD9 RID: 4057 RVA: 0x0000B2C8 File Offset: 0x000094C8
	public string ParentGameObject { get; set; }

	// Token: 0x170003BA RID: 954
	// (get) Token: 0x06000FDA RID: 4058 RVA: 0x0000B2D1 File Offset: 0x000094D1
	// (set) Token: 0x06000FDB RID: 4059 RVA: 0x0000B2D9 File Offset: 0x000094D9
	public string FileName { get; set; }

	// Token: 0x170003BB RID: 955
	// (get) Token: 0x06000FDC RID: 4060 RVA: 0x0000B2E2 File Offset: 0x000094E2
	// (set) Token: 0x06000FDD RID: 4061 RVA: 0x0000B2EA File Offset: 0x000094EA
	public AssetBundle AssetBundle { get; set; }
}
