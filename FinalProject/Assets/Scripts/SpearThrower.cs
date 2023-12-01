using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrower : MonoBehaviour
{
    public GameObject projectilePrefab;
    [SerializeField] float speed = 5f;

    List<GameObject> pool;

    private void Awake()
    {
        pool = new List<GameObject>();
    }

    public void Throw(Vector3 targetPosition)
    {
        GameObject newProjectile;

        if(pool.Count > 50)
        {
            pool.RemoveAt(0);
            newProjectile = pool[0];
            newProjectile.transform.position = transform.position;
        }
        else
        {
            newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
        pool.Add(newProjectile);

        targetPosition.z = 0;
        Vector3 direction = (targetPosition - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x);

        float degrees = Mathf.Rad2Deg * angle;

        newProjectile.transform.rotation = Quaternion.Euler(0, 0, degrees);

        Debug.Log(degrees.ToString());

        Rigidbody2D newProjectileRB = newProjectile.GetComponent<Rigidbody2D>();

        newProjectileRB.velocity = direction * speed;
        newProjectileRB.rotation = degrees;
    }
}
