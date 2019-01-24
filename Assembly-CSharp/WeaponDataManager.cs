using System;
using UberStrike.Core.Models.Views;
using UnityEngine;

// Token: 0x02000455 RID: 1109
public static class WeaponDataManager
{
	// Token: 0x06001FAD RID: 8109 RVA: 0x00097F80 File Offset: 0x00096180
	public static Vector3 ApplyDispersion(Vector3 shootingRay, UberStrikeItemWeaponView view, bool ironSight)
	{
		float num = WeaponConfigurationHelper.GetAccuracySpread(view);
		if (WeaponFeedbackManager.Instance && WeaponFeedbackManager.Instance.IsIronSighted && ironSight)
		{
			num *= 0.5f;
		}
		Vector2 vector = UnityEngine.Random.insideUnitCircle * num * 0.5f;
		return Quaternion.AngleAxis(vector.x, GameState.Current.Player.WeaponCamera.transform.right) * Quaternion.AngleAxis(vector.y, GameState.Current.Player.WeaponCamera.transform.up) * shootingRay;
	}
}
