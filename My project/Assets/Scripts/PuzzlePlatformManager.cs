using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePlatformManager : MonoBehaviour
{
    public Transform parentObject;
    private Vector3 startPos;
    public bool isPushed = false;
    public float speed;
    public float maksh = 30f;
    public bool check1, check2, check3, check4 = false;
    public bool isSolved = false;
    public GameObject button;
    public GameObject puzzle;
    public GameObject puzzleCheck;
    public GameObject[] lights;
    public bool isPuzzleStarted = false;

    private void Start()
    {
        startPos = parentObject.position;
    }

    private void FixedUpdate()
    {
        if (isPushed)
        {
            Up();
        }

        if (isSolved)
        {
            Down();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform") && !isPuzzleStarted)
        {
            isPushed = true;
        }

        if (other.CompareTag("PlatformButton"))
        {
            button.SetActive(false);
            puzzle.SetActive(true);
            isPuzzleStarted = true;
        }

        if (isPuzzleStarted)
        {
            if (other.CompareTag("red"))
            {
                check1 = true;
                lights[0].SetActive(true);
            }
            else if (other.CompareTag("yellow") && check1)
            {
                check2 = true;
                lights[1].SetActive(true);
            }
            else if (other.CompareTag("blue") && check1 && check2)
            {
                check3 = true;
                lights[2].SetActive(true);
            }
            else if (other.CompareTag("green") && check1 && check2 && check3)
            {
                check4 = true;
                lights[3].SetActive(true);
                puzzle.SetActive(false);
                button.SetActive(false);
                puzzleCheck.SetActive(false);
                isSolved = true;
            }
            else
            {
                ResetLights();
                ResetBools();
            }
        }
    }

    public void Up()
    {
        parentObject.transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (parentObject.transform.position.y - startPos.y >= maksh)
        {
            isPushed = false;
            button.SetActive(true);
            StartCoroutine(TurnOnLightsRandomly());
        }
    }

    public void Down()
    {
        parentObject.transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (parentObject.transform.position.y == startPos.y)
        {
            isSolved = false;
        }
    }

    IEnumerator TurnOnLightsRandomly()
    {
        yield return new WaitForSeconds(2f);
        lights[0].SetActive(true);
        yield return new WaitForSeconds(2f);
        lights[0].SetActive(false);

        lights[1].SetActive(true);
        yield return new WaitForSeconds(2f);
        lights[1].SetActive(false);

        lights[2].SetActive(true);
        yield return new WaitForSeconds(2f);
        lights[2].SetActive(false);

        lights[3].SetActive(true);
        yield return new WaitForSeconds(2f);
        lights[3].SetActive(false);

        puzzleCheck.SetActive(true);
    }

    public void ResetLights()
    {
        lights[0].SetActive(false);
        lights[1].SetActive(false);
        lights[2].SetActive(false);
        lights[3].SetActive(false);
    }

    public void ResetBools()
    {
        check1 = false;
        check2 = false;
        check3 = false;
        check4 = false;
    }
}