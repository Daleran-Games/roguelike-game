﻿using UnityEngine;

namespace DaleranGames.PixelArt
{
    [ExecuteInEditMode]
    public class SpriteOutline : MonoBehaviour
    {
        public Color Color = Color.white;

        [Range(0, 16)]
        public int outlineSize = 1;

        private SpriteRenderer spriteRenderer;

        void OnEnable()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            UpdateOutline(true);
        }

        void OnDisable()
        {
            UpdateOutline(false);
        }

        void Update()
        {
            UpdateOutline(true);
        }

        void UpdateOutline(bool outline)
        {
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();
            spriteRenderer.GetPropertyBlock(mpb);
            mpb.SetFloat("_Outline", outline ? 1f : 0);
            mpb.SetColor("_OutlineColor", Color);
            mpb.SetFloat("_OutlineSize", outlineSize);
            spriteRenderer.SetPropertyBlock(mpb);
        }
    }
}
