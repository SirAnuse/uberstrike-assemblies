using System;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x0200028D RID: 653
public class SpawnPoint : MonoBehaviour
{
	// Token: 0x1700045B RID: 1115
	// (get) Token: 0x06001203 RID: 4611 RVA: 0x0006A788 File Offset: 0x00068988
	public GameModeType GameModeType
	{
		get
		{
			GameMode gameMode = this.GameMode;
			if (gameMode == GameMode.TeamDeathMatch)
			{
				return GameModeType.TeamDeathMatch;
			}
			if (gameMode == GameMode.DeathMatch)
			{
				return GameModeType.DeathMatch;
			}
			if (gameMode != GameMode.TeamElimination)
			{
				return GameModeType.None;
			}
			return GameModeType.EliminationMode;
		}
	}

	// Token: 0x1700045C RID: 1116
	// (get) Token: 0x06001204 RID: 4612 RVA: 0x0000C772 File Offset: 0x0000A972
	public Vector3 Position
	{
		get
		{
			return base.transform.position;
		}
	}

	// Token: 0x1700045D RID: 1117
	// (get) Token: 0x06001205 RID: 4613 RVA: 0x0006A7C0 File Offset: 0x000689C0
	public Vector2 Rotation
	{
		get
		{
			return new Vector2(base.transform.rotation.eulerAngles.y, base.transform.rotation.eulerAngles.x);
		}
	}

	// Token: 0x1700045E RID: 1118
	// (get) Token: 0x06001206 RID: 4614 RVA: 0x0000C77F File Offset: 0x0000A97F
	public TeamID TeamId
	{
		get
		{
			return this.TeamPoint;
		}
	}

	// Token: 0x1700045F RID: 1119
	// (get) Token: 0x06001207 RID: 4615 RVA: 0x0000C787 File Offset: 0x0000A987
	public float SpawnRadius
	{
		get
		{
			return this.Radius;
		}
	}

	// Token: 0x06001208 RID: 4616 RVA: 0x0006A808 File Offset: 0x00068A08
	private void OnDrawGizmos()
	{
		if (!this.DrawGizmos)
		{
			return;
		}
		switch (this.TeamPoint)
		{
		case TeamID.NONE:
			Gizmos.color = Color.green;
			break;
		case TeamID.BLUE:
			Gizmos.color = Color.blue;
			break;
		case TeamID.RED:
			Gizmos.color = Color.red;
			break;
		}
		Gizmos.matrix = Matrix4x4.TRS(base.transform.position, Quaternion.identity, new Vector3(1f, 0.1f, 1f));
		Gizmos.DrawSphere(Vector3.zero, this.Radius);
		GameModeType gameModeType = this.GameModeType;
		if (gameModeType != GameModeType.DeathMatch)
		{
			if (gameModeType == GameModeType.TeamDeathMatch)
			{
				Gizmos.color = Color.white;
			}
		}
		else
		{
			Gizmos.color = Color.yellow;
		}
		Gizmos.matrix = Matrix4x4.identity;
		Gizmos.DrawLine(base.transform.position + base.transform.forward * this.Radius, base.transform.position + base.transform.forward * 2f * this.Radius);
	}

	// Token: 0x04000EED RID: 3821
	[SerializeField]
	private bool DrawGizmos = true;

	// Token: 0x04000EEE RID: 3822
	[SerializeField]
	private float Radius = 1f;

	// Token: 0x04000EEF RID: 3823
	[SerializeField]
	public TeamID TeamPoint;

	// Token: 0x04000EF0 RID: 3824
	[SerializeField]
	public GameMode GameMode;
}
