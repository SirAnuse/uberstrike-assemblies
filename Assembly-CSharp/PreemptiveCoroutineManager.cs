using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x020002DA RID: 730
public class PreemptiveCoroutineManager : Singleton<PreemptiveCoroutineManager>
{
	// Token: 0x060014EE RID: 5358 RVA: 0x0000E0E8 File Offset: 0x0000C2E8
	private PreemptiveCoroutineManager()
	{
		this.coroutineFuncIds = new Dictionary<PreemptiveCoroutineManager.CoroutineFunction, int>();
	}

	// Token: 0x060014EF RID: 5359 RVA: 0x00076C40 File Offset: 0x00074E40
	public int IncrementId(PreemptiveCoroutineManager.CoroutineFunction func)
	{
		if (this.coroutineFuncIds.ContainsKey(func))
		{
			Dictionary<PreemptiveCoroutineManager.CoroutineFunction, int> dictionary2;
			Dictionary<PreemptiveCoroutineManager.CoroutineFunction, int> dictionary = dictionary2 = this.coroutineFuncIds;
			int num = dictionary2[func];
			return dictionary[func] = num + 1;
		}
		return this.ResetCoroutineId(func);
	}

	// Token: 0x060014F0 RID: 5360 RVA: 0x0000E0FB File Offset: 0x0000C2FB
	public bool IsCurrent(PreemptiveCoroutineManager.CoroutineFunction func, int coroutineId)
	{
		return this.coroutineFuncIds.ContainsKey(func) && this.coroutineFuncIds[func] == coroutineId;
	}

	// Token: 0x060014F1 RID: 5361 RVA: 0x0000E11F File Offset: 0x0000C31F
	public int ResetCoroutineId(PreemptiveCoroutineManager.CoroutineFunction func)
	{
		this.coroutineFuncIds[func] = 0;
		return 0;
	}

	// Token: 0x040013D2 RID: 5074
	private Dictionary<PreemptiveCoroutineManager.CoroutineFunction, int> coroutineFuncIds;

	// Token: 0x020002DB RID: 731
	// (Invoke) Token: 0x060014F3 RID: 5363
	public delegate IEnumerator CoroutineFunction();
}
