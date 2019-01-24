using System;
using System.Collections;
using System.Collections.Generic;

namespace UberStrike.Realtime.UnitySdk
{
	// Token: 0x02000340 RID: 832
	public static class CrossdomainPolicy
	{
		// Token: 0x06001395 RID: 5013 RVA: 0x00022EA0 File Offset: 0x000210A0
		private static IEnumerator Default(string address, Action callback)
		{
			CrossdomainPolicy.SetPolicyValue(address, true);
			callback();
			yield break;
		}

		// Token: 0x06001396 RID: 5014 RVA: 0x00022ED0 File Offset: 0x000210D0
		public static bool HasValidPolicy(string address)
		{
			Dictionary<string, bool?> dict = CrossdomainPolicy._dict;
			bool? flag;
			lock (dict)
			{
				if (!CrossdomainPolicy._dict.TryGetValue(address, out flag))
				{
					return false;
				}
			}
			return flag != null && flag.Value;
		}

		// Token: 0x06001397 RID: 5015 RVA: 0x00022F3C File Offset: 0x0002113C
		public static bool HasPolicyEntry(string address)
		{
			Dictionary<string, bool?> dict = CrossdomainPolicy._dict;
			bool? flag;
			lock (dict)
			{
				CrossdomainPolicy._dict.TryGetValue(address, out flag);
			}
			return flag != null;
		}

		// Token: 0x06001398 RID: 5016 RVA: 0x00022F88 File Offset: 0x00021188
		public static void RemovePolicyEntry(string address)
		{
			Dictionary<string, bool?> dict = CrossdomainPolicy._dict;
			lock (dict)
			{
				CrossdomainPolicy._dict.Remove(address);
			}
		}

		// Token: 0x06001399 RID: 5017 RVA: 0x00022FCC File Offset: 0x000211CC
		public static void SetPolicyValue(string address, bool b)
		{
			Dictionary<string, bool?> dict = CrossdomainPolicy._dict;
			lock (dict)
			{
				CrossdomainPolicy._dict[address] = new bool?(b);
			}
		}

		// Token: 0x04000E07 RID: 3591
		private static Dictionary<string, bool?> _dict = new Dictionary<string, bool?>(20);

		// Token: 0x04000E08 RID: 3592
		public static Func<string, Action, IEnumerator> CheckPolicyRoutine = new Func<string, Action, IEnumerator>(CrossdomainPolicy.Default);
	}
}
