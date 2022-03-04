using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnowmanScript : MonoBehaviour
{
    //[SerializeField] public TextMeshProUGUI countText;
    //public GameObject snowman;
    private int minus;
    //public AudioSource growl;
    public AudioSource pain;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(snowman, transform.position, Quaternion.identity);
    }

    // Update is called once per frames
    void Update()
    {
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //growl.Play();
            //pain.Play();
            minus = minus + 1;

            //if(minus == 3)
            //{
            //    //game over 
            //}
        }
    }

    //void MinusCountText()
    //{

    //    countText.text = "Count: " + minus.ToString();

    //}


}
