using System.Collections.Generic;
using UnityEngine.UI;

namespace CrossPlatform.CheckBox
{
	public abstract class BaseCheckBoxState
	{
		protected readonly CheckBoxGroup _stateMachine;

		protected BaseCheckBoxState(CheckBoxGroup stateMachine)
		{
			_stateMachine = stateMachine;
		}

		public abstract void EnterState(Toggle mainToggle, List<Toggle> toggles);

		public abstract void RecalculateState(List<Toggle> toggles);
	}
}