using System.Collections;
using System.Collections.Generic;

using UnityEngine.Events;

using UnityEngine;

namespace Main.Scene
{
    public class MainScene : MonoBehaviour
    {
        [SerializeField]
        private SceneComponent[] initializeComponents;

        #region Unity Methids

        private void Start()
        {
            var size = FindObjectsOfType<MainScene>().Length;
            Debug.Assert(size == 1, "Should only count one instance of the class");
            InitComponents();
        }

        #endregion

        #region Private Methods

        private void InitComponents()
        {
            for (int i = 0; i < initializeComponents.Length; i++)
            {
                initializeComponents[i].Initialize();
            }
        }

        #endregion

    }
}