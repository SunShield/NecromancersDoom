using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;

namespace NDoom.Unity.Service.Extensions
{
    public static class BattlefieldSideExtensions
    {
        public static BattlefieldSide Opposite(this BattlefieldSide side)
            => side == BattlefieldSide.Left ? BattlefieldSide.Right : BattlefieldSide.Left;
    }
}
