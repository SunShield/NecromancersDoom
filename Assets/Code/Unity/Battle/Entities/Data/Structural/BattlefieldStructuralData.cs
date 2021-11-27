using NDoom.Unity.EntitySystem.DataStructure.Data;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities.Data.Structural
{
	public class BattlefieldStructuralData : EntityStructuralData
	{
		public int Rows { get; set; }
		public int Cols { get; set; }
		public Vector2 Offset { get; private set; }
	}
}