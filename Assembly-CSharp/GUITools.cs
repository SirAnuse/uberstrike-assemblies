using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200014E RID: 334
public static class GUITools
{
	// Token: 0x060008B7 RID: 2231 RVA: 0x0003883C File Offset: 0x00036A3C
	// Note: this type is marked as 'beforefieldinit'.
	static GUITools()
	{
		GUITools._screenX = 1;
		GUITools._screenY = 1;
		GUITools._screenHalfX = 1;
		GUITools._screenHalfY = 1;
		GUITools._aspectRatio = 1f;
		GUITools._lastClick = 0f;
		GUITools._lastRepeatClick = 0f;
		GUITools._repeatButtonPressed = 0f;
		GUITools._stateStack = new Stack<bool>();
	}

	// Token: 0x1700027B RID: 635
	// (get) Token: 0x060008B8 RID: 2232 RVA: 0x00007677 File Offset: 0x00005877
	public static float AspectRatio
	{
		get
		{
			return GUITools._aspectRatio;
		}
	}

	// Token: 0x1700027C RID: 636
	// (get) Token: 0x060008B9 RID: 2233 RVA: 0x0000767E File Offset: 0x0000587E
	public static float SinusPulse
	{
		get
		{
			return (Mathf.Sin(Time.time * 2f) + 1.3f) * 0.5f;
		}
	}

	// Token: 0x1700027D RID: 637
	// (get) Token: 0x060008BA RID: 2234 RVA: 0x0000769C File Offset: 0x0000589C
	public static float FastSinusPulse
	{
		get
		{
			return (Mathf.Sin(Time.time * 5f) + 1.3f) * 0.5f;
		}
	}

	// Token: 0x060008BB RID: 2235 RVA: 0x000388A4 File Offset: 0x00036AA4
	public static IEnumerator StartScreenSizeListener(float s)
	{
		GUITools.UpdateScreenSize();
		yield return new WaitForEndOfFrame();
		for (;;)
		{
			GUITools.UpdateScreenSize();
			yield return new WaitForSeconds(s);
		}
		yield break;
	}

	// Token: 0x060008BC RID: 2236 RVA: 0x000388C8 File Offset: 0x00036AC8
	public static void UpdateScreenSize()
	{
		if (GUITools.ScreenWidth != Screen.width)
		{
			GUITools.ScreenWidth = Screen.width;
			GUITools._aspectRatio = (float)(GUITools.ScreenWidth / GUITools.ScreenHeight);
		}
		if (GUITools.ScreenHeight != Screen.height)
		{
			GUITools.ScreenHeight = Screen.height;
			GUITools._aspectRatio = (float)(GUITools.ScreenWidth / GUITools.ScreenHeight);
		}
	}

	// Token: 0x1700027E RID: 638
	// (get) Token: 0x060008BD RID: 2237 RVA: 0x000076BA File Offset: 0x000058BA
	public static int ScreenHalfWidth
	{
		get
		{
			return GUITools._screenHalfX;
		}
	}

	// Token: 0x1700027F RID: 639
	// (get) Token: 0x060008BE RID: 2238 RVA: 0x000076C1 File Offset: 0x000058C1
	public static int ScreenHalfHeight
	{
		get
		{
			return GUITools._screenHalfY;
		}
	}

	// Token: 0x17000280 RID: 640
	// (get) Token: 0x060008BF RID: 2239 RVA: 0x000076C8 File Offset: 0x000058C8
	// (set) Token: 0x060008C0 RID: 2240 RVA: 0x000076CF File Offset: 0x000058CF
	public static int ScreenWidth
	{
		get
		{
			return GUITools._screenX;
		}
		private set
		{
			GUITools._screenX = Mathf.Max(value, 1);
			GUITools._screenHalfX = GUITools._screenX >> 1;
		}
	}

	// Token: 0x17000281 RID: 641
	// (get) Token: 0x060008C1 RID: 2241 RVA: 0x000076E9 File Offset: 0x000058E9
	// (set) Token: 0x060008C2 RID: 2242 RVA: 0x000076F0 File Offset: 0x000058F0
	public static int ScreenHeight
	{
		get
		{
			return GUITools._screenY;
		}
		private set
		{
			GUITools._screenY = Mathf.Max(value, 1);
			GUITools._screenHalfY = GUITools._screenY >> 1;
		}
	}

