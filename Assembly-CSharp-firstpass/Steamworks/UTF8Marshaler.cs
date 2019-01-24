using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks
{
	// Token: 0x0200009A RID: 154
	public class UTF8Marshaler : ICustomMarshaler
	{
		// Token: 0x0600041F RID: 1055 RVA: 0x000040CA File Offset: 0x000022CA
		private UTF8Marshaler(bool freenativememory)
		{
			this._freeNativeMemory = freenativememory;
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0000F37C File Offset: 0x0000D57C
		public IntPtr MarshalManagedToNative(object managedObj)
		{
			if (managedObj == null)
			{
				return IntPtr.Zero;
			}
			string text = managedObj as string;
			if (text == null)
			{
				throw new Exception("UTF8Marshaler must be used on a string.");
			}
			byte[] array = new byte[Encoding.UTF8.GetByteCount(text) + 1];
			Encoding.UTF8.GetBytes(text, 0, text.Length, array, 0);
			IntPtr intPtr = Marshal.AllocHGlobal(array.Length);
			Marshal.Copy(array, 0, intPtr, array.Length);
			return intPtr;
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x0000F3EC File Offset: 0x0000D5EC
		public object MarshalNativeToManaged(IntPtr pNativeData)
		{
			int num = 0;
			while (Marshal.ReadByte(pNativeData, num) != 0)
			{
				num++;
			}
			if (num == 0)
			{
				return string.Empty;
			}
			byte[] array = new byte[num];
			Marshal.Copy(pNativeData, array, 0, array.Length);
			return Encoding.UTF8.GetString(array);
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x000040F1 File Offset: 0x000022F1
		public void CleanUpNativeData(IntPtr pNativeData)
		{
			if (this._freeNativeMemory)
			{
				Marshal.FreeHGlobal(pNativeData);
			}
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00004074 File Offset: 0x00002274
		public void CleanUpManagedData(object managedObj)
		{
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00004104 File Offset: 0x00002304
		public int GetNativeDataSize()
		{
			return -1;
		}

		// This isn't used in either Assembly-CSharp or its own dll
		//public static ICustomMarshaler GetInstance(string cookie)
		//{
			/*if (cookie != null)
			{
				if (UTF8Marshaler. == null)
				{
					UTF8Marshaler.<>f__switch$map0 = new Dictionary<string, int>(1)
					{
						{
							"DoNotFree",
							0
						}
					};
				}
				int num;
				if (UTF8Marshaler.<>f__switch$map0.TryGetValue(cookie, out num))
				{
					if (num == 0)
					{
						return UTF8Marshaler.static_instance;
					}
				}
			}
			return UTF8Marshaler.static_instance_free;
            */
		//}

		// Token: 0x04000330 RID: 816
		public const string DoNotFree = "DoNotFree";

		// Token: 0x04000331 RID: 817
		private static UTF8Marshaler static_instance_free = new UTF8Marshaler(true);

		// Token: 0x04000332 RID: 818
		private static UTF8Marshaler static_instance = new UTF8Marshaler(false);

		// Token: 0x04000333 RID: 819
		private bool _freeNativeMemory;
	}
}
