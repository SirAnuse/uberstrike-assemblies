using System;
using AnimationOrTween;
using UnityEngine;

// Token: 0x02000019 RID: 25
[AddComponentMenu("NGUI/Interaction/Checkbox")]
public class UICheckbox : MonoBehaviour
{
	// Token: 0x17000007 RID: 7
	// (get) Token: 0x0600007B RID: 123 RVA: 0x00002788 File Offset: 0x00000988
	// (set) Token: 0x0600007C RID: 124 RVA: 0x00002790 File Offset: 0x00000990
	public bool isChecked
	{
		get
		{
			return this.mChecked;
		}
		set
		{
			if (this.radioButtonRoot == null || value || this.optionCanBeNone || !this.mStarted)
			{
				this.Set(value);
			}
		}
	}

	// Token: 0x0600007D RID: 125 RVA: 0x00017634 File Offset: 0x00015834
	private void Awake()
	{
		this.mTrans = base.transform;
		if (this.checkSprite != null)
		{
			this.checkSprite.alpha = ((!this.startsChecked) ? 0f : 1f);
		}
		if (this.option)
		{
			this.option = false;
			if (this.radioButtonRoot == null)
			{
				this.radioButtonRoot = this.mTrans.parent;
			}
		}
	}

	// Token: 0x0600007E RID: 126 RVA: 0x000176B8 File Offset: 0x000158B8
	private void Start()
	{
		if (this.eventReceiver == null)
		{
			this.eventReceiver = base.gameObject;
		}
		this.mChecked = !this.startsChecked;
		this.mStarted = true;
		this.Set(this.startsChecked);
	}

	// Token: 0x0600007F RID: 127 RVA: 0x000027C6 File Offset: 0x000009C6
	private void OnClick()
	{
		if (base.enabled)
		{
			this.isChecked = !this.isChecked;
		}
	}

	// Token: 0x06000080 RID: 128 RVA: 0x00017704 File Offset: 0x00015904
	private void Set(bool state)
	{
		if (!this.mStarted)
		{
			this.mChecked = state;
			this.startsChecked = state;
			if (this.checkSprite != null)
			{
				this.checkSprite.alpha = ((!state) ? 0f : 1f);
			}
		}
		else if (this.mChecked != state)
		{
			if (this.radioButtonRoot != null && state)
			{
				UICheckbox[] componentsInChildren = this.radioButtonRoot.GetComponentsInChildren<UICheckbox>(true);
				int i = 0;
				int num = componentsInChildren.Length;
				while (i < num)
				{
					UICheckbox uicheckbox = componentsInChildren[i];
					if (uicheckbox != this && uicheckbox.radioButtonRoot == this.radioButtonRoot)
					{
						uicheckbox.Set(false);
					}
					i++;
				}
			}
			this.mChecked = state;
			if (this.checkSprite != null)
			{
				if (this.instantTween)
				{
					this.checkSprite.alpha = ((!this.mChecked) ? 0f : 1f);
				}
				else
				{
					TweenAlpha.Begin(this.checkSprite.gameObject, 0.15f, (!this.mChecked) ? 0f : 1f);
				}
			}
			UICheckbox.current = this;
			if (this.onStateChange != null)
			{
				this.onStateChange(this.mChecked);
			}
			if (this.eventReceiver != null && !string.IsNullOrEmpty(this.functionName))
			{
				this.eventReceiver.SendMessage(this.functionName, this.mChecked, SendMessageOptions.DontRequireReceiver);
			}
			UICheckbox.current = null;
			if (this.checkAnimation != null)
			{
				ActiveAnimation.Play(this.checkAnimation, (!state) ? Direction.Reverse : Direction.Forward);
			}
		}
	}

	// Token: 0x0400009A RID: 154
	public static UICheckbox current;

	// Token: 0x0400009B RID: 155
	public UISprite checkSprite;

	// Token: 0x0400009C RID: 156
	public Animation checkAnimation;

	// Token: 0x0400009D RID: 157
	public bool instantTween;

	// Token: 0x0400009E RID: 158
	public bool startsChecked = true;

	// Token: 0x0400009F RID: 159
	public Transform radioButtonRoot;

	// Token: 0x040000A0 RID: 160
	public bool optionCanBeNone;

	// Token: 0x040000A1 RID: 161
	public GameObject eventReceiver;

	// Token: 0x040000A2 RID: 162
	public string functionName = "OnActivate";

	// Token: 0x040000A3 RID: 163
	public UICheckbox.OnStateChange onStateChange;

	// Token: 0x040000A4 RID: 164
	[SerializeField]
	[HideInInspector]
	private bool option;

	// Token: 0x040000A5 RID: 165
	private bool mChecked = true;

	// Token: 0x040000A6 RID: 166
	private bool mStarted;

	// Token: 0x040000A7 RID: 167
	private Transform mTrans;

	// Token: 0x0200001A RID: 26
	// (Invoke) Token: 0x06000082 RID: 130
	public delegate void OnStateChange(bool state);
}
