using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;

public class Player : MonoBehaviour
{
    public GameObject battery;

    public Rigidbody rigidBody;
    AudioSource audioSource;
    public ParticleSystem flyPartical;

    public float rotSpeed;
    public float flySpeed;

    public int healthPlayer;
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Lounch();
        Rotation();
        HealthBar();
    }

    public void Lounch()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            float flyningSpeed = flySpeed * Time.deltaTime;

            rigidBody.AddRelativeForce(Vector3.up * flyningSpeed);
            healthPlayer -= 1;
            if(audioSource.isPlaying == false)
            {
                audioSource.Play();
                flyPartical.Play();
            }
        }
        else
        {
            audioSource.Stop();
            flyPartical.Stop();
        }
    }

    void Rotation()
    {
        float rotationSpeed = rotSpeed * Time.deltaTime;

        rigidBody.freezeRotation = true;
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }
    }

    void HealthBar()
    {
        healthBar.value = healthPlayer;

        if(healthBar.value == 0)
        {
            flySpeed = 0;
            audioSource.Stop();
            flyPartical.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Battery")
        {
            healthPlayer = 100;
            Destroy(battery);
        }
    }
}