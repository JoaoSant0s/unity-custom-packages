using System.Collections;
using System.Collections.Generic;

using UnityEngine.Events;

using UnityEngine;

namespace JoaoSant0s.Scene
{
    public abstract partial class MainScene : MonoBehaviour
    {
        [SerializeField]
        protected SceneComponent[] initializeComponents;

        #region Unity Methids

        protected virtual void Start()
        {
            var size = FindObjectsOfType<MainScene>().Length;
            Debug.Assert(size == 1, "Should only count one instance of the class");
            InitComponents();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Init all components on initialize components
        /// </summary>
        protected void InitComponents()
        {
            for (int i = 0; i < initializeComponents.Length; i++)
            {
                initializeComponents[i].Initialize();
            }
        }

        #endregion

    }
}