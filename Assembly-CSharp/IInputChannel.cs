using System;
using System.IO;

// Token: 0x020002BE RID: 702
public interface IInputChannel
{
	// Token: 0x170004A5 RID: 1189
	// (get) Token: 0x06001376 RID: 4982
	InputChannelType ChannelType { get; }

	// Token: 0x170004A6 RID: 1190
	// (get) Token: 0x06001377 RID: 4983
	string Name { get; }

	// Token: 0x170004A7 RID: 1191
	// (get) Token: 0x06001378 RID: 4984
	bool IsChanged { get; }

	// Token: 0x06001379 RID: 4985
	float RawValue();

	// Token: 0x170004A8 RID: 1192
	// (get) Token: 0x0600137A RID: 4986
	float Value { get; }

	// Token: 0x0600137B RID: 4987
	void Listen();

	// Token: 0x0600137C RID: 4988
	void Reset();

	// Token: 0x0600137D RID: 4989
	void Serialize(MemoryStream stream);
}
