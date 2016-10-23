using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GenerationPoint
{
    int posx;
    int posy;
    int power;

    public int Posx
    {
        get
        {
            return posx;
        }

        set
        {
            posx = value;
        }
    }

    public int Posy
    {
        get
        {
            return posy;
        }

        set
        {
            posy = value;
        }
    }

    public int Power
    {
        get
        {
            return power;
        }

        set
        {
            power = value;
        }
    }
}
public class MapGenterato : MonoBehaviour {
    List<GenerationPoint> points = new List<GenerationPoint>();
    public GameObject pref;
    public int y;
    public int sizex;
    public int sizey;
    public int pointcountmin;
    public int pointcountmax;
    public int powermax;
    public int powermin;
    IEnumerator Creating()
    {
        int count = Random.Range(pointcountmin, pointcountmax);
        for (int i = 0; i < count; i++)
        {
            int x = Random.Range(0, sizex);
            int y = Random.Range(0, sizex);
            int pow = Random.Range(powermin, powermax);
            foreach (var p in points)
            {
                if (p.Posx == x && p.Posy == y)
                {
                    p.Power += pow;
                    continue;
                }
            }
            points.Add(new GenerationPoint() { Posx = x, Posy = y, Power = pow });
        }

        List<GenerationPoint> toTest = new List<GenerationPoint>();
        List<GenerationPoint> TestOver = new List<GenerationPoint>();
        foreach (var p in points)
        {
            toTest.Add(p);
        }

        for (int i = 0; i < toTest.Count; i++)
        {
           
            if (toTest[i].Power == 0)
            {
                TestOver.Add(toTest[i]);
                toTest.Remove(toTest[i]);
                continue;
            }
            List<GenerationPoint> pretendent = new List<GenerationPoint>();

            int newx = toTest[i].Posx + 1;
            int newy = toTest[i].Posy;
            GenerationPoint gp = new GenerationPoint() { Posx = newx, Posy = newy };
            if (!IsContaint(TestOver, gp))
            {
                pretendent.Add(gp);
            }
            newx = toTest[i].Posx - 1;
            newy = toTest[i].Posy;
            gp = new GenerationPoint() { Posx = newx, Posy = newy };
            if (!IsContaint(TestOver, gp))
            {
                pretendent.Add(gp);
            }

            newx = toTest[i].Posx;
            newy = toTest[i].Posy + 1;
            gp = new GenerationPoint() { Posx = newx, Posy = newy };
            if (!IsContaint(TestOver, gp))
            {
                pretendent.Add(gp);
            }

            newx = toTest[i].Posx;
            newy = toTest[i].Posy - 1;
            gp = new GenerationPoint() { Posx = newx, Posy = newy };
            if (!IsContaint(TestOver, gp))
            {
                pretendent.Add(gp);
            }

            if (pretendent.Count == 0)
                continue;
            int cont;
            if (i == toTest.Count - 1)
            {
                cont = pretendent.Count;
            }
            else
            {
                cont = Random.Range(0, pretendent.Count);
            }

            while (cont > 0)
            {
                GenerationPoint toAdd = pretendent[Random.Range(0, pretendent.Count)];
                toAdd.Power = toTest[i].Power - 1;
                toTest.Add(toAdd);
                pretendent.Remove(toAdd);
                cont--;
                CreateObject(pref, new Vector3(toAdd.Posx, y, toAdd.Posy));
                yield return new WaitForFixedUpdate();
            }
            TestOver.Add(toTest[i]);
            toTest.Remove(toTest[i]);



        }

    }
    bool IsContaint(List<GenerationPoint> arr, GenerationPoint gp)
    {
        
        foreach (var p in arr)
        {
            if (gp.Posx == p.Posx && gp.Posy == p.Posy)
            {
                return true;
            }
        }
        return false;
    }
    void CreateObject(GameObject pref, Vector3 pos)
    {
        GameObject go=(GameObject) Instantiate(pref, pos, pref.transform.rotation);
        go.name = pos.x.ToString() + "|" + pos.z.ToString();
        ChankManager.AddToChank(go);
    }
    // Use this for initialization
    void Start () {

        int count = Random.Range(pointcountmin, pointcountmax);
        for (int i = 0; i < count; i++)
        {
            int x = Random.Range(0, sizex);
            int y = Random.Range(0, sizex);
            int pow = Random.Range(powermin, powermax);
            foreach (var p in points)
            {
                if (p.Posx == x && p.Posy == y)
                {
                    p.Power += pow;
                    continue;
                }
            }
            points.Add(new GenerationPoint() { Posx = x, Posy = y, Power = pow });
        }

        List<GenerationPoint> toTest = new List<GenerationPoint>();
        List<GenerationPoint> TestOver = new List<GenerationPoint>();
        foreach (var p in points)
        {
            toTest.Add(p);
            CreateObject(pref, new Vector3(p.Posx,y,p.Posy));
        }

        for (int i = 0; i < toTest.Count; i++)
        {
            
            TestOver.Add(toTest[i]);
            
            if (toTest[i].Power <= 0)
            {
               
                continue;
            }
            List<GenerationPoint> pretendent = new List<GenerationPoint>();

            int newx = toTest[i].Posx + 1;
            int newy = toTest[i].Posy;
            GenerationPoint gp = new GenerationPoint() { Posx = newx, Posy = newy };
            if (!IsContaint(TestOver, gp))
            {
                pretendent.Add(gp);
            }
            newx = toTest[i].Posx - 1;
            newy = toTest[i].Posy;
            gp = new GenerationPoint() { Posx = newx, Posy = newy };
            if (!IsContaint(TestOver, gp))
            {
                pretendent.Add(gp);
            }

            newx = toTest[i].Posx;
            newy = toTest[i].Posy + 1;
            gp = new GenerationPoint() { Posx = newx, Posy = newy };
            if (!IsContaint(TestOver, gp))
            {
                pretendent.Add(gp);
            }

            newx = toTest[i].Posx;
            newy = toTest[i].Posy - 1;
            gp = new GenerationPoint() { Posx = newx, Posy = newy };
            if (!IsContaint(TestOver, gp))
            {
                pretendent.Add(gp);
            }

            if (pretendent.Count == 0)
                continue;
            int cont;
            if (i == toTest.Count - 1)
            {
                cont = pretendent.Count;
            }
            else
            {
                cont = pretendent.Count;
            }
           

            while (cont > 0)
            {
                GenerationPoint toAdd = pretendent[Random.Range(0, pretendent.Count)];
                toAdd.Power = toTest[i].Power - 1;
                toTest.Add(toAdd);
                pretendent.Remove(toAdd);
                cont--;
                CreateObject(pref, new Vector3(toAdd.Posx, y, toAdd.Posy));
            }
            toTest.Remove(toTest[i]);

        }
        ChankManager.DeactivateAll();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
