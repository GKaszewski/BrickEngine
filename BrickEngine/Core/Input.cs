using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Input;

namespace BrickEngine.Core
{
    public class Input
    {
        #region Keyboard
        private static List<Key> currentKeys = new List<Key>();
        private static List<Key> downKeys = new List<Key>();
        private static List<Key> upKeys = new List<Key>();
        #endregion

        #region Mouse
        private static List<MouseButton> currentMouseButtons = new List<MouseButton>();
        private static List<MouseButton> downMouseButtons = new List<MouseButton>();
        private static List<MouseButton> upMouseButtons = new List<MouseButton>();
        #endregion

        internal static void Update()
        {
            downKeys.Clear();
            for (var i = 0; i < Enum.GetNames(typeof(Key)).Length; i++)
                if (GetKey((Key)i) && !currentKeys.Contains((Key)i))
                    downKeys.Add((Key)i);

            upKeys.Clear();
            for (var i = 0; i < Enum.GetNames(typeof(Key)).Length; i++)
                if (!GetKey((Key) i) && currentKeys.Contains((Key) i))
                    upKeys.Add((Key) i);

            currentKeys.Clear();
            for (var i = 0; i < Enum.GetNames(typeof(Key)).Length; i++)
                if (GetKey((Key) i))
                    currentKeys.Add((Key) i);

            upMouseButtons.Clear();
            for (var i = 0; i < Enum.GetNames(typeof(MouseButton)).Length; i++)
                if (!GetMouseButton((MouseButton)i) && currentMouseButtons.Contains((MouseButton)i))
                    upMouseButtons.Add((MouseButton)i);

            downMouseButtons.Clear();
            for (var i = 0; i < Enum.GetNames(typeof(MouseButton)).Length; i++)
                if (GetMouseButton((MouseButton)i) && !currentMouseButtons.Contains((MouseButton)i))
                    downMouseButtons.Add((MouseButton)i);

            currentMouseButtons.Clear();
            for (var i = 0; i < Enum.GetNames(typeof(MouseButton)).Length; i++)
                if (GetMouseButton((MouseButton) i))
                    currentMouseButtons.Add((MouseButton) i);

        }

        public static bool GetKey(Key key) => BaseEngine.Instance.Focused && Keyboard.GetState().IsKeyDown((short) key);

        public static bool GetKeyDown(Key key) => BaseEngine.Instance.Focused && downKeys.Contains(key);

        public static bool GetKeyUp(Key key) => BaseEngine.Instance.Focused && upKeys.Contains(key);

        public static bool GetMouseButton(MouseButton button) => BaseEngine.Instance.Focused && Mouse.GetState().IsButtonDown(button);

        public static bool GetMouseButtonDown(MouseButton button) => BaseEngine.Instance.Focused && downMouseButtons.Contains(button);

        public static bool GetMouseButtonUp(MouseButton button) => BaseEngine.Instance.Focused && upMouseButtons.Contains(button);

        public static Vector2 GetMousePosition() => new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

        public static void SetMousePosition(Vector2 position) => Mouse.SetPosition(position.X, position.Y);
        public static void SetMousePosition(float x, float y) => Mouse.SetPosition(x, y);

        public static void ShowCursor(bool visibility) => BaseEngine.Instance.CursorVisible = visibility;
    }
}
