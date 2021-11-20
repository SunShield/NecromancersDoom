using NDoom.Unity.Battles.Entities.Concrete;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using NDoom.Unity.Entities.Initializing;

namespace NDoom.Unity.Battles.Entities.Initialization
{
	public class TileInitArgs
	{
		public int Row { get; private set; }
		public int Col { get; private set; }
		public Battlefield Battlefield { get; private set; }

		public void FillFrom(TileSpawnArgs args)
		{
			Row = args.Row;
			Col = args.Col;
			Battlefield = args.Battlefield;
		}
	}
}