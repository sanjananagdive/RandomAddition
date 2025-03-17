using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubEqGenerator : MonoBehaviour
{
    private int num1;
    private int num2;
    private int difference;

    public GameObject[] shapes;
    public Transform[] spawnPositions;

    private Vector3[] initialPositions;

    public Image dropImg;

    public DropSlot dropSlot;

    public bool resetPos = false;

    public TextMeshProUGUI eqText;

    private List<int> usedNumbers = new List<int>();

    public static SubEqGenerator instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        SubGenerateEq();
        CheckAnswer();
        SpawnShapes();
    }

    void Update()
    {
        if (DropSlot.instance.correctlyPlaced)
        {
            DropSlot.instance.correctlyPlaced = false;
            SubGameManager.instance.ReloadSceneWithDelay();
        }
    }

    // Generate Subtraction Equation
    public void SubGenerateEq()
    {
        num1 = Random.Range(0, 11);  // Random number between 0 and 10
        num2 = Random.Range(0, num1 + 1);  // Ensure num2 is less than or equal to num1

        difference = num1 - num2;

        eqText.text = num1 + " - " + num2 + " = ";
    }

    public void CheckAnswer()
    {
        print(difference);  // This is just for debugging purposes
    }

    public void SpawnShapes()
    {
        ShuffleArray(shapes);

        int correctAnsIndex = Random.Range(0, spawnPositions.Length);

        for (int i = 0; i < spawnPositions.Length; i++)
        {
            GameObject spawnedShape = Instantiate(shapes[i], spawnPositions[i].position, Quaternion.identity, spawnPositions[i]);

            TextMeshProUGUI shapeText = spawnedShape.GetComponentInChildren<TextMeshProUGUI>();

            if (i == correctAnsIndex)
            {
                shapeText.text = difference.ToString();

                Image sourceImageComponent = spawnedShape.GetComponent<Image>();
                dropImg.sprite = sourceImageComponent.sprite;

                spawnedShape.tag = "correct";
            }
            else
            {
                int randomNum;

                do
                {
                    randomNum = Random.Range(0, 20);
                } while (randomNum == difference || NumberAlreadyUsed(randomNum));

                shapeText.text = randomNum.ToString();
                spawnedShape.tag = "incorrect";
            }
        }
    }

    private bool NumberAlreadyUsed(int randomNum)
    {
        if (usedNumbers.Contains(randomNum))
        {
            return true;
        }
        else
        {
            usedNumbers.Add(randomNum);
            return false;
        }
    }

    public void ShuffleArray(GameObject[] shapeArray)
    {
        for (int i = 0; i < shapeArray.Length; i++)
        {
            int randomIndex = Random.Range(0, shapeArray.Length);
            GameObject temp = shapeArray[i];
            shapeArray[i] = shapeArray[randomIndex];
            shapeArray[randomIndex] = temp;
        }
    }
}
