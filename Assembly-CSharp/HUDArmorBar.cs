using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000323 RID: 803
public class HUDArmorBar : MonoBehaviour
{
	// Token: 0x0600166B RID: 5739 RVA: 0x0007C8E8 File Offset: 0x0007AAE8
	private void Start()
	{
		this.baseWidth = this.bgr.transform.localScale.x;
		this.baseScale = this.text.transform.localScale.x;
		GameState.Current.PlayerData.ArmorPoints.AddEventAndFire(new Action<int>(this.OnArmorPoints), this);
	}

	// Token: 0x0600166C RID: 5740 RVA: 0x0000F1D8 File Offset: 0x0000D3D8
	public void OnArmorPoints(int value)
	{
		base.StopAllCoroutines();
		if ((float)value != this.oldValue)
		{
			base.StartCoroutine(this.PulseCrt((float)value >= this.oldValue));
		}
	}

	// Token: 0x0600166D RID: 5741 RVA: 0x0007C954 File Offset: 0x0007AB54
	private void Update()
	{
		int value = GameState.Current.PlayerData.ArmorPoints.Value;
		if ((float)value != this.oldValue)
		{
			this.oldValue = Mathf.MoveTowards(this.oldValue, (float)value, Time.deltaTime * this.animateSpeed);
			this.bgr.transform.localScale = this.bgr.transform.localScale.SetX(Mathf.Max(this.NORMAL_MAX, this.oldValue) / this.NORMAL_MAX * this.baseWidth);
			this.bar.transform.localScale = this.bgr.transform.localScale.SetX(this.oldValue / this.NORMAL_MAX * this.baseWidth);
			this.text.text = Mathf.FloorToInt(this.oldValue).ToString();
		}
	}

	// Token: 0x0600166E RID: 5742 RVA: 0x0007CA40 File Offset: 0x0007AC40
	private IEnumerator PulseCrt(bool up)
	{
		float time = 0f;
		for (;;)
		{
			time = Mathf.Min(time + Time.deltaTime * this.PulseSpeed, 3.14159274f);
			float pulse = Mathf.Sin(time) * this.PulseScale;
			this.text.transform.localScale = (Vector3.one * (this.baseScale + pulse * (float)((!up) ? -1 : 1))).SetZ(1f);
			if (time >= 3.14159274f)
			{
				break;
			}
			yield return 0;
		}
		yield break;
		yield break;
	}

	// Token: 0x04001545 RID: 5445
	[SerializeField]
	private UISprite bar;

	// Token: 0x04001546 RID: 5446
	[SerializeField]
	private UISprite bgr;

	// Token: 0x04001547 RID: 5447
	[SerializeField]
	private UISprite icon;

	// Token: 0x04001548 RID: 5448
	[SerializeField]
	private UILabel text;

	// Token: 0x04001549 RID: 5449
	[SerializeField]
	private float animateSpeed = 200f;

	// Token: 0x0400154A RID: 5450
	[SerializeField]
	private float PulseSpeed = 20f;

	// Token: 0x0400154B RID: 5451
	[SerializeField]
	private float PulseScale = 7f;

	// Token: 0x0400154C RID: 5452
	private float oldValue = -1f;

	// Token: 0x0400154D RID: 5453
	private float baseWidth;

	// Token: 0x0400154E RID: 5454
	private float baseScale;

	// Token: 0x0400154F RID: 5455
	private readonly float NORMAL_MAX = 100f;
}
