using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000075 RID: 117
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("NGUI/UI/Camera")]
public class UICamera : MonoBehaviour
{
	// Token: 0x1700006F RID: 111
	// (get) Token: 0x060002E8 RID: 744 RVA: 0x000042EE File Offset: 0x000024EE
	private bool handlesEvents
	{
		get
		{
			return UICamera.eventHandler == this;
		}
	}

	// Token: 0x17000070 RID: 112
	// (get) Token: 0x060002E9 RID: 745 RVA: 0x000042FB File Offset: 0x000024FB
	public Camera cachedCamera
	{
		get
		{
			if (this.mCam == null)
			{
				this.mCam = base.camera;
			}
			return this.mCam;
		}
	}

	// Token: 0x17000071 RID: 113
	// (get) Token: 0x060002EA RID: 746 RVA: 0x00004320 File Offset: 0x00002520
	// (set) Token: 0x060002EB RID: 747 RVA: 0x00023220 File Offset: 0x00021420
	public static GameObject selectedObject
	{
		get
		{
			return UICamera.mSel;
		}
		set
		{
			if (UICamera.mSel != value)
			{
				if (UICamera.mSel != null)
				{
					UICamera uicamera = UICamera.FindCameraForLayer(UICamera.mSel.layer);
					if (uicamera != null)
					{
						UICamera.current = uicamera;
						UICamera.currentCamera = uicamera.mCam;
						UICamera.Notify(UICamera.mSel, "OnSelect", false);
						if (uicamera.useController || uicamera.useKeyboard)
						{
							UICamera.Highlight(UICamera.mSel, false);
						}
						UICamera.current = null;
					}
				}
				UICamera.mSel = value;
				if (UICamera.mSel != null)
				{
					UICamera uicamera2 = UICamera.FindCameraForLayer(UICamera.mSel.layer);
					if (uicamera2 != null)
					{
						UICamera.current = uicamera2;
						UICamera.currentCamera = uicamera2.mCam;
						if (uicamera2.useController || uicamera2.useKeyboard)
						{
							UICamera.Highlight(UICamera.mSel, true);
						}
						UICamera.Notify(UICamera.mSel, "OnSelect", true);
						UICamera.current = null;
					}
				}
			}
		}
	}

