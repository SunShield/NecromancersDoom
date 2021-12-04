using System;
using Sirenix.OdinInspector;

namespace NDoom.Unity.Service.Classes
{
	[Serializable]
	public class Vector2Int
	{
		[HorizontalGroup("Main")]
		[LabelWidth(12)]
		public int X;

		[HorizontalGroup("Main")]
		[LabelWidth(12)]
		public int Y;
	}
}