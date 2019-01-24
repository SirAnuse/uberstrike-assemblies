using System;
using UnityEngine;

namespace UberStrike.WebService.Unity
{
	// Token: 0x020002C2 RID: 706
	internal class MonoInstance : MonoBehaviour
	{
		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x0600112D RID: 4397 RVA: 0x0001B1E8 File Offset: 0x000193E8
		public static MonoBehaviour Mono
		{
			get
			{
				if (MonoInstance.mono == null)
				{
					GameObject gameObject = GameObject.Find("AutoMonoBehaviours");
					if (gameObject == null)
					{
						gameObject = new GameObject("AutoMonoBehaviours");
					}
					UnityEngine.Object.DontDestroyOnLoad(gameObject);
					MonoInstance.mono = gameObject.AddComponent<MonoInstance>();
				}
				return MonoInstance.mono;
			}
		}

		// Token: 0x04000CA5 RID: 3237
		private static MonoBehaviour mono;
	}
}
