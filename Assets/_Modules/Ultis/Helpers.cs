using System.Collections.Generic;
using UnityEngine;

namespace Utilities {
    public static class Helpers {
        static Dictionary<float, WaitForSeconds> WaitForSeconds = new();

        public static void QuitGame() {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    

        public static WaitForSeconds GetWaitForSeconds(float seconds) {
            if (!WaitForSeconds.ContainsKey(seconds)) {
                WaitForSeconds[seconds] = new WaitForSeconds(seconds);
            }

            return WaitForSeconds[seconds];
        }
    }
}