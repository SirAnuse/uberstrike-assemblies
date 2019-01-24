using System;
using System.IO;

namespace UberStrike.Core.Serialization.Utils
{
	// Token: 0x020002BB RID: 699
	public class DeltaCompression
	{
		// Token: 0x0600111A RID: 4378 RVA: 0x0001B064 File Offset: 0x00019264
		public static byte[] Deflate(byte[] baseData, byte[] newData)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				byte b = 0;
				for (int i = 0; i < newData.Length; i++)
				{
					if (i < baseData.Length)
					{
						if (baseData[i] == newData[i])
						{
							b += 1;
						}
						else
						{
							memoryStream.WriteByte(b);
							memoryStream.WriteByte(newData[i]);
							b = 0;
						}
					}
					else
					{
						memoryStream.WriteByte(newData[i]);
					}
				}
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x0600111B RID: 4379 RVA: 0x0001B0FC File Offset: 0x000192FC
		public static byte[] Inflate(byte[] baseData, byte[] delta)
		{
			if (delta.Length == 0)
			{
				return baseData;
			}
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				int num = 0;
				int i = 0;
				while (i < delta.Length)
				{
					if (num < baseData.Length)
					{
						int j = 0;
						while (j < (int)delta[i])
						{
							memoryStream.WriteByte(baseData[num]);
							j++;
							num++;
						}
						memoryStream.WriteByte(delta[i + 1]);
						num++;
						i += 2;
					}
					else
					{
						memoryStream.WriteByte(delta[i]);
						i++;
					}
				}
				result = memoryStream.ToArray();
			}
			return result;
		}
	}
}
