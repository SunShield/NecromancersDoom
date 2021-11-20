using System;
using System.Collections.Generic;
using NDoom.Core.DataManagement.DataStructure.Functional;
using NDoom.Core.DataManagement.DataStructure.Spawn;
using NDoom.Unity.ScriptableObjects.Data;
using NDoom.Unity.ScriptableObjects.Data.Battle;
using NDoom.Unity.ScriptableObjects.Data.Unit;

namespace NDoom.Core.DataManagement.Loading
{
	public abstract class AbstractDataLoader<TNamedData, TFunctionalData, TSpawningData>
		where TNamedData : NamedData
		where TFunctionalData : FunctionalDataT<TNamedData>, new()
		where TSpawningData : LoadedSpawnData<TNamedData>, new()
	{
		private static readonly HashSet<Type> _functionalDataConvertibleDatas = new HashSet<Type>()
		{
			typeof(UnitData)
		};

		private static readonly HashSet<Type> _spawningDataConvertibleDatas = new HashSet<Type>()
		{
			typeof(BattleData),
			typeof(UnitData)
		};

		public (Dictionary<string, TFunctionalData> functionalData, Dictionary<string, TSpawningData> spawningData) LoadData(List<TNamedData> namedDatas)
		{
			var functionalDatas = _functionalDataConvertibleDatas.Contains(typeof(TNamedData)) 
				? GetFunctionalDatas(namedDatas) 
				: null;

			var spawningDatas = _spawningDataConvertibleDatas.Contains(typeof(TNamedData)) 
				? GetSpawningDatas(namedDatas) 
				: null;
			
			return (functionalDatas, spawningDatas);
		}

		private Dictionary<string, TFunctionalData> GetFunctionalDatas(List<TNamedData> namedDatas)
		{
			var functionalDatas = new Dictionary<string, TFunctionalData>();
			foreach (var namedData in namedDatas)
			{
				var functionalData = new TFunctionalData();
				functionalData.FillFrom(namedData);
				functionalDatas.Add(namedData.name, functionalData);
			}

			return functionalDatas;
		}

		private Dictionary<string, TSpawningData> GetSpawningDatas(List<TNamedData> namedDatas)
		{
			var spawningDatas = new Dictionary<string, TSpawningData>();
			foreach (var namedData in namedDatas)
			{
				var spawningData = new TSpawningData();
				spawningData.FillFrom(namedData);
				spawningDatas.Add(namedData.DataName, spawningData);
			}

			return spawningDatas;
		}
	}
}