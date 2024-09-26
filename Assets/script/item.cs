using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public GameObject coinPrefab;
    public ParticleSystem particlePrefab;

    GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Bullet"))
        {
            //파티클생성
            ParticleSystem particle = Instantiate(particlePrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            ParticleSystem.Destroy(particle, 5.0f);
            //선인장파괴
            GameObject.Destroy(gameObject, 0.0f);
            //코인생성
            coin = Instantiate(coinPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            
        }

    }

}