	// Token: 0x060008C3 RID: 2243 RVA: 0x0000770A File Offset: 0x0000590A
	public static bool IsScreenResolutionChanged()
	{
		return Screen.width != Screen.width || Screen.height != Screen.height;
	}

	// Token: 0x060008C4 RID: 2244 RVA: 0x0003892C File Offset: 0x00036B2C
	public static bool RepeatClick(float vel)
	{
		if (Mathf.Abs(Time.time - GUITools._lastRepeatClick - Time.deltaTime) < 0.0001f)
		{
			GUITools._repeatButtonPressed += Time.deltaTime;
		}
		else
		{
			GUITools._repeatButtonPressed = 0f;
		}
		GUITools._lastRepeatClick = Time.time;
		return GUITools._repeatButtonPressed == 0f || (GUITools._repeatButtonPressed > 0.5f && GUITools.SaveClickIn(vel));
	}

	// Token: 0x17000282 RID: 642
	// (get) Token: 0x060008C5 RID: 2245 RVA: 0x0000772D File Offset: 0x0000592D
	public static float LastClick
	{
		get
		{
			return GUITools._lastClick;
		}
	}

	// Token: 0x17000283 RID: 643
	// (get) Token: 0x060008C6 RID: 2246 RVA: 0x00007734 File Offset: 0x00005934
	public static bool SaveClick
	{
		get
		{
			return GUITools._lastClick + 0.5f < Time.time;
		}
	}

	// Token: 0x060008C7 RID: 2247 RVA: 0x00007748 File Offset: 0x00005948
	public static bool SaveClickIn(float t)
	{
		return GUITools._lastClick + t < Time.time;
	}

	// Token: 0x060008C8 RID: 2248 RVA: 0x00007758 File Offset: 0x00005958
	public static void ClickAndUse()
	{
		if (Event.current != null)
		{
			Event.current.Use();
		}
		GUITools._lastClick = Time.time;
	}

	// Token: 0x060008C9 RID: 2249 RVA: 0x00007778 File Offset: 0x00005978
	public static void Clicked()
	{
		GUITools._lastClick = Time.time;
	}

	// Token: 0x060008CA RID: 2250 RVA: 0x00007784 File Offset: 0x00005984
	public static int CheckGUIState()
	{
		return GUITools._stateStack.Count;
	}

	// Token: 0x060008CB RID: 2251 RVA: 0x00007790 File Offset: 0x00005990
	public static void PushGUIState()
	{
		if (GUITools._stateStack.Count < 100)
		{
			GUITools._stateStack.Push(GUI.enabled);
		}
		else
		{
			Debug.LogError("Check your calls of PushGUIState");
		}
	}

	// Token: 0x060008CC RID: 2252 RVA: 0x000077C1 File Offset: 0x000059C1
	public static void PopGUIState()
	{
		GUI.enabled = GUITools._stateStack.Pop();
	}

	// Token: 0x060008CD RID: 2253 RVA: 0x000077D2 File Offset: 0x000059D2
	public static void BeginGUIColor(Color color)
	{
		GUITools._lastGuiColor = GUI.color;
		GUI.color = color;
	}

	// Token: 0x060008CE RID: 2254 RVA: 0x000077E4 File Offset: 0x000059E4
	public static void EndGUIColor()
	{
		GUI.color = GUITools._lastGuiColor;
	}

	// Token: 0x060008CF RID: 2255 RVA: 0x000389B4 File Offset: 0x00036BB4
	public static void LabelShadow(Rect rect, string text, GUIStyle style, Color color)
	{
		GUI.color = new Color(0f, 0f, 0f, color.a * 0.5f);
		GUI.Label(new Rect(rect.x + 1f, rect.y + 1f, rect.width, rect.height), text, style);
		GUI.color = color;
		GUI.Label(rect, text, style);
		GUI.color = Color.white;
	}

	// Token: 0x060008D0 RID: 2256 RVA: 0x000077F0 File Offset: 0x000059F0
	public static bool Button(Rect rect, GUIContent content, GUIStyle style)
	{
		return GUITools.Button(rect, content, style, GameAudio.ButtonClick);
	}

