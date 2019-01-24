using System;
using System.Collections.Generic;

// Token: 0x020003C7 RID: 967
public class EventHandler
{
	// Token: 0x06001C63 RID: 7267 RVA: 0x00012D5F File Offset: 0x00010F5F
	public void Clear()
	{
		this.eventContainer.Clear();
	}

	// Token: 0x06001C64 RID: 7268 RVA: 0x0008FEAC File Offset: 0x0008E0AC
	public void AddListener<T>(Action<T> callback)
	{
		global::EventHandler.IEventContainer eventContainer;
		if (!this.eventContainer.TryGetValue(typeof(T), out eventContainer))
		{
			eventContainer = new global::EventHandler.EventContainer<T>();
			this.eventContainer.Add(typeof(T), eventContainer);
		}
		global::EventHandler.EventContainer<T> eventContainer2 = eventContainer as global::EventHandler.EventContainer<T>;
		if (eventContainer2 != null)
		{
			eventContainer2.AddCallbackMethod(callback);
		}
	}

	// Token: 0x06001C65 RID: 7269 RVA: 0x0008FF08 File Offset: 0x0008E108
	public void RemoveListener<T>(Action<T> callback)
	{
		global::EventHandler.IEventContainer eventContainer;
		if (this.eventContainer.TryGetValue(typeof(T), out eventContainer))
		{
			global::EventHandler.EventContainer<T> eventContainer2 = eventContainer as global::EventHandler.EventContainer<T>;
			if (eventContainer2 != null)
			{
				eventContainer2.RemoveCallbackMethod(callback);
			}
		}
	}

	// Token: 0x06001C66 RID: 7270 RVA: 0x0008FF48 File Offset: 0x0008E148
	public void Fire(object message)
	{
		global::EventHandler.IEventContainer eventContainer;
		if (this.eventContainer.TryGetValue(message.GetType(), out eventContainer))
		{
			eventContainer.CastEvent(message);
		}
	}

	// Token: 0x04001967 RID: 6503
	public static readonly global::EventHandler Global = new global::EventHandler();

	// Token: 0x04001968 RID: 6504
	private Dictionary<Type, global::EventHandler.IEventContainer> eventContainer = new Dictionary<Type, global::EventHandler.IEventContainer>();

	// Token: 0x020003C8 RID: 968
	private interface IEventContainer
	{
		// Token: 0x06001C67 RID: 7271
		void CastEvent(object m);
	}

	// Token: 0x020003C9 RID: 969
	private class EventContainer<T> : global::EventHandler.IEventContainer
	{
		// Token: 0x14000024 RID: 36
		// (add) Token: 0x06001C69 RID: 7273 RVA: 0x00012D7F File Offset: 0x00010F7F
		// (remove) Token: 0x06001C6A RID: 7274 RVA: 0x00012D98 File Offset: 0x00010F98
		public event Action<T> Sender;

		// Token: 0x06001C6B RID: 7275 RVA: 0x0008FF74 File Offset: 0x0008E174
		public void AddCallbackMethod(Action<T> callback)
		{
			string callbackMethodId = this.GetCallbackMethodId(callback);
			if (!this._dictionary.ContainsKey(callbackMethodId))
			{
				this._dictionary.Add(callbackMethodId, callback);
				this.Sender = (Action<T>)Delegate.Combine(this.Sender, callback);
			}
		}

		// Token: 0x06001C6C RID: 7276 RVA: 0x00012DB1 File Offset: 0x00010FB1
		public void RemoveCallbackMethod(Action<T> callback)
		{
			if (this._dictionary.Remove(this.GetCallbackMethodId(callback)))
			{
				this.Sender = (Action<T>)Delegate.Remove(this.Sender, callback);
			}
		}

		// Token: 0x06001C6D RID: 7277 RVA: 0x0008FFC0 File Offset: 0x0008E1C0
		private string GetCallbackMethodId(Action<T> callback)
		{
			string text = callback.Method.DeclaringType.FullName + callback.Method.Name;
			if (callback.Target != null)
			{
				text += callback.Target.GetHashCode().ToString();
			}
			return text;
		}

		// Token: 0x06001C6E RID: 7278 RVA: 0x00012DE1 File Offset: 0x00010FE1
		public void CastEvent(object m)
		{
			if (this.Sender != null)
			{
				this.Sender((T)((object)m));
			}
		}

		// Token: 0x04001969 RID: 6505
		private Dictionary<string, Action<T>> _dictionary = new Dictionary<string, Action<T>>();
	}
}
