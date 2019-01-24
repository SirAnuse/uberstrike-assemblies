using System;
using System.Collections;

namespace UberStrike.Realtime.UnitySdk
{
	// Token: 0x0200033D RID: 829
	public static class Comparison
	{
		// Token: 0x06001381 RID: 4993 RVA: 0x00022CB0 File Offset: 0x00020EB0
		public static bool IsEqual(object a, object b)
		{
			if (object.ReferenceEquals(a, b))
			{
				return true;
			}
			if (a == null || b == null)
			{
				return false;
			}
			if (a is ICollection && b is ICollection)
			{
				return Comparison.IsSequenceEqual(a as ICollection, b as ICollection);
			}
			return a.Equals(b);
		}

		// Token: 0x06001382 RID: 4994 RVA: 0x00022D08 File Offset: 0x00020F08
		private static bool IsSequenceEqual(ICollection a1, ICollection a2)
		{
			if (a1 != null && a2 != null)
			{
				bool flag = true;
				IEnumerator enumerator = a1.GetEnumerator();
				IEnumerator enumerator2 = a2.GetEnumerator();
				while (flag && enumerator.MoveNext() && enumerator2.MoveNext())
				{
					if (enumerator.Current is ICollection && enumerator2.Current is ICollection)
					{
						flag = Comparison.IsSequenceEqual(enumerator.Current as ICollection, enumerator2.Current as ICollection);
					}
					else
					{
						flag = (enumerator.Current != null && enumerator.Current.Equals(enumerator2.Current));
					}
				}
				return flag;
			}
			return false;
		}
	}
}
