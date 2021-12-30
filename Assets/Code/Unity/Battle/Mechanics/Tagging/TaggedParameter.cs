using NDoom.Unity.Battles.Mechanics.Modifiable;
using System.Collections.Generic;
using System.Linq;

namespace NDoom.Unity.Battles.Mechanics.Tagging
{
	/// <summary>
	/// Tagged values are aclually... Values with certain tags applied to them
	/// Those tags determine how values will be affected by certain effects.
	/// </summary>
	public struct TaggedParameter
	{
		/// <summary>
		/// Name here is more for cosmetic, debugging and semantical purposes, then
		/// for real usage
		/// </summary>
		public string Name { get; private set; }

		public HashSet<ParameterTag> Tags { get; private set; }
		public ModifiableFloat Value { get; set; }

		public TaggedParameter(string name)
		{
			Tags = new HashSet<ParameterTag>();
			Value = new ModifiableFloat(0);
			Name = name;
		}

		public TaggedParameter(string name, IEnumerable<ParameterTag> tags) : this(name) { Tags = tags.ToHashSet(); }

		public TaggedParameter(string name, IEnumerable<ParameterTag> tags, float value) : this(name, tags) => Value = new ModifiableFloat(value);

		public TaggedParameter(string name, IEnumerable<ParameterTag> tags, ModifiableFloat value) : this(name, tags) => Value = new ModifiableFloat(value);

		public TaggedParameter(TaggedParameter parameter) : this(parameter.Name, parameter.Tags, parameter.Value) {}
	}
}