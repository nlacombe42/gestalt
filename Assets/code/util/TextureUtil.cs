using UnityEngine;

namespace code.util
{
    public static class TextureUtil
    {
        public static Texture2D GetColorTexture(Color color)
        {
            var texture = new Texture2D(1, 1) {wrapMode = TextureWrapMode.Repeat};
            texture.SetPixel(0, 0, color);
            texture.Apply();

            return texture;
        }
    }
}