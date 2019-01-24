using System;
using UnityEngine;

// Token: 0x0200013D RID: 317
public class MoveTrailrendererObject : MonoBehaviour
{
	// Token: 0x06000885 RID: 2181 RVA: 0x00037558 File Offset: 0x00035758
	public void MoveTrail(Vector3 destination, Vector3 muzzlePosition, float distance)
	{
		if (this._lineRenderer != null)
		{
			this._alpha = 1f;
			this._move = true;
			this._lineRenderer.SetPosition(0, muzzlePosition);
			this._lineRenderer.SetPosition(1, destination);
			this._timeToArrive = Time.time + this._duration;
		}
	}

	// Token: 0x06000886 RID: 2182 RVA: 0x000375B4 File Offset: 0x000357B4
	private void Update()
	{
		if (this._move)
		{
			this._locationOnPath = 1f - (this._timeToArrive - Time.time);
			this._alpha = Mathf.Lerp(this._alpha, 0f, this._locationOnPath);
			Color color = this._lineRenderer.material.GetColor("_TintColor");
			color.a = this._alpha;
			this._lineRenderer.materials[0].SetColor("_TintColor", color);
			if (Time.time >= this._timeToArrive)
			{
				this._move = false;
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}

	// Token: 0x040008A0 RID: 2208
	[SerializeField]
	private LineRenderer _lineRenderer;

	// Token: 0x040008A1 RID: 2209
	[SerializeField]
	private float _duration = 0.1f;

	// Token: 0x040008A2 RID: 2210
	private float _locationOnPath;

	// Token: 0x040008A3 RID: 2211
	private bool _move;

	// Token: 0x040008A4 RID: 2212
	private float _timeToArrive = 1f;

	// Token: 0x040008A5 RID: 2213
	private float _alpha = 1f;
}
