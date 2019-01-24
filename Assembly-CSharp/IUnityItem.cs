using System;
using UberStrike.Core.Models.Views;
using UnityEngine;

// Token: 0x0200024F RID: 591
public interface IUnityItem
{
	// Token: 0x170003EC RID: 1004
	// (get) Token: 0x0600104A RID: 4170
	string Name { get; }

	// Token: 0x170003ED RID: 1005
	// (get) Token: 0x0600104B RID: 4171
	bool Equippable { get; }

	// Token: 0x170003EE RID: 1006
	// (get) Token: 0x0600104C RID: 4172
	BaseUberStrikeItemView View { get; }

	// Token: 0x170003EF RID: 1007
	// (get) Token: 0x0600104D RID: 4173
	bool IsLoaded { get; }

	// Token: 0x170003F0 RID: 1008
	// (get) Token: 0x0600104E RID: 4174
	GameObject Prefab { get; }

	// Token: 0x0600104F RID: 4175
	GameObject Create(Vector3 position, Quaternion rotation);

	// Token: 0x06001050 RID: 4176
	void Unload();

	// Token: 0x06001051 RID: 4177
	void DrawIcon(Rect position);
}