	// Token: 0x060008D1 RID: 2257 RVA: 0x000077FF File Offset: 0x000059FF
	public static bool Button(Rect rect, GUIContent content, GUIStyle style, AudioClip soundEffect)
	{
		if (GUI.Button(rect, content, style) && AutoMonoBehaviour<SfxManager>.Instance != null)
		{
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(soundEffect, 0UL, 1f, 1f);
			return true;
		}
		return false;
	}

	// Token: 0x17000284 RID: 644
	// (get) Token: 0x060008D2 RID: 2258 RVA: 0x00007838 File Offset: 0x00005A38
	// (set) Token: 0x060008D3 RID: 2259 RVA: 0x0000783F File Offset: 0x00005A3F
	public static bool IsScrolling { get; private set; }

	// Token: 0x060008D4 RID: 2260 RVA: 0x00038A34 File Offset: 0x00036C34
	public static Rect ToGlobal(Rect rect)
	{
		Vector2 vector = GUIUtility.GUIToScreenPoint(new Vector2(rect.x, rect.y));
		return new Rect(vector.x, vector.y, rect.width, rect.height);
	}

	// Token: 0x060008D5 RID: 2261 RVA: 0x00007847 File Offset: 0x00005A47
	public static bool Label(Rect rect, Texture2D image, GUIStyle style)
	{
		GUI.Label(rect, image, style);
		return rect.Contains(Event.current.mousePosition);
	}

