using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200032C RID: 812
public class HUDNotificationWarning : MonoBehaviour
{
	// Token: 0x060016A4 RID: 5796 RVA: 0x0000F3AC File Offset: 0x0000D5AC
	private void Start()
	{
		GameData.Instance.OnWarningNotification.AddEvent(delegate(string el)
		{
			this.Show(el);
		}, this);
		this.panel.alpha = 0f;
	}

	// Token: 0x060016A5 RID: 5797 RVA: 0x0000F3DA File Offset: 0x0000D5DA
	private void OnEnable()
	{
		this.panel.alpha = 0f;
	}

	// Token: 0x060016A6 RID: 5798 RVA: 0x0000F3EC File Offset: 0x0000D5EC
	public void Show(string text)
	{
		base.StopAllCoroutines();
		base.StartCoroutine(this.ShowCrt(text, this.defaultFadeInSpeed, this.defaultFadeOutSpeed, 1f));
	}

	// Token: 0x060016A7 RID: 5799 RVA: 0x0007DBD4 File Offset: 0x0007BDD4
	public IEnumerator ShowCrt(string text, float fadeInSpeed, float fadeOutSpeed, float duration)
	{
		this.panel.alpha = 0f;
		this.label.text = text;
		while (this.panel.alpha < 1f)
		{
			this.panel.alpha = Mathf.MoveTowards(this.panel.alpha, 1f, Time.deltaTime * fadeInSpeed);
			yield return 0;
		}
		if (duration > 0f)
		{
			yield return new WaitForSeconds(duration);
		}
		while (this.panel.alpha > 0f)
		{
			this.panel.alpha = Mathf.MoveTowards(this.panel.alpha, 0f, Time.deltaTime * fadeOutSpeed);
			yield return 0;
		}
		yield break;
	}

	// Token: 0x04001591 RID: 5521
	[SerializeField]
	private UIPanel panel;

	// Token: 0x04001592 RID: 5522
	[SerializeField]
	private UILabel label;

	// Token: 0x04001593 RID: 5523
	[SerializeField]
	private float defaultFadeInSpeed = 20f;

	// Token: 0x04001594 RID: 5524
	[SerializeField]
	private float defaultFadeOutSpeed = 5f;
}
