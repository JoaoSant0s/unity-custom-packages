using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.ServicePackage.General;
using JoaoSant0s.ServicePackage.Routine;
using JoaoSant0s.CommonWrapper;

public class TestRoutineService : MonoBehaviour
{
    private RoutineService routineService;

    private bool condition;

    private bool condition2;

    private int counter;

    void Awake()
    {
        routineService = Services.Get<RoutineService>();
        Debug.Log("Execute the function after 5 seconds");

        routineService.WaitTimeThenDo(5, () =>
        {
            Debug.Log("Executed after 5 seconds");
            condition = true;
        });

        Debug.Log("Checking when condition will be true");

        routineService.WaitUntilThenDo(() => condition, () =>
        {
            Debug.Log("Executed if condition true");
            condition2 = true;
        });

        Debug.Log("Checking when condition will be true");

        routineService.RepeatActionUntilDuringIntervalTime(() =>
        {
            Debugs.Log("Repeat action", counter);
            counter++;
        }, () => condition2, 1, WaitRoutineOptions.SkipFrame);
    }
}
