using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class ChankManager
{
    public static int chankradius =2;
    static Vector2 centerpos;
    public static void ChengeCenterPos(int x, int y)
    {


        List<Chank> newchunks = new List<Chank>();
        for (int i = -chankradius; i < chankradius; i++)
        {
            for (int j = -chankradius; j < chankradius; j++)
            {
                if (Chanks.ContainsKey(x + i) && Chanks[x + i].ContainsKey(y + j))
                {
                    Chanks[x + i][y + j].Activate();
                    newchunks.Add(Chanks[x + i][y + j]);
                }
    
            }
            
        }
        for (int i = 0; i < ActiveChunks.Count; i++)
        {
            if (!newchunks.Contains(ActiveChunks[i]))
            {
                ActiveChunks[i].Deactive();
                i--;
            }
        }

    }
    public static void DeactivateAll()
    {
        foreach (var v in Chanks)
        {
            foreach(var c in v.Value)
            {
                c.Value.Deactive();
            }
        }
    }
    public static int chunksize=30;
    public static List<Chank> ActiveChunks = new List<Chank>();
    public static Dictionary<int, Dictionary<int, Chank>> Chanks =  new Dictionary<int, Dictionary<int, Chank>>() ;
    public static void AddToChank(GameObject obj)
    {
        int x = (int)obj.transform.position.x;
        int y = (int)obj.transform.position.z;
        x /= chunksize;
        y /= chunksize;
        if (Chanks.ContainsKey(x))
        {
            if (!Chanks[x].ContainsKey(y))
            {
              Chanks[x].Add(y, new Chank());
            }
        }
        else
        {
            Chanks.Add(x, new Dictionary<int, Chank>());
            Chanks[x].Add(y, new Chank());
        }

        Chanks[x][y].Objs.Add(obj);
       

    }
}
    public class Chank
    {
    public List<GameObject> Objs =new List<GameObject>();

    public void Activate()
    {
        foreach (var o in Objs)
        {
            o.SetActive(true);
        }
        if (!ChankManager.ActiveChunks.Contains(this))
        {
            ChankManager.ActiveChunks.Add(this);
        }
    }
    public void Deactive()
    {
        foreach (var o in Objs)
        {
            o.SetActive(false);
        }
        if (ChankManager.ActiveChunks.Contains(this))
        {
            ChankManager.ActiveChunks.Remove(this);
        }

    }

}
