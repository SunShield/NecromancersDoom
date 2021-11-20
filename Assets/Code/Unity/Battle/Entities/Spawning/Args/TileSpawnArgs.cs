using NDoom.Unity.Battles.Entities.Concrete;
using NDoom.Unity.Entities.Spawning.Args;

namespace NDoom.Unity.Battles.Entities.Spawning.Args
{
	public class TileSpawnArgs : IGameEntitySpawnArgs
	{
		public int Row { get; private set; }
		public int Col { get; private set; }
		public Battlefield Battlefield { get; private set; }

		public TileSpawnArgs(int row, int col, Battlefield battlefield)
		{
			Row = row;
			Col = col;
			Battlefield = battlefield;
		}
	}
}