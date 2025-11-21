using System;
using UnityEditor;
using UnityEngine;

namespace CrossPlatform.CustomButtonScripts
{
	public class CustomButtonDraw
	{
		public Rect Rect;
		public Color NormalColor = Color.gray;
		public Color HoverColor = Color.white;
		public Color PressColor = Color.green;

		public event Action OnHover;
		public event Action OnPressed;
		public event Action OnReleased;

		private bool _isHover;
		private bool _isPressed;

		public CustomButtonDraw(Rect rect)
		{
			Rect = rect;
		}
		
		public CustomButtonDraw(Rect rect, Color normalColor, Color hoverColor, Color pressColor)
		{
			Rect = rect;
			NormalColor = normalColor;
			HoverColor = hoverColor;
			PressColor = pressColor;
		}

		public void Draw()
		{
			Event currentEvent = Event.current;

			bool mouseInside = Rect.Contains(currentEvent.mousePosition);

			if (mouseInside && !_isHover)
			{
				_isHover = true;
				OnHover?.Invoke();
			}
			else if (!mouseInside)
			{
				_isHover = false;
			}

			if (mouseInside && currentEvent.type == EventType.MouseDown && currentEvent.button == 0)
			{
				_isPressed = true;
				OnPressed?.Invoke();
			}

			if (_isPressed && currentEvent.type == EventType.MouseUp)
			{
				_isPressed = false;
				OnReleased?.Invoke();
			}

			Color currentColor =
				_isPressed ? PressColor :
				_isHover ? HoverColor :
				NormalColor;

			EditorGUI.DrawRect(Rect, currentColor);
		}
	}
}