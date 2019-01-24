using System;
using UnityEngine;

// Token: 0x0200001C RID: 28
[AddComponentMenu("NGUI/Interaction/Checkbox Controlled Object")]
public class UICheckboxControlledObject : MonoBehaviour
{
	// Token: 0x0600008A RID: 138 RVA: 0x0001792C File Offset: 0x00015B2C
	private void OnEnable()
	{
		UICheckbox component = base.GetComponent<UICheckbox>();
		if (component != null)
		{
			this.OnActivate(component.isChecked);
		}
	}

	// Token: 0x0600008B RID: 139 RVA: 0x00017958 File Offset: 0x00015B58
	private void OnActivate(bool isActive)
	{
		if (this.target != null)
		{
			NGUITools.SetActive(this.target, (!this.inverse) ? isActive : (!isActive));
			UIPanel uipanel = NGUITools.FindInParents<UIPanel>(this.target);
			if (uipanel != null)
			{
				uipanel.Refresh();
			}
		}
	}

	// Token: 0x040000AB RID: 171
	public GameObject target;

	// Token: 0x040000AC RID: 172
	public bool inverse;
}
