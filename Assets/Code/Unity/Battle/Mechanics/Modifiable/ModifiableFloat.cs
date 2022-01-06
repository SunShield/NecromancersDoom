using NDoom.Unity.Battle.Mechanics.Modifiable;
using System.Collections.Generic;

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

		private Dictionary<ModificationType, List<Modification>> _allModifications = new Dictionary<ModificationType, List<Modification>>()
		{
			{ ModificationType.FlatBase,              new List<Modification>() },
			{ ModificationType.IncreasementReduction, new List<Modification>() },
			{ ModificationType.FlatAdditional,        new List<Modification>() },
			{ ModificationType.MoreLess,              new List<Modification>() },
		};

		public float FinalValue { get; set; }

		public ModifiableFloat(float baseValue)
		{ 
			BaseValue = baseValue;
			FinalValue = BaseValue;
		}

		public ModifiableFloat(ModifiableFloat another)
        {
			BaseValue = another.BaseValue;
			FinalValue = BaseValue;
			foreach (var modificationType in _allModifications.Keys)
            {
				if (!_allModifications.ContainsKey(modificationType)) _allModifications.Add(modificationType, new List<Modification>());
				
				foreach(var modification in another._allModifications[modificationType])
					_allModifications[modificationType].Add(new Modification(modification));
            }

			RecalculateFinalValue();
        }

		public void AddModification(Modification modification)
		{
			_allModifications[modification.Type].Add(modification);
			RecalculateFinalValue();
		}

		private void RecalculateFinalValue()
		{
			var baseValue = _baseValue;
			ApplyFlatBaseModifications(ref baseValue);
			ApplyIncreasementReductionModifications(ref baseValue);
			ApplyFlatAdditionalModifications(ref baseValue);
			ApplyMoreLessModifications(ref baseValue);
			FinalValue = baseValue;
		}

		private void ApplyFlatBaseModifications(ref float value)
        {
			foreach(var modification in _allModifications[ModificationType.FlatBase])
				value += modification.Value;
        }

		private void ApplyIncreasementReductionModifications(ref float value)
        {
			float increasementReductionPercent = 0;
			foreach (var modification in _allModifications[ModificationType.IncreasementReduction])
				increasementReductionPercent += modification.Value;

			value = value * (1 + increasementReductionPercent / 100f);
		}

		private void ApplyFlatAdditionalModifications(ref float value)
		{
			foreach (var modification in _allModifications[ModificationType.FlatAdditional])
				value += modification.Value;
		}

		private void ApplyMoreLessModifications(ref float value)
		{
			foreach (var modification in _allModifications[ModificationType.MoreLess])
				value *= (modification.Value / 100f);
		}
	}
}