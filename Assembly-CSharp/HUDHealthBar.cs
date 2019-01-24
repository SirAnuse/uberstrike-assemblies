using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000327 RID: 807
public class HUDHealthBar : MonoBehaviour
{
	// Token: 0x06001684 RID: 5764 RVA: 0x0007D05C File Offset: 0x0007B25C
	private void Start()
	{
		this.baseWidth = this.bgr.transform.localScale.x;
		this.baseScale = this.text.transform.localScale.x;
		this.normalBarColor = this.bar.color;
		GameState.Current.PlayerData.Health.AddEventAndFire(new Action<int, int>(this.OnHealthPoints), this);
	}

	// Token: 0x06001685 RID: 5765 RVA: 0x0000F28F File Offset: 0x0000D48F
	private void OnEnable()
	{
		GameState.Current.PlayerData.Health.Fire();
	}

	// Token: 0x06001686 RID: 5766 RVA: 0x0007D0D8 File Offset: 0x0007B2D8
	public void OnHealthPoints(int value, int oldValue)
	{
		if (GameData.Instance.GameState != GameStateId.None && oldValue > 0 && oldValue <= 100 && value > 100)
		{
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(SoundEffects.Instance.Health_100_200_Increase.Interpolate((float)value, 100f, 200f));
		}
		base.StopAllCoroutines();
		if (value != oldValue)
		{
			base.StartCoroutine(this.PulseCrt(value >= oldValue));
		}
		base.StartCoroutine(this.AnimateCrt(value));
	}

	// Token: 0x06001687 RID: 5767 RVA: 0x0007D164 File Offset: 0x0007B364
	private IEnumerator AnimateCrt(int value)
	{
		this.panel.alpha = 1f;
		while ((float)value != this.oldValue)
		{
			this.oldValue = Mathf.MoveTowards(this.oldValue, (float)value, Time.deltaTime * this.animateSpeed);
			this.bgr.transform.localScale = this.bgr.transform.localScale.SetX(Mathf.Max(this.NORMAL_MAX, this.oldValue) / this.NORMAL_MAX * this.baseWidth);
			this.bar.transform.localScale = this.bgr.transform.localScale.SetX(this.oldValue / this.NORMAL_MAX * this.baseWidth);
			this.bar.color = ((this.oldValue <= this.CRITICAL_VALUE) ? new Color(1f, 0.235294119f, 0.1882353f) : this.normalBarColor);
			this.text.text = Mathf.FloorToInt(this.oldValue).ToString();
			if (this.oldValue == 0f || this.oldValue > this.CRITICAL_VALUE)
			{
				AutoMonoBehaviour<SfxManager>.Instance.StopLoopedAudioClip();
			}
			yield return 0;
		}
		if (this.oldValue > this.CRITICAL_VALUE || this.oldValue <= 0f)
		{
			yield break;
		}
		AutoMonoBehaviour<SfxManager>.Instance.PlayLoopedAudioClip(SoundEffects.Instance.HealthNoise_0_25.Interpolate(this.oldValue, 0f, this.CRITICAL_VALUE));
		for (;;)
		{
			float time = Time.time * this.criticalBlinkingSpeed;
			this.panel.alpha = Mathf.Clamp01(Mathf.Sin(time) + 1f);
			if (time % 6.28318548f >= 3.14159274f && this.criticalHealthLastTime != (int)(time / 6.28318548f))
			{
				this.criticalHealthLastTime = (int)(time / 6.28318548f);
				AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(SoundEffects.Instance.HealthHeartbeat_0_25.Interpolate(this.oldValue, 0f, this.CRITICAL_VALUE));
			}
			yield return 0;
		}
	}

	// Token: 0x06001688 RID: 5768 RVA: 0x0007D190 File Offset: 0x0007B390
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

	// Token: 0x0400155F RID: 5471
	[SerializeField]
	private UIPanel panel;

	// Token: 0x04001560 RID: 5472
	[SerializeField]
	private UISprite bar;

	// Token: 0x04001561 RID: 5473
	[SerializeField]
	private UISprite bgr;

	// Token: 0x04001562 RID: 5474
	[SerializeField]
	private UISprite icon;

	// Token: 0x04001563 RID: 5475
	[SerializeField]
	private UILabel text;

	// Token: 0x04001564 RID: 5476
	[SerializeField]
	private float animateSpeed = 200f;

	// Token: 0x04001565 RID: 5477
	[SerializeField]
	private float criticalBlinkingSpeed = 6.5f;

	// Token: 0x04001566 RID: 5478
	[SerializeField]
	private float PulseSpeed = 20f;

	// Token: 0x04001567 RID: 5479
	[SerializeField]
	private float PulseScale = 7f;

	// Token: 0x04001568 RID: 5480
	private float oldValue = -1f;

	// Token: 0x04001569 RID: 5481
	private float baseWidth;

	// Token: 0x0400156A RID: 5482
	private float baseScale;

	// Token: 0x0400156B RID: 5483
	private Color normalBarColor;

	// Token: 0x0400156C RID: 5484
	private int criticalHealthLastTime;

	// Token: 0x0400156D RID: 5485
	private readonly float CRITICAL_VALUE = 25f;

	// Token: 0x0400156E RID: 5486
	private readonly float NORMAL_MAX = 100f;
}
