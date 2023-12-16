using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float speed;

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    void Update()
    {
        if (target)
        {
            Vector3 dir = target.position - transform.position;
            transform.forward = dir;
            transform.Translate(transform.forward * TimedeltaTime * speed, Space.World);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


}