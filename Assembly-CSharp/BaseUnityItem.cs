using System;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000244 RID: 580
public abstract class BaseUnityItem : MonoBehaviour
{
	// Token: 0x170003CB RID: 971
	// (get) Token: 0x06001005 RID: 4101 RVA: 0x0000B40A File Offset: 0x0000960A
	// (set) Token: 0x06001006 RID: 4102 RVA: 0x0000B412 File Offset: 0x00009612
	public UberstrikeItemClass TestItemClass
	{
		get
		{
			return this._testItemClass;
		}
		set
		{
			this._testItemClass = value;
		}
	}

	// Token: 0x04000DE8 RID: 3560
	[SerializeField]
	private UberstrikeItemClass _testItemClass;
}
