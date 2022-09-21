/*
Copyright (c) 2022, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using UnityEngine;

namespace JoaoSant0s.CustomVariable
{
    [CreateAssetMenu(fileName = "BoolVariable", menuName = "JoaoSant0s/CustomVariablePackage/BoolVariable")]

    public class BoolVariable : Variable<bool>
    {
        #region Public Methods

        public void OperationAnd(bool value)
        {
            Value &= value;
        }

        public void OperationOr(bool value)
        {
            Value |= value;
        }

        #endregion
    }
}
