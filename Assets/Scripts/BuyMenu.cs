using UnityEngine;
using TMPro;

public class BuyMenu : MonoBehaviour
{
    private SaveData SD; // Reference to the SaveData object

    public GameObject ARButton;
    public GameObject PistolButton;
    public GameObject ShotgunButton;

    public TMP_Text Message;
    public GameObject Messagee;

    void Start()
    {
        // Load the SaveData object
        SD = SaveManager.LoadData();
        Messagee.SetActive(false);
    }

    void Update()
    {
        SD = SaveManager.LoadData();
    }

    // Method to buy the AR
    public void BuyAR()
    {
        // Check if the AR has already been bought
        if (SD.HasAR)
        {
            ShowMessage("AR Already Bought");
            return;
        }

        // Check if the player has enough resources
        if (SD.coins >= 15 && SD.gold >= 5 && SD.copper >= 5)
        {
            // Deduct the resources
            SD.coins -= 15;
            SD.gold -= 5;
            SD.copper -= 5;

            // Update HasAR flag
            SD.HasAR = true;

            // Save the updated data
            SaveManager.SaveData(SD);

            // Change the AR button text
            ARButton.GetComponentInChildren<TMP_Text>().text = "AR Bought";
        }
        else
        {
            ShowMessage("Not Enough Materials");
        }
    }

    // Method to buy the Pistol
    public void BuyPistol()
    {
        // Check if the Pistol has already been bought
        if (SD.HasPistol)
        {
            ShowMessage("Pistol Already Bought");
            return;
        }

        // Check if the player has enough resources
        if (SD.coins >= 5 && SD.silver >= 5 && SD.iron >= 7)
        {
            // Deduct the resources
            SD.coins -= 5;
            SD.silver -= 5;
            SD.iron -= 7;

            // Update HasPistol flag
            SD.HasPistol = true;

            // Save the updated data
            SaveManager.SaveData(SD);

            // Change the Pistol button text
            PistolButton.GetComponentInChildren<TMP_Text>().text = "Pistol Bought";
        }
        else
        {
            ShowMessage("Not Enough Materials");
        }
    }

    // Method to buy the Shotgun
    public void BuyShotgun()
    {
        // Check if the Shotgun has already been bought
        if (SD.HasShootgun)
        {
            ShowMessage("Shotgun Already Bought");
            return;
        }

        // Check if the player has enough resources
        if (SD.coins >= 10 && SD.copper >= 10 && SD.iron >= 3)
        {
            // Deduct the resources
            SD.coins -= 10;
            SD.copper -= 10;
            SD.iron -= 3;

            // Update HasShootgun flag
            SD.HasShootgun = true;

            // Save the updated data
            SaveManager.SaveData(SD);

            // Change the Shotgun button text
            ShotgunButton.GetComponentInChildren<TMP_Text>().text = "Shotgun Bought";
        }
        else
        {
            ShowMessage("Not Enough Materials");
        }
    }

    // Method to show a message
    void ShowMessage(string messagee)
    {
        Debug.Log(messagee);

        Message.text = messagee;
        Messagee.SetActive(true);
        Invoke("ResetMessage", 1f);
    }

    // Method to reset the message
    void ResetMessage()
    {
        Messagee.SetActive(false);
    }

    // Method to buy Key2
    public void BuyKey2()
    {
        // Check if Key2 has already been bought
        if (SD.key2)
        {
            ShowMessage("Key 2 Already Bought");
            return;
        }

        // Check if the player has enough resources
        if (SD.copper >= 5 && SD.coins >= 10)
        {
            // Deduct the resources
            SD.copper -= 5;
            SD.coins -= 10;

            // Update key2 flag
            SD.key2 = true;

            // Save the updated data
            SaveManager.SaveData(SD);
        }
        else
        {
            ShowMessage("Not Enough Materials");
        }
    }

    // Method to buy Key3
    public void BuyKey3()
    {
        // Check if Key3 has already been bought
        if (SD.key3)
        {
            ShowMessage("Key 3 Already Bought");
            return;
        }

        // Check if the player has enough resources
        if (SD.iron >= 5 && SD.coins >= 20)
        {
            // Deduct the resources
            SD.iron -= 5;
            SD.coins -= 20;

            // Update key3 flag
            SD.key3 = true;

            // Save the updated data
            SaveManager.SaveData(SD);
        }
        else
        {
            ShowMessage("Not Enough Materials");
        }
    }

    // Method to buy Key4
    public void BuyKey4()
    {
        // Check if Key4 has already been bought
        if (SD.key4)
        {
            ShowMessage("Key 4 Already Bought");
            return;
        }

        // Check if the player has enough resources
        if (SD.silver >= 5 && SD.coins >= 30)
        {
            // Deduct the resources
            SD.silver -= 5;
            SD.coins -= 30;

            // Update key4 flag
            SD.key4 = true;

            // Save the updated data
            SaveManager.SaveData(SD);
        }
        else
        {
            ShowMessage("Not Enough Materials");
        }
    }

    // Method to buy Key5
    public void BuyKey5()
    {
        // Check if Key5 has already been bought
        if (SD.key5)
        {
            ShowMessage("Key 5 Already Bought");
            return;
        }

        // Check if the player has enough resources
        if (SD.gold >= 10 && SD.coins >= 50)
        {
            // Deduct the resources
            SD.gold -= 10;
            SD.coins -= 50;

            // Update key5 flag
            SD.key5 = true;

            // Save the updated data
            SaveManager.SaveData(SD);
        }
        else
        {
            ShowMessage("Not Enough Materials");
        }
    }

    // Method to sell Copper
    public void SellCopper()
    {
        // Check if the player has Copper to sell
        if (SD.copper > 0)
        {
            // Sell Copper for 1 coin
            SD.coins += 1;
            SD.copper -= 1;

            // Save the updated data
            SaveManager.SaveData(SD);
        }
        else
        {
            ShowMessage("Not Enough Materials");
        }
    }

    // Method to sell Iron
    public void SellIron()
    {
        // Check if the player has Iron to sell
        if (SD.iron > 0)
        {
            // Sell Iron for 2 coins
            SD.coins += 2;
            SD.iron -= 1;

            // Save the updated data
            SaveManager.SaveData(SD);
        }
        else
        {
            ShowMessage("Not Enough Materials");
        }
    }

    // Method to sell Silver
    public void SellSilver()
    {
        // Check if the player has Silver to sell
        if (SD.silver > 0)
        {
            // Sell Silver for 3 coins
            SD.coins += 3;
            SD.silver -= 1;

            // Save the updated data
            SaveManager.SaveData(SD);
        }
        else
        {
            ShowMessage("Not Enough Materials");
        }
    }

    // Method to sell Gold
    public void SellGold()
    {
        // Check if the player has Gold to sell
        if (SD.gold > 0)
        {
            // Sell Gold for 5 coins
            SD.coins += 5;
            SD.gold -= 1;

            // Save the updated data
            SaveManager.SaveData(SD);
        }
        else
        {
            ShowMessage("Not Enough Materials");
        }
    }
}
