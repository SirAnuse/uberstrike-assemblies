using System;
using UnityEngine;

// Token: 0x0200035F RID: 863
[Serializable]
public class AvatarBone
{
	// Token: 0x1700057F RID: 1407
	// (get) Token: 0x06001801 RID: 6145 RVA: 0x00010248 File Offset: 0x0000E448
	// (set) Token: 0x06001802 RID: 6146 RVA: 0x00010250 File Offset: 0x0000E450
	public Vector3 OriginalPosition { get; set; }

	// Token: 0x17000580 RID: 1408
	// (get) Token: 0x06001803 RID: 6147 RVA: 0x00010259 File Offset: 0x0000E459
	// (set) Token: 0x06001804 RID: 6148 RVA: 0x00010261 File Offset: 0x0000E461
	public Quaternion OriginalRotation { get; set; }

	// Token: 0x17000581 RID: 1409
	// (get) Token: 0x06001805 RID: 6149 RVA: 0x0001026A File Offset: 0x0000E46A
	// (set) Token: 0x06001806 RID: 6150 RVA: 0x00010272 File Offset: 0x0000E472
	public Collider Collider { get; set; }

	// Token: 0x17000582 RID: 1410
	// (get) Token: 0x06001807 RID: 6151 RVA: 0x0001027B File Offset: 0x0000E47B
	// (set) Token: 0x06001808 RID: 6152 RVA: 0x00010283 File Offset: 0x0000E483
	public Rigidbody Rigidbody { get; set; }

	// Token: 0x040016C7 RID: 5831
	public BoneIndex Bone;

	// Token: 0x040016C8 RID: 5832
	public Transform Transform;
}
