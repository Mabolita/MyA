using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float maxThrust;
    public float maxTorque;
    public float speed;
    public Rigidbody2D rb;
    public int Size;
    private GameHandler gameHandler;
    public ParticleSystem PS;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void OnEnable()
    {
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);
        rb.AddForce(thrust);
            transform.Rotate(Vector3.right * torque * Time.deltaTime);
    }
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            if (Size == 3)
            {
                EventManager.Instance.CallEvent("SendScore", 10);
                MultipleObjectPooler.Instance.SpawnFromPool("MediumAsteroid", this.transform.position, this.transform.rotation);
                MultipleObjectPooler.Instance.SpawnFromPool("MediumAsteroid", this.transform.position, this.transform.rotation);
            }
            else if (Size == 2)
            {
                EventManager.Instance.CallEvent("SendScore", 25);
                MultipleObjectPooler.Instance.SpawnFromPool("SmallAsteroid", transform.position, transform.rotation);

            }
            else
            {
                EventManager.Instance.CallEvent("SendScore", 50);
                this.gameObject.SetActive(false);

            }
            
            ParticleSystem obj = Instantiate(PS, transform.position, transform.rotation);
            obj.Play();
            Destroy(obj.gameObject, 2f);
            this.gameObject.SetActive(false);
        }
    }


}
