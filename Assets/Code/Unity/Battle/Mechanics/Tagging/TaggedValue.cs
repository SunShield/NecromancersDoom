using System.Collections.Generic;

namespace NDoom.Unity.Battles.Mechanics.Tagging
{
	/// <summary>
	/// Tagged values are aclually... Values with certain tags applied to them
	/// Those tags determine how values will be affected by certain effects.
	/// </summary>
	public struct TaggedValue
	{
		/// <summary>
		/// Name here is more for cosmetic, debugging and semantical purposes, then
		/// for real usage
		/// </summary>
		public string Name { get; private set; }

		public HashSet<ValueTag> Tags { get; }
		public float InnerValue { get; private set; }

		public TaggedValue(string name, IEnumerable<ValueTag> tags)
		{
			Tags = new HashSet<ValueTag>();
			InnerValue = 0;
			Name = name;
		}

		public TaggedValue(string name, IEnumerable<ValueTag> tags, float value) : this(name, tags) => InnerValue = value;
		public TaggedValue(TaggedValue value) : this(value.Name, value.Tags, value.InnerValue) {}

		public static TaggedValue operator +(TaggedValue value, float another) => new TaggedValue(value.Name, value.Tags, value.InnerValue + another);
		public static TaggedValue operator +(float another, TaggedValue value) => new TaggedValue(value.Name, value.Tags, value.InnerValue + another);
		public static TaggedValue operator -(TaggedValue value, float another) => new TaggedValue(value.Name, value.Tags, value.InnerValue - another);
		public static TaggedValue operator *(TaggedValue value, float another) => new TaggedValue(value.Name, value.Tags, value.InnerValue * another);
		public static TaggedValue operator *(float another, TaggedValue value) => new TaggedValue(value.Name, value.Tags, value.InnerValue * another);
		public static TaggedValue operator /(TaggedValue value, float another) => new TaggedValue(value.Name, value.Tags, value.InnerValue / another);
	}
}