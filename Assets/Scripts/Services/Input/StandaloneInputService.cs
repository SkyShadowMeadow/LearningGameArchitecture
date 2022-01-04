using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Services.Input
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 Axes
        {
            get
            {
                Vector2 axes = GetSimpleInputAxes();
                if (axes == Vector2.zero)
                    axes = GetSimpleInputAxes();

                return axes;
            }
        }
        private Vector2 GetUnityInputAxes() =>
            new Vector2(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
    }
}

