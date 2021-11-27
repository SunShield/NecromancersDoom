using NDoom.Unity.Battles.Entities.Data.Positioning;
using NDoom.Unity.EntitySystem;
using NDoom.Unity.EntitySystem.Interfaces;

namespace NDoom.Unity.Battles.Entities
{
	public class Tile 
		: Entity, 
		  IPositionableEntity<TilePositioningData, Battlefield, Tile>
	{
		public Battlefield Battlefield { get; private set; }
		public int Row { get; private set; }
		public int Col { get; private set; }

		protected override void InitializeEntityInternal()
		{
		}

		public void BindToAncestor(Battlefield battlefield) => Battlefield = battlefield;

		public void SetPosition(TilePositioningData data)
		{
			Row = data.Row;
			Col = data.Col;
		}
	}
}