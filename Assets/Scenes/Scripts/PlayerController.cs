using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public AudioSource coinSound;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
       float moveHorizontal = Input.GetAxis("Horizontal");
       float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }  


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            coinSound.Play();
        }
    }

    void  SetCountText ()
    {
      
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
           winText.text = "Haz ganado!";
           StartCoroutine(espera());
        }
    }


    IEnumerator espera()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("menu");
    }


}
     
