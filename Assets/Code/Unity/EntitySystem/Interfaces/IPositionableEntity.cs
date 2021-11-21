using NDoom.Unity.EntitySystem.DataStructure.Data;

namespace NDoom.Unity.EntitySystem.Interfaces
{
	/// <summary>
	/// Interface for all the entitites able to be "positioned" in some way.
	/// It doesn't refer to the Unity position, it's about "logical" position,
	/// like unit has (y, x, side) coords.
	/// </summary>
	/// <typeparam name="TPositionData"></typeparam>
	public interface IPositionableEntity<TPositionData, TAncestor, TChild> : IChildEntity<TAncestor, TChild>
		where TPositionData : EntityPositionData
		where TAncestor : IAncestorEntity<TChild, TAncestor>	
		where TChild : IPositionableEntity<TPositionData, TAncestor, TChild>
	{
		void SetPosition(TPositionData data);
	}
}
