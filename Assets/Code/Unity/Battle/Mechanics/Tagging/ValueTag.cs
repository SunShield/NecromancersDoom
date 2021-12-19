using System.Collections.Generic;

namespace NDoom.Unity.Battles.Mechanics.Tagging
{
	/// <summary>
	/// Tags represent specific "domain" value having them is related to.
	/// For example, "Damage" is a tag or "Ice" is a tag, or "Healing" is a tag, etc.
	/// Tags determine how effects work on specific numbers: Numbers effects affect
	/// Determined by their tags: For example "+30% Cold Damage"
	/// will increase all values having "Cold" and "Damage".
	/// </summary>
	public class ValueTag
	{
		/// <summary>
		/// Tags can be build into the hierarchies.
		/// For example, tag "Cold" is a child of a tag "Elemental",
		/// Tag "AngularSpeed" is a child of tag "Motion" etc.
		/// </summary>
		public HashSet<ValueTag> Ancestors { get; } = new HashSet<ValueTag>();

		public string Name { get; set; }

		public ValueTag(string name) => Name = name;
	}
}