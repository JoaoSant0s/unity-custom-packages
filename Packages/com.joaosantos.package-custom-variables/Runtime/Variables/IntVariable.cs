/*
Copyright (c) 2022, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using UnityEngine;

namespace JoaoSant0s.CustomVariable
{
    [CreateAssetMenu(fileName = "IntVariable", menuName = "JoaoSant0s/CustomVariablePackage/IntVariable")]
    public class IntVariable : Variable<int>
    {
        #region Public Methods

        public void Increment(int value)
        {
            Value += value;
        }

        #endregion
    }
}
