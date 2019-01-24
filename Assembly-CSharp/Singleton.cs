using System;
using System.Reflection;

// Token: 0x020003FC RID: 1020
public class Singleton<T> : IDisposable where T : Singleton<T>
{
	// Token: 0x1700066C RID: 1644
	// (get) Token: 0x06001D59 RID: 7513 RVA: 0x00091F54 File Offset: 0x00090154
	public static T Instance
	{
		get
		{
			if (Singleton<T>._instance == null)
			{
				object @lock = Singleton<T>._lock;
				lock (@lock)
				{
					if (Singleton<T>._instance == null)
					{
						ConstructorInfo constructor = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[0], null);
						if (constructor == null || constructor.IsAssembly)
						{
							throw new Exception(string.Format("A private or protected constructor is missing for '{0}'.", typeof(T).Name));
						}
						Singleton<T>._instance = (T)((object)constructor.Invoke(null));
					}
				}
			}
			return Singleton<T>._instance;
		}
	}

	// Token: 0x06001D5A RID: 7514 RVA: 0x00013867 File Offset: 0x00011A67
	public void Dispose()
	{
		this.OnDispose();
		Singleton<T>._instance = (T)((object)null);
	}

	// Token: 0x06001D5B RID: 7515 RVA: 0x00003C87 File Offset: 0x00001E87
	protected virtual void OnDispose()
	{
	}

	// Token: 0x040019CD RID: 6605
	private static volatile T _instance;

	// Token: 0x040019CE RID: 6606
	private static object _lock = new object();
}
