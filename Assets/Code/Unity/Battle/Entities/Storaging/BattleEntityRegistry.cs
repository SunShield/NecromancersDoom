using System.Collections.Generic;
using NDoom.Unity.Battles.Entities.Concrete;

namespace NDoom.Unity.Battles.Entities.Storaging
{
	public class BattleEntityRegistry
	{
		private readonly Dictionary<int, IBattleEntity> _allEntities = new Dictionary<int, IBattleEntity>();
		private readonly Dictionary<int, Battlefield> _battlefields = new Dictionary<int, Battlefield>();
		private readonly Dictionary<int, Tile> _tiles = new Dictionary<int, Tile>();
		private readonly Dictionary<int, Unit> _units = new Dictionary<int, Unit>();
		
		public Battle Battle { get; private set; }
		public IReadOnlyDictionary<int, Battlefield> Battlefields => _battlefields;
		public IReadOnlyDictionary<int, Tile> Tiles => _tiles;
		public IReadOnlyDictionary<int, Unit> Units => _units;

		public void AddEntity(IBattleEntity entity)
		{
			// TODO: Possibly refactor... Or fuck this?
			var id = entity.Id;
			_allEntities.Add(id, entity);
			if (entity is Battle battle)           Battle = battle;
			if (entity is Battlefield battlefield) _battlefields.Add(id, battlefield);
			if (entity is Tile tile)               _tiles.Add(id, tile);
			if (entity is Unit unit)               _units.Add(id, unit);
		}

		public void RemoveEntity(IBattleEntity entity)
		{
			var id = entity.Id;
			if(entity is Battlefield) _battlefields.Remove(id);
			if(entity is Tile)        _tiles.Remove(id);
			if(entity is Unit)        _units.Remove(id);
		}

		public void RemoveEntity(int id)
		{
			var entity = _allEntities[id];
			RemoveEntity(entity);
		}
	}
}