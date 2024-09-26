using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{	
	private float plSpeed = 5.0f;
	private float turnSpeed = 5.0f;
	private float bulletspeed = 10.0f;

	public GameObject bulletPrefab;
	public ParticleSystem particlePrefab;
	private Rigidbody mRigidBody = null;

	GameObject bullet = null;

	Vector3 offset = Vector3.zero;

	// Start is called before the first frame update
	void Start()
    {
        mRigidBody = GetComponent<Rigidbody>();
		
	}

	void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.forward * Time.deltaTime * plSpeed);
		}
		if (Input.GetKey(KeyCode.A))
		{		
			transform.Rotate(Vector3.down * turnSpeed);
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.back * Time.deltaTime * plSpeed);
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(Vector3.up * turnSpeed);
		}
		if (Input.GetKey(KeyCode.Q)) //왼쪽으로 90도회전
        {
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-Vector3.right * 90), turnSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.E)) //왼쪽으로 90도회전
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right * 90), turnSpeed * Time.deltaTime);
		}

  //      //테스트용 파티클
  //      if (Input.GetKey(KeyCode.Z))
  //      {
		//	ParticleSystem particle = Instantiate(particlePrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
		//	ParticleSystem.Destroy(particle, 5.0f);
		//}


        if (bullet != null)
        {
			bullet.transform.Translate(Vector3.forward * bulletspeed * Time.deltaTime);
		}

	}


	// Update is called once per frame
	void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			bullet = GameObject.Instantiate<GameObject>(bulletPrefab, transform.position, transform.rotation);
		}
		GameObject.Destroy(bullet, 5.0f);
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Coin"))
		{
			//충돌오브젝트들 삭제
			GameObject.Destroy(other.gameObject, 0.0f);
		}
	}

}
