using System;
using System.IO;
using UberStrike.Core.Serialization;
using UberStrike.Realtime.UnitySdk;

// Token: 0x020003A5 RID: 933
public class SecureMemory<T>
{
	// Token: 0x06001B84 RID: 7044 RVA: 0x0001234A File Offset: 0x0001054A
	public SecureMemory(T value)
	{
		this.WriteData(value);
	}

	// Token: 0x06001B85 RID: 7045 RVA: 0x0008D66C File Offset: 0x0008B86C
	public void WriteData(T value)
	{
		try
		{
			this._cachedValue = value;
			this._encryptedData = Cryptography.RijndaelEncrypt(this.Serialize(value), "h&dk2Ks901HenM", "huSj39Dl)2kJ4nat");
		}
		catch (Exception ex)
		{
			throw new Exception(string.Format("SecureMemory failed encrypting Data: {0}", ex.Message), ex.InnerException);
		}
	}

	// Token: 0x06001B86 RID: 7046 RVA: 0x00012359 File Offset: 0x00010559
	public void ValidateData()
	{
		if (!Comparison.IsEqual(this._cachedValue, this.DecryptValue()))
		{
			throw new Exception("Failed to validate data due to a corrupted memory");
		}
	}

	// Token: 0x06001B87 RID: 7047 RVA: 0x00012386 File Offset: 0x00010586
	public object ReadObject(bool secure)
	{
		return this.ReadData(secure);
	}

	// Token: 0x06001B88 RID: 7048 RVA: 0x00012394 File Offset: 0x00010594
	public T ReadData(bool secure)
	{
		if (secure)
		{
			this._cachedValue = this.DecryptValue();
		}
		return this._cachedValue;
	}

	// Token: 0x06001B89 RID: 7049 RVA: 0x0008D6D4 File Offset: 0x0008B8D4
	private T DecryptValue()
	{
		T result;
		try
		{
			byte[] array = Cryptography.RijndaelDecrypt(this._encryptedData, "h&dk2Ks901HenM", "huSj39Dl)2kJ4nat");
			if (array == null)
			{
				throw new Exception("SecureMemory failed decrypting Data becauase CmuneSecurity.Decrypt returned NULL");
			}
			object obj = this.Deserialize(array);
			if (obj == null)
			{
				throw new Exception("SecureMemory failed decrypting Data becauase RealtimeSerialization.ToObject returned NULL");
			}
			result = (T)((object)obj);
		}
		catch (Exception ex)
		{
			throw new Exception(string.Format("SecureMemory failed decrypting Data: {0}", ex.Message), ex.InnerException);
		}
		return result;
	}

	// Token: 0x06001B8A RID: 7050 RVA: 0x0008D76C File Offset: 0x0008B96C
	private byte[] Serialize(T obj)
	{
		byte[] result;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			Type typeFromHandle = typeof(T);
			if (typeFromHandle == typeof(int))
			{
				Int32Proxy.Serialize(memoryStream, (int)((object)obj));
			}
			else if (typeFromHandle == typeof(float))
			{
				SingleProxy.Serialize(memoryStream, (float)((object)obj));
			}
			else if (typeFromHandle == typeof(string))
			{
				StringProxy.Serialize(memoryStream, (string)((object)obj));
			}
			result = memoryStream.ToArray();
		}
		return result;
	}

	// Token: 0x06001B8B RID: 7051 RVA: 0x0008D828 File Offset: 0x0008BA28
	private T Deserialize(byte[] bytes)
	{
		T result;
		using (MemoryStream memoryStream = new MemoryStream(bytes))
		{
			Type typeFromHandle = typeof(T);
			if (typeFromHandle == typeof(int))
			{
				result = (T)((object)Int32Proxy.Deserialize(memoryStream));
			}
			else if (typeFromHandle == typeof(float))
			{
				result = (T)((object)SingleProxy.Deserialize(memoryStream));
			}
			else if (typeFromHandle == typeof(string))
			{
				result = (T)((object)StringProxy.Deserialize(memoryStream));
			}
			else
			{
				result = default(T);
			}
		}
		return result;
	}

	// Token: 0x0400188A RID: 6282
	private const string pp = "h&dk2Ks901HenM";

	// Token: 0x0400188B RID: 6283
	private const string iv = "huSj39Dl)2kJ4nat";

	// Token: 0x0400188C RID: 6284
	private byte[] _encryptedData;

	// Token: 0x0400188D RID: 6285
	private T _cachedValue;
}
