using System;
using System.Collections;
using System.Text;
using UnityEngine;

// Token: 0x02000283 RID: 643
[RequireComponent(typeof(Collider))]
public class LevelBoundary : MonoBehaviour
{
	// Token: 0x060011D1 RID: 4561 RVA: 0x0000C5CB File Offset: 0x0000A7CB
	private void Awake()
	{
		if (base.renderer)
		{
			base.renderer.enabled = false;
		}
		base.StartCoroutine(this.StartCheckingPlayerInBounds(base.collider));
		base.collider.isTrigger = true;
	}

	// Token: 0x060011D2 RID: 4562 RVA: 0x0000C608 File Offset: 0x0000A808
	private void OnDisable()
	{
		LevelBoundary._checkTime = 0f;
		LevelBoundary._currentLevelBoundary = null;
	}

	// Token: 0x060011D3 RID: 4563 RVA: 0x0006A12C File Offset: 0x0006832C
	private void OnTriggerExit(Collider c)
	{
		if (c.tag == "Player" && GameState.Current.HasJoinedGame)
		{
			if (LevelBoundary._currentLevelBoundary == this)
			{
				LevelBoundary._currentLevelBoundary = null;
			}
			base.StartCoroutine(this.StartCheckingPlayer());
		}
	}

	// Token: 0x060011D4 RID: 4564 RVA: 0x0006A180 File Offset: 0x00068380
	private IEnumerator StartCheckingPlayer()
	{
		if (LevelBoundary._checkTime == 0f)
		{
			LevelBoundary._checkTime = Time.time + 0.5f;
			while (LevelBoundary._checkTime > Time.time)
			{
				yield return new WaitForEndOfFrame();
			}
			if (LevelBoundary._currentLevelBoundary == null)
			{
				GameState.Current.Actions.KillPlayer();
			}
			LevelBoundary._checkTime = 0f;
		}
		else
		{
			LevelBoundary._checkTime = Time.time + 1f;
		}
		yield break;
	}

	// Token: 0x060011D5 RID: 4565 RVA: 0x0006A194 File Offset: 0x00068394
	private IEnumerator StartCheckingPlayerInBounds(Collider c)
	{
		for (;;)
		{
			if (!c.bounds.Contains(GameState.Current.PlayerData.Position))
			{
				GameState.Current.Actions.KillPlayer();
			}
			yield return new WaitForSeconds(1f);
		}
		yield break;
	}

	// Token: 0x060011D6 RID: 4566 RVA: 0x0000C61A File Offset: 0x0000A81A
	private void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Player" && GameState.Current.HasJoinedGame)
		{
			LevelBoundary._currentLevelBoundary = this;
		}
	}

	// Token: 0x060011D7 RID: 4567 RVA: 0x0006A1B8 File Offset: 0x000683B8
	private string PrintHierarchy(Transform t)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(t.name);
		Transform parent = t.parent;
		while (parent)
		{
			stringBuilder.Insert(0, parent.name + "/");
			parent = parent.parent;
		}
		return stringBuilder.ToString();
	}

	// Token: 0x060011D8 RID: 4568 RVA: 0x0000C646 File Offset: 0x0000A846
	private string PrintVector(Vector3 v)
	{
		return string.Format("({0:N6},{1:N6},{2:N6})", v.x, v.y, v.z);
	}

	// Token: 0x04000ED0 RID: 3792
	private static float _checkTime;

	// Token: 0x04000ED1 RID: 3793
	private static LevelBoundary _currentLevelBoundary;
}
