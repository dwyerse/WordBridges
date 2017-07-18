using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class levels {

    public int easy = 3;
    public int medium = 3;
    public int hard = 3;
    public int extreme = 3;
  
    public string [,] A1()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = "P";
        letters[0, 1] = "O";
        letters[0, 2] = "T";
        letters[1, 2] = "E";
        letters[2, 2] = "A";
        return letters;
    }

    public string[,] A2()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = "A";
        letters[0, 1] = "X";
        letters[0, 2] = "E";
        letters[1, 2] = "V";
        letters[2, 2] = "E";
        return letters;
    }

    public string[,] A3()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = "R";
        letters[0, 1] = "Y";
        letters[0, 2] = "E";
        letters[1, 2] = "Y";
        letters[2, 2] = "E";
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

}
