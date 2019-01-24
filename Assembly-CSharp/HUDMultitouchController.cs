using System;
using UnityEngine;

// Token: 0x02000319 RID: 793
public class HUDMultitouchController : MonoBehaviour
{
	// Token: 0x17000536 RID: 1334
	// (get) Token: 0x0600162F RID: 5679 RVA: 0x0000EF86 File Offset: 0x0000D186
	// (set) Token: 0x06001630 RID: 5680 RVA: 0x0000EF8E File Offset: 0x0000D18E
	public bool Moving { get; private set; }

	// Token: 0x06001631 RID: 5681 RVA: 0x0007BC68 File Offset: 0x00079E68
	private void Start()
	{
		this.upButton.OnPressed = delegate(bool el)
		{
			this.moveFwd = el;
		};
		this.downButton.OnPressed = delegate(bool el)
		{
			this.moveBack = el;
		};
		this.rightButton.OnPressed = delegate(bool el)
		{
			this.moveRight = el;
		};
		this.leftButton.OnPressed = delegate(bool el)
		{
			this.moveLeft = el;
		};
		this.jumpButton.OnPressed = delegate(bool el)
		{
			TouchInput.WishJump = el;
		};
	}

	// Token: 0x06001632 RID: 5682 RVA: 0x0007BCFC File Offset: 0x00079EFC
	private void LateUpdate()
	{
		this.Moving = (this.moveFwd || this.moveBack || this.moveLeft || this.moveRight);
		Vector2 vector = Vector2.zero;
		if (this.moveLeft)
		{
			vector += new Vector2(-1f, 0f);
		}
		if (this.moveRight)
		{
			vector += new Vector2(1f, 0f);
		}
		if (this.moveFwd)
		{
			vector += new Vector2(0f, 1f);
		}
		if (this.moveBack)
		{
			vector += new Vector2(0f, -1f);
		}
		if (vector.y == 0f)
		{
			vector.y = Mathf.Lerp(this.lastDirection.y, vector.y, Time.deltaTime * this.MoveInteriaRolloff.y);
		}
		if (vector.x == 0f)
		{
			vector.x = Mathf.Lerp(this.lastDirection.x, vector.x, Time.deltaTime * this.MoveInteriaRolloff.x);
		}
		this.lastDirection = TouchInput.WishDirection;
		TouchInput.WishDirection = vector;
	}

	// Token: 0x040014F8 RID: 5368
	[SerializeField]
	private UIEventReceiver upButton;

	// Token: 0x040014F9 RID: 5369
	[SerializeField]
	private UIEventReceiver downButton;

	// Token: 0x040014FA RID: 5370
	[SerializeField]
	private UIEventReceiver rightButton;

	// Token: 0x040014FB RID: 5371
	[SerializeField]
	private UIEventReceiver leftButton;

	// Token: 0x040014FC RID: 5372
	[SerializeField]
	private UIEventReceiver jumpButton;

	// Token: 0x040014FD RID: 5373
	private bool moveFwd;

	// Token: 0x040014FE RID: 5374
	private bool moveBack;

	// Token: 0x040014FF RID: 5375
	private bool moveRight;

	// Token: 0x04001500 RID: 5376
	private bool moveLeft;

	// Token: 0x04001501 RID: 5377
	private Vector2 lastDirection;

	// Token: 0x04001502 RID: 5378
	private Vector2 MoveInteriaRolloff = new Vector2(24f, 20f);
}
