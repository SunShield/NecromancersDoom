﻿using NDoom.Unity.EntitySystem.DataStructure.Data;

namespace NDoom.Unity.EntitySystem.Interfaces
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TFunctionalData"></typeparam>
	public interface IFunctionalEntity<TFunctionalData> : IEntity
		where TFunctionalData : EntityFunctionalData
	{
		public TFunctionalData FunctionalData { get; }
		void SetFunctionalData(TFunctionalData functionalData);
	}
}