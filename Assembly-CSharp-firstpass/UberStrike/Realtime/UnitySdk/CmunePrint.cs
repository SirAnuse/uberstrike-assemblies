using System;
using System.Collections;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace UberStrike.Realtime.UnitySdk
{
	// Token: 0x0200033B RID: 827
	public static class CmunePrint
	{
		// Token: 0x06001362 RID: 4962 RVA: 0x0002240C File Offset: 0x0002060C
		public static string Properties(object instance, bool publicOnly = true)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (instance == null)
			{
				stringBuilder.Append("[Class=null]");
			}
			else
			{
				stringBuilder.AppendFormat("[Class={0}] ", instance.GetType().Name);
				foreach (PropertyInfo propertyInfo in instance.GetType().GetProperties((!publicOnly) ? (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) : (BindingFlags.Instance | BindingFlags.Public)))
				{
					stringBuilder.AppendFormat("[{0}={1}],", propertyInfo.Name, CmunePrint.Object(propertyInfo.GetValue(instance, null)));
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06001363 RID: 4963 RVA: 0x000224A8 File Offset: 0x000206A8
		public static string Object(object value)
		{
			if (value == null)
			{
				return "null";
			}
			if (value is string)
			{
				return value as string;
			}
			if (value.GetType().IsValueType)
			{
				return value.ToString();
			}
			if (value is ICollection)
			{
				return CmunePrint.Values(new object[]
				{
					value
				});
			}
			return value.ToString();
		}

		// Token: 0x06001364 RID: 4964 RVA: 0x0002250C File Offset: 0x0002070C
		public static int GetHashCode(object obj)
		{
			if (obj == null)
			{
				return 0;
			}
			if (obj is ICollection)
			{
				int num = 0;
				foreach (object obj2 in (obj as ICollection))
				{
					num += obj2.GetHashCode();
				}
				return num;
			}
			return obj.GetHashCode();
		}

		// Token: 0x06001365 RID: 4965 RVA: 0x0000BEAF File Offset: 0x0000A0AF
		public static string Percent(float f)
		{
			return string.Format("{0:N0}%", Math.Round((double)(f * 100f)));
		}

		// Token: 0x06001366 RID: 4966 RVA: 0x0002258C File Offset: 0x0002078C
		public static string Order(int time)
		{
			if (time <= 0)
			{
				return time.ToString();
			}
			if (time == 1)
			{
				return "1st";
			}
			if (time == 2)
			{
				return "2nd";
			}
			if (time == 3)
			{
				return "3rd";
			}
			return time + "th";
		}

		// Token: 0x06001367 RID: 4967 RVA: 0x0000BECD File Offset: 0x0000A0CD
		public static string Time(DateTime time)
		{
			return time.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss.fffffffK");
		}

		// Token: 0x06001368 RID: 4968 RVA: 0x000225E0 File Offset: 0x000207E0
		public static string Time(TimeSpan s)
		{
			if (s.Days > 0)
			{
				return string.Format("{0:D1}d, {1:D2}:{2:D2}h", s.Days, s.Hours, s.Minutes);
			}
			if (s.Hours > 0)
			{
				return string.Format("{0:D2}:{1:D2}:{2:D2}", s.Hours, s.Minutes, s.Seconds);
			}
			if (s.Minutes > 0)
			{
				return string.Format("{0:D2}:{1:D2}", s.Minutes, s.Seconds);
			}
			if (s.Seconds > 10)
			{
				return string.Format("{0:D2}", s.Seconds);
			}
			return string.Format("{0:D1}", s.Seconds);
		}

		// Token: 0x06001369 RID: 4969 RVA: 0x0000BEDB File Offset: 0x0000A0DB
		public static string Time(int seconds)
		{
			return CmunePrint.Time(TimeSpan.FromSeconds((double)Math.Max(seconds, 0)));
		}

		// Token: 0x0600136A RID: 4970 RVA: 0x0000BEEF File Offset: 0x0000A0EF
		public static string Flag(sbyte flag)
		{
			return CmunePrint.Flag((uint)flag, 7);
		}

		// Token: 0x0600136B RID: 4971 RVA: 0x0000BEF9 File Offset: 0x0000A0F9
		public static string Flag(byte flag)
		{
			return CmunePrint.Flag((uint)flag, 7);
		}

		// Token: 0x0600136C RID: 4972 RVA: 0x0000BF02 File Offset: 0x0000A102
		public static string Flag(ushort flag)
		{
			return CmunePrint.Flag((uint)flag, 15);
		}

		// Token: 0x0600136D RID: 4973 RVA: 0x0000BF0C File Offset: 0x0000A10C
		public static string Flag(short flag)
		{
			return CmunePrint.Flag((uint)flag, 15);
		}

		// Token: 0x0600136E RID: 4974 RVA: 0x0000BF17 File Offset: 0x0000A117
		public static string Flag(int flag)
		{
			return CmunePrint.Flag((uint)flag, 31);
		}

		// Token: 0x0600136F RID: 4975 RVA: 0x0000BF17 File Offset: 0x0000A117
		public static string Flag(uint flag)
		{
			return CmunePrint.Flag(flag, 31);
		}

		// Token: 0x06001370 RID: 4976 RVA: 0x000226D0 File Offset: 0x000208D0
		public static string Flag<T>(T flag) where T : IConvertible
		{
			if (typeof(T).IsEnum)
			{
				return CmunePrint.Flag(Convert.ToUInt32(flag), typeof(T));
			}
			return CmunePrint.Flag(Convert.ToUInt32(flag), 31);
		}

		// Token: 0x06001371 RID: 4977 RVA: 0x00022720 File Offset: 0x00020920
		private static string Flag(uint flag, int bytes)
		{
			int num = 1 << bytes;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = bytes; i >= 0; i--)
			{
				stringBuilder.Append((((ulong)flag & (ulong)((long)num)) != 0UL) ? '1' : '0');
				if (i % 8 == 0)
				{
					stringBuilder.Append(' ');
				}
				flag <<= 1;
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06001372 RID: 4978 RVA: 0x00022784 File Offset: 0x00020984
		private static string Flag(uint flag, Type type)
		{
			Type underlyingType = Enum.GetUnderlyingType(type);
			string result;
			try
			{
				int num = 31;
				if (underlyingType == typeof(byte) || underlyingType == typeof(sbyte))
				{
					num = 7;
				}
				else if (underlyingType == typeof(short) || underlyingType == typeof(ushort))
				{
					num = 15;
				}
				int num2 = 1 << num;
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = num; i >= 0; i--)
				{
					if (underlyingType == typeof(byte))
					{
						if (((ulong)flag & (ulong)((long)num2)) != 0UL && Enum.IsDefined(type, (byte)(1 << i)))
						{
							stringBuilder.Append(Enum.GetName(type, 1 << i) + " ");
						}
					}
					else if (underlyingType == typeof(ushort))
					{
						if (((ulong)flag & (ulong)((long)num2)) != 0UL && Enum.IsDefined(type, (ushort)(1 << i)))
						{
							stringBuilder.Append(Enum.GetName(type, 1 << i) + " ");
						}
					}
					else if (((ulong)flag & (ulong)((long)num2)) != 0UL && Enum.IsDefined(type, 1 << i))
					{
						stringBuilder.Append(Enum.GetName(type, 1 << i) + " ");
					}
					flag <<= 1;
				}
				result = stringBuilder.ToString();
			}
			catch
			{
				result = type.Name + " unsupported: " + underlyingType;
			}
			return result;
		}

		// Token: 0x06001373 RID: 4979 RVA: 0x00022954 File Offset: 0x00020B54
		public static string Values(params object[] args)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (args != null)
			{
				if (args.Length == 0)
				{
					stringBuilder.Append("EMPTY");
				}
				else
				{
					for (int i = 0; i < args.Length; i++)
					{
						object obj = args[i];
						if (obj != null)
						{
							if (obj is IEnumerable)
							{
								IEnumerable enumerable = obj as IEnumerable;
								stringBuilder.Append("|");
								IEnumerator enumerator = enumerable.GetEnumerator();
								int num = 0;
								while (enumerator.MoveNext() && num < 50)
								{
									if (enumerator.Current != null)
									{
										stringBuilder.AppendFormat("{0}|", enumerator.Current);
									}
									else
									{
										stringBuilder.Append("null|");
									}
									num++;
								}
								if (num == 0)
								{
									stringBuilder.Append("empty|");
								}
								else if (num == 50)
								{
									stringBuilder.Append("...");
								}
							}
							else
							{
								stringBuilder.AppendFormat("{0}", obj);
							}
						}
						else
						{
							stringBuilder.AppendFormat("null", new object[0]);
						}
						if (i < args.Length - 1)
						{
							stringBuilder.AppendFormat(", ", new object[0]);
						}
					}
				}
			}
			else
			{
				stringBuilder.Append("NULL");
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06001374 RID: 4980 RVA: 0x00022AA8 File Offset: 0x00020CA8
		public static string Types(params object[] args)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (args != null)
			{
				if (args.Length == 0)
				{
					stringBuilder.Append("EMPTY");
				}
				else
				{
					for (int i = 0; i < args.Length; i++)
					{
						object obj = args[i];
						if (obj != null)
						{
							if (obj is ICollection)
							{
								ICollection collection = obj as ICollection;
								stringBuilder.AppendFormat("{0}({1})", collection.GetType().Name, collection.Count);
							}
							else
							{
								stringBuilder.AppendFormat("{0}", obj.GetType().Name);
							}
						}
						else
						{
							stringBuilder.AppendFormat("null", new object[0]);
						}
						if (i < args.Length - 1)
						{
							stringBuilder.AppendFormat(", ", new object[0]);
						}
					}
				}
			}
			else
			{
				stringBuilder.Append("NULL");
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06001375 RID: 4981 RVA: 0x00022B94 File Offset: 0x00020D94
		public static string Dictionary(IDictionary t)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (object obj in t)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				stringBuilder.AppendFormat("{0}: {1}\n", dictionaryEntry.Key, dictionaryEntry.Value);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06001376 RID: 4982 RVA: 0x0000BF21 File Offset: 0x0000A121
		public static void DebugBitString(byte[] x)
		{
			Debug.Log(CmunePrint.BitString(x));
		}

		// Token: 0x06001377 RID: 4983 RVA: 0x0000BF2E File Offset: 0x0000A12E
		public static void DebugBitString(int x)
		{
			Debug.Log(CmunePrint.BitString(x));
		}

		// Token: 0x06001378 RID: 4984 RVA: 0x0000BF3B File Offset: 0x0000A13B
		public static void DebugBitString(string x)
		{
			Debug.Log(CmunePrint.BitString(x));
		}

		// Token: 0x06001379 RID: 4985 RVA: 0x0000BF48 File Offset: 0x0000A148
		public static void DebugBitString(byte x)
		{
			Debug.Log(CmunePrint.BitString(x));
		}

		// Token: 0x0600137A RID: 4986 RVA: 0x00022C14 File Offset: 0x00020E14
		public static string BitString(byte x)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i <= (int)CmunePrint._byteBitCountConstant; i++)
			{
				stringBuilder.Append(((x & CmunePrint._byteBitMaskConstant) != 0) ? '1' : '0');
				x = (byte)(x << 1);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600137B RID: 4987 RVA: 0x0000BF55 File Offset: 0x0000A155
		public static string BitString(int x)
		{
			return CmunePrint.BitString(BitConverter.GetBytes(x));
		}

		// Token: 0x0600137C RID: 4988 RVA: 0x0000BF62 File Offset: 0x0000A162
		public static string BitString(string x)
		{
			return CmunePrint.BitString(Encoding.Unicode.GetBytes(x));
		}

		// Token: 0x0600137D RID: 4989 RVA: 0x00022C68 File Offset: 0x00020E68
		public static string BitString(byte[] bytes)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = bytes.Length - 1; i >= 0; i--)
			{
				stringBuilder.Append(CmunePrint.BitString(bytes[i])).Append(' ');
			}
			return stringBuilder.ToString();
		}

		// Token: 0x04000E03 RID: 3587
		private static readonly byte _byteBitCountConstant = 7;

		// Token: 0x04000E04 RID: 3588
		private static readonly byte _byteBitMaskConstant = 128;
	}
}
