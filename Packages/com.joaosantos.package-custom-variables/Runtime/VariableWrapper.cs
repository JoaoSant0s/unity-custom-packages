/*
Copyright (c) 2022, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System;
using System.Collections.Generic;

namespace JoaoSant0s.CustomVariable
{
    public static class VariableWrapper<T>
    {
        private static Dictionary<Variable<T>, Entry> variables = new Dictionary<Variable<T>, Entry>();

        #region Public Methods

        public static T GetValue(Variable<T> variable, T startValue)
        {
            SetIfUninitialized(variable, startValue);
            return (T)variables[variable].value;
        }

        public static void SetValue(Variable<T> variable, T value)
        {
            if (!variables.ContainsKey(variable)) CreateEntry(variable);

            T previousValue = variables[variable].value;
            variables[variable].value = value;
            variables[variable].OnChanged?.Invoke(previousValue, value);
        }

        public static void AddListener(Variable<T> variable, Action<T, T> onChange)
        {
            variables[variable].OnChanged += onChange;
        }

        public static void RemoveListener(Variable<T> variable, Action<T, T> onChange)
        {
            variables[variable].OnChanged -= onChange;
        }

        public static void SetIfUninitialized(Variable<T> variable, T defaultValue)
        {
            if (variables.ContainsKey(variable)) return;

            CreateEntry(variable);
            variables[variable].value = defaultValue;
        }

        #endregion

        #region Private Methods

        private static void CreateEntry(Variable<T> key)
        {
            variables[key] = new Entry();
        }

        #endregion

        private class Entry
        {
            public T value;
            public Action<T, T> OnChanged;
        }
    }
}
