using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonUp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool onObject;
    public GameObject player;
    public Player pl;
    AudioSource audioSource;
    public ParticleSystem flyPartical;

    public void OnPointerEnter(PointerEventData eventData) => onObject = true;

    public void OnPointerExit(PointerEventData eventData) => onObject = false;

    private void Start()
    {
        pl = player.GetComponent<Player>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(onObject && Input.GetMouseButton(0))
        {
            //player.transform.Translate(Vector3.up * flySpeed * Time.deltaTime);
            pl.rigidBody.AddRelativeForce(Vector3.up * pl.flySpeed);
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
}