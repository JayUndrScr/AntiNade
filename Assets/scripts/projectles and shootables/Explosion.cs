using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject checkSphere;
    public GameObject vfx;
    private Rigidbody rb;
    [SerializeField] public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    private void Update()
    {
        Destroy(gameObject, 1.2f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="small")
        {
            Destroy(gameObject);
            GameObject Kaboom = Instantiate(checkSphere, transform.position, transform.rotation);
            Destroy(Kaboom, .03f);
            GameObject goVfx = Instantiate(vfx, transform.position, transform.rotation);
            Destroy(goVfx, 1.2f);
        }
    }
    private void OnDestroy()
    {
        GameObject Kaboom = Instantiate(checkSphere, transform.position, transform.rotation);
        GameObject goVfx = Instantiate(vfx, transform.position, transform.rotation);
        Destroy(Kaboom, .03f);
        Destroy(goVfx, 1.2f);
    }
}
