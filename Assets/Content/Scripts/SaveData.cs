using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour {
    private static Data toSave = new Data(); // Istanzia l'oggetto SaveData

    private readonly string saveFilePath = "saveData.json"; // Percorso del file di salvataggio

    private void Start() {
        LoadSaveData(); // Carica i dati salvati all'avvio del gioco
    }

    public void RecordDungeon(){
        toSave.record = GameController.recordDungeon;
        SaveDataToFile();
    }

    public void AddPotion() {
        GameController.nPotion++;
        toSave.nPotion = GameController.nPotion; // Aggiorna nPotion in toSave
        
        SaveDataToFile(); // Salva i dati in un file JSON
    }

    public void AddSwordLevel() {
        Sword.swordLevel++;
        toSave.swordLevel = Sword.swordLevel; // Aggiorna swordLevel in toSave
        
        SaveDataToFile(); // Salva i dati in un file JSON
    }
    public void AddKnifeLevel() {
        Knife.knifeLevel++;
        toSave.knifeLevel = Knife.knifeLevel; // Aggiorna knifeLevel in toSave

        SaveDataToFile(); // Salva i dati in un file JSON
    }
    public void AddBowLevel() {
        Bow.bowLevel++;
        toSave.bowLevel = Bow.bowLevel; // Aggiorna bowLevel in toSave
        
        SaveDataToFile(); // Salva i dati in un file JSON
    }
    public void AddAxeLevel() {
        Axe.axeLevel++;
        toSave.axeLevel = Axe.axeLevel; // Aggiorna axeLevel in toSave
        
        SaveDataToFile(); // Salva i dati in un file JSON
    }
    public void AddMoney(){
        toSave.money = GameController.playerMoney; 
        
        SaveDataToFile(); // Salva i dati in un file JSON
    }

    private void SaveDataToFile() {
        string json = JsonUtility.ToJson(toSave);
        File.WriteAllText(Application.dataPath + "/Resources/saveData.json", json);
        File.WriteAllText(saveFilePath, json);
    }

    private void LoadSaveData() {
        if (File.Exists(saveFilePath)) {
            string json = File.ReadAllText(saveFilePath);
            toSave = JsonUtility.FromJson<Data>(json);
            //livelli armi
            Sword.swordLevel = toSave.swordLevel; // Carica swordLevel dal file
            Knife.knifeLevel = toSave.knifeLevel; // Carica knifeLevel dal file
            Bow.bowLevel = toSave.bowLevel; // Carica bowLevel dal file
            Axe.axeLevel = toSave.axeLevel; // Carica axeLevel dal file
            //_________________________
            GameController.nPotion = toSave.nPotion; // Carica nPotion dal file
            GameController.recordDungeon = toSave.record; // Carica recordDungeon dal file
        } else {
            // Se il file non esiste, inizia con valori predefiniti
            Sword.swordLevel = 0;
            Knife.knifeLevel = 0;
            Bow.bowLevel = 0;
            Axe.axeLevel = 0;
            SaveDataToFile(); // Crea un nuovo file con i dati predefiniti
        }
    }
}

[System.Serializable]
public class Data {
    public int swordLevel;
    public int knifeLevel;
    public int bowLevel;
    public int axeLevel; 
    public int money;
    public int nPotion;
    public int record;
    // Altri dati che desideri salvare...
}
