using System;
using UnityEngine;

// Token: 0x020003B1 RID: 945
public abstract class TouchBaseControl
{
	// Token: 0x06001BA9 RID: 7081 RVA: 0x0001249A File Offset: 0x0001069A
	public TouchBaseControl()
	{
		Singleton<TouchController>.Instance.AddControl(this);
	}

	// Token: 0x17000624 RID: 1572
	// (get) Token: 0x06001BAA RID: 7082 RVA: 0x000124AD File Offset: 0x000106AD
	// (set) Token: 0x06001BAB RID: 7083 RVA: 0x000124B5 File Offset: 0x000106B5
	public virtual bool Enabled { get; set; }

	// Token: 0x17000625 RID: 1573
	// (get) Token: 0x06001BAC RID: 7084 RVA: 0x000124BE File Offset: 0x000106BE
	// (set) Token: 0x06001BAD RID: 7085 RVA: 0x000124C6 File Offset: 0x000106C6
	public virtual Rect Boundary { get; set; }

	// Token: 0x06001BAE RID: 7086 RVA: 0x00003C87 File Offset: 0x00001E87
	public virtual void FirstUpdate()
	{
	}

	// Token: 0x06001BAF RID: 7087 RVA: 0x00003C87 File Offset: 0x00001E87
	public virtual void UpdateTouches(Touch touch)
	{
	}

	// Token: 0x06001BB0 RID: 7088 RVA: 0x00003C87 File Offset: 0x00001E87
	public virtual void FinalUpdate()
	{
	}

	// Token: 0x06001BB1 RID: 7089 RVA: 0x00003C87 File Offset: 0x00001E87
	public virtual void Draw()
	{
	}

	// Token: 0x06001BB2 RID: 7090 RVA: 0x0008E1B8 File Offset: 0x0008C3B8
	~TouchBaseControl()
	{
		Singleton<TouchController>.Instance.RemoveControl(this);
	}
}
