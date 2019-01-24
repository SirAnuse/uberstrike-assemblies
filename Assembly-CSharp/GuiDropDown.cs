using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020003D2 RID: 978
public class GuiDropDown
{
	// Token: 0x17000657 RID: 1623
	// (get) Token: 0x06001C97 RID: 7319 RVA: 0x0001309A File Offset: 0x0001129A
	// (set) Token: 0x06001C98 RID: 7320 RVA: 0x000130A2 File Offset: 0x000112A2
	public GUIContent Caption { get; set; }

	// Token: 0x06001C99 RID: 7321 RVA: 0x0009062C File Offset: 0x0008E82C
	public void Add(GUIContent content, Action onClick)
	{
		this._data.Add(new GuiDropDown.Button(content)
		{
			Action = onClick
		});
	}

	// Token: 0x06001C9A RID: 7322 RVA: 0x00090654 File Offset: 0x0008E854
	public void Add(GUIContent onContent, GUIContent offContent, Func<bool> isOn, Action onClick)
	{
		this._data.Add(new GuiDropDown.Button(onContent, offContent, isOn)
		{
			Action = onClick
		});
	}

	// Token: 0x06001C9B RID: 7323 RVA: 0x000130AB File Offset: 0x000112AB
	public void SetRect(Rect rect)
	{
		this._rect = GUITools.ToGlobal(rect);
	}

	// Token: 0x06001C9C RID: 7324 RVA: 0x00090680 File Offset: 0x0008E880
	public void Draw()
	{
		bool isDown = this._isDown;
		this._isDown = GUI.Toggle(this._rect, this._isDown, this.Caption, BlueStonez.buttondark_medium);
		if (isDown != this._isDown)
		{
			MouseOrbit.Disable = false;
		}
		if (this._isDown)
		{
			MouseOrbit.Disable = true;
			Rect position;
			if (this.ShowRightAligned)
			{
				position = new Rect(this._rect.xMax - this.ButtonWidth, this._rect.yMax, this.ButtonWidth, this.ButtonHeight * (float)this._data.Count);
			}
			else
			{
				position = new Rect(this._rect.x, this._rect.yMax, this.ButtonWidth, this.ButtonHeight * (float)this._data.Count);
			}
			if (!position.Contains(Event.current.mousePosition) && !this._rect.Contains(Event.current.mousePosition) && (Event.current.type == EventType.MouseUp || Event.current.type == EventType.Used))
			{
				this._isDown = false;
				MouseOrbit.Disable = false;
			}
			GUI.BeginGroup(position);
			for (int i = 0; i < this._data.Count; i++)
			{
				if (this._data[i].IsEnabled())
				{
					GUIStyle style = BlueStonez.dropdown;
					if (ApplicationDataManager.IsMobile)
					{
						style = BlueStonez.dropdown_large;
					}
					if (GUI.Button(new Rect(0f, (float)i * this.ButtonHeight, this.ButtonWidth, this.ButtonHeight), this._data[i].Content, style))
					{
						this._isDown = false;
						MouseOrbit.Disable = false;
						this._data[i].Action();
					}
				}
			}
			GUI.EndGroup();
		}
	}

	// Token: 0x0400196D RID: 6509
	private List<GuiDropDown.Button> _data = new List<GuiDropDown.Button>();

	// Token: 0x0400196E RID: 6510
	private bool _isDown;

	// Token: 0x0400196F RID: 6511
	private Rect _rect;

	// Token: 0x04001970 RID: 6512
	public bool ShowRightAligned = true;

	// Token: 0x04001971 RID: 6513
	public float ButtonWidth = 100f;

	// Token: 0x04001972 RID: 6514
	public float ButtonHeight = 20f;

	// Token: 0x020003D3 RID: 979
	private class Button
	{
		// Token: 0x06001C9D RID: 7325 RVA: 0x000130B9 File Offset: 0x000112B9
		public Button(GUIContent onContent) : this(onContent, onContent, () => true)
		{
		}

		// Token: 0x06001C9E RID: 7326 RVA: 0x00090870 File Offset: 0x0008EA70
		public Button(GUIContent onContent, GUIContent offContent, Func<bool> isOn)
		{
			this.onContent = onContent;
			this.offContent = offContent;
			this.isOn = isOn;
			this.IsEnabled = (() => true);
			this.Action = delegate()
			{
			};
		}

		// Token: 0x17000658 RID: 1624
		// (get) Token: 0x06001C9F RID: 7327 RVA: 0x000130E0 File Offset: 0x000112E0
		public GUIContent Content
		{
			get
			{
				return (this.isOn != null && !this.isOn()) ? this.offContent : this.onContent;
			}
		}

		// Token: 0x04001974 RID: 6516
		private GUIContent onContent;

		// Token: 0x04001975 RID: 6517
		private GUIContent offContent;

		// Token: 0x04001976 RID: 6518
		private Func<bool> isOn;

		// Token: 0x04001977 RID: 6519
		public Action Action;

		// Token: 0x04001978 RID: 6520
		public Func<bool> IsEnabled;
	}
}
