using System.Collections.Generic;
using CrossPlatform.CheckBox.Enums;
using UnityEngine.UI;

namespace CrossPlatform.CheckBox.States
{
	public class DisabledCheckBoxState : BaseCheckBoxState
	{
		public DisabledCheckBoxState(CheckBoxGroup stateMachine) : base(stateMachine)
		{
		}

		public override void EnterState(Toggle mainToggle, List<Toggle> toggles)
		{
			mainToggle.isOn = false;
			_stateMachine.UpdateToggleGroupIcon(CheckBoxGroutType.Disabled);

			foreach (var toggle in toggles)
			{
				toggle.isOn = false;
			}
		}

		public override void RecalculateState(List<Toggle> toggles)
		{
			bool isAllEnabled = false;
			bool isAllDisabled = false;
			int counter = 0;
			
			foreach (var toggle in toggles)
			{
				isAllEnabled = (toggle.isOn && counter == 0) || (toggle.isOn && isAllEnabled);
				isAllDisabled = (!toggle.isOn && counter == 0) || (!toggle.isOn && isAllDisabled);

				counter++;
			}

			if (isAllDisabled)
			{
				return;
			}
			else if (isAllEnabled)
			{
				_stateMachine.SetState<EnabledCheckBoxState>();
			}
			else
			{
				_stateMachine.SetState<MixedCheckBoxState>();
			}
		}
	}
}