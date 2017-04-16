using UnityEngine;
using System.Collections;

public class tankControl : MonoBehaviour {
    public float rotatespeed;
    public float movespeed;
    Rigidbody2D myRigidbody;
    private float timehit;
    public float timeSpin;
    bool isSpinning;
    public float hitSpinSpeed;
	public string axisPlayerRot;
	public string axisPlayerMove;
	public string axisPlayerShoot;
	public GameObject bullet;
	public float bulDelay;
	private float bulTimer;
	public float distFromTank;

    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
		bulTimer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (bullet == null) {

		} else {
			if (Input.GetAxis (axisPlayerShoot) > 0 && Time.time > bulTimer + bulDelay) { // && !isSpinning
				Transform bulTransform = this.transform;
				GameObject tempBullet = (GameObject)Object.Instantiate (bullet, bulTransform.position +
					(Vector3.Scale(transform.forward, transform.localScale) * distFromTank) , bulTransform.rotation);
				//tempBullet.transform.Translate (Vector3.Scale (;//all the knowledge
				Debug.Log(bulTransform.position + (Vector3.Scale(transform.up, transform.localScale) * distFromTank));
			}
		}
	

		float rotation = Input.GetAxis(axisPlayerRot);
        transform.Rotate(0, 0, rotation*rotatespeed*Time.deltaTime);
		float move = Input.GetAxis(axisPlayerMove);
        myRigidbody.velocity = move * movespeed * transform.up;
        if(isSpinning == true)
        {
            transform.Rotate(0, 0, hitSpinSpeed * rotatespeed * Time.deltaTime);
            if(Time.time > timehit + timeSpin)
            {
                isSpinning = false;
            }
        }

        


    }

    public void getHit()
    {
        timehit = Time.time;
        isSpinning = true;
    }
}
