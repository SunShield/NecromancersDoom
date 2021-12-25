using System.Collections.Generic;

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

		public HashSet<ParameterTag> Tags { get; }
		public float InnerValue { get; set; }

		public TaggedParameter(string name, IEnumerable<ParameterTag> tags)
		{
			Tags = new HashSet<ParameterTag>();
			InnerValue = 0;
			Name = name;
		}

		public TaggedParameter(string name, IEnumerable<ParameterTag> tags, float value) : this(name, tags) => InnerValue = value;
		public TaggedParameter(TaggedParameter parameter) : this(parameter.Name, parameter.Tags, parameter.InnerValue) {}

		public static TaggedParameter operator +(TaggedParameter parameter, float another) 
			=> new TaggedParameter(parameter.Name, parameter.Tags, parameter.InnerValue + another);
		public static TaggedParameter operator +(float another, TaggedParameter parameter) 
			=> new TaggedParameter(parameter.Name, parameter.Tags, parameter.InnerValue + another);
		public static TaggedParameter operator -(TaggedParameter parameter, float another)
			=> new TaggedParameter(parameter.Name, parameter.Tags, parameter.InnerValue - another);
		public static TaggedParameter operator *(TaggedParameter parameter, float another) 
			=> new TaggedParameter(parameter.Name, parameter.Tags, parameter.InnerValue * another);
		public static TaggedParameter operator *(float another, TaggedParameter parameter) 
			=> new TaggedParameter(parameter.Name, parameter.Tags, parameter.InnerValue * another);
		public static TaggedParameter operator /(TaggedParameter parameter, float another) 
			=> new TaggedParameter(parameter.Name, parameter.Tags, parameter.InnerValue / another);
	}
}