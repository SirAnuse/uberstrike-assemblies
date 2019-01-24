using System;
using System.Collections;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x02000224 RID: 548
public class PlayerDropCoinPickupItem : PickupItem
{
	// Token: 0x06000F2B RID: 3883 RVA: 0x00064158 File Offset: 0x00062358
	private IEnumerator Start()
	{
		this._timeout = Time.time + this.Timeout;
		Vector3 oldpos = base.transform.position;
		Vector3 newpos = oldpos;
		RaycastHit hit;
		if (Physics.Raycast(oldpos + Vector3.up, Vector3.down, out hit, 100f, UberstrikeLayerMasks.ProtectionMask) && oldpos.y > hit.point.y + 1f)
		{
			newpos = hit.point + Vector3.up;
		}
		this._timeout = Time.time + this.Timeout;
		float time = 0f;
		while (this._timeout > Time.time)
		{
			yield return new WaitForEndOfFrame();
			time += Time.deltaTime;
			base.transform.position = Vector3.Lerp(oldpos, newpos, time);
		}
		base.SetItemAvailable(false);
		base.enabled = false;
		yield return new WaitForSeconds(2f);
		UnityEngine.Object.Destroy(base.gameObject);
		yield break;
	}

	// Token: 0x06000F2C RID: 3884 RVA: 0x0000AE2E File Offset: 0x0000902E
	private void Update()
	{
		if (this._pickupItem)
		{
			this._pickupItem.Rotate(Vector3.up, 150f * Time.deltaTime, Space.Self);
		}
	}

	// Token: 0x06000F2D RID: 3885 RVA: 0x00064174 File Offset: 0x00062374
	protected override bool OnPlayerPickup()
	{
		GameState.Current.Actions.PickupPowerup(base.PickupID, PickupItemType.Coin, 1);
		GameData.Instance.OnItemPickup.Fire("Point", PickUpMessageType.Coin);
		base.PlayLocalPickupSound(GameAudio.GetPoints);
		base.StartCoroutine(base.StartHidingPickupForSeconds(0));
		return true;
	}

	// Token: 0x06000F2E RID: 3886 RVA: 0x0000AE5C File Offset: 0x0000905C
	protected override void OnRemotePickup()
	{
		base.PlayRemotePickupSound(GameAudio.GetPoints, base.transform.position);
	}

	// Token: 0x04000D6F RID: 3439
	public float Timeout = 10f;

	// Token: 0x04000D70 RID: 3440
	private float _timeout;
}
