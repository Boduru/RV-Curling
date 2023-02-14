using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : MonoBehaviour
{
    public GameObject prefab;
    private GameObject stone;
    public AudioSource fireSound;
    public float delay = 1.0f;

    private float force = 15.0f;
    private float smooth = 2.0f;
    private float timeFire = 0.0f;

    private float xAngle;
    private float yAngle;
    private float zAngle;
    private bool canFire = false;

    // Start is called before the first frame update
    void Start()
    {
        xAngle = transform.rotation.eulerAngles.x;
        yAngle = transform.rotation.eulerAngles.y;
        zAngle = transform.rotation.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        if (canFire && Time.time - timeFire >= delay)
        {
            timeFire = Time.time;
            float angle = transform.rotation.eulerAngles.z;

            Vector3 pos = transform.GetChild(0).position;

            stone = Instantiate(prefab, pos, transform.rotation);
            stone.GetComponent<Rigidbody>().AddForce(transform.rotation * new Vector3(0, force, 0), ForceMode.Impulse);

            // Get particles from the stone
            GameObject.Find("ExplosionPS").GetComponent<ParticleSystem>().Play();

            fireSound.volume = 0.5f;
            fireSound.Play();
        }
    }

    public void SetCanFire(bool canFire)
    {
        this.canFire = canFire;
    }

    public bool GetCanFire()
    {
        return canFire;
    }

    public void ChangeYAngle(float angle)
    {
        Quaternion target = Quaternion.Euler(xAngle, yAngle, zAngle + angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
    }
}
