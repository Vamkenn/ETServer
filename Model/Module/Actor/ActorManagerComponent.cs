﻿using System.Collections.Generic;

namespace Model
{
	[ObjectSystem]
	public class ActorManagerComponentAwakeSystem : AwakeSystem<ActorManagerComponent>
	{
		public override void Awake(ActorManagerComponent self)
		{
			self.Awake();
		}
	}

	/// <summary>
	/// 用来管理该服务器上所有的Actor对象
	/// </summary>
	public class ActorManagerComponent : Component
	{
		private readonly Dictionary<long, Entity> dictionary = new Dictionary<long, Entity>();

		public void Awake()
		{
		}

		public void Add(Entity entity)
		{
			dictionary[entity.Id] = entity;
		}

		public void Remove(long id)
		{
			this.dictionary.Remove(id);
		}

		public Entity Get(long id)
		{
			Entity entity = null;
			this.dictionary.TryGetValue(id, out entity);
			return entity;
		}

		public override void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}
			base.Dispose();
		}
	}
}