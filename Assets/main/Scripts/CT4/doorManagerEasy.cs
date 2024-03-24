using UnityEngine;

public class doorManagerEasy : MonoBehaviour
{
    public placeMentCT4[] floor1;
    public placeMentCT4[] floor2;
    public placeAble[] floor3;
    public placeMentCT4[] finalFloor;
    public Animator door01;
    public Animator door02;
    public Animator door03;
    public GameObject finalDoor;
    public Animator[] finalWall;
    private void Update()
    {
        if (!floor1[0].correctANS)
        {
            door01.SetTrigger("up");
        }
        else
        {
            door01.SetTrigger("down");
        }
        if (!floor2[0].correctANS)
        {
            door02.SetTrigger("up");
        }
        else
        {
            door02.SetTrigger("down");
        }
        if (floor3All())
        {
            door03.SetTrigger("up");
        }
        else
        {
            door03.SetTrigger("down");
        }
        if (finalfloor())
        {
            finalDoor.gameObject.SetActive(false);
        }
        if (finalFloor[0].correctANS)
        {
            finalWall[0].SetBool("active", true);
        }
        else
        {
            finalWall[0].SetBool("active", false);
        }
        if (finalFloor[1].correctANS)
        {
            finalWall[1].SetBool("active", true);
        }
        else
        {
            finalWall[1].SetBool("active", false);
        }
        if (finalFloor[2].correctANS)
        {
            finalWall[2].SetBool("active", true);
        }
        else
        {
            finalWall[2].SetBool("active", false);
        }
    }
    private bool floor3All()
    {
        for (int i = 0; i < floor3.Length; i++)
        {
            if (floor3[i].correctANS != true)
            {
                return false;
            }
        }

        return true;
    }
    private bool finalfloor()
    {
        for (int i = 0; i < finalFloor.Length; i++)
        {
            if (finalFloor[i].correctANS != true)
            {
                return false;
            }
        }

        return true;
    }
}
