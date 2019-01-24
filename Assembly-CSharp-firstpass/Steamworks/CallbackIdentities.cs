using System;

namespace Steamworks
{
	// Token: 0x02000078 RID: 120
	internal class CallbackIdentities
	{
		// Token: 0x060003A0 RID: 928 RVA: 0x0000EC60 File Offset: 0x0000CE60
		public static int GetCallbackIdentity(Type callbackStruct)
		{
			object[] customAttributes = callbackStruct.GetCustomAttributes(typeof(CallbackIdentityAttribute), false);
			int num = 0;
			if (num >= customAttributes.Length)
			{
				throw new Exception("Callback number not found for struct " + callbackStruct);
			}
			CallbackIdentityAttribute callbackIdentityAttribute = (CallbackIdentityAttribute)customAttributes[num];
			return callbackIdentityAttribute.Identity;
		}
	}
}
