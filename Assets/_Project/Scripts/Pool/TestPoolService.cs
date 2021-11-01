using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.ServicePackage.Pool;
using JoaoSant0s.ServicePackage.General;

public class TestPoolService : MonoBehaviour
{
    [SerializeField]
    private Transform spawnArea;
    private PoolService poolService;
    void Start()
    {
        poolService = Services.Get<PoolService>();
    }

    #region UI Methosd

    public void SpawnElement()
    {
        var element = poolService.Instatiate<PoolBase>(spawnArea, spawnArea.position);
    }

    #endregion
}
