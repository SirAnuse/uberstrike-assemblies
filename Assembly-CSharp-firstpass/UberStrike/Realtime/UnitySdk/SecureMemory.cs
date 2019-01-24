using System;
using System.IO;
using UberStrike.Core.Serialization;

namespace UberStrike.Realtime.UnitySdk
{
	// Token: 0x02000349 RID: 841
	public class SecureMemory<T>
	{
		// Token: 0x060013CD RID: 5069 RVA: 0x000233A0 File Offset: 0x000215A0
		public SecureMemory(T value, bool monitorMemory = true, bool useAOTCompatibleMode = false)
		{
			this._useAOTCompatibleMode = useAOTCompatibleMode;
			if (this._useAOTCompatibleMode)
			{
				this._cachedValue = value;
			}
			else
			{
				this.WriteData(value);
				if (monitorMemory)
				{
					SecureMemoryMonitor.Instance.AddToMonitor += this.ValidateData;
				}
			}
		}

		// Token: 0x060013CE RID: 5070 RVA: 0x0000C285 File Offset: 0x0000A485
		public void ReleaseData(SecureMemory<T> instance)
		{
			if (!this._useAOTCompatibleMode && instance != null)
			{
				SecureMemoryMonitor.Instance.AddToMonitor -= instance.ValidateData;
			}
		}

		// Token: 0x060013CF RID: 5071 RVA: 0x0000C2AE File Offset: 0x0000A4AE
		public void SimulateMemoryHack(T value)
		{
			this._cachedValue = value;
		}

		// Token: 0x060013D0 RID: 5072 RVA: 0x000233F4 File Offset: 0x000215F4
		public void WriteData(T value)
		{
			try
			{
				this._cachedValue = value;
				if (!this._useAOTCompatibleMode)
				{
					this._encryptedData = Cryptography.RijndaelEncrypt(this.Serialize(value), "h&dk2Ks901HenM", "huSj39Dl)2kJ4nat");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(string.Format("SecureMemory failed encrypting Data: {0}", ex.Message), ex.InnerException);
			}
		}

		// Token: 0x060013D1 RID: 5073 RVA: 0x0000C2B7 File Offset: 0x0000A4B7
		public void ValidateData()
		{
			if (!Comparison.IsEqual(this._cachedValue, this.DecryptValue()))
			{
				throw new Exception("Failed to validate data due to a corrupted memory");
			}
		}

		// Token: 0x060013D2 RID: 5074 RVA: 0x0000C2E4 File Offset: 0x0000A4E4
		public object ReadObject(bool secure)
		{
			return this.ReadData(secure);
		}

		// Token: 0x060013D3 RID: 5075 RVA: 0x0000C2F2 File Offset: 0x0000A4F2
		public T ReadData(bool secure)
		{
			if (secure)
			{
				this._cachedValue = this.DecryptValue();
			}
			return this._cachedValue;
		}

		// Token: 0x060013D4 RID: 5076 RVA: 0x00023468 File Offset: 0x00021668
		private T DecryptValue()
		{
			if (this._useAOTCompatibleMode)
			{
				return this._cachedValue;
			}
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

		// Token: 0x060013D5 RID: 5077 RVA: 0x00023510 File Offset: 0x00021710
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

		// Token: 0x060013D6 RID: 5078 RVA: 0x000235CC File Offset: 0x000217CC
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

		// Token: 0x04000E21 RID: 3617
		private const string pp = "h&dk2Ks901HenM";

		// Token: 0x04000E22 RID: 3618
		private const string iv = "huSj39Dl)2kJ4nat";

		// Token: 0x04000E23 RID: 3619
		private byte[] _encryptedData;

		// Token: 0x04000E24 RID: 3620
		private T _cachedValue;

		// Token: 0x04000E25 RID: 3621
		private bool _useAOTCompatibleMode;
	}
}
