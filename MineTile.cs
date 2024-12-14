using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MineTile : MonoBehaviour
{
    public bool mine;
    public List<bool> mineFiled;
    public int index;
    private int amountOfMines;
    private int width = 6;

    public void Invoke()
    {
        mineFiled = transform.parent.parent.gameObject.GetComponent<Control>().minefield;
        CountMines();
        if (mine)
        {
            //GetComponent<Image>().color = Color.red;
        } else
        {
            //GetComponent<Image>().color = Color.gray;
        }
    }

    public void Press()
    {
        GameObject parent = transform.parent.parent.gameObject;
        if(mine)
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "M";
            parent.GetComponent<Control>().MakeMineField();
        } else
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = amountOfMines.ToString();
        }
    }

    private void CountMines()
    {
        List<int> first = new List<int>();
        List<int> last = new List<int>();
        int temp = 0;
        int safe = 0;
        while (temp < mineFiled.Count+1)
        {
            first.Add(temp);
            temp += (width - 1);
            last.Add(temp);
            temp++;
            
            safe++;
            if(safe == 100)
            {
                Debug.Log("Safe");
                break;
            }
        }
        //Debug.Log(first[0]+" " + first[1] + " " + first[2] + " " + first[3] + " " + first[4] + " " + first[5] + " " + first[6] + " " + first[7] + " " + first[8]);
        //Debug.Log(last[0] + " " + last[1] + " " + last[2] + " " + last[3] + " " + last[4] + " " + last[5] + " " + last[6] + " " + last[7] + " " + last[8]);


        //Next
        if (mineFiled.Count > index + 1)
        {
            if(!last.Contains(index))
            {
                if (mineFiled[index + 1])
                {
                    amountOfMines++;
                }
            }
        }

        //Previous
        if(0 <= index - 1)
        {
            if(!first.Contains(index))
            {
                if (mineFiled[index - 1])
                {
                    amountOfMines++;
                }
            }
        }

        //Down
        if(mineFiled.Count > index + 6)
        {
            if (mineFiled[index + 6])
            {
                amountOfMines++;
            }
        }

        //Up
        if (0 <= index - 6)
        {
            if (mineFiled[index - 6])
            {
                amountOfMines++;
            }
        }

        //Next Up
        if (0 <= index - 6)
        {
            if (!last.Contains(index))
            {
                if (mineFiled[index - 6 + 1])
                {
                    amountOfMines++;
                }
            }
        }

        //Previous Up
        if (0 <= index - 6)
        {
            if (!first.Contains(index))
            {
                if (mineFiled[index - 6 - 1])
                {
                    amountOfMines++;
                }
            }
        }

        //Next Down
        if (mineFiled.Count > index + 6)
        {
            if (!last.Contains(index))
            {
                if (mineFiled[index + 6 + 1])
                {
                    amountOfMines++;
                }
            }
        }

        //Previous Down
        if (mineFiled.Count > index + 6)
        {
            if (!first.Contains(index))
            {
                if (mineFiled[index + 6 - 1])
                {
                    amountOfMines++;
                }
            }
        }
    }

}
