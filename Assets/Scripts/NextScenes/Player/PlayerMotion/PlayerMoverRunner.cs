using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoverRunner : MonoBehaviour
{
    public float Velocity;

    private bool canMotion = true;

    public bool CanMotion { get => canMotion; set => canMotion = value; }

    private void FixedUpdate()
    {
        if (!canMotion)
        {
            return;
        }
        transform.position += new Vector3(0F, 0F, 1F) * Time.deltaTime * Velocity;

        if (transform.position.x > 0.14F)
        {
            transform.position = new Vector3(0.14f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -0.14F)
        {
            transform.position = new Vector3(-0.14f, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FinalZone")
        {
            Debug.Log($"OnTriggerEnter {other.gameObject.name}");

            AccesEndPoint();

            if(SceneManager.GetActiveScene().buildIndex != 5)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void AccesEndPoint()
    {
        canMotion = false;
    }
}