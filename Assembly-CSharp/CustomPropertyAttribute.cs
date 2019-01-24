using System;

// Token: 0x0200023D RID: 573
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class CustomPropertyAttribute : Attribute
{
	// Token: 0x06000FD2 RID: 4050 RVA: 0x0000B28F File Offset: 0x0000948F
	public CustomPropertyAttribute(string name)
	{
		this.Name = name;
	}

	// Token: 0x170003B7 RID: 951
	// (get) Token: 0x06000FD3 RID: 4051 RVA: 0x0000B29E File Offset: 0x0000949E
	// (set) Token: 0x06000FD4 RID: 4052 RVA: 0x0000B2A6 File Offset: 0x000094A6
	public string Name { get; private set; }
}
