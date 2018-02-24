using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace DaleranGames.Transformers
{
    public class RandomTransformer : MonoBehaviour
    {

        [SerializeField]
        Vector2 RandomTranslation;

        [SerializeField]
        Vector2 RandomRotation;

        [SerializeField]
        Vector2 RandomTime;

        // Use this for initialization
        void Start()
        {
            Vector3 translate = transform.position + new Vector3(Random.Float(RandomTranslation.x, RandomTranslation.y), Random.Float(RandomTranslation.x, RandomTranslation.y), 0f);
            Vector3 rotation = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Random.Float(RandomRotation.x, RandomRotation.y));
            float time = Random.Float(RandomTime.x, RandomTime.y);

            transform.DOMove(translate, time);
            transform.DOLocalRotate(rotation, time);


        }

    }
}

