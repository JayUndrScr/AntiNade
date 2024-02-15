using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroid : MonoBehaviour
{
    public movement Movement;


    Rigidbody rb;
    public GameObject astroids;
    public Transform astroidP;
    public GameObject megumin;

    private bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        Movement = FindAnyObjectByType<movement>();

        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(Random.Range(100f, -100f), 0, Random.Range(100, -100)));
        rb.AddTorque(new Vector3(Random.Range(100f, -100f), 0, Random.Range(100, -100)));
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "bullet")
        {
            if (astroids != null && !isHit)
            {
                isHit = true;
                for (int i = 0; i < 2; i++)
                {
                    Instantiate(astroids, astroidP.transform.position, Quaternion.identity);
                }
                StartCoroutine(HitCooldown());
            }
            GameObject meguMegu = Instantiate(megumin, astroidP.transform.position, Quaternion.identity);
            Destroy(meguMegu, 2f);
            if (astroids == null)
            {

                GameObject.Find("gameManager").GetComponent<gameManager>().LostAstroids();
            }
            else
            {
                int current = 1;
                if (astroids.name.Equals("astroidsM"))
                {
                    current = 2;
                }
                GameObject.Find("gameManager").GetComponent<gameManager>().SplitAstroids(current);
            }
            Movement.charge++;
            Destroy(gameObject);
        }



        if (collision.gameObject.tag == "Player")
        {
            if (astroids != null)
            {
                for (int i = 0; i < 2; i++)
                {
                    Instantiate(astroids, astroidP.transform.position, Quaternion.identity);
                }
            }
            GameObject meguMegu = Instantiate(megumin, astroidP.transform.position, Quaternion.identity);
            Destroy(meguMegu, 2f);
            if (astroids == null)
            {

                GameObject.Find("gameManager").GetComponent<gameManager>().LostToSmall();
            }


            else
            {
                int current = 1;
                if (astroids.name.Equals("astroidsM"))
                {
                    current = 2;
                }
                GameObject.Find("gameManager").GetComponent<gameManager>().LosePoints(current);
            }
            Destroy(gameObject);
        }
    }
    public void Dynamite()
    {
        if (astroids != null)
        {
            for (int i = 0; i < 2; i++)
            {
                Instantiate(astroids, astroidP.transform.position, Quaternion.identity);
            }
        }
        GameObject meguMegu = Instantiate(megumin, astroidP.transform.position, Quaternion.identity);
        Destroy(meguMegu, 2f);
        if (astroids == null)
        {
            GameObject.Find("gameManager").GetComponent<gameManager>().LostAstroids();
        }
        else
        {
            int current = 1;
            if (astroids.name.Equals("astroidsM"))
            {
                current = 2;
            }
            GameObject.Find("gameManager").GetComponent<gameManager>().SplitAstroids(current);
        }
        Destroy(gameObject);
    }
    IEnumerator HitCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        isHit = false;
    }
}
