using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{


    [SerializeField]
    protected float score;

    [SerializeField]
    protected int level;

    public void Update()
    {
        if (score >= 500f && score < 1000f)
        {
            this.level = 2;
        } else if (score >= 1000f && score < 1500f)
        {
            this.level = 3;
        }
        else if (score >= 1500f && score < 2000f)
        {
            this.level = 4;
        }
        else if (score >= 2000f)
        {
            this.level = 5;
        } else
        {
            this.level = 1;
        }
    }

    public void setScore(float x)
    {
        this.score = x;
    }


    public float getScore()
    {
        return this.score;
    }

    public int getLevel()
    {
        return this.level;
    }
}
