using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonWrapper
{
    public class DestroyAfterAnimationEnd : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        [SerializeField]
        private float destroyDelay;

        private void Start()
        {
            StartCoroutine(DestroyRoutine());
        }

        private IEnumerator DestroyRoutine()
        {
            yield return new WaitUntil(() => { return this.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.999f; });

            yield return new WaitForSeconds(this.destroyDelay);

            Destroy(gameObject);
        }
    }
}