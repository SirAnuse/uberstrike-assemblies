using System;
using UnityEngine;

// Token: 0x020001DD RID: 477
public abstract class BaseEventPopup : IPopupDialog
{
	// Token: 0x1700033F RID: 831
	// (get) Token: 0x06000D6C RID: 3436 RVA: 0x00009F3C File Offset: 0x0000813C
	// (set) Token: 0x06000D6D RID: 3437 RVA: 0x00009F44 File Offset: 0x00008144
	public string Text { get; set; }

	// Token: 0x17000340 RID: 832
	// (get) Token: 0x06000D6E RID: 3438 RVA: 0x00009F4D File Offset: 0x0000814D
	// (set) Token: 0x06000D6F RID: 3439 RVA: 0x00009F55 File Offset: 0x00008155
	public string Title { get; set; }

	// Token: 0x17000341 RID: 833
	// (get) Token: 0x06000D70 RID: 3440 RVA: 0x00008F9A File Offset: 0x0000719A
	public GuiDepth Depth
	{
		get
		{
			return GuiDepth.Event;
		}
	}

	// Token: 0x17000342 RID: 834
	// (get) Token: 0x06000D71 RID: 3441 RVA: 0x00009F5E File Offset: 0x0000815E
	public float Scale
	{
		get
		{
			if (this._startTime > Time.time - 1f)
			{
				return Mathfx.Berp(0.01f, 1f, (Time.time - this._startTime) * 2.5f);
			}
			return 1f;
		}
	}

	// Token: 0x06000D72 RID: 3442
	protected abstract void DrawGUI(Rect rect);

	// Token: 0x06000D73 RID: 3443 RVA: 0x00003C87 File Offset: 0x00001E87
	public virtual void OnHide()
	{
	}

	// Token: 0x06000D74 RID: 3444 RVA: 0x0005E170 File Offset: 0x0005C370
	public void OnGUI()
	{
		if (this._startTime == 0f)
		{
			this._startTime = Time.time;
		}
		GUI.color = Color.white.SetAlpha(this.Scale);
		float num = (float)(Screen.width - this.Width) * 0.5f;
		float num2 = (float)GlobalUIRibbon.Instance.Height() + (float)(Screen.height - GlobalUIRibbon.Instance.Height() - this.Height) * 0.5f;
		Rect rect = new Rect(num, num2, (float)this.Width, (float)(64 + this.Height) - 64f * this.Scale);
		GUI.Box(new Rect(num - 1f, num2 - 1f, rect.width + 2f, rect.height + 2f), GUIContent.none, BlueStonez.window);
		GUI.BeginGroup(rect);
		if (GUI.Button(new Rect(rect.width - 20f, 0f, 20f, 20f), "X", BlueStonez.friends_hidden_button))
		{
			this.Close();
		}
		this.DrawGUI(rect);
		GUI.EndGroup();
		GUI.color = Color.white;
		if (this.ClickAnywhereToExit && Event.current.type == EventType.MouseDown && !rect.Contains(Event.current.mousePosition))
		{
			Event.current.Use();
			this.Close();
		}
		this.OnAfterGUI();
	}

	// Token: 0x06000D75 RID: 3445 RVA: 0x00003C87 File Offset: 0x00001E87
	public virtual void OnAfterGUI()
	{
	}

	// Token: 0x06000D76 RID: 3446 RVA: 0x00009F9D File Offset: 0x0000819D
	private void Close()
	{
		PopupSystem.HideMessage(this);
		if (this._onCloseButtonClicked != null)
		{
			this._onCloseButtonClicked();
		}
	}

	// Token: 0x04000CC2 RID: 3266
	private const float BerpSpeed = 2.5f;

	// Token: 0x04000CC3 RID: 3267
	protected int Width = 650;

	// Token: 0x04000CC4 RID: 3268
	protected int Height = 330;

	// Token: 0x04000CC5 RID: 3269
	protected bool ClickAnywhereToExit = true;

	// Token: 0x04000CC6 RID: 3270
	private float _startTime;

	// Token: 0x04000CC7 RID: 3271
	protected Action _onCloseButtonClicked;
}
