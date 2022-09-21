/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using UnityEngine;

namespace JoaoSant0s.Scene
{
    public abstract class MainScene : MonoBehaviour
    {
        [Header("Main Scene")]
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