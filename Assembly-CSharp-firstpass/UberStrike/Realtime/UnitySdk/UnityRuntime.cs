using System;
using UnityEngine;

namespace UberStrike.Realtime.UnitySdk
{
	// Token: 0x0200034F RID: 847
	internal class UnityRuntime : MonoBehaviour
	{
		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06001411 RID: 5137 RVA: 0x0000C42D File Offset: 0x0000A62D
		// (remove) Token: 0x06001412 RID: 5138 RVA: 0x0000C446 File Offset: 0x0000A646
		public event Action OnFixedUpdate
		{
			add
			{
				this.onFixedUpdate = (Action)Delegate.Combine(this.onFixedUpdate, value);
			}
			remove
			{
				this.onFixedUpdate = (Action)Delegate.Remove(this.onFixedUpdate, value);
			}
		}

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06001413 RID: 5139 RVA: 0x0000C45F File Offset: 0x0000A65F
		// (remove) Token: 0x06001414 RID: 5140 RVA: 0x0000C478 File Offset: 0x0000A678
		public event Action OnUpdate
		{
			add
			{
				this.onUpdate = (Action)Delegate.Combine(this.onUpdate, value);
			}
			remove
			{
				this.onUpdate = (Action)Delegate.Remove(this.onUpdate, value);
			}
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06001415 RID: 5141 RVA: 0x0000C491 File Offset: 0x0000A691
		// (remove) Token: 0x06001416 RID: 5142 RVA: 0x0000C4AA File Offset: 0x0000A6AA
		public event Action OnShutdown
		{
			add
			{
				this.onShutdown = (Action)Delegate.Combine(this.onShutdown, value);
			}
			remove
			{
				this.onShutdown = (Action)Delegate.Remove(this.onShutdown, value);
			}
		}

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x06001417 RID: 5143 RVA: 0x00024360 File Offset: 0x00022560
		public static UnityRuntime Instance
		{
			get
			{
				if (UnityRuntime.instance == null)
				{
					GameObject gameObject = GameObject.Find("AutoMonoBehaviours");
					if (gameObject == null)
					{
						gameObject = new GameObject("AutoMonoBehaviours");
					}
					UnityRuntime.instance = gameObject.AddComponent<UnityRuntime>();
				}
				return UnityRuntime.instance;
			}
		}

		// Token: 0x06001418 RID: 5144 RVA: 0x000243B0 File Offset: 0x000225B0
		private void OnGUI()
		{
			if (this.showInvocationList)
			{
				GUILayout.BeginArea(new Rect(10f, 100f, 400f, (float)(Screen.height - 200)));
				if (this.onUpdate != null)
				{
					foreach (Delegate @delegate in this.onUpdate.GetInvocationList())
					{
						GUILayout.Label("Update: " + @delegate.Method.DeclaringType.Name + "." + @delegate.Method.Name, new GUILayoutOption[0]);
					}
				}
				if (this.onFixedUpdate != null)
				{
					foreach (Delegate delegate2 in this.onFixedUpdate.GetInvocationList())
					{
						GUILayout.Label("FixedUpdate: " + delegate2.Method.DeclaringType.Name + "." + delegate2.Method.Name, new GUILayoutOption[0]);
					}
				}
				if (this.onShutdown != null)
				{
					foreach (Delegate delegate3 in this.onShutdown.GetInvocationList())
					{
						GUILayout.Label("OnApplicationQuit: " + delegate3.Method.DeclaringType.Name + "." + delegate3.Method.Name, new GUILayoutOption[0]);
					}
				}
				GUILayout.EndArea();
			}
		}

		// Token: 0x06001419 RID: 5145 RVA: 0x0000C4C3 File Offset: 0x0000A6C3
		private void Update()
		{
			if (this.onUpdate != null)
			{
				this.onUpdate();
			}
		}

		// Token: 0x0600141A RID: 5146 RVA: 0x0000C4DB File Offset: 0x0000A6DB
		private void FixedUpdate()
		{
			if (this.onFixedUpdate != null)
			{
				this.onFixedUpdate();
			}
		}

		// Token: 0x0600141B RID: 5147 RVA: 0x0000C4F3 File Offset: 0x0000A6F3
		private void OnApplicationQuit()
		{
			if (this.onShutdown != null)
			{
				this.onShutdown();
			}
		}

		// Token: 0x04000E2F RID: 3631
		[SerializeField]
		private bool showInvocationList;

		// Token: 0x04000E30 RID: 3632
		private static UnityRuntime instance;

		// Token: 0x04000E31 RID: 3633
		private Action onFixedUpdate;

		// Token: 0x04000E32 RID: 3634
		private Action onUpdate;

		// Token: 0x04000E33 RID: 3635
		private Action onShutdown;
	}
}
