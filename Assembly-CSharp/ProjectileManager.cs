using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000250 RID: 592
public class ProjectileManager : Singleton<ProjectileManager>
{
	// Token: 0x06001052 RID: 4178 RVA: 0x0000B5B9 File Offset: 0x000097B9
	private ProjectileManager()
	{
		this._projectiles = new Dictionary<int, IProjectile>();
		this._limitedProjectiles = new List<int>();
	}

	// Token: 0x170003F1 RID: 1009
	// (get) Token: 0x06001053 RID: 4179 RVA: 0x0000B5D7 File Offset: 0x000097D7
	public IEnumerable<KeyValuePair<int, IProjectile>> AllProjectiles
	{
		get
		{
			return this._projectiles;
		}
	}

	// Token: 0x170003F2 RID: 1010
	// (get) Token: 0x06001054 RID: 4180 RVA: 0x0000B5DF File Offset: 0x000097DF
	public IEnumerable<int> LimitedProjectiles
	{
		get
		{
			return this._limitedProjectiles;
		}
	}

	// Token: 0x170003F3 RID: 1011
	// (get) Token: 0x06001055 RID: 4181 RVA: 0x0000B5E7 File Offset: 0x000097E7
	public static GameObject Container
	{
		get
		{
			if (ProjectileManager.container == null)
			{
				ProjectileManager.container = new GameObject("Projectiles");
			}
			return ProjectileManager.container;
		}
	}

	// Token: 0x06001056 RID: 4182 RVA: 0x0000B60D File Offset: 0x0000980D
	public void AddProjectile(IProjectile p, int id)
	{
		if (p != null)
		{
			p.ID = id;
			this._projectiles[p.ID] = p;
		}
	}

	// Token: 0x06001057 RID: 4183 RVA: 0x0000B62E File Offset: 0x0000982E
	public void AddLimitedProjectile(IProjectile p, int id, int count)
	{
		if (p != null)
		{
			p.ID = id;
			this._projectiles[p.ID] = p;
			this._limitedProjectiles.Add(p.ID);
			this.CheckLimitedProjectiles(count);
		}
	}

	// Token: 0x06001058 RID: 4184 RVA: 0x00065D84 File Offset: 0x00063F84
	private void CheckLimitedProjectiles(int count)
	{
		int[] array = this._limitedProjectiles.ToArray();
		for (int i = 0; i < this._limitedProjectiles.Count - count; i++)
		{
			this.RemoveProjectile(array[i], true);
			GameState.Current.Actions.RemoveProjectile(array[i], true);
		}
	}

	// Token: 0x06001059 RID: 4185 RVA: 0x00065DE0 File Offset: 0x00063FE0
	public void RemoveAllLimitedProjectiles(bool explode = true)
	{
		int[] array = this._limitedProjectiles.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			this.RemoveProjectile(array[i], explode);
			GameState.Current.Actions.RemoveProjectile(array[i], explode);
		}
	}

	// Token: 0x0600105A RID: 4186 RVA: 0x00065E30 File Offset: 0x00064030
	public void RemoveProjectile(int id, bool explode = true)
	{
		try
		{
			IProjectile projectile;
			if (this._projectiles.TryGetValue(id, out projectile))
			{
				if (explode)
				{
					projectile.Explode();
				}
				else
				{
					projectile.Destroy();
				}
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		finally
		{
			this._limitedProjectiles.RemoveAll((int i) => i == id);
			this._projectiles.Remove(id);
		}
	}

	// Token: 0x0600105B RID: 4187 RVA: 0x00065ED4 File Offset: 0x000640D4
	public void RemoveAllProjectilesFromPlayer(byte playerNumber)
	{
		foreach (int num in this._projectiles.KeyArray<int, IProjectile>())
		{
			if ((num & 255) == (int)playerNumber)
			{
				this.RemoveProjectile(num, false);
			}
		}
	}

	// Token: 0x0600105C RID: 4188 RVA: 0x00065F1C File Offset: 0x0006411C
	public void Clear()
	{
		try
		{
			foreach (KeyValuePair<int, IProjectile> keyValuePair in this._projectiles)
			{
				if (keyValuePair.Value != null)
				{
					keyValuePair.Value.Destroy();
				}
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		finally
		{
			this._projectiles.Clear();
			this._limitedProjectiles.Clear();
			UnityEngine.Object.Destroy(ProjectileManager.container);
			ProjectileManager.container = null;
		}
	}

	// Token: 0x0600105D RID: 4189 RVA: 0x0000B667 File Offset: 0x00009867
	public static int CreateGlobalProjectileID(byte playerNumber, int localProjectileId)
	{
		return (localProjectileId << 8) + (int)playerNumber;
	}

	// Token: 0x0600105E RID: 4190 RVA: 0x0000B66E File Offset: 0x0000986E
	public static string PrintID(int id)
	{
		return ProjectileManager.GetPlayerId(id) + "/" + (id >> 8);
	}

	// Token: 0x0600105F RID: 4191 RVA: 0x0000B68D File Offset: 0x0000988D
	private static int GetPlayerId(int projectileId)
	{
		return projectileId & 255;
	}

	// Token: 0x04000DFA RID: 3578
	private Dictionary<int, IProjectile> _projectiles;

	// Token: 0x04000DFB RID: 3579
	private List<int> _limitedProjectiles;

	// Token: 0x04000DFC RID: 3580
	private static GameObject container;
}
