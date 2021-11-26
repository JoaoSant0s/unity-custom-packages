using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace JoaoSant0s.CommonWrapper
{
    public class AnimationWrapper : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        #region Public Methods

        /// <summary>
        /// Execute a action after a animation end
        /// </summary>
        /// <param name="action"> Unity action that be executed after animation end</param>
        /// <param name="beforeAnimationDelay"> An extra delay to check if the animation really started</param>
        /// <param name="afterAnimationDelay"> An extra delay that apply after the animation end</param>
        public Coroutine ExecuteOnAnimationEnd(UnityAction action, float beforeAnimationDelay = 0, float afterAnimationDelay = 0)
        {
            return StartCoroutine(ExecuteOnAnimationEndRoutine(action, beforeAnimationDelay, afterAnimationDelay));
        }

        #endregion

        #region Private Methods

        private IEnumerator ExecuteOnAnimationEndRoutine(UnityAction action, float beforeAnimationDelay, float afterAnimationDelay)
        {
            if (beforeAnimationDelay != 0)
            {
                yield return new WaitForSeconds(beforeAnimationDelay);
            }

            yield return new WaitUntil(() => { return this.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.999f; });

            if (afterAnimationDelay != 0)
            {
                yield return new WaitForSeconds(afterAnimationDelay);
            }

            action();
        }

        #endregion
    }
}