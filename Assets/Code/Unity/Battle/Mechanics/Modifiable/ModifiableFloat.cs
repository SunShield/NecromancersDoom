namespace NDoom.Unity.Battles.Mechanics.Modifiable
{
	/// <summary>
	/// This class wraps a float value and adds all the list of modifications from effects atc,
	/// applied to it.
	/// The final formula is:
	/// ((BaseValue + FlatAddedBase - FlatRemovedBase) * (1 + (Increasements - Reductions) / 100) + FlatAddedAddtional - FlatRemovedAdditional)
	/// * More1 * More2 * ... * MoreN * Less1 * Less2 * ... * LessN
	/// All the modifications here are in form of flat values or percents (less/more and increased/reduced)
	/// </summary>
	public class ModifiableFloat
	{
		private float _baseValue;
		public float BaseValue
		{
			get => _baseValue;
			set
			{
				_baseValue = value;
				RecalculateFinalValue();
			}
		}

		public float FinalValue { get; set; }

		public ModifiableFloat(float baseValue) => BaseValue = baseValue;

		private void RecalculateFinalValue()
		{

		}
	}
}