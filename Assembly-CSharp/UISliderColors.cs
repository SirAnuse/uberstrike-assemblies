using System;
using UnityEngine;

// Token: 0x02000038 RID: 56
[RequireComponent(typeof(UISlider))]
[AddComponentMenu("NGUI/Examples/Slider Colors")]
[ExecuteInEditMode]
public class UISliderColors : MonoBehaviour
{
	// Token: 0x06000139 RID: 313 RVA: 0x000030A6 File Offset: 0x000012A6
	private void Start()
	{
		this.mSlider = base.GetComponent<UISlider>();
		this.Update();
	}

	// Token: 0x0600013A RID: 314 RVA: 0x0001BD5C File Offset: 0x00019F5C
	private void Update()
	{
		if (this.sprite == null || this.colors.Length == 0)
		{
			return;
		}
		float num = this.mSlider.sliderValue;
		num *= (float)(this.colors.Length - 1);
		int num2 = Mathf.FloorToInt(num);
		Color color = this.colors[0];
		if (num2 >= 0)
		{
			if (num2 + 1 < this.colors.Length)
			{
				float t = num - (float)num2;
				color = Color.Lerp(this.colors[num2], this.colors[num2 + 1], t);
			}
			else if (num2 < this.colors.Length)
			{
				color = this.colors[num2];
			}
			else
			{
				color = this.colors[this.colors.Length - 1];
			}
		}
		color.a = this.sprite.color.a;
		this.sprite.color = color;
	}

	// Token: 0x0400015E RID: 350
	public UISprite sprite;

	// Token: 0x0400015F RID: 351
	public Color[] colors = new Color[]
	{
		Color.red,
		Color.yellow,
		Color.green
	};

	// Token: 0x04000160 RID: 352
	private UISlider mSlider;
}
