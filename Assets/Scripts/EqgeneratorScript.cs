using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EqgeneratorScript : MonoBehaviour
{
    private int num1;
    private int num2;
    private int sum;
    private int product;
    private int difference;
    private int quotient;//

    public GameObject[] shapes;
    public Transform[] spawnPositions;

    private Vector3[] initialPositions;

    public Image dropImg;

    public DropSlot dropSlot;


    public bool resetPos=false;
    //private bool isRegenerating = false;

    public GameObject[] fruitSpawnPos1;
    public GameObject[] fruitSpawnPos2;
    public Sprite bananaSprite;
    public Sprite[] fruitSprites;

    public bool add;//
    public bool mul;//
    public bool subs;//
    public bool div;//



    //public bool isCorrectAns=false;



    public TextMeshProUGUI eqText;

    private List<int> usedNumbers = new List<int>();

    public static EqgeneratorScript instance;

    private void Awake()
    {
        if(instance==null)
        {
            instance=this;
        }
    }

    void Start()
    {
        //GenerateEq();//
        if(add && !mul && !subs && !div)
        {
            GenerateEq();
        }
        else if(mul && !add && !subs && !div)
        {
            MulGenerateEq();
        }
        else if(subs && !add && !mul && !div)
        {
            SubGenerateEq();
        }
        else if(div && !add && !mul && !subs)
        {
            DivGenerateEq();
        }
        CheckAnswer();
        SpawnShapes();
       


        //StoreInitialPositions();
    }

    void Update()
    {
        if(DropSlot.instance.correctlyPlaced)
        {
            DropSlot.instance.correctlyPlaced = false;  // Reset the flag to prevent multiple triggers
            GameManagerScript.instance.ReloadSceneWithDelay();
        }

        
    }

    
    


    public void GenerateEq()
    {
        do
        {
            num1 = Random.Range(0,11);
            num2 = Random.Range(0,11);

            sum = num1 + num2;

        }while(sum>9);

        eqText.text = num1 + "         +        " + num2 + " = ";

        SpawnFruits();


    }

    public void MulGenerateEq()
    {
        num1 = Random.Range(0, 5);
        num2 = Random.Range(0, 6);

        product = num1 * num2;

        //eqText.text = num1 + " X " + num2 + " = ";
        eqText.text = num1 + "         x        " + num2 + " = ";

        SpawnFruits();//
    }

    public void SubGenerateEq()
    {
        num1 = Random.Range(0, 11);  // Random number between 0 and 10
        num2 = Random.Range(0, num1 + 1);  // Ensure num2 is less than or equal to num1

        difference = num1 - num2;

        eqText.text = num1 + "         -        " + num2 + " = ";

        SpawnFruits();//
    }
    public void DivGenerateEq()
    {
        num2 = Random.Range(1, 11);  
        quotient = Random.Range(1, (10 / num2) + 1);    
        num1 = quotient * num2;        

        eqText.text = num1 + "         /        " + num2 + " = "; 

        //eqText.text = num1 + " / " + num2 + " = ";
        SpawnFruits();//
    }

    

    public void SpawnFruits()//
    {
        int x = Random.Range(0,fruitSprites.Length);

        for(int i =0;i<num1;i++)
        {
            Image temp = fruitSpawnPos1[i].GetComponent<Image>();
            //temp.sprite = bananaSprite;//
            temp.sprite = fruitSprites[x];
        }
        for(int i=num1;i<fruitSpawnPos1.Length;i++)
        {
            Image temp = fruitSpawnPos1[i].GetComponent<Image>();
            temp.sprite = null;
        }

        for(int i =0;i<num2;i++)
        {
            Image temp = fruitSpawnPos2[i].GetComponent<Image>();
            //temp.sprite = bananaSprite;//
            temp.sprite = fruitSprites[x];
        }
        for(int i=num2;i<fruitSpawnPos2.Length;i++)
        {
            Image temp = fruitSpawnPos2[i].GetComponent<Image>();
            temp.sprite = null;
        }
    }

    public void CheckAnswer()
    {
        if(add && !mul && !subs && !div)
        {
            print(sum);
        }
        else if(mul && !add && !subs && !div)
        {
            print(product);
        }
        else if(subs && !add && !mul && !div)
        {
            print(difference);
        }
        else if(div && !add && !mul && !subs)
        {
            print(quotient);
        }
        
    }
    public void SpawnShapes()
    {
        ShuffleArray(shapes);


        int correctAnsIndex = Random.Range(0,spawnPositions.Length);

        for(int i=0;i<spawnPositions.Length;i++)
        {
            GameObject spawnedShape = Instantiate(shapes[i], spawnPositions[i].position, Quaternion.identity, spawnPositions[i]);

            TextMeshProUGUI shapeText = spawnedShape.GetComponentInChildren<TextMeshProUGUI>();


            if(i==correctAnsIndex)
            {
                //shapeText.text = sum.ToString();

                if(add && !mul && !subs && !div)
                {
                    shapeText.text = sum.ToString();
                }
                else if(mul && !add && !subs && !div)
                {
                    shapeText.text = product.ToString();
                }
                else if(subs && !add && !mul && !div)
                {
                    shapeText.text = difference.ToString();
                }
                else if(div && !add && !mul && !subs)
                {
                    shapeText.text = quotient.ToString();
                }

                Image sourceImageComponent = spawnedShape.GetComponent<Image>();

                // Assign the sprite from the source Image to the target Image
                dropImg.sprite = sourceImageComponent.sprite;

                //isCorrectAns = true;

                spawnedShape.tag = "correct";

                

                
            }
            else if(add || subs || div && !mul)
            {
                int randomNum;
                do{
                    randomNum = Random.Range(0,10);
                }while(randomNum==sum || NumberAlreadyUsed(randomNum));

                shapeText.text = randomNum.ToString();

                spawnedShape.tag = "incorrect";

            }
            else if(mul && !add )
            {
                int randomNum;
                do{
                    randomNum = Random.Range(0,20);
                }while(randomNum==sum || NumberAlreadyUsed(randomNum));

                shapeText.text = randomNum.ToString();

                spawnedShape.tag = "incorrect";

            }
               
        }
    }

    private bool NumberAlreadyUsed(int randomNum)
    {
        if(usedNumbers.Contains(randomNum))
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
        for(int i=0;i<shapeArray.Length;i++)
        {
            int randomIndex = Random.Range(0,shapeArray.Length);
            GameObject temp = shapeArray[i];
            shapeArray[i] = shapeArray[randomIndex];
            shapeArray[randomIndex] = temp;
            
        }
    }



    /*public void DestroyChildren()
    {
        // Destroy existing shapes before generating new ones
        foreach (Transform spawn in spawnPositions)
        {
            if (spawn.childCount > 0)
            {
                Destroy(spawn.GetChild(0).gameObject);  // Destroy the current shape
            }
        }
    }*/

   

    


}
