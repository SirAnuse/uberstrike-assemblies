using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200026F RID: 623
public class QuickItemSfx : MonoBehaviour
{
	// Token: 0x1700043A RID: 1082
	// (get) Token: 0x06001158 RID: 4440 RVA: 0x0000C033 File Offset: 0x0000A233
	// (set) Token: 0x06001159 RID: 4441 RVA: 0x0000C03B File Offset: 0x0000A23B
	public int ID { get; set; }

	// Token: 0x1700043B RID: 1083
	// (get) Token: 0x0600115A RID: 4442 RVA: 0x0000C044 File Offset: 0x0000A244
	// (set) Token: 0x0600115B RID: 4443 RVA: 0x00069058 File Offset: 0x00067258
	public bool IsShortAudio
	{
		get
		{
			return this._isShortAudio;
		}
		set
		{
			this._isShortAudio = value;
			AudioSource componentInChildren = base.GetComponentInChildren<AudioSource>();
			if (componentInChildren != null)
			{
				componentInChildren.clip = ((!this._isShortAudio) ? this._normalLoopAudio : this._shortLoopAudio);
			}
		}
	}

	// Token: 0x1700043C RID: 1084
	// (get) Token: 0x0600115C RID: 4444 RVA: 0x0000C04C File Offset: 0x0000A24C
	// (set) Token: 0x0600115D RID: 4445 RVA: 0x0000C054 File Offset: 0x0000A254
	public Transform Parent { get; set; }

	// Token: 0x1700043D RID: 1085
	// (get) Token: 0x0600115E RID: 4446 RVA: 0x0000C05D File Offset: 0x0000A25D
	// (set) Token: 0x0600115F RID: 4447 RVA: 0x0000C065 File Offset: 0x0000A265
	public Vector3 Offset { get; set; }

	// Token: 0x06001160 RID: 4448 RVA: 0x000690A4 File Offset: 0x000672A4
	public void Play(int robotLifeTime, int scrapsLifeTime, bool isInstant)
	{
		this.IsShortAudio = isInstant;
		AudioSource componentInChildren = base.GetComponentInChildren<AudioSource>();
		if (componentInChildren != null)
		{
			componentInChildren.Play();
		}
		base.StartCoroutine(this.StopEffectAfterSeconds(robotLifeTime, scrapsLifeTime));
	}

	// Token: 0x06001161 RID: 4449 RVA: 0x000690E0 File Offset: 0x000672E0
	public void Explode(int scrapsLifeTime)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(this._robotPiecesPrefab, this._robotTransform.position, Quaternion.identity) as GameObject;
		if (gameObject != null)
		{
			RobotPiecesLogic componentInChildren = gameObject.GetComponentInChildren<RobotPiecesLogic>();
			componentInChildren.ExplodeRobot(gameObject, scrapsLifeTime);
		}
		this.Destroy();
	}

	// Token: 0x06001162 RID: 4450 RVA: 0x0000C06E File Offset: 0x0000A26E
	public void Destroy()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	// Token: 0x06001163 RID: 4451 RVA: 0x00069130 File Offset: 0x00067330
	private IEnumerator StopEffectAfterSeconds(int robotLifeTime, int scrapsLifeTime)
	{
		yield return new WaitForSeconds((float)(robotLifeTime / 1000));
		Singleton<QuickItemSfxController>.Instance.RemoveEffect(this.ID);
		this.Explode(scrapsLifeTime);
		yield break;
	}

	// Token: 0x04000E75 RID: 3701
	[SerializeField]
	private GameObject _robotPiecesPrefab;

	// Token: 0x04000E76 RID: 3702
	[SerializeField]
	private AudioClip _shortLoopAudio;

	// Token: 0x04000E77 RID: 3703
	[SerializeField]
	private AudioClip _normalLoopAudio;

	// Token: 0x04000E78 RID: 3704
	[SerializeField]
	private Transform _robotTransform;

	// Token: 0x04000E79 RID: 3705
	private bool _isShortAudio;
}