	// Token: 0x17000072 RID: 114
	// (get) Token: 0x060002EC RID: 748 RVA: 0x00023338 File Offset: 0x00021538
	public static int touchCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < UICamera.mTouches.Count; i++)
			{
				if (UICamera.mTouches[i].pressed != null)
				{
					num++;
				}
			}
			for (int j = 0; j < UICamera.mMouse.Length; j++)
			{
				if (UICamera.mMouse[j].pressed != null)
				{
					num++;
				}
			}
			if (UICamera.mController.pressed != null)
			{
				num++;
			}
			return num;
		}
	}

	// Token: 0x060002ED RID: 749 RVA: 0x00004327 File Offset: 0x00002527
	private void OnApplicationQuit()
	{
		UICamera.mHighlighted.Clear();
	}

	// Token: 0x17000073 RID: 115
	// (get) Token: 0x060002EE RID: 750 RVA: 0x000233D0 File Offset: 0x000215D0
	public static Camera mainCamera
	{
		get
		{
			UICamera eventHandler = UICamera.eventHandler;
			return (!(eventHandler != null)) ? null : eventHandler.cachedCamera;
		}
	}

	// Token: 0x17000074 RID: 116
	// (get) Token: 0x060002EF RID: 751 RVA: 0x000233FC File Offset: 0x000215FC
	public static UICamera eventHandler
	{
		get
		{
			for (int i = 0; i < UICamera.mList.Count; i++)
			{
				UICamera uicamera = UICamera.mList[i];
				if (!(uicamera == null) && uicamera.enabled && NGUITools.GetActive(uicamera.gameObject))
				{
					return uicamera;
				}
			}
			return null;
		}
	}

	// Token: 0x060002F0 RID: 752 RVA: 0x00004333 File Offset: 0x00002533
	private static int CompareFunc(UICamera a, UICamera b)
	{
		if (a.cachedCamera.depth < b.cachedCamera.depth)
		{
			return 1;
		}
		if (a.cachedCamera.depth > b.cachedCamera.depth)
		{
			return -1;
		}
		return 0;
	}

	// Token: 0x060002F1 RID: 753 RVA: 0x00023460 File Offset: 0x00021660
	public static bool Raycast(Vector3 inPos, ref RaycastHit hit)
	{
		for (int i = 0; i < UICamera.mList.Count; i++)
		{
			UICamera uicamera = UICamera.mList[i];
			if (uicamera.enabled && NGUITools.GetActive(uicamera.gameObject))
			{
				UICamera.currentCamera = uicamera.cachedCamera;
				Vector3 vector = UICamera.currentCamera.ScreenToViewportPoint(inPos);
				if (vector.x >= 0f && vector.x <= 1f && vector.y >= 0f && vector.y <= 1f)
				{
					Ray ray = UICamera.currentCamera.ScreenPointToRay(inPos);
					int layerMask = UICamera.currentCamera.cullingMask & uicamera.eventReceiverMask;
					float distance = (uicamera.rangeDistance <= 0f) ? (UICamera.currentCamera.farClipPlane - UICamera.currentCamera.nearClipPlane) : uicamera.rangeDistance;
					if (uicamera.clipRaycasts)
					{
						RaycastHit[] array = Physics.RaycastAll(ray, distance, layerMask);
						if (array.Length > 1)
						{
							Array.Sort<RaycastHit>(array, (RaycastHit r1, RaycastHit r2) => r1.distance.CompareTo(r2.distance));
							int j = 0;
							int num = array.Length;
							while (j < num)
							{
								if (UICamera.IsVisible(ref array[j]))
								{
									hit = array[j];
									return true;
								}
								j++;
							}
						}
						else if (array.Length == 1 && UICamera.IsVisible(ref array[0]))
						{
							hit = array[0];
							return true;
						}
					}
					else if (Physics.Raycast(ray, out hit, distance, layerMask))
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x060002F2 RID: 754 RVA: 0x00023644 File Offset: 0x00021844
	private static bool IsVisible(ref RaycastHit hit)
	{
		UIPanel uipanel = NGUITools.FindInParents<UIPanel>(hit.collider.gameObject);
		return uipanel == null || uipanel.IsVisible(hit.point);
	}

	// Token: 0x060002F3 RID: 755 RVA: 0x00023684 File Offset: 0x00021884
	public static UICamera FindCameraForLayer(int layer)
	{
		int num = 1 << layer;
		for (int i = 0; i < UICamera.mList.Count; i++)
		{
			UICamera uicamera = UICamera.mList[i];
			Camera cachedCamera = uicamera.cachedCamera;
			if (cachedCamera != null && (cachedCamera.cullingMask & num) != 0)
			{
				return uicamera;
			}
		}
		return null;
	}

	// Token: 0x060002F4 RID: 756 RVA: 0x00004370 File Offset: 0x00002570
	private static int GetDirection(KeyCode up, KeyCode down)
	{
		if (Input.GetKeyDown(up))
		{
			return 1;
		}
		if (Input.GetKeyDown(down))
		{
			return -1;
		}
		return 0;
	}

	// Token: 0x060002F5 RID: 757 RVA: 0x0000438D File Offset: 0x0000258D
	private static int GetDirection(KeyCode up0, KeyCode up1, KeyCode down0, KeyCode down1)
	{
		if (Input.GetKeyDown(up0) || Input.GetKeyDown(up1))
		{
			return 1;
		}
		if (Input.GetKeyDown(down0) || Input.GetKeyDown(down1))
		{
			return -1;
		}
		return 0;
	}

	// Token: 0x060002F6 RID: 758 RVA: 0x000236E4 File Offset: 0x000218E4
	private static int GetDirection(string axis)
	{
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		if (UICamera.mNextEvent < realtimeSinceStartup)
		{
			float axis2 = Input.GetAxis(axis);
			if (axis2 > 0.75f)
			{
				UICamera.mNextEvent = realtimeSinceStartup + 0.25f;
				return 1;
			}
			if (axis2 < -0.75f)
			{
				UICamera.mNextEvent = realtimeSinceStartup + 0.25f;
				return -1;
			}
		}
		return 0;
	}

	// Token: 0x060002F7 RID: 759 RVA: 0x0002373C File Offset: 0x0002193C
	public static bool IsHighlighted(GameObject go)
	{
		int i = UICamera.mHighlighted.Count;
		while (i > 0)
		{
			UICamera.Highlighted highlighted = UICamera.mHighlighted[--i];
			if (highlighted.go == go)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060002F8 RID: 760 RVA: 0x00023784 File Offset: 0x00021984
	private static void Highlight(GameObject go, bool highlighted)
	{
		if (go != null)
		{
			int i = UICamera.mHighlighted.Count;
			while (i > 0)
			{
				UICamera.Highlighted highlighted2 = UICamera.mHighlighted[--i];
				if (highlighted2 == null || highlighted2.go == null)
				{
					UICamera.mHighlighted.RemoveAt(i);
				}
				else if (highlighted2.go == go)
				{
					if (highlighted)
					{
						highlighted2.counter++;
					}
					else if (--highlighted2.counter < 1)
					{
						UICamera.mHighlighted.Remove(highlighted2);
						UICamera.Notify(go, "OnHover", false);
					}
					return;
				}
			}
			if (highlighted)
			{
				UICamera.Highlighted highlighted3 = new UICamera.Highlighted();
				highlighted3.go = go;
				highlighted3.counter = 1;
				UICamera.mHighlighted.Add(highlighted3);
				UICamera.Notify(go, "OnHover", true);
			}
		}
	}

	// Token: 0x060002F9 RID: 761 RVA: 0x00023880 File Offset: 0x00021A80
	public static void Notify(GameObject go, string funcName, object obj)
	{
		if (go != null)
		{
			go.SendMessage(funcName, obj, SendMessageOptions.DontRequireReceiver);
			if (UICamera.genericEventHandler != null && UICamera.genericEventHandler != go)
			{
				UICamera.genericEventHandler.SendMessage(funcName, obj, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	// Token: 0x060002FA RID: 762 RVA: 0x000238D0 File Offset: 0x00021AD0
	public static UICamera.MouseOrTouch GetTouch(int id)
	{
		UICamera.MouseOrTouch mouseOrTouch = null;
		if (!UICamera.mTouches.TryGetValue(id, out mouseOrTouch))
		{
			mouseOrTouch = new UICamera.MouseOrTouch();
			mouseOrTouch.touchBegan = true;
			UICamera.mTouches.Add(id, mouseOrTouch);
		}
		return mouseOrTouch;
	}

	// Token: 0x060002FB RID: 763 RVA: 0x000043C0 File Offset: 0x000025C0
	public static void RemoveTouch(int id)
	{
		UICamera.mTouches.Remove(id);
	}

	// Token: 0x060002FC RID: 764 RVA: 0x0002390C File Offset: 0x00021B0C
	private void Awake()
	{
		this.cachedCamera.eventMask = 0;
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
		{
			this.useMouse = false;
			this.useTouch = true;
			if (Application.platform == RuntimePlatform.IPhonePlayer)
			{
				this.useKeyboard = false;
				this.useController = false;
			}
		}
		else if (Application.platform == RuntimePlatform.PS3 || Application.platform == RuntimePlatform.XBOX360)
		{
			this.useMouse = false;
			this.useTouch = false;
			this.useKeyboard = false;
			this.useController = true;
		}
		else if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
		{
			this.mIsEditor = true;
		}
		UICamera.mMouse[0].pos.x = Input.mousePosition.x;
		UICamera.mMouse[0].pos.y = Input.mousePosition.y;
		UICamera.lastTouchPosition = UICamera.mMouse[0].pos;
		UICamera.mList.Add(this);
		UICamera.mList.Sort(new Comparison<UICamera>(UICamera.CompareFunc));
		if (this.eventReceiverMask == -1)
		{
			this.eventReceiverMask = this.cachedCamera.cullingMask;
		}
	}

	// Token: 0x060002FD RID: 765 RVA: 0x000043CE File Offset: 0x000025CE
	private void OnDestroy()
	{
		UICamera.mList.Remove(this);
	}

	// Token: 0x060002FE RID: 766 RVA: 0x00023A54 File Offset: 0x00021C54
	private void FixedUpdate()
	{
		if (this.useMouse && Application.isPlaying && this.handlesEvents)
		{
			UICamera.hoveredObject = ((!UICamera.Raycast(Input.mousePosition, ref UICamera.lastHit)) ? UICamera.fallThrough : UICamera.lastHit.collider.gameObject);
			if (UICamera.hoveredObject == null)
			{
				UICamera.hoveredObject = UICamera.genericEventHandler;
			}
			for (int i = 0; i < 3; i++)
			{
				UICamera.mMouse[i].current = UICamera.hoveredObject;
			}
		}
	}

	// Token: 0x060002FF RID: 767 RVA: 0x00023AF0 File Offset: 0x00021CF0
	private void Update()
	{
		if (!Application.isPlaying || !this.handlesEvents)
		{
			return;
		}
		UICamera.current = this;
		if (this.useMouse || (this.useTouch && this.mIsEditor))
		{
			this.ProcessMouse();
		}
		if (this.useTouch)
		{
			this.ProcessTouches();
		}
		if (UICamera.onCustomInput != null)
		{
			UICamera.onCustomInput();
		}
		if (this.useMouse && UICamera.mSel != null && ((this.cancelKey0 != KeyCode.None && Input.GetKeyDown(this.cancelKey0)) || (this.cancelKey1 != KeyCode.None && Input.GetKeyDown(this.cancelKey1))))
		{
			UICamera.selectedObject = null;
		}
		if (UICamera.mSel != null)
		{
			string inputString = Input.inputString;
			UICamera.lastInputEvents += inputString;
			if (this.useKeyboard && Input.GetKeyDown(KeyCode.Delete) && UICamera.lastInputEvents.LastIndexOf('\b') == -1)
			{
				UICamera.lastInputEvents += "\b";
			}
			if (UICamera.lastInputEvents.Length > 0)
			{
				if (!this.stickyTooltip && this.mTooltip != null)
				{
					this.ShowTooltip(false);
				}
				UICamera.Notify(UICamera.mSel, "OnInput", UICamera.lastInputEvents);
				UICamera.lastInputEvents = string.Empty;
			}
		}
		else
		{
			UICamera.inputHasFocus = false;
		}
		if (UICamera.mSel != null)
		{
			this.ProcessOthers();
		}
		if (this.useMouse && UICamera.mHover != null)
		{
			float axis = Input.GetAxis(this.scrollAxisName);
			if (axis != 0f)
			{
				UICamera.Notify(UICamera.mHover, "OnScroll", axis);
			}
			if (UICamera.showTooltips && this.mTooltipTime != 0f && (this.mTooltipTime < Time.realtimeSinceStartup || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
			{
				this.mTooltip = UICamera.mHover;
				this.ShowTooltip(true);
			}
		}
		UICamera.current = null;
	}

	// Token: 0x06000300 RID: 768 RVA: 0x00023D38 File Offset: 0x00021F38
	public void ProcessMouse()
	{
		bool flag = this.useMouse && Time.timeScale < 0.9f;
		if (!flag)
		{
			for (int i = 0; i < 3; i++)
			{
				if (Input.GetMouseButton(i) || Input.GetMouseButtonUp(i))
				{
					flag = true;
					break;
				}
			}
		}
		UICamera.mMouse[0].pos = Input.mousePosition;
		UICamera.mMouse[0].delta = UICamera.mMouse[0].pos - UICamera.lastTouchPosition;
		bool flag2 = UICamera.mMouse[0].pos != UICamera.lastTouchPosition;
		UICamera.lastTouchPosition = UICamera.mMouse[0].pos;
		if (flag)
		{
			UICamera.hoveredObject = ((!UICamera.Raycast(Input.mousePosition, ref UICamera.lastHit)) ? UICamera.fallThrough : UICamera.lastHit.collider.gameObject);
			if (UICamera.hoveredObject == null)
			{
				UICamera.hoveredObject = UICamera.genericEventHandler;
			}
			UICamera.mMouse[0].current = UICamera.hoveredObject;
		}
		for (int j = 1; j < 3; j++)
		{
			UICamera.mMouse[j].pos = UICamera.mMouse[0].pos;
			UICamera.mMouse[j].delta = UICamera.mMouse[0].delta;
			UICamera.mMouse[j].current = UICamera.mMouse[0].current;
		}
		bool flag3 = false;
		for (int k = 0; k < 3; k++)
		{
			if (Input.GetMouseButton(k))
			{
				flag3 = true;
				break;
			}
		}
		if (flag3)
		{
			this.mTooltipTime = 0f;
		}
		else if (this.useMouse && flag2 && (!this.stickyTooltip || UICamera.mHover != UICamera.mMouse[0].current))
		{
			if (this.mTooltipTime != 0f)
			{
				this.mTooltipTime = Time.realtimeSinceStartup + this.tooltipDelay;
			}
			else if (this.mTooltip != null)
			{
				this.ShowTooltip(false);
			}
		}
		if (this.useMouse && !flag3 && UICamera.mHover != null && UICamera.mHover != UICamera.mMouse[0].current)
		{
			if (this.mTooltip != null)
			{
				this.ShowTooltip(false);
			}
			UICamera.Highlight(UICamera.mHover, false);
			UICamera.mHover = null;
		}
		if (this.useMouse)
		{
			for (int l = 0; l < 3; l++)
			{
				bool mouseButtonDown = Input.GetMouseButtonDown(l);
				bool mouseButtonUp = Input.GetMouseButtonUp(l);
				UICamera.currentTouch = UICamera.mMouse[l];
				UICamera.currentTouchID = -1 - l;
				if (mouseButtonDown)
				{
					UICamera.currentTouch.pressedCam = UICamera.currentCamera;
				}
				else if (UICamera.currentTouch.pressed != null)
				{
					UICamera.currentCamera = UICamera.currentTouch.pressedCam;
				}
				this.ProcessTouch(mouseButtonDown, mouseButtonUp);
			}
			UICamera.currentTouch = null;
		}
		if (this.useMouse && !flag3 && UICamera.mHover != UICamera.mMouse[0].current)
		{
			this.mTooltipTime = Time.realtimeSinceStartup + this.tooltipDelay;
			UICamera.mHover = UICamera.mMouse[0].current;
			UICamera.Highlight(UICamera.mHover, true);
		}
	}

	// Token: 0x06000301 RID: 769 RVA: 0x000240C8 File Offset: 0x000222C8
	public void ProcessTouches()
	{
		for (int i = 0; i < Input.touchCount; i++)
		{
			Touch touch = Input.GetTouch(i);
			UICamera.currentTouchID = ((!this.allowMultiTouch) ? 1 : touch.fingerId);
			UICamera.currentTouch = UICamera.GetTouch(UICamera.currentTouchID);
			bool flag = touch.phase == TouchPhase.Began || UICamera.currentTouch.touchBegan;
			bool flag2 = touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended;
			UICamera.currentTouch.touchBegan = false;
			if (flag)
			{
				UICamera.currentTouch.delta = Vector2.zero;
			}
			else
			{
				UICamera.currentTouch.delta = touch.position - UICamera.currentTouch.pos;
			}
			UICamera.currentTouch.pos = touch.position;
			UICamera.hoveredObject = ((!UICamera.Raycast(UICamera.currentTouch.pos, ref UICamera.lastHit)) ? UICamera.fallThrough : UICamera.lastHit.collider.gameObject);
			if (UICamera.hoveredObject == null)
			{
				UICamera.hoveredObject = UICamera.genericEventHandler;
			}
			UICamera.currentTouch.current = UICamera.hoveredObject;
			UICamera.lastTouchPosition = UICamera.currentTouch.pos;
			if (flag)
			{
				UICamera.currentTouch.pressedCam = UICamera.currentCamera;
			}
			else if (UICamera.currentTouch.pressed != null)
			{
				UICamera.currentCamera = UICamera.currentTouch.pressedCam;
			}
			if (touch.tapCount > 1)
			{
				UICamera.currentTouch.clickTime = Time.realtimeSinceStartup;
			}
			this.ProcessTouch(flag, flag2);
			if (flag2)
			{
				UICamera.RemoveTouch(UICamera.currentTouchID);
			}
			UICamera.currentTouch = null;
			if (!this.allowMultiTouch)
			{
				break;
			}
		}
	}

	// Token: 0x06000302 RID: 770 RVA: 0x000242A8 File Offset: 0x000224A8
	public void ProcessOthers()
	{
		UICamera.currentTouchID = -100;
		UICamera.currentTouch = UICamera.mController;
		UICamera.inputHasFocus = (UICamera.mSel != null && UICamera.mSel.GetComponent<UIInput>() != null);
		bool flag = (this.submitKey0 != KeyCode.None && Input.GetKeyDown(this.submitKey0)) || (this.submitKey1 != KeyCode.None && Input.GetKeyDown(this.submitKey1));
		bool flag2 = (this.submitKey0 != KeyCode.None && Input.GetKeyUp(this.submitKey0)) || (this.submitKey1 != KeyCode.None && Input.GetKeyUp(this.submitKey1));
		if (flag || flag2)
		{
			UICamera.currentTouch.current = UICamera.mSel;
			this.ProcessTouch(flag, flag2);
			UICamera.currentTouch.current = null;
		}
		int num = 0;
		int num2 = 0;
		if (this.useKeyboard)
		{
			if (UICamera.inputHasFocus)
			{
				num += UICamera.GetDirection(KeyCode.UpArrow, KeyCode.DownArrow);
				num2 += UICamera.GetDirection(KeyCode.RightArrow, KeyCode.LeftArrow);
			}
			else
			{
				num += UICamera.GetDirection(KeyCode.W, KeyCode.UpArrow, KeyCode.S, KeyCode.DownArrow);
				num2 += UICamera.GetDirection(KeyCode.D, KeyCode.RightArrow, KeyCode.A, KeyCode.LeftArrow);
			}
		}
		if (this.useController)
		{
			if (!string.IsNullOrEmpty(this.verticalAxisName))
			{
				num += UICamera.GetDirection(this.verticalAxisName);
			}
			if (!string.IsNullOrEmpty(this.horizontalAxisName))
			{
				num2 += UICamera.GetDirection(this.horizontalAxisName);
			}
		}
		if (num != 0)
		{
			UICamera.Notify(UICamera.mSel, "OnKey", (num <= 0) ? KeyCode.DownArrow : KeyCode.UpArrow);
		}
		if (num2 != 0)
		{
			UICamera.Notify(UICamera.mSel, "OnKey", (num2 <= 0) ? KeyCode.LeftArrow : KeyCode.RightArrow);
		}
		if (this.useKeyboard && Input.GetKeyDown(KeyCode.Tab))
		{
			UICamera.Notify(UICamera.mSel, "OnKey", KeyCode.Tab);
		}
		if (this.cancelKey0 != KeyCode.None && Input.GetKeyDown(this.cancelKey0))
		{
			UICamera.Notify(UICamera.mSel, "OnKey", KeyCode.Escape);
		}
		if (this.cancelKey1 != KeyCode.None && Input.GetKeyDown(this.cancelKey1))
		{
			UICamera.Notify(UICamera.mSel, "OnKey", KeyCode.Escape);
		}
		UICamera.currentTouch = null;
	}

	// Token: 0x06000303 RID: 771 RVA: 0x00024538 File Offset: 0x00022738
	public void ProcessTouch(bool pressed, bool unpressed)
	{
		bool flag = UICamera.currentTouch == UICamera.mMouse[0];
		float num = (!flag) ? this.touchDragThreshold : this.mouseDragThreshold;
		float num2 = (!flag) ? this.touchClickThreshold : this.mouseClickThreshold;
		if (pressed)
		{
			if (this.mTooltip != null)
			{
				this.ShowTooltip(false);
			}
			UICamera.currentTouch.pressStarted = true;
			UICamera.Notify(UICamera.currentTouch.pressed, "OnPress", false);
			UICamera.currentTouch.pressed = UICamera.currentTouch.current;
			UICamera.currentTouch.dragged = UICamera.currentTouch.current;
			UICamera.currentTouch.clickNotification = UICamera.ClickNotification.Always;
			UICamera.currentTouch.totalDelta = Vector2.zero;
			UICamera.currentTouch.dragStarted = false;
			UICamera.Notify(UICamera.currentTouch.pressed, "OnPress", true);
			if (UICamera.currentTouch.pressed != UICamera.mSel)
			{
				if (this.mTooltip != null)
				{
					this.ShowTooltip(false);
				}
				UICamera.selectedObject = null;
			}
		}
		else
		{
			if (UICamera.currentTouch.clickNotification != UICamera.ClickNotification.None && !this.stickyPress && !unpressed && UICamera.currentTouch.pressStarted && UICamera.currentTouch.pressed != UICamera.hoveredObject)
			{
				UICamera.isDragging = true;
				UICamera.Notify(UICamera.currentTouch.pressed, "OnPress", false);
				UICamera.currentTouch.pressed = UICamera.hoveredObject;
				UICamera.Notify(UICamera.currentTouch.pressed, "OnPress", true);
				UICamera.isDragging = false;
			}
			if (UICamera.currentTouch.pressed != null)
			{
				float magnitude = UICamera.currentTouch.delta.magnitude;
				if (magnitude != 0f)
				{
					UICamera.currentTouch.totalDelta += UICamera.currentTouch.delta;
					magnitude = UICamera.currentTouch.totalDelta.magnitude;
					if (!UICamera.currentTouch.dragStarted && num < magnitude)
					{
						UICamera.currentTouch.dragStarted = true;
						UICamera.currentTouch.delta = UICamera.currentTouch.totalDelta;
					}
					if (UICamera.currentTouch.dragStarted)
					{
						if (this.mTooltip != null)
						{
							this.ShowTooltip(false);
						}
						UICamera.isDragging = true;
						bool flag2 = UICamera.currentTouch.clickNotification == UICamera.ClickNotification.None;
						UICamera.Notify(UICamera.currentTouch.dragged, "OnDrag", UICamera.currentTouch.delta);
						UICamera.isDragging = false;
						if (flag2)
						{
							UICamera.currentTouch.clickNotification = UICamera.ClickNotification.None;
						}
						else if (UICamera.currentTouch.clickNotification == UICamera.ClickNotification.BasedOnDelta && num2 < magnitude)
						{
							UICamera.currentTouch.clickNotification = UICamera.ClickNotification.None;
						}
					}
				}
			}
		}
		if (unpressed)
		{
			UICamera.currentTouch.pressStarted = false;
			if (this.mTooltip != null)
			{
				this.ShowTooltip(false);
			}
			if (UICamera.currentTouch.pressed != null)
			{
				UICamera.Notify(UICamera.currentTouch.pressed, "OnPress", false);
				if (this.useMouse && UICamera.currentTouch.pressed == UICamera.mHover)
				{
					UICamera.Notify(UICamera.currentTouch.pressed, "OnHover", true);
				}
				if (UICamera.currentTouch.dragged == UICamera.currentTouch.current || (UICamera.currentTouch.clickNotification != UICamera.ClickNotification.None && UICamera.currentTouch.totalDelta.magnitude < num))
				{
					if (UICamera.currentTouch.pressed != UICamera.mSel)
					{
						UICamera.mSel = UICamera.currentTouch.pressed;
						UICamera.Notify(UICamera.currentTouch.pressed, "OnSelect", true);
					}
					else
					{
						UICamera.mSel = UICamera.currentTouch.pressed;
					}
					if (UICamera.currentTouch.clickNotification != UICamera.ClickNotification.None)
					{
						float realtimeSinceStartup = Time.realtimeSinceStartup;
						UICamera.Notify(UICamera.currentTouch.pressed, "OnClick", null);
						if (UICamera.currentTouch.clickTime + 0.35f > realtimeSinceStartup)
						{
							UICamera.Notify(UICamera.currentTouch.pressed, "OnDoubleClick", null);
						}
						UICamera.currentTouch.clickTime = realtimeSinceStartup;
					}
				}
				else
				{
					UICamera.Notify(UICamera.currentTouch.current, "OnDrop", UICamera.currentTouch.dragged);
				}
			}
			UICamera.currentTouch.dragStarted = false;
			UICamera.currentTouch.pressed = null;
			UICamera.currentTouch.dragged = null;
		}
	}

	// Token: 0x06000304 RID: 772 RVA: 0x000043DC File Offset: 0x000025DC
	public void ShowTooltip(bool val)
	{
		this.mTooltipTime = 0f;
		UICamera.Notify(this.mTooltip, "OnTooltip", val);
		if (!val)
		{
			this.mTooltip = null;
		}
	}

	// Token: 0x04000293 RID: 659
	public bool debug;

	// Token: 0x04000294 RID: 660
	public bool useMouse = true;

	// Token: 0x04000295 RID: 661
	public bool useTouch = true;

	// Token: 0x04000296 RID: 662
	public bool allowMultiTouch = true;

	// Token: 0x04000297 RID: 663
	public bool useKeyboard = true;

	// Token: 0x04000298 RID: 664
	public bool useController = true;

	// Token: 0x04000299 RID: 665
	public bool stickyPress = true;

	// Token: 0x0400029A RID: 666
	public LayerMask eventReceiverMask = -1;

	// Token: 0x0400029B RID: 667
	public bool clipRaycasts = true;

	// Token: 0x0400029C RID: 668
	public float tooltipDelay = 1f;

	// Token: 0x0400029D RID: 669
	public bool stickyTooltip = true;

	// Token: 0x0400029E RID: 670
	public float mouseDragThreshold = 4f;

	// Token: 0x0400029F RID: 671
	public float mouseClickThreshold = 10f;

	// Token: 0x040002A0 RID: 672
	public float touchDragThreshold = 40f;

	// Token: 0x040002A1 RID: 673
	public float touchClickThreshold = 40f;

	// Token: 0x040002A2 RID: 674
	public float rangeDistance = -1f;

	// Token: 0x040002A3 RID: 675
	public string scrollAxisName = "Mouse ScrollWheel";

	// Token: 0x040002A4 RID: 676
	public string verticalAxisName = "Vertical";

	// Token: 0x040002A5 RID: 677
	public string horizontalAxisName = "Horizontal";

	// Token: 0x040002A6 RID: 678
	public KeyCode submitKey0 = KeyCode.Return;

	// Token: 0x040002A7 RID: 679
	public KeyCode submitKey1 = KeyCode.JoystickButton0;

	// Token: 0x040002A8 RID: 680
	public KeyCode cancelKey0 = KeyCode.Escape;

	// Token: 0x040002A9 RID: 681
	public KeyCode cancelKey1 = KeyCode.JoystickButton1;

	// Token: 0x040002AA RID: 682
	public static UICamera.OnCustomInput onCustomInput;

	// Token: 0x040002AB RID: 683
	public static bool showTooltips = true;

	// Token: 0x040002AC RID: 684
	public static Vector2 lastTouchPosition = Vector2.zero;

	// Token: 0x040002AD RID: 685
	public static RaycastHit lastHit;

	// Token: 0x040002AE RID: 686
	public static UICamera current = null;

	// Token: 0x040002AF RID: 687
	public static Camera currentCamera = null;

	// Token: 0x040002B0 RID: 688
	public static int currentTouchID = -1;

	// Token: 0x040002B1 RID: 689
	public static UICamera.MouseOrTouch currentTouch = null;

	// Token: 0x040002B2 RID: 690
	public static bool inputHasFocus = false;

	// Token: 0x040002B3 RID: 691
	public static GameObject genericEventHandler;

	// Token: 0x040002B4 RID: 692
	public static GameObject fallThrough;

	// Token: 0x040002B5 RID: 693
	private static List<UICamera> mList = new List<UICamera>();

	// Token: 0x040002B6 RID: 694
	private static List<UICamera.Highlighted> mHighlighted = new List<UICamera.Highlighted>();

	// Token: 0x040002B7 RID: 695
	private static GameObject mSel = null;

	// Token: 0x040002B8 RID: 696
	private static UICamera.MouseOrTouch[] mMouse = new UICamera.MouseOrTouch[]
	{
		new UICamera.MouseOrTouch(),
		new UICamera.MouseOrTouch(),
		new UICamera.MouseOrTouch()
	};

	// Token: 0x040002B9 RID: 697
	private static GameObject mHover;

	// Token: 0x040002BA RID: 698
	private static UICamera.MouseOrTouch mController = new UICamera.MouseOrTouch();

	// Token: 0x040002BB RID: 699
	private static float mNextEvent = 0f;

	// Token: 0x040002BC RID: 700
	private static Dictionary<int, UICamera.MouseOrTouch> mTouches = new Dictionary<int, UICamera.MouseOrTouch>();

	// Token: 0x040002BD RID: 701
	private GameObject mTooltip;

	// Token: 0x040002BE RID: 702
	private Camera mCam;

	// Token: 0x040002BF RID: 703
	private LayerMask mLayerMask;

	// Token: 0x040002C0 RID: 704
	private float mTooltipTime;

	// Token: 0x040002C1 RID: 705
	private bool mIsEditor;

	// Token: 0x040002C2 RID: 706
	public static bool isDragging = false;

	// Token: 0x040002C3 RID: 707
	public static GameObject hoveredObject;

	// Token: 0x040002C4 RID: 708
	private static string lastInputEvents = string.Empty;

	// Token: 0x02000076 RID: 118
	public enum ClickNotification
	{
		// Token: 0x040002C7 RID: 711
		None,
		// Token: 0x040002C8 RID: 712
		Always,
		// Token: 0x040002C9 RID: 713
		BasedOnDelta
	}

	// Token: 0x02000077 RID: 119
	public class MouseOrTouch
	{
		// Token: 0x040002CA RID: 714
		public Vector2 pos;

		// Token: 0x040002CB RID: 715
		public Vector2 delta;

		// Token: 0x040002CC RID: 716
		public Vector2 totalDelta;

		// Token: 0x040002CD RID: 717
		public Camera pressedCam;

		// Token: 0x040002CE RID: 718
		public GameObject current;

		// Token: 0x040002CF RID: 719
		public GameObject pressed;

		// Token: 0x040002D0 RID: 720
		public GameObject dragged;

		// Token: 0x040002D1 RID: 721
		public float clickTime;

		// Token: 0x040002D2 RID: 722
		public UICamera.ClickNotification clickNotification = UICamera.ClickNotification.Always;

		// Token: 0x040002D3 RID: 723
		public bool touchBegan = true;

		// Token: 0x040002D4 RID: 724
		public bool pressStarted;

		// Token: 0x040002D5 RID: 725
		public bool dragStarted;
	}

	// Token: 0x02000078 RID: 120
	private class Highlighted
	{
		// Token: 0x040002D6 RID: 726
		public GameObject go;

		// Token: 0x040002D7 RID: 727
		public int counter;
	}

	// Token: 0x02000079 RID: 121
	// (Invoke) Token: 0x06000309 RID: 777
	public delegate void OnCustomInput();
}
