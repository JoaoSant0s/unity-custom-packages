/*
Copyright (c) 2024, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using UnityEngine;

using NUnit.Framework;
using JoaoSant0s.ServicePackage.General;

namespace JoaoSant0s.ServicePackage.Flag.Tests
{
    public class FlagServiceTests
    {
        [Test]
        public void CreateFlagAsset()
        {
            var flagAsset = ScriptableObject.CreateInstance<FlagAsset>();

            Assert.AreEqual(true, flagAsset != null, "The created instance can't be null");
        }

        [Test]
        public void NotInitializedFlagState()
        {
            var flagAsset = ScriptableObject.CreateInstance<FlagAsset>();
            var flagService = Services.Get<FlagService>();

            var state = flagService.GetState(flagAsset);

            Assert.AreEqual(FlagState.None, state, "The state must be None (Not Initialized)");
        }

        [Test]
        public void SetRaiseState()
        {
            var flagAsset = ScriptableObject.CreateInstance<FlagAsset>();

            var flagService = Services.Get<FlagService>();
            flagService.Raise(flagAsset);

            var state = flagService.GetState(flagAsset);

            Assert.AreEqual(FlagState.Raise, state, "Must be a Raise state");
        }

        [Test]
        public void SetLowerState()
        {
            var flagAsset = ScriptableObject.CreateInstance<FlagAsset>();

            var flagService = Services.Get<FlagService>();
            flagService.Lower(flagAsset);

            var state = flagService.GetState(flagAsset);

            Assert.AreEqual(FlagState.Lower, state, "Must be a Lower state");
        }

        [TestCase(FlagState.Lower)]
        [TestCase(FlagState.Raise)]
        [TestCase(FlagState.None)]
        public void SetState(FlagState testState)
        {
            var flagAsset = ScriptableObject.CreateInstance<FlagAsset>();

            var flagService = Services.Get<FlagService>();

            if (testState == FlagState.Raise)
                flagService.Raise(flagAsset);
            else if (testState == FlagState.Lower)
                flagService.Lower(flagAsset);

            var state = flagService.GetState(flagAsset);

            Assert.AreEqual(testState, state, "Must Have the same state");
        }
    }
}
