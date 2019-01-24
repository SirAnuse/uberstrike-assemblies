using System;
using UnityEngine;

// Token: 0x02000289 RID: 649
public class SecretBehaviour : MonoBehaviour
{
	// Token: 0x060011F2 RID: 4594 RVA: 0x0006A48C File Offset: 0x0006868C
	private void Awake()
	{
		foreach (SecretBehaviour.Door door in this._doors)
		{
			foreach (SecretTrigger secretTrigger in door.Trigger)
			{
				secretTrigger.SetSecretReciever(this);
			}
		}
	}

	// Token: 0x060011F3 RID: 4595 RVA: 0x0006A4E8 File Offset: 0x000686E8
	public void SetTriggerActivated(SecretTrigger trigger)
	{
		foreach (SecretBehaviour.Door door in this._doors)
		{
			door.CheckAllTriggers();
		}
	}

	// Token: 0x04000EDE RID: 3806
	[SerializeField]
	private SecretBehaviour.Door[] _doors;

	// Token: 0x0200028A RID: 650
	[Serializable]
	public class Door
	{
		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x060011F5 RID: 4597 RVA: 0x0000C70E File Offset: 0x0000A90E
		public SecretTrigger[] Trigger
		{
			get
			{
				return this._trigger;
			}
		}

		// Token: 0x060011F6 RID: 4598 RVA: 0x0006A51C File Offset: 0x0006871C
		public void CheckAllTriggers()
		{
			bool flag = true;
			foreach (SecretTrigger secretTrigger in this._trigger)
			{
				flag &= (secretTrigger.ActivationTimeOut > Time.time);
			}
			if (flag)
			{
				this._door.Open();
			}
		}

		// Token: 0x04000EDF RID: 3807
		public string _description;

		// Token: 0x04000EE0 RID: 3808
		[SerializeField]
		private SecretDoor _door;

		// Token: 0x04000EE1 RID: 3809
		[SerializeField]
		private SecretTrigger[] _trigger;
	}
}
