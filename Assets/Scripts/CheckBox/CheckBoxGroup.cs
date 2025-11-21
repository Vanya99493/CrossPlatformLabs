using System;
using System.Collections.Generic;
using System.Linq;
using CrossPlatform.CheckBox.DataAssets;
using CrossPlatform.CheckBox.Enums;
using CrossPlatform.CheckBox.States;
using UnityEngine;
using UnityEngine.UI;

namespace CrossPlatform.CheckBox
{
	public class CheckBoxGroup : MonoBehaviour
	{
		[SerializeField]
		private Toggle _mainToggle;
		
		[SerializeField]
		private List<Toggle> _toggles;

		[SerializeField]
		private Image _iconImage;

		[SerializeField]
		private CheckBoxIconsDataAsset _checkBoxIconsDataAsset;
		
		private List<BaseCheckBoxState> _checkBoxStates;
		
		private BaseCheckBoxState _currentCheckBoxState;

		private void Awake()
		{
			Initialize();
		}

		private void OnEnable()
		{
			SubscribeToEvents();
		}

		private void OnDisable()
		{
			UnsubscribeFromEvents();
		}

		public void Initialize()
		{
			_checkBoxStates = new()
			{
				new EnabledCheckBoxState(this),
				new DisabledCheckBoxState(this),
				new MixedCheckBoxState(this)
			};
			
			SetState<DisabledCheckBoxState>();
		}

		private void SubscribeToEvents()
		{
			_mainToggle.onValueChanged.AddListener(OnMainToggleValueChanged);
			foreach (var toggle in _toggles)
			{
				toggle.onValueChanged.AddListener(_ => RecalculateState());
			}
		}

		private void UnsubscribeFromEvents()
		{
			_mainToggle.onValueChanged.RemoveListener(OnMainToggleValueChanged);
			foreach (var toggle in _toggles)
			{
				toggle.onValueChanged.RemoveListener(_ => RecalculateState());
			}
		}
		
		public void SetState<T>() where T : BaseCheckBoxState
		{
			_mainToggle.onValueChanged.RemoveListener(OnMainToggleValueChanged);
			
			_currentCheckBoxState = _checkBoxStates.FirstOrDefault(x => x.GetType() == typeof(T));
			_currentCheckBoxState?.EnterState(_mainToggle, _toggles);
			
			_mainToggle.onValueChanged.AddListener(OnMainToggleValueChanged);
		}

		public void UpdateToggleGroupIcon(CheckBoxGroutType checkBoxGroutType)
		{
			try
			{
				_iconImage.sprite = _checkBoxIconsDataAsset.CheckBoxStateDatas.FirstOrDefault(x => x.Type == checkBoxGroutType).Sprite;
			}
			catch (NullReferenceException e)
			{
				Debug.LogWarning("No matched icon image data");
			}
		}

		private void OnMainToggleValueChanged(bool value)
		{
			if (value)
			{
				SetState<EnabledCheckBoxState>();
			}
			else
			{
				SetState<DisabledCheckBoxState>();
			}
		}

		private  void RecalculateState()
		{
			_currentCheckBoxState?.RecalculateState(_toggles);
		}
	}
}