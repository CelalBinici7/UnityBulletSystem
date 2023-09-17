using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public int TotalBullets;
    public int MagazineCapacity;
    public int RemainingBullets;
    public string gun_name;
    public TMP_Text TotalBulletsText;
    public TMP_Text RemainingBulletsText;

    void bulletstate(string state)
    {
        switch (state)
        {
            case "bullets":
                if (TotalBullets <= MagazineCapacity)
                {
                    int pulse = RemainingBullets += TotalBullets;
                    if (pulse > MagazineCapacity)
                    {
                        TotalBullets = pulse - MagazineCapacity;
                        RemainingBullets = MagazineCapacity;
                        PlayerPrefs.SetInt(gun_name + "_Bullet", TotalBullets);
                    }
                    else if (pulse < MagazineCapacity)
                    {
                        RemainingBullets = pulse;
                        TotalBullets = 0;
                        PlayerPrefs.SetInt(gun_name + "_Bullet", TotalBullets);
                    }
                    
                }
                else
                {
                    spendbullet = MagazineCapacity - RemainingBullets;
                    TotalBullets -= spendbullet;
                    RemainingBullets = MagazineCapacity;
                    PlayerPrefs.SetInt(gun_name + "_Bullet", TotalBullets);
                }
                TotalBulletsText.text = TotalBullets.ToString();
                RemainingBulletsText.text = RemainingBullets.ToString();
                break;
            case "nobullets":
                if (TotalBullets <= MagazineCapacity)
                {
                    RemainingBullets = TotalBullets;
                    TotalBullets = 0;
                    PlayerPrefs.SetInt(gun_name + "_Bullet", TotalBullets);
                }
                else
                {
                    TotalBullets -= MagazineCapacity;
                    RemainingBullets = MagazineCapacity;
                    PlayerPrefs.SetInt(gun_name + "_Bullet", TotalBullets);
                }

                TotalBulletsText.text = TotalBullets.ToString();
                RemainingBulletsText.text = RemainingBullets.ToString();
                break;
            case "print":
                TotalBulletsText.text = TotalBullets.ToString();
                RemainingBulletsText.text = RemainingBullets.ToString();
                break;
        }
    }
     public void reloadgun()
    {
        if (RemainingBullets < MagazineCapacity && TotalBullets != 0)
        {
            if (RemainingBullets != 0)
            {
                bulletstate("bullets");

            }
            else
            {
                bulletstate("nobullets");

            }

        }

    }
}
