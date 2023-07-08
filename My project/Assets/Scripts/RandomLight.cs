using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLight : MonoBehaviour
{
    //public GameObject greenLight;
    //public GameObject yellowLight;
    //public GameObject blueLight;
    //public GameObject redLight;
    public GameObject puzzlleCheck;
    public GameObject[] objects;
    //private int currentIndex = 0;
    public bool lightsOn = false ,check=false;
   

    private void Start()
    {
        // Iþýklarý kapat
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(false);
        }

       
    }

   public void ToggleLights()
    {
        if (!lightsOn)
        {
            StartCoroutine(TurnOnLightsRandomly());
        }




    }


  

    private System.Collections.IEnumerator TurnOnLightsRandomly()
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
        check = true;

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
