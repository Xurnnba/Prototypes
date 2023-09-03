using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;

    public float minSpeed = 14;
    public float maxSpeed = 16;
    public float maxTorque = 10;
    public float xRange = 4;
    public float ySpawnPos = -6;
    public int pointValue;
    public ParticleSystem explosionParticle;
    [HideInInspector]
    public int fellGoodObject = 1;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(),RandomTorque(),
           RandomTorque(),ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-4, 4), -6);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    

    private void OnMouseDown()
    {
        if (GameManager.gM.isgameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            GameManager.gM.UpdateScore(pointValue);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fellGoodObject > 3)
        {
            GameManager.gM.GameOver();
        }
        if (transform.position.y<ySpawnPos-2)
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("Good"))
            {
                Debug.Log("function called");
                Debug.Log(fellGoodObject);
                //fellGoodObject++;
                
                GameManager.gM.GameOver();
            }

            //if (fellGoodObject > 3)
            //{
            //    GameManager.gM.GameOver();
            //}
        }


    }
}
