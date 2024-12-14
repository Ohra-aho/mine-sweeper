using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    [HideInInspector] public List<bool> minefield = new List<bool>();
    [SerializeField] private GameObject mineTile;
    public int size;
    public int amount;

    public void MakeMineField()
    {
        ClearMineField();
        List<int> mineIndexes = MakeUniqueNumbers(size, amount);
        
        for(int i = 0; i < size; i++)
        {
            bool mine = false;
            for(int j = 0; j < mineIndexes.Count; j++)
            {
                if (i == mineIndexes[j]) {
                    mine = true;
                    break;
                }
            }
            minefield.Add(mine);
        }

        for (int i = 0; i < minefield.Count; i++)
        {
            if(minefield[i])
            {
                GameObject tile = Instantiate(mineTile, transform.GetChild(0));
                tile.GetComponent<MineTile>().mine = true;
                tile.GetComponent<MineTile>().index = i;
                //tile.GetComponent<MineTile>().Invoke();
            } else
            {
                GameObject tile = Instantiate(mineTile, transform.GetChild(0));
                tile.GetComponent<MineTile>().mine = false;
                tile.GetComponent<MineTile>().index = i;
                //tile.GetComponent<MineTile>().Invoke();
            }
        }
        for(int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            transform.GetChild(0).GetChild(i).GetComponent<MineTile>().Invoke();
        }
    }

    public void ClearMineField()
    {
        minefield.Clear();
        Transform parent = transform.GetChild(0);

        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            Destroy(parent.GetChild(i).gameObject);
        }

    }

    public List<int> MakeUniqueNumbers(int size, int amount)
    {
        List<int> temp = new List<int>();
        for(int i = 0; i < amount; i++)
        {
            int x = Random.Range(0, size);
            while(temp.Contains(x))
            {
                x = Random.Range(0, size);
            }
            temp.Add(x);
        }
        return temp;
    }

}
