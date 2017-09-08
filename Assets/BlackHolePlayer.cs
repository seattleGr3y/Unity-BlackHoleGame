using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackHolePlayer : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;

    private int count;
    public Text countText;

    public float pullRadius = 201;
    public float pullForce = 50;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        // SetCountText();
    }
    // Update will contain the code called before rendering a frame
    // this is where most of the game code will go
    void Update()
    {

    }

    // FixedUpdate is called before any physics calculations are made
    // this is where the physics code will go
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
        //foreach (Collider collider in Physics.OverlapSphere(transform.position, pullRadius))
        //{
        //    // calculate direction from target to me
        //    Vector3 forceDirection = transform.position - collider.transform.position;

        //    // apply force on target towards me
        //    if (gameObject.CompareTag("PickUp"))
        //    {
        //        collider.attachedRigidbody.AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);
        //    }
        //}
    }

    void OnTriggerEnter(Collider other)
    {
        // Destroy(other.gameObject);
        if (other.gameObject.CompareTag("PickUp"))
        {
            Vector3 forceDirection = transform.position - other.transform.position;
            other.attachedRigidbody.AddForce(forceDirection.normalized * pullForce * Time.unscaledTime);
            other.gameObject.SetActive(false);
            count = count + 1;
            //SetCountText();
            //if (count.Equals(11))
            //{
            //    countText.text = "YOU WON THE GAME!!!!";
            //}
        }
    }

    //void SetCountText()
    //{
    //    countText.text = "Count: " + count.ToString();
    //}
}
