using System;
using UnityEngine;

// Token: 0x02000422 RID: 1058
public class CrossbowWeaponDecorator : BaseWeaponDecorator
{
	// Token: 0x06001E39 RID: 7737 RVA: 0x0001412C File Offset: 0x0001232C
	protected override void ShowImpactEffects(RaycastHit hit, Vector3 direction, Vector3 muzzlePosition, float distance, bool playSound)
	{
		this.CreateArrow(hit, direction);
		base.ShowImpactEffects(hit, direction, muzzlePosition, distance, playSound);
	}

	// Token: 0x06001E3A RID: 7738 RVA: 0x00094BC4 File Offset: 0x00092DC4
	private void CreateArrow(RaycastHit hit, Vector3 direction)
	{
		if (this._arrowProjectile && hit.collider != null)
		{
			Quaternion rotation = default(Quaternion);
			rotation = Quaternion.FromToRotation(Vector3.back, direction * -1f);
			ArrowProjectile arrowProjectile = UnityEngine.Object.Instantiate(this._arrowProjectile, hit.point, rotation) as ArrowProjectile;
			if (hit.collider.gameObject.layer == 18)
			{
				if (GameState.Current.Avatar.Decorator)
				{
					arrowProjectile.gameObject.transform.parent = GameState.Current.Avatar.Decorator.GetBone(BoneIndex.Hips);
					foreach (Renderer renderer in arrowProjectile.GetComponentsInChildren<Renderer>(true))
					{
						renderer.enabled = false;
					}
				}
			}
			else if (hit.collider.gameObject.layer == 20)
			{
				arrowProjectile.SetParent(hit.collider.transform);
			}
			arrowProjectile.Destroy(15);
		}
	}

	// Token: 0x04001A2D RID: 6701
	[SerializeField]
	private ArrowProjectile _arrowProjectile;
}
