using System;
using NDoom.Unity.Environment.Main;
using UnityEngine;

namespace NDoom.Unity.Battles.UI.Unit
{
	public class UnitResourceUi : ExtendedMonoBehaviour
	{
		[SerializeField] private SpriteRenderer _renderer;
		private Entities.Unit _unit;
		private float _spriteWidthStored;

		public void Initialize(Entities.Unit unit)
		{
			_unit = unit;
			_spriteWidthStored = _renderer.size.x;
		}

		// Lazy view
		public override void UpdateManually()
		{
			var currentBarFillMultiplier = Math.Min(_unit.Data.Resource.Current / _unit.Data.Resource.Max.FinalValue, 1f);
			_renderer.size = new Vector2(_spriteWidthStored * currentBarFillMultiplier, _renderer.size.y);
		}
	}
}