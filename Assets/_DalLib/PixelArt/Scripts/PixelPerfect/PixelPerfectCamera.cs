using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DaleranGames.PixelArt
{
    [AddComponentMenu("Rendering/Pixel Perfect Camera")]
    public class PixelPerfectCamera : MonoBehaviour
    {
        [SerializeField]
        int pixelsPerUnit = 1;
        public float PixelsPerUnit { get { return pixelsPerUnit; } }

        float unitsInPixels;
        public float UnitsInPixel { get { return unitsInPixels; } }

        [SerializeField]
        [Range(1,20)]
        int scale = 1;
        public int Scale
        {
            get { return scale; }
            set
            {
                if (value > 0)
                {
                    scale = value;
                    ScaleCamera();
                    ScaleChanged?.Invoke(scale); 
                }
            }
        }
        public event Action<int> ScaleChanged;

        protected Camera cam;
        // Use this for initialization
        void Start()
        {
            ScaleCamera();
        }

        private void OnValidate()
        {
            unitsInPixels = 1 / pixelsPerUnit;
        }

        protected virtual float CalculateOrthographicSize(float scale)
        {
            return Screen.height / (scale * PixelsPerUnit) * 0.5f;
        }

        [ContextMenu("Scale Camera")]
        public void ScaleCamera()
        {
            ScaleCamera(Scale);
        }

        public void ScaleCamera(int scale)
        {
            cam = gameObject.GetRequiredComponent<Camera>();
            cam.orthographicSize = CalculateOrthographicSize(scale);
        }

    }
}

