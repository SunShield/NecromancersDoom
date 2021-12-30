namespace NDoom.Unity.Battle.Mechanics.Modifiable
{
    public class Modification
    {
        public float Value { get; private set; }
        public ModificationType Type { get; private set; }
        // TODO: Later, here will be some info about modification source: innate effect/granted effect, item, etc

        public Modification(float value, ModificationType type)
        {
            Value = value;
            Type = type;
        }

        public Modification(Modification another)
        {
            Value = another.Value;
            Type = another.Type;
        }
    }
}
