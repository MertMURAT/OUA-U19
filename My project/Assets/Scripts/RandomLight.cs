using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLight : MonoBehaviour
{
    public static RandomLight instance;
    public GameObject puzzlleCheck;
    public GameObject[] objects;
    public bool lightsOn = false;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ResetLights();
    }

   public void ToggleLights()
    {
        if (!lightsOn)
        {
            StartCoroutine(TurnOnLightsRandomly());
        }
    }

    public void ResetLights()
    {
        objects[0].SetActive(false);
        objects[1].SetActive(false);
        objects[2].SetActive(false);
        objects[3].SetActive(false);
    }

    IEnumerator TurnOnLightsRandomly()
    {
        lightsOn = true;

        // Renkleri rastgele bir sýra oluþtur
        //int[] randomOrder = GenerateRandomOrder();

        

        // Iþýklarý rastgele olarak yak
       
                    yield return new WaitForSeconds(2f);
                    objects[0].SetActive(true);
                    yield return new WaitForSeconds(2f);
                    objects[0].SetActive(false);




        //yield return new WaitForSeconds(2f);
                     objects[1].SetActive(true);
                    yield return new WaitForSeconds(2f);
                     objects[1].SetActive(false);



        //yield return new WaitForSeconds(2f);
                    objects[2].SetActive(true);
                    yield return new WaitForSeconds(2f);
                    objects[2].SetActive(false);


        //yield return new WaitForSeconds(2f);
                    objects[3].SetActive(true);
                    yield return new WaitForSeconds(2f);
                    objects[3].SetActive(false);
                    
        lightsOn = false;
        puzzlleCheck.SetActive(true);
    }



  
   



  


    //private int[] GenerateRandomOrder()
    //{
    //    int[] order = new int[4] { 0, 1, 2 ,3};

    //    // Renklerin sýrasýný karýþtýr
    //    for (int i = 0; i < order.Length; i++)
    //    {
    //        int temp = order[i];
    //        int randomIndex = Random.Range(i, order.Length);
    //        order[i] = order[randomIndex];
    //        order[randomIndex] = temp;


    //    }

    //    return order;
    //}
}
