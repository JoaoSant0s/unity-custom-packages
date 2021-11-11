using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.ServicePackage.Pool;
using JoaoSant0s.ServicePackage.General;

public class TestPoolService : MonoBehaviour
{
    [SerializeField]
    private Transform spawnArea;

    [SerializeField]
    [Range(0, 1)]
    private int index;

    private PoolService poolService;
    void Start()
    {
        poolService = Services.Get<PoolService>();
    }

    #region UI Methosd

    public void SpawnElement()
    {
        poolService.Get<TestPoolElement>(spawnArea, spawnArea.position, index);
    }

    #endregion
}
