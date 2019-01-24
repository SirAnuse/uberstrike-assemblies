using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace UberStrike.Realtime.UnitySdk
{
	// Token: 0x0200034D RID: 845
	public static class TextUtility
	{
		// Token: 0x060013F3 RID: 5107 RVA: 0x00023D44 File Offset: 0x00021F44
		public static string ConvertText(string textToSecure)
		{
			string text = TextUtility.HtmlEncode(textToSecure);
			text = text.Replace("`", "&#96;");
			text = text.Replace("´", "&acute");
			text = text.Replace("'", "&#39");
			text = text.Replace("-", "&#45;");
			text = text.Replace("!", "&#33;");
			return text.Replace("?", "&#63;");
		}

		// Token: 0x060013F4 RID: 5108 RVA: 0x00023708 File Offset: 0x00021908
		public static string HtmlEncode(string text)
		{
			if (text == null)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder(text.Length);
			int length = text.Length;
			for (int i = 0; i < length; i++)
			{
				char c = text[i];
				switch (c)
				{
				case '<':
					stringBuilder.Append("&lt;");
					break;
				default:
					if (c != '"')
					{
						if (c != '&')
						{
							if (text[i] > '\u009f')
							{
								stringBuilder.Append("&#");
								stringBuilder.Append(((int)text[i]).ToString(CultureInfo.InvariantCulture));
								stringBuilder.Append(";");
							}
							else
							{
								stringBuilder.Append(text[i]);
							}
						}
						else
						{
							stringBuilder.Append("&amp;");
						}
					}
					else
					{
						stringBuilder.Append("&quot;");
					}
					break;
				case '>':
					stringBuilder.Append("&gt;");
					break;
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060013F5 RID: 5109 RVA: 0x0000C38B File Offset: 0x0000A58B
		public static string ProtectSqlField(string textToSecure)
		{
			return textToSecure.Replace("'", "''");
		}

		// Token: 0x060013F6 RID: 5110 RVA: 0x0002381C File Offset: 0x00021A1C
		public static string ConvertTextForJavaScript(string textToSecure)
		{
			string text = textToSecure.Replace("'", string.Empty);
			return text.Replace("|", string.Empty);
		}

		// Token: 0x060013F7 RID: 5111 RVA: 0x00023DC0 File Offset: 0x00021FC0
		public static long InetAToN(string addressIP)
		{
			long result = 0L;
			if (addressIP.Equals("::1"))
			{
				addressIP = "127.0.0.1";
			}
			if (!TextUtility.IsNullOrEmpty(addressIP))
			{
				string[] array = addressIP.ToString().Split(new char[]
				{
					'.'
				});
				if (array.Length == 4)
				{
					bool flag = true;
					int num = 0;
					long num2 = 0L;
					for (int i = array.Length - 1; i >= 0; i--)
					{
						bool flag2 = int.TryParse(array[i], out num);
						if (flag2 && num >= 0 && num < 256)
						{
							num2 += (long)(num % 256) * (long)Math.Pow(256.0, (double)(3 - i));
						}
						else
						{
							flag = false;
						}
					}
					if (flag)
					{
						result = num2;
					}
				}
			}
			return result;
		}

		// Token: 0x060013F8 RID: 5112 RVA: 0x00023920 File Offset: 0x00021B20
		public static string InetNToA(long networkAddress)
		{
			string result = string.Empty;
			if (networkAddress <= (long)-1)
			{
				long num = networkAddress / 16777216L;
				if (num == 0L)
				{
					num = 255L;
					networkAddress += 16777216L;
				}
				else if (num < 0L)
				{
					if (networkAddress % 16777216L == 0L)
					{
						num += 256L;
					}
					else
					{
						num += 255L;
						if (num == 128L)
						{
							networkAddress += (long)(int.MinValue);
						}
						else
						{
							networkAddress += 16777216L * (256L - num);
						}
					}
				}
				else
				{
					networkAddress -= 16777216L * num;
				}
				networkAddress %= 16777216L;
				long num2 = networkAddress / 65536L;
				networkAddress %= 65536L;
				long num3 = networkAddress / 256L;
				networkAddress %= 256L;
				long num4 = networkAddress;
				result = string.Concat(new string[]
				{
					num.ToString(),
					".",
					num2.ToString(),
					".",
					num3.ToString(),
					".",
					num4.ToString()
				});
			}
			return result;
		}

		// Token: 0x060013F9 RID: 5113 RVA: 0x00023E94 File Offset: 0x00022094
		public static bool IsNumeric(string numericText)
		{
			bool flag = true;
			if (!TextUtility.IsNullOrEmpty(numericText))
			{
				if (numericText.StartsWith("-"))
				{
					numericText = numericText.Replace("-", string.Empty);
				}
				foreach (char c in numericText)
				{
					flag = char.IsNumber(c);
					if (!flag)
					{
						return flag;
					}
				}
			}
			else
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x060013FA RID: 5114 RVA: 0x00023F08 File Offset: 0x00022108
		public static string ShortenText(string input, int maxSize, bool addPoints)
		{
			string text = input;
			if (maxSize < input.Length && maxSize > 3)
			{
				text = text.Substring(0, maxSize - 3);
				if (addPoints)
				{
					text += "...";
				}
			}
			return text;
		}

		// Token: 0x060013FB RID: 5115 RVA: 0x00023F48 File Offset: 0x00022148
		public static bool IsNullOrEmpty(string value)
		{
			bool result = true;
			if (!string.IsNullOrEmpty(value))
			{
				value = value.Trim();
				if (!string.IsNullOrEmpty(value))
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x060013FC RID: 5116 RVA: 0x00023F78 File Offset: 0x00022178
		public static List<int> IndexOfAll(string haystack, string needle)
		{
			int num = 0;
			List<int> list = new List<int>();
			if (!TextUtility.IsNullOrEmpty(haystack) && !TextUtility.IsNullOrEmpty(needle))
			{
				int length = needle.Length;
				int num2;
				do
				{
					num2 = haystack.IndexOf(needle);
					if (num2 > -1)
					{
						haystack = haystack.Substring(num2 + length);
						list.Add(num2 + num);
						num += num2 + length;
					}
				}
				while (num2 > -1 && !TextUtility.IsNullOrEmpty(haystack));
			}
			return list;
		}

		// Token: 0x060013FD RID: 5117 RVA: 0x00023BC8 File Offset: 0x00021DC8
		public static string Base64Encode(string data)
		{
			string result = string.Empty;
			if (data != null)
			{
				byte[] inArray = new byte[data.Length];
				inArray = Encoding.UTF8.GetBytes(data);
				result = Convert.ToBase64String(inArray);
			}
			return result;
		}

		// Token: 0x060013FE RID: 5118 RVA: 0x00023C04 File Offset: 0x00021E04
		public static string Base64Decode(string data)
		{
			string result = string.Empty;
			if (data != null)
			{
				UTF8Encoding utf8Encoding = new UTF8Encoding();
				Decoder decoder = utf8Encoding.GetDecoder();
				byte[] array = Convert.FromBase64String(data);
				int charCount = decoder.GetCharCount(array, 0, array.Length);
				char[] array2 = new char[charCount];
				decoder.GetChars(array, 0, array.Length, array2, 0);
				result = new string(array2);
			}
			return result;
		}

		// Token: 0x060013FF RID: 5119 RVA: 0x00023C60 File Offset: 0x00021E60
		public static byte[] StringToByteArray(string inputString)
		{
			UTF8Encoding utf8Encoding = new UTF8Encoding();
			return utf8Encoding.GetBytes(inputString);
		}

		// Token: 0x06001400 RID: 5120 RVA: 0x0000C3AD File Offset: 0x0000A5AD
		public static string CompleteTrim(string text)
		{
			if (text != null)
			{
				text = text.Trim();
				text = Regex.Replace(text, "\\s+", " ");
			}
			return text;
		}

		// Token: 0x06001401 RID: 5121 RVA: 0x00023C7C File Offset: 0x00021E7C
		public static bool TryParseFacebookId(string handle, out long facebookId)
		{
			bool result = false;
			facebookId = 0L;
			bool flag = long.TryParse(handle, out facebookId);
			if (flag && facebookId > 0L)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06001402 RID: 5122 RVA: 0x00023CAC File Offset: 0x00021EAC
		public static bool TryParseMySpaceId(string handle, out int mySpaceId)
		{
			bool result = false;
			mySpaceId = 0;
			bool flag = int.TryParse(handle, out mySpaceId);
			if (flag && mySpaceId > 0)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06001403 RID: 5123 RVA: 0x00023CAC File Offset: 0x00021EAC
		public static bool TryParseCyworldId(string handle, out int cyworldId)
		{
			bool result = false;
			cyworldId = 0;
			bool flag = int.TryParse(handle, out cyworldId);
			if (flag && cyworldId > 0)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06001404 RID: 5124 RVA: 0x00023CD8 File Offset: 0x00021ED8
		public static string Join<T>(string separator, List<T> list)
		{
			string result = string.Empty;
			if (list != null && list.Count > 0)
			{
				string[] array = new string[list.Count];
				for (int i = 0; i < list.Count; i++)
				{
					string[] array2 = array;
					int num = i;
					T t = list[i];
					array2[num] = t.ToString();
				}
				result = string.Join(separator, array);
			}
			return result;
		}
	}
}
