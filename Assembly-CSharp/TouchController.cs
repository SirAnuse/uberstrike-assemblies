using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020003B3 RID: 947
public class TouchController : Singleton<TouchController>
{
	// Token: 0x06001BC5 RID: 7109 RVA: 0x0008E3F0 File Offset: 0x0008C5F0
	private TouchController()
	{
		this._controls = new List<TouchBaseControl>();
		AutoMonoBehaviour<UnityRuntime>.Instance.OnUpdate += this.OnUpdate;
		AutoMonoBehaviour<UnityRuntime>.Instance.OnGui += this.OnGui;
	}

	// Token: 0x06001BC6 RID: 7110 RVA: 0x0008E448 File Offset: 0x0008C648
	private void OnUpdate()
	{
		foreach (TouchBaseControl touchBaseControl in this._controls)
		{
			if (touchBaseControl.Enabled)
			{
				touchBaseControl.FirstUpdate();
				foreach (Touch touch in Input.touches)
				{
					touchBaseControl.UpdateTouches(touch);
				}
				touchBaseControl.FinalUpdate();
			}
		}
	}

	// Token: 0x06001BC7 RID: 7111 RVA: 0x0008E4EC File Offset: 0x0008C6EC
	private void OnGui()
	{
		foreach (TouchBaseControl touchBaseControl in this._controls)
		{
			if (touchBaseControl.Enabled)
			{
				touchBaseControl.Draw();
			}
		}
	}

	// Token: 0x06001BC8 RID: 7112 RVA: 0x00012666 File Offset: 0x00010866
	public void AddControl(TouchBaseControl control)
	{
		this._controls.Add(control);
	}

	// Token: 0x06001BC9 RID: 7113 RVA: 0x00012674 File Offset: 0x00010874
	public void RemoveControl(TouchBaseControl control)
	{
		this._controls.Remove(control);
	}

	// Token: 0x040018C3 RID: 6339
	public float GUIAlpha = 1f;

	// Token: 0x040018C4 RID: 6340
	private List<TouchBaseControl> _controls;
}
