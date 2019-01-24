using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UberStrike.Realtime.Client;
using UnityEngine;

// Token: 0x0200039B RID: 923
public class RealtimeUnitTest : AutoMonoBehaviour<RealtimeUnitTest>
{
	// Token: 0x06001B49 RID: 6985 RVA: 0x00012150 File Offset: 0x00010350
	private RealtimeUnitTest()
	{
		this.methodCalls = new Dictionary<string, List<RealtimeUnitTest.RemoteCall>>();
	}

	// Token: 0x06001B4A RID: 6986 RVA: 0x0008C7AC File Offset: 0x0008A9AC
	private void OnGUI()
	{
		string[] array = this.methodCalls.KeyArray<string, List<RealtimeUnitTest.RemoteCall>>();
		GUILayout.BeginArea(new Rect(0f, 100f, (float)Screen.width, (float)(Screen.height - 100)));
		this.index = GUILayout.SelectionGrid(this.index, array, array.Length, new GUILayoutOption[0]);
		if (this.index < array.Length)
		{
			this.scroll = GUILayout.BeginScrollView(this.scroll, new GUILayoutOption[0]);
			List<RealtimeUnitTest.RemoteCall> list = this.methodCalls[array[this.index]];
			foreach (RealtimeUnitTest.RemoteCall remoteCall in list)
			{
				if (GUILayout.Button(remoteCall.debug, new GUILayoutOption[0]))
				{
					remoteCall.method.Invoke(remoteCall.target, remoteCall.arguments);
				}
			}
			GUILayout.EndScrollView();
		}
		GUILayout.EndArea();
	}

	// Token: 0x06001B4B RID: 6987 RVA: 0x0008C8B8 File Offset: 0x0008AAB8
	public void Add(IOperationSender target)
	{
		List<RealtimeUnitTest.RemoteCall> list;
		if (!this.methodCalls.TryGetValue(target.GetType().Name, out list))
		{
			list = new List<RealtimeUnitTest.RemoteCall>();
			this.methodCalls[target.GetType().Name] = list;
		}
		MethodInfo[] methods = target.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public);
		foreach (MethodInfo methodInfo in methods)
		{
			if (methodInfo.Name.StartsWith("Send"))
			{
				list.Add(new RealtimeUnitTest.RemoteCall(target, methodInfo));
			}
		}
	}

	// Token: 0x06001B4C RID: 6988 RVA: 0x0008C950 File Offset: 0x0008AB50
	public void Add(IEventDispatcher target)
	{
		List<RealtimeUnitTest.RemoteCall> list;
		if (!this.methodCalls.TryGetValue(target.GetType().Name, out list))
		{
			list = new List<RealtimeUnitTest.RemoteCall>();
			this.methodCalls[target.GetType().Name] = list;
		}
		MethodInfo[] methods = target.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
		foreach (MethodInfo methodInfo in methods)
		{
			if (methodInfo.Name.StartsWith("On"))
			{
				list.Add(new RealtimeUnitTest.RemoteCall(target, methodInfo));
			}
		}
	}

	// Token: 0x0400184E RID: 6222
	private Dictionary<string, List<RealtimeUnitTest.RemoteCall>> methodCalls;

	// Token: 0x0400184F RID: 6223
	private int index;

	// Token: 0x04001850 RID: 6224
	private Vector2 scroll;

	// Token: 0x0200039C RID: 924
	private class RemoteCall
	{
		// Token: 0x06001B4D RID: 6989 RVA: 0x0008C9E8 File Offset: 0x0008ABE8
		public RemoteCall(object target, MethodInfo method)
		{
			this.target = target;
			this.method = method;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(method.Name).Append("(");
			List<object> list = new List<object>();
			foreach (ParameterInfo parameterInfo in method.GetParameters())
			{
				list.Add(RealtimeUnitTest.RemoteCall.CreateArgument(parameterInfo.ParameterType));
				stringBuilder.Append(parameterInfo.ParameterType.Name).Append(":").Append(RealtimeUnitTest.RemoteCall.CreateArgument(parameterInfo.ParameterType)).Append(" ");
			}
			stringBuilder.Append(")");
			this.arguments = list.ToArray();
			this.debug = stringBuilder.ToString();
		}

		// Token: 0x17000615 RID: 1557
		// (get) Token: 0x06001B4E RID: 6990 RVA: 0x00012163 File Offset: 0x00010363
		// (set) Token: 0x06001B4F RID: 6991 RVA: 0x0001216B File Offset: 0x0001036B
		public object target { get; private set; }

		// Token: 0x17000616 RID: 1558
		// (get) Token: 0x06001B50 RID: 6992 RVA: 0x00012174 File Offset: 0x00010374
		// (set) Token: 0x06001B51 RID: 6993 RVA: 0x0001217C File Offset: 0x0001037C
		public MethodInfo method { get; private set; }

		// Token: 0x17000617 RID: 1559
		// (get) Token: 0x06001B52 RID: 6994 RVA: 0x00012185 File Offset: 0x00010385
		// (set) Token: 0x06001B53 RID: 6995 RVA: 0x0001218D File Offset: 0x0001038D
		public object[] arguments { get; private set; }

		// Token: 0x17000618 RID: 1560
		// (get) Token: 0x06001B54 RID: 6996 RVA: 0x00012196 File Offset: 0x00010396
		// (set) Token: 0x06001B55 RID: 6997 RVA: 0x0001219E File Offset: 0x0001039E
		public string debug { get; private set; }

		// Token: 0x06001B56 RID: 6998 RVA: 0x000121A7 File Offset: 0x000103A7
		private static object CreateArgument(Type t)
		{
			if (t.IsGenericType)
			{
				return Activator.CreateInstance(t);
			}
			if (t == typeof(string))
			{
				return "asdf";
			}
			if (t.IsClass)
			{
				return null;
			}
			return Activator.CreateInstance(t);
		}
	}
}
