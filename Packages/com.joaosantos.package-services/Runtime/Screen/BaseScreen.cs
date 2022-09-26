using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace JoaoSant0s.ServicePackage.Screens
{
    public abstract class BaseScreen : MonoBehaviour
    {
        protected abstract void OnPrepare();
        protected abstract void OnRelease();

        #region Public Methods

        public void Release()
        {
            OnRelease();
            Destroy(gameObject);
        }

        public void Prepare()
        {
            OnPrepare();
        }

        #endregion
    }
}
