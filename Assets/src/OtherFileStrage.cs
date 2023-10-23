using System.IO;
using UnityEngine;

public class OtherFileStorage
{
    private bool fileAppend = true; //true=追記, false=上書き
    private string fileName = "empty";
    private string extension = ".csv";
    private int distimation = 0;
    private readonly string date = System.DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
    private string filePath = Application.dataPath + "/SensorData";

    public OtherFileStorage(string fileName,int distimation)
    { 
        this.fileName = fileName;
        this.distimation = distimation;

        //一行目の表題の確認
        this.writeText(firstLog(distimation),pathGet());
    }


    public void doLog(string text)
    {
        string logText = DateUtility.Now().ToString() + "," + text ;
        writeText(logText, pathGet());
    }

    private void writeText(string text, string path)
    {
        StreamWriter sw = new StreamWriter(path, fileAppend);// TextData.txtというファイルを新規で用意
        sw.WriteLine(text);// ファイルに書き出したあと改行
        sw.Flush();// StreamWriterのバッファに書き出し残しがないか確認
        sw.Close();// ファイルを閉じる
    }

    private string firstLog(int dimension)
    {
        switch (dimension) 
        {
            case 1:
                return "time,x";
            case 2:
                return "time,x,y";
            case 3:
                return "time,x,y,z";
            case 4:
                return "time,x,y,z,w";
            default:
                return "time,x,y,z";
        }
    }

    private string pathGet()
    {
        return filePath + "/" + date + "-" + fileName + extension;
    }
}