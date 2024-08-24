/*
Copyright (c) 2022, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System.Collections;
using System.Linq;
using System.Collections.Generic;

using UnityEditor;

using JoaoSant0s.ServicePackage.Canvases;
using JoaoSant0s.CommonWrapper.GUIDrawerEditor;

namespace JoaoSant0s.ServicePackage.CanvasesEditor
{
    [CustomPropertyDrawer(typeof(CanvasIdAttribute))]
    public class CanvasIdAttributeDrawer : CustomIdAttributeDrawer
    {
        protected override string[] Options
        {
            get
            {
                var options = new List<string>() { "-empty-" };
                return options.Concat(CanvasConfig.Get().Ids).ToArray();
            }
        }
    }

}
