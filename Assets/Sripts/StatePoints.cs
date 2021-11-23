using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TMPro;


public class StatePoints : MonoBehaviour
{
    public  static  StatePoints StatePoints1;
    public int pointsMaximal;
    private String path;
    
    public TMPro.TextMeshProUGUI pointsText;
    
    private void Awake()
    {
        
        path = Application.persistentDataPath + "/points.dat";
        
        if (StatePoints1==null)
        {
            StatePoints1 =  this; 
            DontDestroyOnLoad(gameObject);
        }
        else if(StatePoints1!=this)
        {
            Destroy(gameObject);
        }

    }
    
    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        //Load();
    }
    
    
    public void Save()
    {
        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);
        
        DataToSave data = new DataToSave(pointsMaximal); ;
        
        bf.Serialize(file, data);
        
        file.Close();
    }
    
    
    public void  Load()
    {

        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
        
            DataToSave data = (DataToSave)bf.Deserialize(file);
        
            pointsMaximal=data.pointsMax;
        
            file.Close();
            
            pointsText.text = pointsMaximal.ToString();
            
        }else
        {
            pointsMaximal=0;
        }
    }
    
}

[Serializable]
class DataToSave
{
    public int pointsMax;
    
    
    public DataToSave(int pointsMax)
    {
        this.pointsMax = pointsMax;
    }
    
}
