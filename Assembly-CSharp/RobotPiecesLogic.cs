using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000271 RID: 625
internal class RobotPiecesLogic : MonoBehaviour
{
	// Token: 0x0600116B RID: 4459 RVA: 0x000691EC File Offset: 0x000673EC
	public void ExplodeRobot(GameObject robotObject, int lifeTimeMilliSeconds)
	{
		if (this._robotPieces != null)
		{
			foreach (Rigidbody rigidbody in this._robotPieces.GetComponentsInChildren<Rigidbody>())
			{
				rigidbody.AddExplosionForce(5f, base.transform.position, 2f, 0f, ForceMode.Impulse);
			}
		}
		if (this._robotScrapsDestructionAudios != null && this._robotScrapsDestructionAudios.Length > 0)
		{
			AudioClip audioClip = this._robotScrapsDestructionAudios[UnityEngine.Random.Range(0, this._robotScrapsDestructionAudios.Length)];
			if (audioClip)
			{
				base.audio.clip = audioClip;
				base.audio.Play();
			}
		}
		base.StartCoroutine(this.DestroyRobotPieces(robotObject, lifeTimeMilliSeconds));
	}

	// Token: 0x0600116C RID: 4460 RVA: 0x000692B0 File Offset: 0x000674B0
	public void PlayRobotScrapsDestructionAudio()
	{
		if (this._robotScrapsDestructionAudios != null && this._robotScrapsDestructionAudios.Length > 0)
		{
			AudioClip audioClip = this._robotScrapsDestructionAudios[UnityEngine.Random.Range(0, this._robotScrapsDestructionAudios.Length)];
			if (audioClip)
			{
				base.audio.clip = audioClip;
				base.audio.Play();
			}
		}
	}

	// Token: 0x0600116D RID: 4461 RVA: 0x00069310 File Offset: 0x00067510
	private IEnumerator DestroyRobotPieces(GameObject robotObject, int lifeTimeMilliSeconds)
	{
		yield return new WaitForSeconds((float)(lifeTimeMilliSeconds / 1000));
		this.PlayRobotScrapsDestructionAudio();
		yield return new WaitForSeconds(base.audio.clip.length);
		UnityEngine.Object.Destroy(robotObject);
		yield break;
	}

	// Token: 0x04000E84 RID: 3716
	[SerializeField]
	private AudioClip[] _robotScrapsDestructionAudios;

	// Token: 0x04000E85 RID: 3717
	[SerializeField]
	private GameObject _robotPieces;
}
