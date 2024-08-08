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
        public void SetRaiseState()
        {
            var flagAsset = ScriptableObject.CreateInstance<FlagAsset>();

            var flagService = Services.Get<FlagService>();
            flagService.Raise(flagAsset);

            var stsate = flagService.State(flagAsset);

            Assert.AreEqual(FlagState.Raise, stsate, "Must be a Raise state");
        }

        [Test]
        public void SetLowerState()
        {
            var flagAsset = ScriptableObject.CreateInstance<FlagAsset>();

            var flagService = Services.Get<FlagService>();
            flagService.Lower(flagAsset);

            var stsate = flagService.State(flagAsset);

            Assert.AreEqual(FlagState.Lower, stsate, "Must be a Lower state");
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

            var stsate = flagService.State(flagAsset);

            Assert.AreEqual(testState, stsate, "Must Have the same state");
        }
    }
}
