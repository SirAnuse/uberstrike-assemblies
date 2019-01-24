using System;
using UnityEngine;

// Token: 0x0200001E RID: 30
[AddComponentMenu("NGUI/Interaction/Drag Object")]
public class UIDragObject : IgnoreTimeScale
{
	// Token: 0x06000092 RID: 146 RVA: 0x00017A4C File Offset: 0x00015C4C
	private void FindPanel()
	{
		this.mPanel = ((!(this.target != null)) ? null : UIPanel.Find(this.target.transform, false));
		if (this.mPanel == null)
		{
			this.restrictWithinPanel = false;
		}
	}

	// Token: 0x06000093 RID: 147 RVA: 0x00017AA0 File Offset: 0x00015CA0
	private void OnPress(bool pressed)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.target != null)
		{
			this.mPressed = pressed;
			if (pressed)
			{
				if (this.restrictWithinPanel && this.mPanel == null)
				{
					this.FindPanel();
				}
				if (this.restrictWithinPanel)
				{
					this.mBounds = NGUIMath.CalculateRelativeWidgetBounds(this.mPanel.cachedTransform, this.target);
				}
				this.mMomentum = Vector3.zero;
				this.mScroll = 0f;
				SpringPosition component = this.target.GetComponent<SpringPosition>();
				if (component != null)
				{
					component.enabled = false;
				}
				this.mLastPos = UICamera.lastHit.point;
				Transform transform = UICamera.currentCamera.transform;
				this.mPlane = new Plane(((!(this.mPanel != null)) ? transform.rotation : this.mPanel.cachedTransform.rotation) * Vector3.back, this.mLastPos);
			}
			else if (this.restrictWithinPanel && this.mPanel.clipping != UIDrawCall.Clipping.None && this.dragEffect == UIDragObject.DragEffect.MomentumAndSpring)
			{
				this.mPanel.ConstrainTargetToBounds(this.target, ref this.mBounds, false);
			}
		}
	}

	// Token: 0x06000094 RID: 148 RVA: 0x00017C0C File Offset: 0x00015E0C
	private void OnDrag(Vector2 delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.target != null)
		{
			UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
			Ray ray = UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos);
			float distance = 0f;
			if (this.mPlane.Raycast(ray, out distance))
			{
				Vector3 point = ray.GetPoint(distance);
				Vector3 vector = point - this.mLastPos;
				this.mLastPos = point;
				if (vector.x != 0f || vector.y != 0f)
				{
					vector = this.target.InverseTransformDirection(vector);
					vector.Scale(this.scale);
					vector = this.target.TransformDirection(vector);
				}
				if (this.dragEffect != UIDragObject.DragEffect.None)
				{
					this.mMomentum = Vector3.Lerp(this.mMomentum, this.mMomentum + vector * (0.01f * this.momentumAmount), 0.67f);
				}
				if (this.restrictWithinPanel)
				{
					Vector3 localPosition = this.target.localPosition;
					this.target.position += vector;
					this.mBounds.center = this.mBounds.center + (this.target.localPosition - localPosition);
					if (this.dragEffect != UIDragObject.DragEffect.MomentumAndSpring && this.mPanel.clipping != UIDrawCall.Clipping.None && this.mPanel.ConstrainTargetToBounds(this.target, ref this.mBounds, true))
					{
						this.mMomentum = Vector3.zero;
						this.mScroll = 0f;
					}
				}
				else
				{
					this.target.position += vector;
				}
			}
		}
	}

	// Token: 0x06000095 RID: 149 RVA: 0x00017DF0 File Offset: 0x00015FF0
	private void LateUpdate()
	{
		float deltaTime = base.UpdateRealTimeDelta();
		if (this.target == null)
		{
			return;
		}
		if (this.mPressed)
		{
			SpringPosition component = this.target.GetComponent<SpringPosition>();
			if (component != null)
			{
				component.enabled = false;
			}
			this.mScroll = 0f;
		}
		else
		{
			this.mMomentum += this.scale * (-this.mScroll * 0.05f);
			this.mScroll = NGUIMath.SpringLerp(this.mScroll, 0f, 20f, deltaTime);
			if (this.mMomentum.magnitude > 0.0001f)
			{
				if (this.mPanel == null)
				{
					this.FindPanel();
				}
				if (this.mPanel != null)
				{
					this.target.position += NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime);
					if (this.restrictWithinPanel && this.mPanel.clipping != UIDrawCall.Clipping.None)
					{
						this.mBounds = NGUIMath.CalculateRelativeWidgetBounds(this.mPanel.cachedTransform, this.target);
						if (!this.mPanel.ConstrainTargetToBounds(this.target, ref this.mBounds, this.dragEffect == UIDragObject.DragEffect.None))
						{
							SpringPosition component2 = this.target.GetComponent<SpringPosition>();
							if (component2 != null)
							{
								component2.enabled = false;
							}
						}
					}
					return;
				}
			}
			else
			{
				this.mScroll = 0f;
			}
		}
		NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime);
	}

	// Token: 0x06000096 RID: 150 RVA: 0x00017F98 File Offset: 0x00016198
	private void OnScroll(float delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject))
		{
			if (Mathf.Sign(this.mScroll) != Mathf.Sign(delta))
			{
				this.mScroll = 0f;
			}
			this.mScroll += delta * this.scrollWheelFactor;
		}
	}

	// Token: 0x040000AF RID: 175
	public Transform target;

	// Token: 0x040000B0 RID: 176
	public Vector3 scale = Vector3.one;

	// Token: 0x040000B1 RID: 177
	public float scrollWheelFactor;

	// Token: 0x040000B2 RID: 178
	public bool restrictWithinPanel;

	// Token: 0x040000B3 RID: 179
	public UIDragObject.DragEffect dragEffect = UIDragObject.DragEffect.MomentumAndSpring;

	// Token: 0x040000B4 RID: 180
	public float momentumAmount = 35f;

	// Token: 0x040000B5 RID: 181
	private Plane mPlane;

	// Token: 0x040000B6 RID: 182
	private Vector3 mLastPos;

	// Token: 0x040000B7 RID: 183
	private UIPanel mPanel;

	// Token: 0x040000B8 RID: 184
	private bool mPressed;

	// Token: 0x040000B9 RID: 185
	private Vector3 mMomentum = Vector3.zero;

	// Token: 0x040000BA RID: 186
	private float mScroll;

	// Token: 0x040000BB RID: 187
	private Bounds mBounds;

	// Token: 0x0200001F RID: 31
	public enum DragEffect
	{
		// Token: 0x040000BD RID: 189
		None,
		// Token: 0x040000BE RID: 190
		Momentum,
		// Token: 0x040000BF RID: 191
		MomentumAndSpring
	}
}
