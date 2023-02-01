using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour 
{
	public float moveSpeed;
	public float angularSpeed;
	public float attackRate;
	private float attackTimer;
	public float bulletSpeed;
	public float bulletSpread = 1.0f;
	public bool canMove;
	public Transform rocketSprite1;
	public Transform rocketSprite2;
	public Transform rocketSprite;
	public bool canHoldFire; //Can the player hold down space to fire?
	public Vector3 mousePosition;
	//Prefabs
	public GameObject bulletPrefab;

	//Components
	public Animator anim;
	public GameObject mousePositionWorld;
	public static Rocket r;

	void Awake () { r = this; }

	void Update ()
	{
		if(canMove){
			RotateRocket();
			movRocket();
			}

		if(!canHoldFire && Input.GetMouseButtonDown(0) && canMove)
		{
			if(attackTimer > attackRate)
			{
				attackTimer = 0.0f;
				Shoot();
			}
		}
		else if(canHoldFire && Input.GetMouseButtonDown(0))
		{
			if(attackTimer > attackRate)
			{
				attackTimer = 0.0f;
				Shoot();
			}
		}

		attackTimer += Time.deltaTime;
	}

	//Rotates the rocket around the planet.
	void RotateRocket ()
	{
		transform.eulerAngles += new Vector3(0, 0, (-angularSpeed * Input.GetAxis("Horizontal")) * Time.deltaTime);
		rocketSprite.localEulerAngles = new Vector3(0, 0, Input.GetAxis("Horizontal") * -30);
	}

	void movRocket ()
	{
		transform.position += new Vector3(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime,   moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0);
		rocketSprite.localEulerAngles = new Vector3(0, 0, Input.GetAxis("Horizontal") * -30);
	}

	//Shoots a bullet forward from the player.
	void Shoot ()
	{
		GameObject bullet1 = Instantiate(bulletPrefab, rocketSprite1.transform.position, transform.rotation);

		Vector2 dir1 = ((mousePositionWorld.transform.position- rocketSprite1.transform.position).normalized)* (bulletSpeed * Random.Range(1.0f, 1.1f));
		//rocketSprite1.transform.position.normalized * (bulletSpeed * Random.Range(1.0f, 1.1f));
		Vector3 offset1 = bullet1.transform.right * Random.Range(-bulletSpread, bulletSpread);
		//dir1.x += offset1.x;
		//dir1.y += offset1.y;





		bullet1.GetComponent<Rigidbody2D>().velocity = dir1;

		if(canHoldFire)
		{
			for(int x = -1; x < 2; x++)
			{
				if(x != 0)
				{
					bullet1 = Instantiate(bulletPrefab, rocketSprite1.transform.position, rocketSprite1.rotation);

					dir1 = ((mousePositionWorld.transform.position- rocketSprite1.transform.position).normalized) * (bulletSpeed * Random.Range(1.0f, 1.1f));
					//rocketSprite1.transform.position.normalized * (bulletSpeed * Random.Range(1.0f, 1.1f));
					offset1 = bullet1.transform.right * (x * 5 + Random.Range(-bulletSpread, bulletSpread));
					//dir1.x += offset1.x;
					//dir1.y += offset1.y;

					bullet1.GetComponent<Rigidbody2D>().velocity = dir1;
				}
			}
		}


				GameObject bullet2 = Instantiate(bulletPrefab, rocketSprite2.transform.position, new Quaternion(0,0,0,0));

		Vector2 dir2 = ((mousePositionWorld.transform.position - rocketSprite2.transform.position).normalized) * (bulletSpeed * Random.Range(1.0f, 1.1f));
		//rocketSprite2.transform.position.normalized * (bulletSpeed * Random.Range(1.0f, 1.1f));
		Vector3 offset2  = bullet2.transform.right * Random.Range(-bulletSpread, bulletSpread);
		//dir2.x += offset2.x;
		//dir2.y += offset2.y;

		bullet2.GetComponent<Rigidbody2D>().velocity = dir2;

		if(canHoldFire)
		{
			for(int x = -1; x < 2; x++)
			{
				if(x != 0)
				{
					bullet2 = Instantiate(bulletPrefab, rocketSprite2.transform.position, rocketSprite2.rotation);

					dir2 =  (mousePositionWorld.transform.position.normalized - rocketSprite2.transform.position.normalized)* (bulletSpeed * Random.Range(1.0f, 1.1f));
					//rocketSprite2.transform.position.normalized * (bulletSpeed * Random.Range(1.0f, 1.1f));
					offset2 = bullet2.transform.right * (x * 5 + Random.Range(-bulletSpread, bulletSpread));
					//dir2.x += offset2.x;
					//dir2.y += offset2.y;


					bullet2.GetComponent<Rigidbody2D>().velocity = dir2;

				}
				



			}




		}
		print("mouse");
		Debug.Log(mousePositionWorld.transform);
		print("pao");
		Debug.Log(rocketSprite2.transform.position);
		print("DIR2");
		Debug.Log(dir2);
		AudioManager.am.PlayShoot();








	}

	//EFFECTS

	//Allows the player to hold down the fire button.
	public void ActivateSpeedFire () { if(!canHoldFire) StartCoroutine(SpeedFireTimer()); }

	IEnumerator SpeedFireTimer ()
	{
		canHoldFire = true;
		yield return new WaitForSeconds(5.0f);
		canHoldFire = false;
	}

			public  void moveLeft ()
		{
			transform.Translate(new Vector3(-1,0,0));
		}

		public void moveRight ()
		{
			
			transform.Translate(new Vector3(1,0,0));
			
		}
		
		public  void moveUp ()
		{
			
			transform.Translate(new Vector3(0,1,0));
			
		}



		public void moveDown ()
		{
			
			transform.Translate(new Vector3(0,-1,0));
			
		}


}
