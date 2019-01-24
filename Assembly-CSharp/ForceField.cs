using System;
using UnityEngine;

// Token: 0x02000281 RID: 641
[RequireComponent(typeof(BoxCollider))]
public class ForceField : MonoBehaviour
{
	// Token: 0x060011CB RID: 4555 RVA: 0x0000C5B1 File Offset: 0x0000A7B1
	private void Awake()
	{
		base.collider.isTrigger = true;
		base.gameObject.layer = 2;
	}

	// Token: 0x060011CC RID: 4556 RVA: 0x0006A008 File Offset: 0x00068208
	private void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player")
		{
			GameState.Current.Player.MoveController.ApplyForce(this._direction.normalized * (float)this._force, CharacterMoveController.ForceType.Exclusive);
			AutoMonoBehaviour<SfxManager>.Instance.PlayInGameAudioClip(GameAudio.JumpPad2D, 0UL);
		}
		else if (collider.gameObject.layer == 20)
		{
			AutoMonoBehaviour<SfxManager>.Instance.Play3dAudioClip(GameAudio.JumpPad, base.transform.position, 1f);
		}
	}

	// Token: 0x060011CD RID: 4557 RVA: 0x0006A0A0 File Offset: 0x000682A0
	private void OnDrawGizmos()
	{
		Gizmos.DrawSphere(base.transform.localPosition, 0.2f);
		Vector3 normalized = this._direction.normalized;
		normalized.y *= 0.6f;
		Gizmos.DrawLine(base.transform.localPosition, base.transform.localPosition + normalized * Mathf.Log((float)this._force) * (float)this._force * this.gizmofactor);
	}

	// Token: 0x04000ECD RID: 3789
	[SerializeField]
	private Vector3 _direction;

	// Token: 0x04000ECE RID: 3790
	[SerializeField]
	private int _force = 1000;

	// Token: 0x04000ECF RID: 3791
	private float gizmofactor = 0.0055f;
}
