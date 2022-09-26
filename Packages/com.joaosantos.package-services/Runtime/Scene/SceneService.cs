/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using JoaoSant0s.ServicePackage.General;

namespace JoaoSant0s.ServicePackage.Scenes
{
    public class SceneService : Service
    {
        public event Action<string, bool> OnLoadStarted;
        public event Action<Scene, LoadSceneMode> OnSceneLoaded;
        public event Action<Scene, Scene> OnActiveSceneChanged;
        public event Action<Scene> OnSceneUnloaded;
        public event Action<AsyncOperation> OnLoadCompleteAsyncScene;

        public string CurrentSceneName { get; protected set; }

        #region Override Methods

        public override void OnInit()
        {
            SceneManager.sceneLoaded += SceneLoaded;
            SceneManager.sceneUnloaded += SceneUnloaded;
            SceneManager.activeSceneChanged += ActiveSceneChanged;

            CurrentSceneName = SceneManager.GetActiveScene().name;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Load a scene Sync
        /// </summary>
        /// <param name="sceneName"> the scene name </param>
        /// <param name="mode"> load scene mode. Default is Single </param>
        public void Load(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
        {
            OnLoadStarted?.Invoke(sceneName, false);

            SceneManager.LoadScene(sceneName, mode);
            CurrentSceneName = sceneName;
        }

        /// <summary>
        /// Load a scene Async
        /// </summary>
        /// <param name="sceneName"> the scene name </param>
        /// <param name="mode"> load scene mode. Default is Single </param>
        public void LoadAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
        {
            OnLoadStarted?.Invoke(sceneName, true);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, mode);
            asyncLoad.completed += (AsyncOperation operation) => CurrentSceneName = sceneName;
            asyncLoad.completed += LoadCompleteAsyncScene;
        }

        #endregion

        #region Private Methods

        private void SceneLoaded(Scene scene, LoadSceneMode mode) => OnSceneLoaded?.Invoke(scene, mode);
        private void ActiveSceneChanged(Scene current, Scene next) => OnActiveSceneChanged?.Invoke(current, next);
        private void SceneUnloaded(Scene current) => OnSceneUnloaded?.Invoke(current);
        private void LoadCompleteAsyncScene(AsyncOperation operation) => OnLoadCompleteAsyncScene?.Invoke(operation);

        #endregion
    }
}
