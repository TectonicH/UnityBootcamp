using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowMe : MonoBehaviour
{
    //[SerializeField] private Transform target;

    //[SerializeField] private int x;
    //[SerializeField] private int y;
    //[SerializeField] private int z;


    //// Update is called once per frame
    //void Update()
    //{wwwwwwwwwwwwwwwwwwwwwww
    //    transform.LookAt(target);
    //    transform.Rotate(x, y, z);
    //}


    public Transform target;

    public AudioSource growl;

    [SerializeField] private int MoveSpeed = 4;
    [SerializeField] private float MaxDist = 3f;
    [SerializeField] private float MinDist = 1f;

    private bool isMoving;
    private bool isAwake;

    private float distanceFromPlayer;

    void Start()
    {
        isMoving = false;
        isAwake = false;
        //growl.Play();
    }

    void Update()
    {
        distanceFromPlayer = Vector3.Distance(transform.position, target.position);
        


        if (distanceFromPlayer < MaxDist)
        {
            isMoving = true;
            isAwake = true;
        }

        if ( isMoving/*distanceFromPlayer >= MaxDist*/)
        {
            transform.LookAt(target);
            
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
           

            if ( distanceFromPlayer  <= MinDist)
            {
                
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    { 

        if (other.CompareTag("Player"))
        {
            if (isAwake)
            {
                growl.Play();
                StartCoroutine(StopSound());
            }
        }
    }


    IEnumerator StopSound()
    {
        yield return new WaitForSeconds(2f);
        growl.Stop();
    }
}
