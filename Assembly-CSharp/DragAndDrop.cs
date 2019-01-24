using System;
using System.Collections;
using Cmune.DataCenter.Common.Entities;
using UnityEngine;

// Token: 0x02000159 RID: 345
public class DragAndDrop : Singleton<DragAndDrop>
{
	// Token: 0x06000929 RID: 2345 RVA: 0x00007B91 File Offset: 0x00005D91
	private DragAndDrop()
	{
		AutoMonoBehaviour<UnityRuntime>.Instance.OnGui += this.OnGui;
	}

	// Token: 0x14000001 RID: 1
	// (add) Token: 0x0600092B RID: 2347 RVA: 0x00007BD6 File Offset: 0x00005DD6
	// (remove) Token: 0x0600092C RID: 2348 RVA: 0x00007BEF File Offset: 0x00005DEF
	public event Action<IDragSlot> OnDragBegin;

	// Token: 0x17000291 RID: 657
	// (get) Token: 0x0600092D RID: 2349 RVA: 0x00007C08 File Offset: 0x00005E08
	// (set) Token: 0x0600092E RID: 2350 RVA: 0x00007C10 File Offset: 0x00005E10
	public int CurrentId { get; private set; }

	// Token: 0x17000292 RID: 658
	// (get) Token: 0x0600092F RID: 2351 RVA: 0x00007C19 File Offset: 0x00005E19
	public bool IsDragging
	{
		get
		{
			return this.CurrentId > 0 && this.DraggedItem != null && this.DraggedItem.Item != null;
		}
	}

	// Token: 0x17000293 RID: 659
	// (get) Token: 0x06000930 RID: 2352 RVA: 0x00007C46 File Offset: 0x00005E46
	// (set) Token: 0x06000931 RID: 2353 RVA: 0x00007C4E File Offset: 0x00005E4E
	public IDragSlot DraggedItem { get; private set; }

	// Token: 0x06000932 RID: 2354 RVA: 0x0003A59C File Offset: 0x0003879C
	private void OnGui()
	{
		if (this._releaseDragItem)
		{
			this._releaseDragItem = false;
			this.CurrentId = 0;
			this.DraggedItem = null;
		}
		if (Event.current.type == EventType.MouseUp)
		{
			this._releaseDragItem = true;
		}
		if (this.IsDragging)
		{
			if (this._dragBegin)
			{
				this._dragBegin = false;
				if (this.OnDragBegin != null)
				{
					this.OnDragBegin(this.DraggedItem);
				}
				UnityRuntime.StartRoutine(this.StartDragZoom(0f, 1f, 1.25f, 0.1f, 0.8f));
			}
			else
			{
				if (!this._isZooming)
				{
					this._dragScalePivot = GUIUtility.ScreenToGUIPoint(Event.current.mousePosition);
				}
				GUIUtility.ScaleAroundPivot(new Vector2(this._zoomMultiplier, this._zoomMultiplier), this._dragScalePivot);
				GUI.backgroundColor = new Color(1f, 1f, 1f, this._alphaValue);
				GUI.matrix = Matrix4x4.identity;
				this.DraggedItem.Item.DrawIcon(new Rect(this._dragScalePivot.x - 24f, this._dragScalePivot.y - 24f, 48f, 48f));
			}
		}
	}

