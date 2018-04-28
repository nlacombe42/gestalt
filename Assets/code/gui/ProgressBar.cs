using code.util;
using UnityEngine;

namespace code.gui
{
    public class ProgressBar
    {
        private static readonly Vector2 TextSize = new Vector2(25, 25);

        private Vector2 _position;
        private Vector2 _size;
        private float _progress;
        private Texture2D _backgroundTexture;
        private Texture2D _foregroundTexture;

        public ProgressBar(Vector2 position, Vector2 size, Color backgroundColor, Color foregroundColor)
        {
            _position = position;
            _size = size;

            _progress = 0;
            _backgroundTexture = TextureUtil.GetColorTexture(backgroundColor);
            _foregroundTexture = TextureUtil.GetColorTexture(foregroundColor);
        }

        public void Draw()
        {
            GUI.DrawTexture(new Rect(_position.x, _position.y, _size.x, _size.y), _backgroundTexture);
            GUI.DrawTexture(new Rect(_position.x, _position.y, _size.x * _progress, _size.y), _foregroundTexture);
            GUI.Label(new Rect(_position.x + _size.x / 2 - TextSize.x / 2, _position.y + _size.y / 2 - TextSize.y / 2, 25, 25), string.Format("{0:N0}%", _progress * 100f));
        }

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Vector2 Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public float Progress
        {
            get { return _progress; }
            set { _progress = value; }
        }
    }
}