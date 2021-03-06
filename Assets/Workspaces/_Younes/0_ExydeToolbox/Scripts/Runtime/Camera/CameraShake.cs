using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExydeToolbox{
    public  class CameraShake : MonoBehaviour{
        public static CameraShake instance;
        private Vector3 originalPos;

        void Awake(){
            originalPos = transform.localPosition;
            instance = this;
        }

        public static void Shake (float duration, float amount) {
            instance.StopAllCoroutines();
            instance.StartCoroutine(instance.cShake(duration, amount));
        }
        
        public IEnumerator cShake (float duration = 0.2f, float amount = 0.2f) {
            float endTime = Time.time + duration;

            while (Time.time < endTime) {
                transform.localPosition = originalPos + Random.insideUnitSphere * amount;

                duration -= Time.deltaTime;

                yield return null;
            }

            transform.localPosition = originalPos;
        }

    }
}


