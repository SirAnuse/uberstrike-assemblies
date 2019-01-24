using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020003DF RID: 991
public class Property<T>
{
	// Token: 0x06001CEE RID: 7406 RVA: 0x0001340F File Offset: 0x0001160F
	public Property()
	{
	}

	// Token: 0x06001CEF RID: 7407 RVA: 0x00013422 File Offset: 0x00011622
	public Property(T defaultValue)
	{
		this.currentValue = defaultValue;
	}

	// Token: 0x06001CF0 RID: 7408 RVA: 0x000918D4 File Offset: 0x0008FAD4
	public void AddEvent(Action<T> onChanged, MonoBehaviour mb)
	{
		this.Callbacks.Add(new Property<T>.Act<T>
		{
			Mb = mb,
			HasMb = (mb != null),
			Changed = onChanged
		});
	}

	// Token: 0x06001CF1 RID: 7409 RVA: 0x00091910 File Offset: 0x0008FB10
	public void AddEvent(Action<T, T> onChanged, MonoBehaviour mb)
	{
		this.Callbacks.Add(new Property<T>.Act<T>
		{
			Mb = mb,
			HasMb = (mb != null),
			ChangedWithPrev = onChanged
		});
	}

	// Token: 0x06001CF2 RID: 7410 RVA: 0x0001343C File Offset: 0x0001163C
	public void AddEventAndFire(Action<T> onChanged, MonoBehaviour mb)
	{
		this.AddEvent(onChanged, mb);
		onChanged(this.currentValue);
	}

	// Token: 0x06001CF3 RID: 7411 RVA: 0x00013452 File Offset: 0x00011652
	public void AddEventAndFire(Action<T, T> onChanged, MonoBehaviour mb)
	{
		this.AddEvent(onChanged, mb);
		onChanged(this.currentValue, this.currentValue);
	}

	// Token: 0x06001CF4 RID: 7412 RVA: 0x0009194C File Offset: 0x0008FB4C
	public void RemoveEvent(Action<T> onChanged)
	{
		this.Callbacks.RemoveAll((Property<T>.Act<T> el) => el.Changed == onChanged);
	}

	// Token: 0x06001CF5 RID: 7413 RVA: 0x00091980 File Offset: 0x0008FB80
	public void RemoveEvent(Action<T, T> onChanged)
	{
		this.Callbacks.RemoveAll((Property<T>.Act<T> el) => el.ChangedWithPrev == onChanged);
	}

	// Token: 0x06001CF6 RID: 7414 RVA: 0x000919B4 File Offset: 0x0008FBB4
	public void RemoveEvent(MonoBehaviour mb)
	{
		this.Callbacks.RemoveAll((Property<T>.Act<T> el) => el.Mb == mb);
	}

	// Token: 0x06001CF7 RID: 7415 RVA: 0x0001346E File Offset: 0x0001166E
	public void Fire()
	{
		this.FireEvent(this.currentValue);
	}

	// Token: 0x06001CF8 RID: 7416 RVA: 0x0001347C File Offset: 0x0001167C
	public void Fire(T newValue)
	{
		this.Value = newValue;
	}

	// Token: 0x06001CF9 RID: 7417 RVA: 0x000919E8 File Offset: 0x0008FBE8
	public void FireEvent(T oldValue)
	{
		this.Callbacks.RemoveAll(delegate(Property<T>.Act<T> el)
		{
			bool result;
			try
			{
				if (el.HasMb && el.Mb == null)
				{
					result = true;
				}
				else
				{
					if (!el.HasMb || (el.Mb.gameObject.activeInHierarchy && el.Mb.enabled))
					{
						if (el.Changed != null)
						{
							el.Changed(this.currentValue);
						}
						if (el.ChangedWithPrev != null)
						{
							el.ChangedWithPrev(this.currentValue, oldValue);
						}
					}
					result = false;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				result = false;
			}
			return result;
		});
	}

	// Token: 0x17000660 RID: 1632
	// (get) Token: 0x06001CFA RID: 7418 RVA: 0x00013485 File Offset: 0x00011685
	// (set) Token: 0x06001CFB RID: 7419 RVA: 0x00091A24 File Offset: 0x0008FC24
	public virtual T Value
	{
		get
		{
			return this.currentValue;
		}
		set
		{
			T oldValue = this.currentValue;
			this.currentValue = value;
			this.FireEvent(oldValue);
		}
	}

	// Token: 0x06001CFC RID: 7420 RVA: 0x0001348D File Offset: 0x0001168D
	public override string ToString()
	{
		return this.currentValue.ToString();
	}

	// Token: 0x06001CFD RID: 7421 RVA: 0x000134A0 File Offset: 0x000116A0
	public static implicit operator T(Property<T> property)
	{
		return property.Value;
	}

	// Token: 0x0400199D RID: 6557
	private List<Property<T>.Act<T>> Callbacks = new List<Property<T>.Act<T>>();

	// Token: 0x0400199E RID: 6558
	private T currentValue;

	// Token: 0x020003E0 RID: 992
	private class Act<TT>
	{
		// Token: 0x0400199F RID: 6559
		public MonoBehaviour Mb;

		// Token: 0x040019A0 RID: 6560
		public bool HasMb;

		// Token: 0x040019A1 RID: 6561
		public Action<TT> Changed;

		// Token: 0x040019A2 RID: 6562
		public Action<TT, TT> ChangedWithPrev;
	}
}
