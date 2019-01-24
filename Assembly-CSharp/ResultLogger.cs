using System;
using System.Collections;
using System.Text;
using UnityEngine;

// Token: 0x020003AA RID: 938
public class ResultLogger : UnityEngine.Object
{
	// Token: 0x06001B9C RID: 7068 RVA: 0x0008DF24 File Offset: 0x0008C124
	public static void logObject(object result)
	{
		if (result == null)
		{
			Debug.Log("attempting to log a null object");
			return;
		}
		if (result.GetType() == typeof(ArrayList))
		{
			ResultLogger.logArraylist((ArrayList)result);
		}
		else if (result.GetType() == typeof(Hashtable))
		{
			ResultLogger.logHashtable((Hashtable)result);
		}
		else
		{
			Debug.Log("result is not a hashtable or arraylist");
		}
	}

	// Token: 0x06001B9D RID: 7069 RVA: 0x0008DF98 File Offset: 0x0008C198
	public static void logArraylist(ArrayList result)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (object obj in result)
		{
			Hashtable item = (Hashtable)obj;
			ResultLogger.addHashtableToString(stringBuilder, item);
			stringBuilder.Append("\n--------------------\n");
		}
		Debug.Log(stringBuilder.ToString());
	}

	// Token: 0x06001B9E RID: 7070 RVA: 0x0008E014 File Offset: 0x0008C214
	public static void logHashtable(Hashtable result)
	{
		StringBuilder stringBuilder = new StringBuilder();
		ResultLogger.addHashtableToString(stringBuilder, result);
		Debug.Log(stringBuilder.ToString());
	}

	// Token: 0x06001B9F RID: 7071 RVA: 0x0008E03C File Offset: 0x0008C23C
	public static void addHashtableToString(StringBuilder builder, Hashtable item)
	{
		foreach (object obj in item)
		{
			DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
			if (dictionaryEntry.Value is Hashtable)
			{
				builder.AppendFormat("{0}: ", dictionaryEntry.Key);
				ResultLogger.addHashtableToString(builder, (Hashtable)dictionaryEntry.Value);
			}
			else if (dictionaryEntry.Value is ArrayList)
			{
				builder.AppendFormat("{0}: ", dictionaryEntry.Key);
				ResultLogger.addArraylistToString(builder, (ArrayList)dictionaryEntry.Value);
			}
			else
			{
				builder.AppendFormat("{0}: {1}\n", dictionaryEntry.Key, dictionaryEntry.Value);
			}
		}
	}

	// Token: 0x06001BA0 RID: 7072 RVA: 0x0008E124 File Offset: 0x0008C324
	public static void addArraylistToString(StringBuilder builder, ArrayList result)
	{
		foreach (object obj in result)
		{
			if (obj is Hashtable)
			{
				ResultLogger.addHashtableToString(builder, (Hashtable)obj);
			}
			else if (obj is ArrayList)
			{
				ResultLogger.addArraylistToString(builder, (ArrayList)obj);
			}
			builder.Append("\n--------------------\n");
		}
	}
}
