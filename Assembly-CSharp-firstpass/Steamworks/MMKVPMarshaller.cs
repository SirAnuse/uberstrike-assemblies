using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200009B RID: 155
	public class MMKVPMarshaller
	{
		// Token: 0x06000427 RID: 1063 RVA: 0x0000F49C File Offset: 0x0000D69C
		public MMKVPMarshaller(MatchMakingKeyValuePair_t[] filters)
		{
			if (filters == null)
			{
				return;
			}
			int num = Marshal.SizeOf(typeof(MatchMakingKeyValuePair_t));
			this.m_pNativeArray = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)) * filters.Length);
			this.m_pArrayEntries = Marshal.AllocHGlobal(num * filters.Length);
			for (int i = 0; i < filters.Length; i++)
			{
				Marshal.StructureToPtr(filters[i], new IntPtr(this.m_pArrayEntries.ToInt64() + (long)(i * num)), false);
			}
			Marshal.WriteIntPtr(this.m_pNativeArray, this.m_pArrayEntries);
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0000F548 File Offset: 0x0000D748
		~MMKVPMarshaller()
		{
			if (this.m_pArrayEntries != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.m_pArrayEntries);
			}
			if (this.m_pNativeArray != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.m_pNativeArray);
			}
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x00004107 File Offset: 0x00002307
		public static implicit operator IntPtr(MMKVPMarshaller that)
		{
			return that.m_pNativeArray;
		}

		// Token: 0x04000335 RID: 821
		private IntPtr m_pNativeArray;

		// Token: 0x04000336 RID: 822
		private IntPtr m_pArrayEntries;
	}
}
