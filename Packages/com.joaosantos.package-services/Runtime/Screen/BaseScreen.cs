using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.ServicePackage.Canvases;

namespace JoaoSant0s.ServicePackage.Screens
{
    public abstract class BaseScreen : MonoBehaviour
    {
        [CanvasIdAttribute]
        [SerializeField]
        private string canvasId;

        public string CanvasId => canvasId;
        
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
