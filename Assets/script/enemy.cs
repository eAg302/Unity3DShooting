using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemy : MonoBehaviour
{
    Vector3 direction;
    private float turnSpeed = 5.0f;
    float degree = 0.5f;

    public ParticleSystem particlePrefab;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (degree > 360.0f)
        {
            degree -= 360.0f;
        }

        degree += 0.5f;
        transform.Translate(Vector3.forward * 10.0f * Mathf.Sin( degree * Mathf.Deg2Rad) * Time.deltaTime);

    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Bullet"))
        {
            //파티클 생성
            ParticleSystem particle = Instantiate(particlePrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            ParticleSystem.Destroy(particle, 5.0f);
            //충돌오브젝트들 삭제
            GameObject.Destroy(other.gameObject, 0.0f);
            GameObject.Destroy(gameObject, 0.0f);
        }
    }


}
