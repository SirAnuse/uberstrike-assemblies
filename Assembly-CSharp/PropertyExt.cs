using System;
using UnityEngine;

// Token: 0x020003EC RID: 1004
public static class PropertyExt
{
	// Token: 0x06001D1A RID: 7450 RVA: 0x0001360A File Offset: 0x0001180A
	public static void Fire(this Property<Tuple> property)
	{
		property.Fire(new Tuple());
	}

	// Token: 0x06001D1B RID: 7451 RVA: 0x00013617 File Offset: 0x00011817
	public static void Fire<T1>(this Property<TupleOne<T1>> property, T1 v1)
	{
		property.Fire(new TupleOne<T1>(v1));
	}

	// Token: 0x06001D1C RID: 7452 RVA: 0x00013625 File Offset: 0x00011825
	public static void Fire<T1, T2>(this Property<TupleTwo<T1, T2>> property, T1 v1, T2 v2)
	{
		property.Fire(new TupleTwo<T1, T2>(v1, v2));
	}

	// Token: 0x06001D1D RID: 7453 RVA: 0x00013634 File Offset: 0x00011834
	public static void Fire<T1, T2, T3>(this Property<TupleThree<T1, T2, T3>> property, T1 v1, T2 v2, T3 v3)
	{
		property.Fire(new TupleThree<T1, T2, T3>(v1, v2, v3));
	}

	// Token: 0x06001D1E RID: 7454 RVA: 0x00013644 File Offset: 0x00011844
	public static void Fire<T1, T2, T3, T4>(this Property<TupleFour<T1, T2, T3, T4>> property, T1 v1, T2 v2, T3 v3, T4 v4)
	{
		property.Fire(new TupleFour<T1, T2, T3, T4>(v1, v2, v3, v4));
	}

	// Token: 0x06001D1F RID: 7455 RVA: 0x00091B20 File Offset: 0x0008FD20
	public static void AddEvent(this Property<Tuple> property, Action action, MonoBehaviour mb)
	{
		property.AddEvent(delegate(Tuple el)
		{
			action();
		}, mb);
	}

	// Token: 0x06001D20 RID: 7456 RVA: 0x00091B50 File Offset: 0x0008FD50
	public static void AddEvent<T1>(this Property<TupleOne<T1>> property, Action<T1> action, MonoBehaviour mb)
	{
		property.AddEvent(delegate(TupleOne<T1> el)
		{
			action(el.El1);
		}, mb);
	}

	// Token: 0x06001D21 RID: 7457 RVA: 0x00091B80 File Offset: 0x0008FD80
	public static void AddEvent<T1, T2>(this Property<TupleTwo<T1, T2>> property, Action<T1, T2> action, MonoBehaviour mb)
	{
		property.AddEvent(delegate(TupleTwo<T1, T2> el)
		{
			action(el.El1, el.El2);
		}, mb);
	}

	// Token: 0x06001D22 RID: 7458 RVA: 0x00091BB0 File Offset: 0x0008FDB0
	public static void AddEvent<T1, T2, T3>(this Property<TupleThree<T1, T2, T3>> property, Action<T1, T2, T3> action, MonoBehaviour mb)
	{
		property.AddEvent(delegate(TupleThree<T1, T2, T3> el)
		{
			action(el.El1, el.El2, el.El3);
		}, mb);
	}

	// Token: 0x06001D23 RID: 7459 RVA: 0x00091BE0 File Offset: 0x0008FDE0
	public static void AddEvent<T1, T2, T3, T4>(this Property<TupleFour<T1, T2, T3, T4>> property, Action<T1, T2, T3, T4> action, MonoBehaviour mb)
	{
		property.AddEvent(delegate(TupleFour<T1, T2, T3, T4> el)
		{
			action(el.El1, el.El2, el.El3, el.El4);
		}, mb);
	}

	// Token: 0x06001D24 RID: 7460 RVA: 0x00091C10 File Offset: 0x0008FE10
	public static void AddEventAndFire(this Property<Tuple> property, Action action, MonoBehaviour mb)
	{
		property.AddEventAndFire(delegate(Tuple el)
		{
			action();
		}, mb);
	}

	// Token: 0x06001D25 RID: 7461 RVA: 0x00091C40 File Offset: 0x0008FE40
	public static void AddEventAndFire<T1>(this Property<TupleOne<T1>> property, Action<T1> action, MonoBehaviour mb)
	{
		property.AddEventAndFire(delegate(TupleOne<T1> el)
		{
			action(el.El1);
		}, mb);
	}

	// Token: 0x06001D26 RID: 7462 RVA: 0x00091C70 File Offset: 0x0008FE70
	public static void AddEventAndFire<T1, T2>(this Property<TupleTwo<T1, T2>> property, Action<T1, T2> action, MonoBehaviour mb)
	{
		property.AddEventAndFire(delegate(TupleTwo<T1, T2> el)
		{
			action(el.El1, el.El2);
		}, mb);
	}

	// Token: 0x06001D27 RID: 7463 RVA: 0x00091CA0 File Offset: 0x0008FEA0
	public static void AddEventAndFire<T1, T2, T3>(this Property<TupleThree<T1, T2, T3>> property, Action<T1, T2, T3> action, MonoBehaviour mb)
	{
		property.AddEventAndFire(delegate(TupleThree<T1, T2, T3> el)
		{
			action(el.El1, el.El2, el.El3);
		}, mb);
	}

	// Token: 0x06001D28 RID: 7464 RVA: 0x00091CD0 File Offset: 0x0008FED0
	public static void AddEventAndFire<T1, T2, T3, T4>(this Property<TupleFour<T1, T2, T3, T4>> property, Action<T1, T2, T3, T4> action, MonoBehaviour mb)
	{
		property.AddEventAndFire(delegate(TupleFour<T1, T2, T3, T4> el)
		{
			action(el.El1, el.El2, el.El3, el.El4);
		}, mb);
	}
}
