using System.Collections.Generic;
using UnityEngine;

namespace CrossPlatform.CheckBox.DataAssets
{
	[CreateAssetMenu(fileName = "CheckBoxIconsDataAsset", menuName = "Scriptable Objects/Check Box Data Asset")]
	public class CheckBoxIconsDataAsset : ScriptableObject
	{
		public List<CheckBoxStateData> CheckBoxStateDatas = new();
	}
}