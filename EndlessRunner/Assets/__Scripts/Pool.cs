using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This class handles the code for the platform pool.
*/
[System.Serializable]
public class PoolItem
{
    //prefab
    public GameObject prefab;

    //amount pf prefabs
    public int amount;

    // expand on the amount of platforms
    public bool expandable;
}

public class Pool : MonoBehaviour
{
    //pool exits in memory while game is running
    public static Pool singelton;

    //list of pool items prefabs
    public List<PoolItem> items;

    //list to take items from pool
    public List<GameObject> pooledItems;

    void Awake()
    {
        //initialse sigelton to this instantiation of class
        singelton = this;

        // create new list
        pooledItems = new List<GameObject>();

        //take each prefab
        foreach (PoolItem item in items)
        {
            for (int i = 0; i < item.amount; i++)
            {
                //instantiate prefab
                GameObject obj = Instantiate(item.prefab);

                //make in-active
                obj.SetActive(false);

                //add to pool
                pooledItems.Add (obj);
            }
        }
    }

    public GameObject GetRandom()
    {
        //shuffle pooled items
        Utils.Shuffle (pooledItems);

        for (int i = 0; i < pooledItems.Count; i++)
        {
            //if current pooled items is not active its available to be used
            if (!pooledItems[i].activeInHierarchy)
            {
                //get pooled item
                return pooledItems[i];
            }
        }

        foreach (PoolItem item in items)
        {
            //if the item is expandable
            if (item.expandable)
            {
                //instantiate item prefab
                GameObject obj = Instantiate(item.prefab);

                //set activhe to false
                obj.SetActive(false);

                //add to pool
                pooledItems.Add (obj);

                //return obj
                return obj;
            }
        }

        //if no items can be expanded return null
        return null;
    }
}

public static class Utils
{
    // random 
    public static System.Random r = new System.Random();

    //fisher yates shuffle
    //shuffle contents of a list
    public static void Shuffle<T>(this IList<T> list)
    {
        //count of list
        int n = list.Count;
        //while list is greater than 1
        while (n > 1)
        {
            //count down through list
            n--;
            //k = random.Next + 1
            int k = r.Next(n + 1);
            // list at position k 
            T value = list[k];
            //list at position k  = list at position n 
            list[k] = list[n];
            //taking ves from different parts of the list and swapping them around
            list[n] = value;
        }
    }
}
