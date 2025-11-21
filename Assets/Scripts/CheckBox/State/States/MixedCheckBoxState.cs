using System.Collections.Generic;
using CrossPlatform.CheckBox.Enums;
using UnityEngine.UI;

namespace CrossPlatform.CheckBox.States
{
	public class MixedCheckBoxState : BaseCheckBoxState
	{
		public MixedCheckBoxState(CheckBoxGroup stateMachine) : base(stateMachine)
		{
		}

		public override void EnterState(Toggle mainToggle, List<Toggle> toggles)
		{
			mainToggle.isOn = true;
			_stateMachine.UpdateToggleGroupIcon(CheckBoxGroutType.Mixed);
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
				_stateMachine.SetState<DisabledCheckBoxState>();
			}
			else if (isAllEnabled)
			{
				_stateMachine.SetState<EnabledCheckBoxState>();
			}
			else
			{
				return;
			}
		}
	}
}