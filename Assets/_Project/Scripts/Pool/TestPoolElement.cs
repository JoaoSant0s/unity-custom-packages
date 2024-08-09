using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.ServicePackage.Pool;

[RequireComponent(typeof(Rigidbody2D))]
public class TestPoolElement : PoolBehaviour
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

    protected override void OnDispose()
    {
        rb2d.velocity = Vector2.zero;
    }

    protected override void OnShow()
    {
        StartCoroutine(DisposeRoutine());
    }
}
