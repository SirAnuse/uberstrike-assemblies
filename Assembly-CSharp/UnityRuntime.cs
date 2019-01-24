using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200041B RID: 1051
public class UnityRuntime : AutoMonoBehaviour<UnityRuntime>
{
	// Token: 0x14000027 RID: 39
	// (add) Token: 0x06001DB2 RID: 7602 RVA: 0x00013A9A File Offset: 0x00011C9A
	// (remove) Token: 0x06001DB3 RID: 7603 RVA: 0x00013AB3 File Offset: 0x00011CB3
	public event Action OnGui;

	// Token: 0x14000028 RID: 40
	// (add) Token: 0x06001DB4 RID: 7604 RVA: 0x00013ACC File Offset: 0x00011CCC
	// (remove) Token: 0x06001DB5 RID: 7605 RVA: 0x00013AE5 File Offset: 0x00011CE5
	public event Action OnUpdate;

	// Token: 0x14000029 RID: 41
	// (add) Token: 0x06001DB6 RID: 7606 RVA: 0x00013AFE File Offset: 0x00011CFE
	// (remove) Token: 0x06001DB7 RID: 7607 RVA: 0x00013B17 File Offset: 0x00011D17
	public event Action OnLateUpdate;

	// Token: 0x1400002A RID: 42
	// (add) Token: 0x06001DB8 RID: 7608 RVA: 0x00013B30 File Offset: 0x00011D30
	// (remove) Token: 0x06001DB9 RID: 7609 RVA: 0x00013B49 File Offset: 0x00011D49
	public event Action OnFixedUpdate;

	// Token: 0x1400002B RID: 43
	// (add) Token: 0x06001DBA RID: 7610 RVA: 0x00013B62 File Offset: 0x00011D62
	// (remove) Token: 0x06001DBB RID: 7611 RVA: 0x00013B7B File Offset: 0x00011D7B
	public event Action OnDrawGizmo;

	// Token: 0x1400002C RID: 44
	// (add) Token: 0x06001DBC RID: 7612 RVA: 0x00013B94 File Offset: 0x00011D94
	// (remove) Token: 0x06001DBD RID: 7613 RVA: 0x00013BAD File Offset: 0x00011DAD
	public event Action<bool> OnAppFocus;

	// Token: 0x06001DBE RID: 7614 RVA: 0x00013BC6 File Offset: 0x00011DC6
	private void FixedUpdate()
	{
		if (this.OnFixedUpdate != null)
		{
			this.OnFixedUpdate();
		}
	}

	// Token: 0x06001DBF RID: 7615 RVA: 0x00013BDE File Offset: 0x00011DDE
	private void Update()
	{
		if (this.OnUpdate != null)
		{
			this.OnUpdate();
		}
	}

	// Token: 0x06001DC0 RID: 7616 RVA: 0x00013BF6 File Offset: 0x00011DF6
	private void LateUpdate()
	{
		if (this.OnLateUpdate != null)
		{
			this.OnLateUpdate();
		}
	}

	// Token: 0x06001DC1 RID: 7617 RVA: 0x00093680 File Offset: 0x00091880
	private void OnGUI()
	{
		if (this.OnGui != null)
		{
			this.OnGui();
		}
		if (this.showInvocationList)
		{
			GUILayout.BeginArea(new Rect(10f, 100f, 400f, (float)(Screen.height - 200)));
			if (this.OnUpdate != null)
			{
				foreach (Delegate @delegate in this.OnUpdate.GetInvocationList())
				{
					GUILayout.Label("Update: " + @delegate.Method.DeclaringType.Name + "." + @delegate.Method.Name, new GUILayoutOption[0]);
				}
			}
			if (this.OnFixedUpdate != null)
			{
				foreach (Delegate delegate2 in this.OnFixedUpdate.GetInvocationList())
				{
					GUILayout.Label("FixedUpdate: " + delegate2.Method.DeclaringType.Name + "." + delegate2.Method.Name, new GUILayoutOption[0]);
				}
			}
			if (this.OnAppFocus != null)
			{
				foreach (Delegate delegate3 in this.OnAppFocus.GetInvocationList())
				{
					GUILayout.Label("OnApplicationFocus: " + delegate3.Method.DeclaringType.Name + "." + delegate3.Method.Name, new GUILayoutOption[0]);
				}
			}
			GUILayout.EndArea();
		}
	}

	// Token: 0x06001DC2 RID: 7618 RVA: 0x00013C0E File Offset: 0x00011E0E
	private void OnApplicationFocus(bool focus)
	{
		if (this.OnAppFocus != null)
		{
			this.OnAppFocus(focus);
		}
	}

	// Token: 0x06001DC3 RID: 7619 RVA: 0x00013C27 File Offset: 0x00011E27
	public static Coroutine StartRoutine(IEnumerator routine)
	{
		if (AutoMonoBehaviour<UnityRuntime>.IsRunning)
		{
			return AutoMonoBehaviour<UnityRuntime>.Instance.StartCoroutine(routine);
		}
		return null;
	}

	// Token: 0x040019F5 RID: 6645
	[SerializeField]
	private bool showInvocationList;
}
