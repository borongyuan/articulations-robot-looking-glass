//Copyright 2017-2021 Looking Glass Factory Inc.
//All rights reserved.
//Unauthorized copying or distribution of this file, and the source code contained herein, is strictly prohibited.

using System;
using UnityEngine;

namespace LookingGlass.Demos {
    public class DemoQuiltToggle : MonoBehaviour {
        [Serializable]
        public enum WhatToShow {
            SceneOnly,
            QuiltOnly,
            SceneOnQuilt
        }

        [SerializeField] private Holoplay holoplay;
        [SerializeField] private Texture2D quiltToOverrideWith;
        [SerializeField] private WhatToShow whatToShow = WhatToShow.SceneOnly;

        private WhatToShow lastFrame;

        private void Start() {
            holoplay.OverrideQuilt = quiltToOverrideWith;
            holoplay.RenderOverrideBehind = true;
            holoplay.CameraData.BackgroundColor = new Color(0, 0, 1, 1);
        }

        private void Update() {
            if (whatToShow != lastFrame) {
                switch (whatToShow) {
                    case WhatToShow.SceneOnly:
                        holoplay.RenderOverrideBehind = true;
                        holoplay.CameraData.BackgroundColor = new Color(0, 0, 1, 1);
                        break;
                    case WhatToShow.QuiltOnly:
                        holoplay.RenderOverrideBehind = false;
                        holoplay.CameraData.BackgroundColor = new Color(0, 0, 1, 1);
                        break;
                    case WhatToShow.SceneOnQuilt:
                        holoplay.RenderOverrideBehind = true;
                        holoplay.CameraData.BackgroundColor = new Color(0, 0, 1, 0);
                        break;
                }
                lastFrame = whatToShow;
            }
        }
    }
}
