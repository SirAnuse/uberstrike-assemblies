using System;
using UnityEngine;

// Token: 0x02000429 RID: 1065
public class BulletImpactTrail : BaseWeaponEffect
{
	// Token: 0x06001E62 RID: 7778 RVA: 0x00014232 File Offset: 0x00012432
	private void Awake()
	{
		this._trailRenderer = base.GetComponent<MoveTrailrendererObject>();
	}

	// Token: 0x06001E63 RID: 7779 RVA: 0x00095180 File Offset: 0x00093380
	public override void OnHits(RaycastHit[] hits)
	{
		if (this._trailRenderer)
		{
			foreach (RaycastHit raycastHit in hits)
			{
				MoveTrailrendererObject moveTrailrendererObject = UnityEngine.Object.Instantiate(this._trailRenderer, this._muzzle.position, Quaternion.identity) as MoveTrailrendererObject;
				if (moveTrailrendererObject)
				{
					moveTrailrendererObject.MoveTrail(raycastHit.point, this._muzzle.position, raycastHit.distance);
				}
			}
		}
	}

	// Token: 0x06001E64 RID: 7780 RVA: 0x00014240 File Offset: 0x00012440
	public override void OnShoot()
	{
		if (this._trailRenderer)
		{
		}
	}

	// Token: 0x06001E65 RID: 7781 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnPostShoot()
	{
	}

	// Token: 0x06001E66 RID: 7782 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void Hide()
	{
	}

	// Token: 0x04001A4C RID: 6732
	[SerializeField]
	private Transform _muzzle;

	// Token: 0x04001A4D RID: 6733
	[SerializeField]
	private MoveTrailrendererObject _trailRenderer;
}
