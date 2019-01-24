using System;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x0200024D RID: 589
public abstract class QuickItem : BaseUnityItem
{
	// Token: 0x170003E7 RID: 999
	// (get) Token: 0x0600103F RID: 4159 RVA: 0x0000B56C File Offset: 0x0000976C
	public QuickItemLogic Logic
	{
		get
		{
			return this._logic;
		}
	}

	// Token: 0x170003E8 RID: 1000
	// (get) Token: 0x06001040 RID: 4160 RVA: 0x0000B574 File Offset: 0x00009774
	public QuickItemSfx Sfx
	{
		get
		{
			return this._sfx;
		}
	}

	// Token: 0x170003E9 RID: 1001
	// (get) Token: 0x06001041 RID: 4161
	// (set) Token: 0x06001042 RID: 4162
	public abstract QuickItemConfiguration Configuration { get; set; }

	// Token: 0x170003EA RID: 1002
	// (get) Token: 0x06001043 RID: 4163 RVA: 0x0000B57C File Offset: 0x0000977C
	// (set) Token: 0x06001044 RID: 4164 RVA: 0x0000B584 File Offset: 0x00009784
	public QuickItemBehaviour Behaviour { get; set; }

	// Token: 0x06001045 RID: 4165
	protected abstract void OnActivated();

	// Token: 0x06001046 RID: 4166 RVA: 0x0000B58D File Offset: 0x0000978D
	private void Awake()
	{
		this.Behaviour = new QuickItemBehaviour(this, new Action(this.OnActivated));
	}

	// Token: 0x04000DF6 RID: 3574
	[SerializeField]
	private QuickItemLogic _logic;

	// Token: 0x04000DF7 RID: 3575
	[SerializeField]
	private QuickItemSfx _sfx;
}
