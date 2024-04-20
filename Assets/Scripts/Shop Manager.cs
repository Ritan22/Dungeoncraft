using System.IO;
using UnityEngine;

public class ShopManager : MonoBehaviour {
    private static SaveData toSave = new SaveData(); // Istanzia l'oggetto SaveData

    private readonly string saveFilePath = "saveData.json"; // Percorso del file di salvataggio

    private void Start() {
        LoadSaveData(); // Carica i dati salvati all'avvio del gioco
        print("All'inizio: " + toSave.swordLevel);
    }

    public void AddSwordLevel() {
        Sword.swordLevel++;
        toSave.swordLevel = Sword.swordLevel; // Aggiorna swordLevel in toSave
        print("new swordLevel: " + toSave.swordLevel);

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
            toSave = JsonUtility.FromJson<SaveData>(json);
            Sword.swordLevel = toSave.swordLevel; // Carica swordLevel dal file
        } else {
            // Se il file non esiste, inizia con valori predefiniti
            Sword.swordLevel = 0;
            SaveDataToFile(); // Crea un nuovo file con i dati predefiniti
        }
    }
}

[System.Serializable]
public class SaveData {
    public int swordLevel;
    // Altri dati che desideri salvare...
}
