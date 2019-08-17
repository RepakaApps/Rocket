using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rigidBody;
    public AudioSource audioSource;
    public ParticleSystem flyPartical;

    public float rotSpeed;
    public float flySpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody.GetComponent<Rigidbody>();
        audioSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Lounch();
        Rotation();
    }

    void Lounch()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            rigidBody.AddRelativeForce(Vector3.up * flySpeed);
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

    public void ButtonUp()
    {
        print("вверх");
        rigidBody.AddRelativeForce(Vector3.up * flySpeed);
    }

    public void ButtonLeft()
    {
        print("влево");
    }

    public void ButtonRight()
    {
        print("вправо");
    }
}
