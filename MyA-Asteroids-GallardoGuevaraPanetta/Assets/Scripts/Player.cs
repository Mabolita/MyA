using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Player : MonoBehaviour
{
    public Vector2 dir;
    public Rigidbody2D _rb;
    public float turnInput;

    public float timer;
    public float timetoshoot;

    public float timer1;
    public float timetoshoot1;

    public Transform fireposition;
    public GameObject projectile;
    public float projectileforce;
    public GameObject[] motorfire;

    public AudioClip[] shootSounds;
    public AudioSource Audio;

    private WeaponHandler WH;
    public GameObject laser;
    public BulletFactory _bulletFactory;
    public ObjectPooler _objectPooler;
    public bool isCrashed;
    bool isFiring;









    List<IObserver> _allObserver = new List<IObserver>();

    void Save()
    {
        // JSONObject player
    }


    // Start is called before the first frame update
    void Start()
    {
        WH = GetComponent<WeaponHandler>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = fireposition.position - transform.position;
        if (MainMenu.GameIsPaused == false)
        {

            if (Input.GetMouseButtonDown(0) & timer <= 0 && isFiring == false)
            {
                Fire();
                timer = timetoshoot;
                Audio.clip = shootSounds[0];
                Audio.Play();

            }
            else if (timer > 0)
            {
                timer -= Time.deltaTime;
            }

            if (Input.GetMouseButton(1) && timer1 <= 0)
            {

                if (WH._currentWeaponIndex == 0)
                {
                    
                    Audio.clip = shootSounds[2];
                    Audio.Play();
                }
                else
                {
                    Audio.clip = shootSounds[1];
                    Audio.Play();
                }
                WH._currentWeapon.Throw();
                timer1 = timetoshoot1;
                isFiring = true;

            }
                
            else if (Input.GetMouseButtonUp(1))
            {
                laser.SetActive(false);
                if (WH._currentWeaponIndex == 0)
                {
                  
                    Audio.Pause();
                }
                isFiring = false;
               

            }
            else if (timer1 > 0)
            {
                timer1 -= Time.deltaTime;
            }
        }


    }

    private void FixedUpdate()
    {
        float inputVer = Input.GetAxis("Vertical");
        float inputHor = Input.GetAxis("Horizontal");
        _rb.AddRelativeForce(Vector2.up * inputVer);
        transform.Rotate(Vector3.forward * inputHor * Time.deltaTime * turnInput);


        if (Input.GetKey(KeyCode.W))
        {
            for (int i = 0; i < motorfire.Length; i++)
            {
                motorfire[i].SetActive(true);
            }
        }
        else
        {
            motorfire[0].SetActive(false);
            motorfire[1].SetActive(false);
        }


    }

    private void Fire()
    {
        _objectPooler.GetPooledObject(fireposition.position, fireposition.rotation);


        // MultipleObjectPooler.Instance.SpawnFromPool("Bullet", fireposition.position, fireposition.rotation);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9 && isCrashed == false)
        {
            EventManager.Instance.CallEvent("LifeLoss");
            StartCoroutine(Crashing());
            return;
            //NotifyEvent("LifeLoss");
        }
    }
    IEnumerator Crashing()
    {
        isCrashed = true;

        yield return new WaitForSeconds(0.5f);

        isCrashed = false;
    }
}
