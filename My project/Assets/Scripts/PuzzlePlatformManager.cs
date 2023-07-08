using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePlatformManager : MonoBehaviour
{
    public static PuzzlePlatformManager instance;
    public RandomLight randmlgt;
    public Transform plane;
    
  
    public Vector3 initialPos;
    bool isMoving;
    public GameObject button, puzzle, triggerCollider;
    public bool check, check1, check2, check3, check4 = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        initialPos = plane.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("plane"))
        {
            StartCoroutine(MovePlatform());
            triggerCollider.SetActive(false);
        }

        if (other.CompareTag("cube"))
        {
            button.SetActive(false);
            puzzle.SetActive(true);
            randmlgt.ToggleLights();
        }

        if (other.CompareTag("red") && randmlgt.check==true  )
        {
            check1 = true;       
        }

        if (other.CompareTag("yellow") && check1 == true)
        {
            check2 = true;
        }

        if (other.CompareTag("blue") && check2 == true)
        {
            check3 = true;
        }

        if (other.CompareTag("green") && check3 == true)

        {
            check4 = true;
            randmlgt.puzzlleCheck.SetActive(false);
            puzzle.SetActive(false);
            button.SetActive(false);
          
            StartCoroutine(StopPlatform());
        }
    }


      


        private IEnumerator MovePlatform()
         {

            isMoving = true;

            Vector3 targetPosition = plane.transform.position + Vector3.up * 2f;
            float duration = 10f; // Süre (saniye) - platformun 10 birim yükseðe hareket etmesi için ayarlayabilirsiniz
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                plane.position = Vector3.Lerp(initialPos, targetPosition, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Ýþlem tamamlandýktan sonra, platformun son pozisyonunu düzelt
            transform.position = targetPosition;
            isMoving = false;
            button.SetActive(true);


        
         }

    private IEnumerator StopPlatform()
    {

        yield return new WaitForSeconds(1f);

       
        float duration = 0.2f; // Süre (saniye) - platformun 10 birim yükseðe hareket etmesi için ayarlayabilirsiniz
        float elapsedTime = 0f;

      

        while (elapsedTime <duration)
        {
            plane.transform.Translate(Vector3.down * 10 * Time.deltaTime); // Platformu aþaðý hareket ettir

            elapsedTime += Time.deltaTime;

            yield return null; // Bir sonraki frame'e geç
        }

    }

}
