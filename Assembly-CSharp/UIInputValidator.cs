using System;
using UnityEngine;

// Token: 0x0200002B RID: 43
[RequireComponent(typeof(UIInput))]
[AddComponentMenu("NGUI/Interaction/Input Validator")]
public class UIInputValidator : MonoBehaviour
{
	// Token: 0x060000E1 RID: 225 RVA: 0x00002D76 File Offset: 0x00000F76
	private void Start()
	{
		base.GetComponent<UIInput>().validator = new UIInput.Validator(this.Validate);
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x00019B9C File Offset: 0x00017D9C
	private char Validate(string text, char ch)
	{
		if (this.logic == UIInputValidator.Validation.None || !base.enabled)
		{
			return ch;
		}
		if (this.logic == UIInputValidator.Validation.Integer)
		{
			if (ch >= '0' && ch <= '9')
			{
				return ch;
			}
			if (ch == '-' && text.Length == 0)
			{
				return ch;
			}
		}
		else if (this.logic == UIInputValidator.Validation.Float)
		{
			if (ch >= '0' && ch <= '9')
			{
				return ch;
			}
			if (ch == '-' && text.Length == 0)
			{
				return ch;
			}
			if (ch == '.' && !text.Contains("."))
			{
				return ch;
			}
		}
		else if (this.logic == UIInputValidator.Validation.Alphanumeric)
		{
			if (ch >= 'A' && ch <= 'Z')
			{
				return ch;
			}
			if (ch >= 'a' && ch <= 'z')
			{
				return ch;
			}
			if (ch >= '0' && ch <= '9')
			{
				return ch;
			}
		}
		else if (this.logic == UIInputValidator.Validation.Username)
		{
			if (ch >= 'A' && ch <= 'Z')
			{
				return Convert.ToChar(ch - 'A' + 'a');
			}
			if (ch >= 'a' && ch <= 'z')
			{
				return ch;
			}
			if (ch >= '0' && ch <= '9')
			{
				return ch;
			}
		}
		else if (this.logic == UIInputValidator.Validation.Name)
		{
			char c = (text.Length <= 0) ? ' ' : text[text.Length - 1];
			if (ch >= 'a' && ch <= 'z')
			{
				if (c == ' ')
				{
					return Convert.ToChar(ch - 'a' + 'A');
				}
				return ch;
			}
			else if (ch >= 'A' && ch <= 'Z')
			{
				if (c != ' ' && c != '\'')
				{
					return Convert.ToChar(ch - 'A' + 'a');
				}
				return ch;
			}
			else if (ch == '\'')
			{
				if (c != ' ' && c != '\'' && !text.Contains("'"))
				{
					return ch;
				}
			}
			else if (ch == ' ' && c != ' ' && c != '\'')
			{
				return ch;
			}
		}
		return '\0';
	}

	// Token: 0x04000111 RID: 273
	public UIInputValidator.Validation logic;

	// Token: 0x0200002C RID: 44
	public enum Validation
	{
		// Token: 0x04000113 RID: 275
		None,
		// Token: 0x04000114 RID: 276
		Integer,
		// Token: 0x04000115 RID: 277
		Float,
		// Token: 0x04000116 RID: 278
		Alphanumeric,
		// Token: 0x04000117 RID: 279
		Username,
		// Token: 0x04000118 RID: 280
		Name
	}
}
