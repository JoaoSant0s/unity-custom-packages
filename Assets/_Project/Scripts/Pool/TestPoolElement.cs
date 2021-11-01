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

    private void OnEnable() 
    {
        //Must Use to enable configs and functions any time, because the object will be reused
        StartCoroutine(HideRoutine());
    }

    private void OnDisable() 
    {
        //Must Use to disable configs and functions any time, because the object will be reused
    }

    private IEnumerator HideRoutine()
    {
        yield return new WaitForSeconds(delayToHide);
        Hide();
    }

    public override void OnHide()
    {
        rb2d.velocity = Vector2.zero;
    }
}
