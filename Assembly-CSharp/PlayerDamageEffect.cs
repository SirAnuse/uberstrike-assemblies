using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000371 RID: 881
public class PlayerDamageEffect : MonoBehaviour
{
	// Token: 0x060018EE RID: 6382 RVA: 0x00010A58 File Offset: 0x0000EC58
	private void Awake()
	{
		this._transform = base.transform;
		this._start = this._transform.position;
	}

	// Token: 0x060018EF RID: 6383 RVA: 0x00085A24 File Offset: 0x00083C24
	private void Update()
	{
		if (this._show)
		{
			float num = this._time * this._speed - this._offset;
			Vector3 b = this._direction * this._time;
			b.y = this._height - num * num * this._width;
			this._time += Time.deltaTime;
			this._transform.position = this._start + b;
			this.UpdateTransform();
			if (this._time > this._duration)
			{
				Color color = this._renderer.material.GetColor("_Color");
				color.a = Mathf.Lerp(color.a, 0f, Time.deltaTime * 3f);
				this._renderer.material.SetColor("_Color", color);
				if (color.a < 0.2f)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
		}
	}

	// Token: 0x060018F0 RID: 6384 RVA: 0x00085B28 File Offset: 0x00083D28
	public void Show(DamageInfo shot)
	{
		if (this._width == 0f)
		{
			this._width = 1f;
		}
		MeshFilter meshFilter = base.gameObject.AddComponent<MeshFilter>();
		if (meshFilter)
		{
			meshFilter.mesh = this.CreateCharacterMesh((int)shot.Damage, this.FONT_METRICS, 313, 43);
		}
		this.UpdateTransform();
		this._show = true;
		this._offset = Mathf.Sqrt(this._height / this._width);
		this._direction = UnityEngine.Random.onUnitSphere;
		this._renderer.material = new Material(this._renderer.material);
		base.StartCoroutine(this.StartEnableRenderer());
	}

	// Token: 0x060018F1 RID: 6385 RVA: 0x00085BE0 File Offset: 0x00083DE0
	private IEnumerator StartEnableRenderer()
	{
		yield return new WaitForSeconds(0.1f);
		this._renderer.enabled = true;
		yield break;
	}

	// Token: 0x060018F2 RID: 6386 RVA: 0x00085BFC File Offset: 0x00083DFC
	private void UpdateTransform()
	{
		float num = Vector3.Distance(this._transform.position, GameState.Current.PlayerData.Position);
		float num2 = 0.003f + 0.0005f * num * LevelCamera.FieldOfView / 60f;
		this._transform.localScale = new Vector3(num2, num2, num2);
		this._transform.rotation = GameState.Current.PlayerData.HorizontalRotation;
	}

	// Token: 0x060018F3 RID: 6387 RVA: 0x00085C70 File Offset: 0x00083E70
	private Mesh CreateCharacterMesh(int number, Vector2[] metrics, int width, int height)
	{
		Mesh mesh = new Mesh();
		string text = Mathf.Abs(number).ToString();
		List<Vector3> list = new List<Vector3>();
		List<Vector2> list2 = new List<Vector2>();
		List<int> list3 = new List<int>();
		Vector3[] array = new Vector3[4];
		Vector2[] array2 = new Vector2[4];
		int[] array3 = new int[]
		{
			0,
			1,
			2,
			0,
			2,
			3
		};
		float num = 0f;
		float num2 = 0f;
		for (int i = 0; i < text.Length; i++)
		{
			int num3 = (int)(text[i] - '0');
			if (num3 >= 0 && num3 < 10)
			{
				for (int j = 0; j < 6; j++)
				{
					list3.Add(array3[j] + list.Count);
				}
				array[0] = new Vector3(metrics[num3].x, 0f, 0f);
				array[1] = new Vector3(metrics[num3].x + metrics[num3].y, 0f, 0f);
				array[2] = new Vector3(metrics[num3].x + metrics[num3].y, (float)height, 0f);
				array[3] = new Vector3(metrics[num3].x, (float)height, 0f);
				array2[0] = new Vector2(array[0].x / (float)width, array[0].y / (float)height);
				array2[1] = new Vector2(array[1].x / (float)width, array[1].y / (float)height);
				array2[2] = new Vector2(array[2].x / (float)width, array[2].y / (float)height);
				array2[3] = new Vector2(array[3].x / (float)width, array[3].y / (float)height);
				list.AddRange(array);
				list2.AddRange(array2);
				num += metrics[num3].y;
			}
		}
		for (int k = 0; k < list.Count / 4; k++)
		{
			List<Vector3> list5;
			List<Vector3> list4 = list5 = list;
			int index2;
			int index = index2 = k * 4 + 1;
			Vector3 a = list5[index2];
			list4[index] = a - new Vector3(list[k * 4].x + num / 2f - num2, (float)(height / 2));
			List<Vector3> list7;
			List<Vector3> list6 = list7 = list;
			int index3 = index2 = k * 4 + 2;
			a = list7[index2];
			list6[index3] = a - new Vector3(list[k * 4 + 3].x + num / 2f - num2, (float)(height / 2));
			List<Vector3> list9;
			List<Vector3> list8 = list9 = list;
			int index4 = index2 = k * 4 + 3;
			a = list9[index2];
			list8[index4] = a - new Vector3(list[k * 4 + 3].x + num / 2f - num2, (float)(height / 2));
			List<Vector3> list11;
			List<Vector3> list10 = list11 = list;
			int index5 = index2 = k * 4;
			a = list11[index2];
			list10[index5] = a - new Vector3(list[k * 4].x + num / 2f - num2, (float)(height / 2));
			num2 += list[k * 4 + 1].x - list[k * 4].x;
		}
		mesh.vertices = list.ToArray();
		mesh.uv = list2.ToArray();
		mesh.triangles = list3.ToArray();
		return mesh;
	}

	// Token: 0x04001754 RID: 5972
	private const int WIDTH = 313;

	// Token: 0x04001755 RID: 5973
	private const int HEIGHT = 43;

	// Token: 0x04001756 RID: 5974
	[SerializeField]
	private float _height;

	// Token: 0x04001757 RID: 5975
	[SerializeField]
	private float _width;

	// Token: 0x04001758 RID: 5976
	[SerializeField]
	private float _duration;

	// Token: 0x04001759 RID: 5977
	[SerializeField]
	private MeshRenderer _renderer;

	// Token: 0x0400175A RID: 5978
	private Vector2[] FONT_METRICS = new Vector2[]
	{
		new Vector2(0f, 42f),
		new Vector2(42f, 21f),
		new Vector2(63f, 29f),
		new Vector2(92f, 28f),
		new Vector2(120f, 34f),
		new Vector2(154f, 28f),
		new Vector2(182f, 33f),
		new Vector2(215f, 31f),
		new Vector2(246f, 34f),
		new Vector2(280f, 33f)
	};

	// Token: 0x0400175B RID: 5979
	public float _speed;

	// Token: 0x0400175C RID: 5980
	private float _offset;

	// Token: 0x0400175D RID: 5981
	private bool _show;

	// Token: 0x0400175E RID: 5982
	private float _time;

	// Token: 0x0400175F RID: 5983
	private Vector3 _start;

	// Token: 0x04001760 RID: 5984
	private Vector3 _direction;

	// Token: 0x04001761 RID: 5985
	private Transform _transform;
}
