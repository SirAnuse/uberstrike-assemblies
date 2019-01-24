using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020003D4 RID: 980
public static class KeyInput
{
	// Token: 0x06001CA3 RID: 7331 RVA: 0x0001310E File Offset: 0x0001130E
	static KeyInput()
	{
		AutoMonoBehaviour<UnityRuntime>.Instance.OnUpdate += KeyInput.Update;
		AutoMonoBehaviour<UnityRuntime>.Instance.OnGui += KeyInput.OnGUI;
	}

	// Token: 0x17000659 RID: 1625
	// (get) Token: 0x06001CA4 RID: 7332 RVA: 0x00013146 File Offset: 0x00011346
	// (set) Token: 0x06001CA5 RID: 7333 RVA: 0x0001314D File Offset: 0x0001134D
	public static bool AltPressed { get; private set; }

	// Token: 0x1700065A RID: 1626
	// (get) Token: 0x06001CA6 RID: 7334 RVA: 0x00013155 File Offset: 0x00011355
	// (set) Token: 0x06001CA7 RID: 7335 RVA: 0x0001315C File Offset: 0x0001135C
	public static bool CtrlPressed { get; private set; }

	// Token: 0x1700065B RID: 1627
	// (get) Token: 0x06001CA8 RID: 7336 RVA: 0x00013164 File Offset: 0x00011364
	// (set) Token: 0x06001CA9 RID: 7337 RVA: 0x0001316B File Offset: 0x0001136B
	public static KeyCode KeyPressed { get; private set; }

	// Token: 0x06001CAA RID: 7338 RVA: 0x00013173 File Offset: 0x00011373
	public static bool GetKeyDown(KeyCode key)
	{
		return KeyInput.KeyPressed == key;
	}

	// Token: 0x06001CAB RID: 7339 RVA: 0x000908E0 File Offset: 0x0008EAE0
	private static void Update()
	{
		if (KeyInput.keys.ContainsKey(KeyInput.LastKey) && KeyInput.keys[KeyInput.LastKey])
		{
			KeyInput.keys[KeyInput.LastKey] = false;
			KeyInput.KeyPressed = KeyInput.LastKey;
		}
		else
		{
			KeyInput.KeyPressed = KeyCode.None;
		}
		KeyInput.LastKey = KeyCode.None;
	}

	// Token: 0x06001CAC RID: 7340 RVA: 0x00090940 File Offset: 0x0008EB40
	private static void OnGUI()
	{
		KeyInput.AltPressed = Event.current.alt;
		KeyInput.CtrlPressed = Event.current.control;
		if (Event.current.type == EventType.KeyDown && Event.current.keyCode != KeyCode.None && !KeyInput.keys.ContainsKey(Event.current.keyCode))
		{
			KeyInput.keys[Event.current.keyCode] = true;
			KeyInput.LastKey = Event.current.keyCode;
		}
		else if (Event.current.type == EventType.KeyUp)
		{
			KeyInput.keys.Remove(Event.current.keyCode);
			KeyInput.LastKey = KeyCode.None;
		}
	}

	// Token: 0x0400197C RID: 6524
	private static Dictionary<KeyCode, bool> keys = new Dictionary<KeyCode, bool>();

	// Token: 0x0400197D RID: 6525
	private static KeyCode LastKey;
}
