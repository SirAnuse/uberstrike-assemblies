using System;
using UnityEngine;

// Token: 0x020003DB RID: 987
public static class MouseInput
{
	// Token: 0x06001CE0 RID: 7392 RVA: 0x00013333 File Offset: 0x00011533
	static MouseInput()
	{
		AutoMonoBehaviour<UnityRuntime>.Instance.OnGui += MouseInput.OnGUI;
	}

	// Token: 0x06001CE1 RID: 7393 RVA: 0x0001334B File Offset: 0x0001154B
	public static bool IsDoubleClick()
	{
		return Time.time - MouseInput.Previous.Time < 0.3f && MouseInput.Current.Point == MouseInput.Previous.Point;
	}

	// Token: 0x06001CE2 RID: 7394 RVA: 0x00013383 File Offset: 0x00011583
	public static bool IsMouseClickIn(Rect rect, int mouse = 0)
	{
		return Event.current.type == EventType.MouseDown && Event.current.button == mouse && rect.Contains(Event.current.mousePosition);
	}

	// Token: 0x06001CE3 RID: 7395 RVA: 0x00091684 File Offset: 0x0008F884
	private static void OnGUI()
	{
		if (Event.current.type == EventType.MouseDown)
		{
			MouseInput.Previous = MouseInput.Current;
			MouseInput.Current.Time = Time.time;
			MouseInput.Current.Point = Event.current.mousePosition;
			MouseInput.Current.Button = Event.current.button;
		}
	}

	// Token: 0x04001992 RID: 6546
	public const float DoubleClickInterval = 0.3f;

	// Token: 0x04001993 RID: 6547
	private static MouseInput.Click Current;

	// Token: 0x04001994 RID: 6548
	private static MouseInput.Click Previous;

	// Token: 0x020003DC RID: 988
	private struct Click
	{
		// Token: 0x04001995 RID: 6549
		public float Time;

		// Token: 0x04001996 RID: 6550
		public Vector2 Point;

		// Token: 0x04001997 RID: 6551
		public int Button;
	}
}