	// Token: 0x060008D6 RID: 2262 RVA: 0x00007862 File Offset: 0x00005A62
	public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect contentRect, bool showHorizontalScrollbar, bool showVerticalScrollbar, GUIStyle hStyle, GUIStyle vStyle, bool allowDrag = true)
	{
		return GUI.BeginScrollView(position, scrollPosition, contentRect);
	}

	// Token: 0x060008D7 RID: 2263 RVA: 0x0000786C File Offset: 0x00005A6C
	public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect contentRect, bool useHorizontal = false, bool useVertical = false, bool allowDrag = true)
	{
		return GUITools.BeginScrollView(position, scrollPosition, contentRect, useHorizontal, useVertical, GUI.skin.horizontalScrollbar, GUI.skin.verticalScrollbar, allowDrag);
	}

	// Token: 0x060008D8 RID: 2264 RVA: 0x0000788F File Offset: 0x00005A8F
	public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect contentRect, GUIStyle hStyle, GUIStyle vStyle)
	{
		return GUITools.BeginScrollView(position, scrollPosition, contentRect, false, false, GUI.skin.horizontalScrollbar, GUI.skin.verticalScrollbar, true);
	}

	// Token: 0x060008D9 RID: 2265 RVA: 0x000078B0 File Offset: 0x00005AB0
	public static void EndScrollView()
	{
		GUI.EndScrollView();
	}

	// Token: 0x060008DA RID: 2266 RVA: 0x00038A7C File Offset: 0x00036C7C
	public static bool BeginList(ref bool showList, Rect listRect, Rect buttonRect)
	{
		if (!showList)
		{
			return false;
		}
		if (Input.GetMouseButtonUp(0) && !listRect.ContainsTouch(Input.mousePosition) && !buttonRect.ContainsTouch(Input.mousePosition))
		{
			showList = false;
		}
		if (Input.touchCount > 0)
		{
			foreach (Touch touch in Input.touches)
			{
				if ((touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) && !listRect.ContainsTouch(touch.position) && !buttonRect.ContainsTouch(touch.position))
				{
					showList = false;
				}
			}
		}
		return showList;
	}

	// Token: 0x060008DB RID: 2267 RVA: 0x00038B40 File Offset: 0x00036D40
	public static EventType HoverButton(Rect position, GUIContent content, GUIStyle style)
	{
		int controlID = GUIUtility.GetControlID(GUITools.HoverButtonHash, FocusType.Native);
		switch (Event.current.GetTypeForControl(controlID))
		{
		case EventType.MouseDown:
			if (position.Contains(Event.current.mousePosition))
			{
				GUIUtility.hotControl = controlID;
				Event.current.Use();
				return EventType.MouseDown;
			}
			break;
		case EventType.MouseUp:
			if (GUIUtility.hotControl == controlID)
			{
				GUIUtility.hotControl = 0;
				if (position.Contains(Event.current.mousePosition))
				{
					Event.current.Use();
					return EventType.MouseUp;
				}
			}
			else if (position.Contains(Event.current.mousePosition))
			{
				return EventType.DragExited;
			}
			return EventType.Ignore;
		case EventType.MouseDrag:
			if (GUIUtility.hotControl == controlID)
			{
				Event.current.Use();
				return EventType.MouseDrag;
			}
			return EventType.Ignore;
		case EventType.Repaint:
			style.Draw(position, content, controlID);
			if (position.Contains(Event.current.mousePosition))
			{
				return EventType.MouseMove;
			}
			return EventType.Repaint;
		}
		if (position.Contains(Event.current.mousePosition))
		{
			return EventType.MouseMove;
		}
		return EventType.Ignore;
	}

	// Token: 0x060008DC RID: 2268 RVA: 0x00038C68 File Offset: 0x00036E68
	public static string PasswordField(Rect mPosition, string mPassword)
	{
		string text;
		if (Event.current.type == EventType.Repaint || Event.current.type == EventType.MouseDown)
		{
			text = string.Empty;
			for (int i = 0; i < mPassword.Length; i++)
			{
				text += "*";
			}
		}
		else
		{
			text = mPassword;
		}
		GUI.changed = false;
		text = GUI.TextField(mPosition, text, 20);
		if (GUI.changed)
		{
			mPassword = text;
		}
		return mPassword;
	}

	// Token: 0x060008DD RID: 2269 RVA: 0x00038CE4 File Offset: 0x00036EE4
	public static string PasswordField(string mPassword)
	{
		string text;
		if (Event.current.type == EventType.Repaint || Event.current.type == EventType.MouseDown)
		{
			text = string.Empty;
			for (int i = 0; i < mPassword.Length; i++)
			{
				text += "*";
			}
		}
		else
		{
			text = mPassword;
		}
		GUI.changed = false;
		text = GUILayout.TextField(text, 24, new GUILayoutOption[]
		{
			GUILayout.Height(30f)
		});
		if (GUI.changed)
		{
			mPassword = text;
		}
		return mPassword;
	}

	// Token: 0x060008DE RID: 2270 RVA: 0x00038D70 File Offset: 0x00036F70
	public static Vector2 DoScrollArea(Rect position, GUIContent[] buttons, int buttonHeight, Vector2 listScroller)
	{
		float num = 0f;
		if (buttons.Length > 0)
		{
			num = (float)((buttons.Length - 1) * buttonHeight);
		}
		listScroller = GUITools.BeginScrollView(position, listScroller, new Rect(0f, 0f, position.width - 20f, num + (float)buttonHeight), false, false, true);
		int i;
		for (i = 0; i < buttons.Length; i++)
		{
			if ((float)((i + 1) * buttonHeight) > listScroller.y)
			{
				break;
			}
		}
		while (i < buttons.Length && (float)(i * buttonHeight) < listScroller.y + position.height)
		{
			GUI.Button(new Rect(0f, (float)(i * buttonHeight), position.width - 16f, (float)buttonHeight), buttons[i]);
			i++;
		}
		GUITools.EndScrollView();
		return listScroller;
	}

	// Token: 0x060008DF RID: 2271 RVA: 0x000078B7 File Offset: 0x00005AB7
	public static void OutlineLabel(Rect position, string text)
	{
		GUITools.OutlineLabel(position, text, "SuperBigTitle", 1);
	}

	// Token: 0x060008E0 RID: 2272 RVA: 0x000078CB File Offset: 0x00005ACB
	public static void OutlineLabel(Rect position, string text, GUIStyle style)
	{
		GUITools.OutlineLabel(position, text, style, 1);
	}

	// Token: 0x060008E1 RID: 2273 RVA: 0x000078D6 File Offset: 0x00005AD6
	public static void OutlineLabel(Rect position, string text, GUIStyle style, Color c)
	{
		GUITools.OutlineLabel(position, text, style, 1, Color.white, c);
	}

	// Token: 0x060008E2 RID: 2274 RVA: 0x000078E7 File Offset: 0x00005AE7
	public static void OutlineLabel(Rect position, string text, GUIStyle style, int Offset)
	{
		GUITools.OutlineLabel(position, text, style, Offset, Color.white, Color.black);
	}

	// Token: 0x060008E3 RID: 2275 RVA: 0x00038E44 File Offset: 0x00037044
	public static void OutlineLabel(Rect position, string text, GUIStyle style, int Offset, Color textColor, Color outlineColor)
	{
		Color textColor2 = style.normal.textColor;
		style.normal.textColor = outlineColor;
		if (Offset > 0)
		{
			GUI.Label(new Rect(position.x, position.y + (float)Offset, position.width, position.height), text, style);
			GUI.Label(new Rect(position.x - (float)Offset, position.y, position.width, position.height), text, style);
			GUI.Label(new Rect(position.x + (float)Offset, position.y, position.width, position.height), text, style);
			GUI.Label(new Rect(position.x, position.y - (float)Offset, position.width, position.height), text, style);
			if (Offset > 1)
			{
				GUI.Label(new Rect(position.x - (float)Offset, position.y - (float)Offset, position.width, position.height), text, style);
				GUI.Label(new Rect(position.x - (float)Offset, position.y + (float)Offset, position.width, position.height), text, style);
				GUI.Label(new Rect(position.x + (float)Offset, position.y + (float)Offset, position.width, position.height), text, style);
				GUI.Label(new Rect(position.x + (float)Offset, position.y - (float)Offset, position.width, position.height), text, style);
			}
		}
		else
		{
			GUI.Label(new Rect(position.x, position.y + 1f, position.width, position.height), text, style);
		}
		style.normal.textColor = textColor2;
		GUI.color = textColor;
		GUI.Label(position, text, style);
		GUI.color = Color.white;
	}

	// Token: 0x060008E4 RID: 2276 RVA: 0x00039034 File Offset: 0x00037234
	public static void ProgressBar(Rect position, string text, float percentage, Color barColor, int barWidth)
	{
		GUI.BeginGroup(position);
		GUI.Label(new Rect(0f, 0f, position.width - (float)(barWidth + 4) - 2f - 30f, 14f), text, BlueStonez.label_interparkbold_11pt_right);
		GUI.Label(new Rect(position.width - (float)barWidth - 30f, 1f, (float)barWidth, 12f), GUIContent.none, BlueStonez.progressbar_background);
		GUI.color = barColor;
		GUI.Label(new Rect(position.width - (float)barWidth - 30f + 2f, 3f, (float)(barWidth - 4) * Mathf.Clamp01(percentage), 8f), string.Empty, BlueStonez.progressbar_thumb);
		GUI.color = Color.white;
		GUI.EndGroup();
	}

	// Token: 0x060008E5 RID: 2277 RVA: 0x00039108 File Offset: 0x00037308
	public static void DrawWarmupBar(Rect position, float value, float maxValue)
	{
		GUI.BeginGroup(position);
		GUI.Box(new Rect(0f, 0f, position.width, position.height), GUIContent.none, StormFront.ProgressBackground);
		float num = (position.width - 8f) * value / maxValue;
		GUI.Box(new Rect(4f, 4f, num, position.height - 8f), GUIContent.none, StormFront.ProgressForeground);
		float num2 = position.height * 0.5f;
		GUI.Box(new Rect(4f + num - num2 * 0.5f, 2f, num2, position.height - 4f), GUIContent.none, StormFront.ProgressThumb);
		GUI.EndGroup();
	}

	// Token: 0x0400091C RID: 2332
	private static int _screenX;

	// Token: 0x0400091D RID: 2333
	private static int _screenY;

	// Token: 0x0400091E RID: 2334
	private static int _screenHalfX;

	// Token: 0x0400091F RID: 2335
	private static int _screenHalfY;

	// Token: 0x04000920 RID: 2336
	private static float _aspectRatio;

	// Token: 0x04000921 RID: 2337
	private static float _lastClick;

	// Token: 0x04000922 RID: 2338
	private static float _lastRepeatClick;

	// Token: 0x04000923 RID: 2339
	private static float _repeatButtonPressed;

	// Token: 0x04000924 RID: 2340
	private static Stack<bool> _stateStack;

	// Token: 0x04000925 RID: 2341
	private static Color _lastGuiColor;

	// Token: 0x04000926 RID: 2342
	private static int HoverButtonHash = "Button".GetHashCode();
}