	// Token: 0x06000933 RID: 2355 RVA: 0x0003A6EC File Offset: 0x000388EC
	private IEnumerator StartDragZoom(float time, float startZoom, float endZoom, float startAlpha, float endAlpha)
	{
		this._isZooming = true;
		Vector2 startPivot = new Vector2(this._draggedControlRect.xMin + 32f, this._draggedControlRect.yMin + 32f);
		float timer = 0f;
		while (timer < time)
		{
			this._alphaValue = Mathf.Lerp(startAlpha, endAlpha, timer / time);
			this._zoomMultiplier = Mathfx.Berp(startZoom, endZoom, timer / time);
			this._dragScalePivot = Vector2.Lerp(startPivot, Event.current.mousePosition, timer / time);
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		this._dragScalePivot = Event.current.mousePosition;
		this._alphaValue = endAlpha;
		this._zoomMultiplier = endZoom;
		this._isZooming = false;
		yield break;
	}

	// Token: 0x06000934 RID: 2356 RVA: 0x0003A754 File Offset: 0x00038954
	public void DrawSlot<T>(Rect rect, T item, Action<int, T> onDropAction = null, Color? color = null, bool isItemList = false) where T : IDragSlot
	{
		int controlID = GUIUtility.GetControlID(DragAndDrop._itemSlotButtonHash, FocusType.Native);
		if ((ApplicationDataManager.Channel == ChannelType.Android || ApplicationDataManager.Channel == ChannelType.IPad || ApplicationDataManager.Channel == ChannelType.IPhone) && Event.current.GetTypeForControl(controlID) == EventType.MouseDown && isItemList)
		{
			rect.width = 50f;
		}
		switch (Event.current.GetTypeForControl(controlID))
		{
		case EventType.MouseDown:
			if (Event.current.type != EventType.Used && rect.Contains(Event.current.mousePosition))
			{
				GUIUtility.hotControl = controlID;
				Event.current.Use();
			}
			break;
		case EventType.MouseUp:
			this.MouseUp<T>(rect, controlID, item.Id, onDropAction);
			break;
		case EventType.MouseDrag:
			if (GUIUtility.hotControl == controlID)
			{
				Vector2 vector = GUIUtility.GUIToScreenPoint(new Vector2(rect.x, rect.y));
				this._draggedControlRect = new Rect(vector.x, vector.y, rect.width, rect.height);
				this._dragBegin = true;
				this.DraggedItem = item;
				this.CurrentId = GUIUtility.hotControl;
				GUIUtility.hotControl = 0;
				Event.current.Use();
			}
			break;
		case EventType.Repaint:
			if (color != null)
			{
				GUI.color = color.Value;
				BlueStonez.loadoutdropslot_highlight.Draw(rect, GUIContent.none, controlID);
				GUI.color = Color.white;
			}
			break;
		}
	}

	// Token: 0x06000935 RID: 2357 RVA: 0x0003A8F8 File Offset: 0x00038AF8
	public void DrawSlot<T>(Rect rect, Action<int, T> onDropAction) where T : IDragSlot
	{
		int controlID = GUIUtility.GetControlID(DragAndDrop._itemSlotButtonHash, FocusType.Native);
		if (Event.current.GetTypeForControl(controlID) == EventType.MouseUp)
		{
			this.MouseUp<T>(rect, controlID, 0, onDropAction);
		}
	}

	// Token: 0x06000936 RID: 2358 RVA: 0x0003A92C File Offset: 0x00038B2C
	private void MouseUp<T>(Rect rect, int id, int slotId, Action<int, T> onDropAction) where T : IDragSlot
	{
		if (GUIUtility.hotControl == id)
		{
			GUIUtility.hotControl = 0;
			Event.current.Use();
		}
		else if (onDropAction != null && this.DraggedItem != null && rect.Contains(Event.current.mousePosition))
		{
			onDropAction(slotId, (T)((object)this.DraggedItem));
		}
	}

	// Token: 0x04000960 RID: 2400
	private static int _itemSlotButtonHash = "Button".GetHashCode();

	// Token: 0x04000961 RID: 2401
	private float _zoomMultiplier = 1f;

	// Token: 0x04000962 RID: 2402
	private float _alphaValue = 1f;

	// Token: 0x04000963 RID: 2403
	private bool _isZooming;

	// Token: 0x04000964 RID: 2404
	private bool _dragBegin;

	// Token: 0x04000965 RID: 2405
	private Rect _draggedControlRect;

	// Token: 0x04000966 RID: 2406
	private Vector2 _dragScalePivot;

	// Token: 0x04000967 RID: 2407
	private bool _releaseDragItem;
}
