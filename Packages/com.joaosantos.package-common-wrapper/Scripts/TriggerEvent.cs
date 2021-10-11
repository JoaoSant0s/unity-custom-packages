using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CommonWrapper
{
    public class TriggerEvent : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent events;

        #region Events Methods

        public void OnTrigger()
        {
            events?.Invoke();
        }

        #endregion

    }
}