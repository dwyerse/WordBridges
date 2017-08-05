using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class levels {

    public int easy = 9;
    public int medium = 4;
    public int hard = 1;
    public string[] file;
    public levels(){
               
    }

    public string [,] A1()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = "A";
        letters[0, 1] = "T";
        letters[1, 1] = "I";
        letters[2, 1] = "E";
        return letters;
    }

    public string[,] A2()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = "P";
        letters[0, 1] = "E";
        letters[0, 2] = "A";
        letters[1, 2] = "I";
        letters[2, 2] = "D";
        return letters;
    }

    public string[,] A3()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = "R";
        letters[0, 1] = "Y";
        letters[0, 2] = "E";
        letters[1, 1] = "O";
        letters[2, 1] = "U";
        return letters;
    }

    public string[,] A4()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = "P";
        letters[0, 1] = "I";
        letters[0, 2] = "E";
        letters[1, 2] = "Y";
        letters[2, 2] = "E";
        return letters;
    }

    public string[,] A5()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = "P";
        letters[0, 1] = "A";
        letters[0, 2] = "N";
        letters[1, 1] = "N";
        letters[2, 1] = "D";
        return letters;
    }


    public string[,] A6()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = "D";
        letters[0, 1] = "O";
        letters[0, 2] = "G";
        letters[1, 2] = "I";
        letters[2, 2] = "N";
        return letters;
    }

    public string[,] A7()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = "L";
        letters[0, 1] = "A";
        letters[0, 2] = "P";
        letters[1, 1] = "S";
        letters[2, 1] = "H";
        return letters;
    }
    public string[,] A8()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = "C";
        letters[0, 1] = "R";
        letters[0, 2] = "Y";
        letters[1, 0] = "U";
        letters[2, 0] = "B";
        return letters;
    }

    public string[,] A9()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = "S";
        letters[0, 1] = "H";
        letters[0, 2] = "Y";
        letters[1, 2] = "A";
        letters[2, 2] = "K";
        return letters;
    }
    public string[,] B1()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = "P";
        letters[0, 1] = "A";
        letters[0, 2] = "S";
        letters[0, 3] = "T";
        letters[1, 3] = "R";
        letters[2, 3] = "A";
        letters[3, 3] = "I";
        letters[4, 3] = "N";
        return letters;
    }

    public string[,] B2()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = "P";
        letters[0, 1] = "A";
        letters[0, 2] = "S";
        letters[0, 3] = "T";
        letters[1, 3] = "R";
        letters[2, 3] = "A";
        letters[3, 3] = "I";
        letters[4, 3] = "N";
        return letters;
    }

    public string[,] B3()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = "P";
        letters[0, 1] = "A";
        letters[0, 2] = "S";
        letters[0, 3] = "T";
        letters[1, 3] = "R";
        letters[2, 3] = "A";
        letters[3, 3] = "I";
        letters[4, 3] = "N";
        return letters;
    }

    public string[,] B4()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = "H";
        letters[0, 1] = "O";
        letters[0, 2] = "O";
        letters[0, 3] = "D";
        letters[1, 2] = "W";
        letters[2, 2] = "L";
        return letters;
    }

    public string[,] C1()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = "N";
        letters[0, 1] = "A";
        letters[0, 2] = "K";
        letters[0, 3] = "E";
        letters[0, 4] = "D";
        letters[1, 2] = "N";
        letters[2, 2] = "E";
        letters[3, 2] = "E";
        letters[4, 2] = "L";
        return letters;
    }

}
