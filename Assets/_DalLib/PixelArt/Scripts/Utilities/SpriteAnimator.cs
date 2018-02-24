using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.Sprites
{
    public class SpriteAnimator : MonoBehaviour
    {
        [SerializeField]
        SpriteRenderer sprite;
#pragma warning disable 0649
        [SerializeField]
        [Reorderable]
        List<Sprite> spriteFrames;
#pragma warning restore 0649

        [SerializeField]
        bool startOnAwake = true;

        [SerializeField]
        protected bool isPlaying;
        public bool IsPlaying
        {
            get { return isPlaying; }
            set { isPlaying = value; }
        }

        [SerializeField]
        protected float framesPerSecond;

        int currentFrame = 0;
        public int CurrentFrame
        {
            get { return currentFrame; }
        }

        [SerializeField]
        protected WrapMode mode;
        public WrapMode Mode
        {
            get { return mode; }
            set { mode = value; }
        }
        float pingPong = 1;
        // Use this for initialization
        void Start()
        {
            if (sprite == null)
                sprite = gameObject.GetRequiredComponent<SpriteRenderer>();

            if (startOnAwake)
            {
                isPlaying = true;
                currentFrame = 0;
            }
        }

        public void ToggleAnimation(bool state)
        {
            if (state)
            {
                currentFrame = 0;
                isPlaying = true;
            }
            else
            {
                currentFrame = 0;
                isPlaying = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (isPlaying)
                UpdateAnimation();
        }

        void UpdateAnimation()
        {
            EvaluateAnimation();
            sprite.sprite = spriteFrames[EvaluateAnimation()];
        }

        int EvaluateAnimation()
        {
            return 0;

            /*
            if (mode == WrapMode.Loop)
            {
                currentFrame += Time.deltaTime;

                if (currentFrame >= animationTime)
                {
                    currentFrame = 0f;
                }
            }
            else if (mode == WrapMode.Once)
            {
                currentFrame += Time.deltaTime;

                if (currentFrame >= animationTime)
                {
                    currentFrame = 0f;
                    isPlaying = false;
                }
            }
            else if (mode == WrapMode.ClampForever || mode == WrapMode.Clamp)
            {
                currentFrame += Time.deltaTime;

                if (currentFrame >= animationTime)
                {
                    currentFrame = animationTime;
                    isPlaying = false;
                }
            }
            else
            {
                currentFrame += Time.deltaTime * pingPong;

                if (currentFrame >= animationTime)
                {
                    currentFrame = animationTime;
                    pingPong = -1f;
                }
                else if (currentFrame <= 0f)
                {
                    currentFrame = 0f;
                    pingPong = 1f;
                }
            }
            */

        }


    }
}

