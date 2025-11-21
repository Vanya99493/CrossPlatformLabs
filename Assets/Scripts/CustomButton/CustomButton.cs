using UnityEngine;

namespace CrossPlatform.CustomButtonScripts
{
	public class CustomButton : MonoBehaviour
	{
		[SerializeField]
		private Color _normalColor;

		[SerializeField]
		private Color _hoverColor;

		[SerializeField]
		private Color _pressColor;
		
		private CustomButtonDraw _buttonDraw;

		private void Start()
		{
			Rect rect = new Rect(810, 500, 300, 80);
			_buttonDraw = new CustomButtonDraw(rect, _normalColor, _hoverColor, _pressColor);

			_buttonDraw.OnHover += () => Debug.Log("Hover!");
			_buttonDraw.OnPressed += () => Debug.Log("Pressed!");
			_buttonDraw.OnReleased += () => Debug.Log("Released!");
		}

		private void OnGUI()
		{
			_buttonDraw.Draw();
		}
	}
}