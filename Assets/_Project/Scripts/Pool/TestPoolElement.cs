using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.ServicePackage.Pool;

[RequireComponent(typeof(Rigidbody2D))]
public class TestPoolElement : PoolBase
{
    [SerializeField]
    private float delayToHide;

    private Rigidbody2D rb2d;
    private void Awake() 
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private IEnumerator DisposeRoutine()
    {
        yield return new WaitForSeconds(delayToHide);
        Dispose();
    }

    public override void OnDispose()
    {
        rb2d.velocity = Vector2.zero;
    }

    public override void OnShow()
    {        
        StartCoroutine(DisposeRoutine());
    }
}
