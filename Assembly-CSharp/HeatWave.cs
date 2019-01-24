using System;
using UnityEngine;

// Token: 0x0200042C RID: 1068
public class HeatWave : MonoBehaviour
{
	// Token: 0x06001E75 RID: 7797 RVA: 0x00095418 File Offset: 0x00093618
	private void Awake()
	{
		this._transform = base.transform;
		this._renderer = base.renderer;
		if (this._renderer == null)
		{
			throw new Exception("No Renderer attached to HeatWave script on GameObject " + base.gameObject.name);
		}
	}

	// Token: 0x06001E76 RID: 7798 RVA: 0x0009546C File Offset: 0x0009366C
	private void Update()
	{
		if (this._transform && this._renderer)
		{
			this._elapsedTime += Time.deltaTime;
			this._normalizedTime = this._elapsedTime / this._duration;
			this._s = Mathf.Lerp(this._startSize, this._maxSize, this._normalizedTime);
			if (this._renderer.material)
			{
				this._renderer.material.SetFloat("_BumpAmt", (1f - this._normalizedTime) * this._distortion);
			}
			this._transform.localScale = new Vector3(this._s, this._s, this._s);
			if (Camera.main)
			{
				this._transform.rotation = Quaternion.LookRotation(Camera.main.transform.position - this._transform.position);
			}
			if (this._elapsedTime > this._duration && base.gameObject)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}

	// Token: 0x04001A5A RID: 6746
	[SerializeField]
	private float _startSize;

	// Token: 0x04001A5B RID: 6747
	[SerializeField]
	private float _maxSize = 0.05f;

	// Token: 0x04001A5C RID: 6748
	[SerializeField]
	private float _duration = 0.25f;

	// Token: 0x04001A5D RID: 6749
	[SerializeField]
	private float _distortion = 64f;

	// Token: 0x04001A5E RID: 6750
	private Transform _transform;

	// Token: 0x04001A5F RID: 6751
	private Renderer _renderer;

	// Token: 0x04001A60 RID: 6752
	private float _elapsedTime;

	// Token: 0x04001A61 RID: 6753
	private float _normalizedTime;

	// Token: 0x04001A62 RID: 6754
	private float _s;
}
