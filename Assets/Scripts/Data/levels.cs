using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class levels {

    public int easy = 20;
    public int medium = 20;
    public int hard = 1;
    public string[] file;
    public levels(){
               
    }

    //TEMPLATE
    /*
        string[,] letters = new string[6, 6];
        letters[0, 0] = "";letters[0, 1] = ""; letters[0, 2] = ""; letters[0, 3] = ""; letters[0, 4] = ""; 
        letters[1, 0] = "";letters[1, 1] = ""; letters[1, 2] = ""; letters[1, 3] = ""; letters[1, 4] = ""; 
        letters[2, 0] = "";letters[2, 1] = ""; letters[2, 2] = ""; letters[2, 3] = ""; letters[2, 4] = ""; 
        letters[3, 0] = "";letters[3, 1] = ""; letters[3, 2] = ""; letters[3, 3] = ""; letters[3, 4] = ""; 
        letters[4, 0] = "";letters[4, 1] = ""; letters[4, 2] = ""; letters[4, 3] = ""; letters[4, 4] = ""; 
        return letters;
    */



    public string [,] A1()
    {
        string[,] letters = new string[6, 6];
        
        letters[1, 2] = "A";
        letters[2, 2] = "R";
        letters[3, 2] = "E";
        letters[2, 1] = "A";
        letters[2, 3] = "T";

        return letters;
    }

    public string[,] A2()
    {
        string[,] letters = new string[6, 6];
        letters[0, 1] = "P";
        letters[0, 2] = "E";
        letters[0, 3] = "A";
        letters[1, 3] = "I";
        letters[2, 3] = "D";
        return letters;
    }

    public string[,] A3()
    {
        string[,] letters = new string[6, 6];
        letters[1, 1] = "R";
        letters[1, 2] = "Y";
        letters[1, 3] = "E";
        letters[2, 2] = "O";
        letters[3, 2] = "U";
        return letters;
    }

    public string[,] A4()
    {
        string[,] letters = new string[6, 6];
        letters[0, 1] = "P";
        letters[0, 2] = "I";
        letters[0, 3] = "E";
        letters[1, 3] = "Y";
        letters[2, 3] = "E";
        return letters;
    }

    public string[,] A5()
    {
        string[,] letters = new string[6, 6];
        letters[0, 1] = "P";
        letters[0, 2] = "A";
        letters[0, 3] = "N";
        letters[1, 2] = "N";
        letters[2, 2] = "D";
        return letters;
    }


    public string[,] A6()
    {
        string[,] letters = new string[6, 6];
        letters[0, 1] = "D";
        letters[0, 2] = "O";
        letters[0, 3] = "G";
        letters[1, 3] = "I";
        letters[2, 3] = "N";
        return letters;
    }

    public string[,] A7()
    {
        string[,] letters = new string[6, 6];
        letters[0, 1] = "L";
        letters[0, 2] = "A";
        letters[0, 3] = "P";
        letters[1, 2] = "S";
        letters[2, 2] = "H";
        return letters;
    }
    public string[,] A8()
    {
        string[,] letters = new string[6, 6];
        letters[0, 1] = "C";
        letters[0, 2] = "R";
        letters[0, 3] = "Y";
        letters[1, 1] = "U";
        letters[2, 1] = "B";
        return letters;
    }

    public string[,] A9()
    {
        string[,] letters = new string[6, 6];
        letters[0, 1] = "S";
        letters[0, 2] = "H";
        letters[0, 3] = "Y";
        letters[1, 3] = "A";
        letters[2, 3] = "R";
        letters[3, 3] = "N";
        return letters;
    }
    public string[,] A10()
    {
        string[,] letters = new string[6, 6];
        letters[0, 2] = "L";
        letters[1, 2] = "A";
        letters[2, 2] = "Z";
        letters[3, 2] = "Y";
        letters[1, 1] = "M";
        letters[1, 3] = "N";
        return letters;
    }
    public string[,] A11()
    {
        string[,] letters = new string[6, 6];
        letters[0, 2] = "T";
        letters[1, 2] = "R";
        letters[2, 2] = "I";
        letters[3, 2] = "A";
        letters[4, 2] = "L";
        letters[2, 3] = "N";
        return letters;
    }
    public string[,] A12()
    {
        string[,] letters = new string[6, 6];
        letters[0, 2] = "P";
        letters[1, 2] = "A";
        letters[2, 2] = "R";
        letters[3, 2] = "K";
        letters[1, 3] = "I";
        letters[1, 4] = "M";
        return letters;
    }
    public string[,] A13()
    {
        string[,] letters = new string[6, 6];
        letters[0, 2] = "P";
        letters[1, 2] = "L";
        letters[2, 2] = "A";
        letters[3, 2] = "N";
        letters[0, 0] = "M";
        letters[0, 1] = "A";
        return letters;
    }
    public string[,] A14()
    {
        string[,] letters = new string[6, 6];
        letters[0, 2] = "W";
        letters[1, 2] = "A";
        letters[2, 2] = "V";
        letters[3, 2] = "E";
        letters[0, 1] = "A";
        letters[0, 3] = "E";
        return letters;
    }
    public string[,] A15()
    {
        string[,] letters = new string[6, 6];
        letters[0, 1] = "C";
        letters[0, 2] = "A";
        letters[0, 3] = "T";

        letters[1, 2] = "C";
        letters[2, 1] = "T";
        letters[2, 3] = "A";
        letters[2, 2] = "E";
        return letters;
    }
    public string[,] A16()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = ""; letters[0, 2] = "D"; letters[0, 3] = ""; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = "O"; letters[1, 2] = "R"; letters[1, 3] = ""; letters[1, 4] = "";
        letters[2, 0] = ""; letters[2, 1] = ""; letters[2, 2] = "A"; letters[2, 3] = "T"; letters[2, 4] = "";
        letters[3, 0] = ""; letters[3, 1] = ""; letters[3, 2] = "W"; letters[3, 3] = ""; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = ""; letters[4, 2] = ""; letters[4, 3] = ""; letters[4, 4] = "";
        return letters;
    }

    public string[,] A17()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = ""; letters[0, 2] = "D"; letters[0, 3] = ""; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = "W"; letters[1, 2] = "A"; letters[1, 3] = "S"; letters[1, 4] = "";
        letters[2, 0] = ""; letters[2, 1] = ""; letters[2, 2] = "S"; letters[2, 3] = ""; letters[2, 4] = "";
        letters[3, 0] = ""; letters[3, 1] = ""; letters[3, 2] = "H"; letters[3, 3] = ""; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = ""; letters[4, 2] = ""; letters[4, 3] = ""; letters[4, 4] = "";
        return letters;
    }
    public string[,] A18()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = ""; letters[0, 2] = ""; letters[0, 3] = ""; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = ""; letters[1, 2] = "L"; letters[1, 3] = ""; letters[1, 4] = "";
        letters[2, 0] = ""; letters[2, 1] = ""; letters[2, 2] = "O"; letters[2, 3] = ""; letters[2, 4] = "";
        letters[3, 0] = ""; letters[3, 1] = "S"; letters[3, 2] = "W"; letters[3, 3] = "A"; letters[3, 4] = "N";
        letters[4, 0] = ""; letters[4, 1] = ""; letters[4, 2] = ""; letters[4, 3] = ""; letters[4, 4] = "";
        return letters;
    }
    public string[,] A19()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = "O"; letters[0, 2] = "N"; letters[0, 3] = "E"; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = ""; letters[1, 2] = "I"; letters[1, 3] = ""; letters[1, 4] = "";
        letters[2, 0] = ""; letters[2, 1] = ""; letters[2, 2] = "C"; letters[2, 3] = ""; letters[2, 4] = "";
        letters[3, 0] = ""; letters[3, 1] = "L"; letters[3, 2] = "E"; letters[3, 3] = "D"; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = ""; letters[4, 2] = ""; letters[4, 3] = ""; letters[4, 4] = "";
        return letters;
    }
    public string[,] A20()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = ""; letters[0, 2] = ""; letters[0, 3] = ""; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = "A"; letters[1, 2] = "G"; letters[1, 3] = "E"; letters[1, 4] = "";
        letters[2, 0] = ""; letters[2, 1] = ""; letters[2, 2] = "U"; letters[2, 3] = ""; letters[2, 4] = "";
        letters[3, 0] = ""; letters[3, 1] = ""; letters[3, 2] = "N"; letters[3, 3] = ""; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = ""; letters[4, 2] = ""; letters[4, 3] = ""; letters[4, 4] = "";
        return letters;
    }

    public string[,] B1()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = ""; letters[0, 2] = "T"; letters[0, 3] = ""; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = ""; letters[1, 2] = "R"; letters[1, 3] = ""; letters[1, 4] = "";
        letters[2, 0] = ""; letters[2, 1] = "P"; letters[2, 2] = "A"; letters[2, 3] = "S"; letters[2, 4] = "T";
        letters[3, 0] = ""; letters[3, 1] = ""; letters[3, 2] = "Y"; letters[3, 3] = ""; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = ""; letters[4, 2] = ""; letters[4, 3] = ""; letters[4, 4] = "";
        return letters;
    }

    public string[,] B2()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = ""; letters[0, 2] = "S"; letters[0, 3] = ""; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = ""; letters[1, 2] = "L"; letters[1, 3] = ""; letters[1, 4] = "";
        letters[2, 0] = ""; letters[2, 1] = "P"; letters[2, 2] = "I"; letters[2, 3] = "N"; letters[2, 4] = "";
        letters[3, 0] = ""; letters[3, 1] = ""; letters[3, 2] = "N"; letters[3, 3] = ""; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = ""; letters[4, 2] = "G"; letters[4, 3] = ""; letters[4, 4] = "";
        return letters;
    }

    public string[,] B3()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = ""; letters[0, 2] = ""; letters[0, 3] = ""; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = ""; letters[1, 2] = "R"; letters[1, 3] = ""; letters[1, 4] = "";
        letters[2, 0] = "C"; letters[2, 1] = "H"; letters[2, 2] = "I"; letters[2, 3] = "N"; letters[2, 4] = "K";
        letters[3, 0] = ""; letters[3, 1] = ""; letters[3, 2] = "D"; letters[3, 3] = ""; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = ""; letters[4, 2] = ""; letters[4, 3] = ""; letters[4, 4] = "";
        return letters;
    }


    public string[,] B4()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = "W"; letters[0, 2] = "H"; letters[0, 3] = "Y"; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = ""; letters[1, 2] = "O"; letters[1, 3] = ""; letters[1, 4] = "";
        letters[2, 0] = ""; letters[2, 1] = ""; letters[2, 2] = "O"; letters[2, 3] = "W"; letters[2, 4] = "L";
        letters[3, 0] = ""; letters[3, 1] = ""; letters[3, 2] = "D"; letters[3, 3] = ""; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = ""; letters[4, 2] = ""; letters[4, 3] = ""; letters[4, 4] = "";
        return letters;
    }

    public string[,] B5()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = ""; letters[0, 2] = ""; letters[0, 3] = ""; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = "T"; letters[1, 2] = "I"; letters[1, 3] = "E"; letters[1, 4] = "";
        letters[2, 0] = ""; letters[2, 1] = "R"; letters[2, 2] = ""; letters[2, 3] = "W"; letters[2, 4] = "";
        letters[3, 0] = ""; letters[3, 1] = "Y"; letters[3, 2] = ""; letters[3, 3] = "E"; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = ""; letters[4, 2] = ""; letters[4, 3] = ""; letters[4, 4] = "";
        return letters;
    }
    public string[,] B6()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = ""; letters[0, 2] = "G"; letters[0, 3] = "O"; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = ""; letters[1, 2] = "R"; letters[1, 3] = ""; letters[1, 4] = "";
        letters[2, 0] = ""; letters[2, 1] = ""; letters[2, 2] = "A"; letters[2, 3] = "T"; letters[2, 4] = "";
        letters[3, 0] = ""; letters[3, 1] = ""; letters[3, 2] = "S"; letters[3, 3] = ""; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = ""; letters[4, 2] = "S"; letters[4, 3] = "O"; letters[4, 4] = "";
        return letters;
    }
    public string[,] B7()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = ""; letters[0, 2] = ""; letters[0, 3] = ""; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = ""; letters[1, 2] = "F"; letters[1, 3] = ""; letters[1, 4] = "";
        letters[2, 0] = ""; letters[2, 1] = ""; letters[2, 2] = "I"; letters[2, 3] = ""; letters[2, 4] = "";
        letters[3, 0] = "H"; letters[3, 1] = "O"; letters[3, 2] = "R"; letters[3, 3] = "N"; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = ""; letters[4, 2] = "E"; letters[4, 3] = ""; letters[4, 4] = "";
        return letters;
    }
    public string[,] B8()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = ""; letters[0, 2] = ""; letters[0, 3] = ""; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = "U"; letters[1, 2] = "S"; letters[1, 3] = "E"; letters[1, 4] = "";
        letters[2, 0] = ""; letters[2, 1] = ""; letters[2, 2] = "T"; letters[2, 3] = ""; letters[2, 4] = "";
        letters[3, 0] = ""; letters[3, 1] = "N"; letters[3, 2] = "E"; letters[3, 3] = "T"; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = ""; letters[4, 2] = "W"; letters[4, 3] = ""; letters[4, 4] = "";
        return letters;
    }

    public string[,] B9()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = "L"; letters[0, 2] = ""; letters[0, 3] = ""; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = "O"; letters[1, 2] = ""; letters[1, 3] = ""; letters[1, 4] = "";
        letters[2, 0] = ""; letters[2, 1] = "G"; letters[2, 2] = "E"; letters[2, 3] = "L"; letters[2, 4] = "";
        letters[3, 0] = ""; letters[3, 1] = "I"; letters[3, 2] = ""; letters[3, 3] = ""; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = "C"; letters[4, 2] = ""; letters[4, 3] = ""; letters[4, 4] = "";
        return letters;
    }

    public string[,] B10()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = ""; letters[0, 2] = ""; letters[0, 3] = ""; letters[0, 4] = "";
        letters[1, 0] = "S"; letters[1, 1] = "A"; letters[1, 2] = "I"; letters[1, 3] = "N"; letters[1, 4] = "T";
        letters[2, 0] = ""; letters[2, 1] = ""; letters[2, 2] = "C"; letters[2, 3] = ""; letters[2, 4] = "";
        letters[3, 0] = ""; letters[3, 1] = ""; letters[3, 2] = "E"; letters[3, 3] = ""; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = ""; letters[4, 2] = ""; letters[4, 3] = ""; letters[4, 4] = "";
        return letters;
    }
    public string[,] B11()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = ""; letters[0, 2] = ""; letters[0, 3] = ""; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = ""; letters[1, 2] = ""; letters[1, 3] = ""; letters[1, 4] = "";
        letters[2, 0] = ""; letters[2, 1] = ""; letters[2, 2] = "C"; letters[2, 3] = ""; letters[2, 4] = "";
        letters[3, 0] = "P"; letters[3, 1] = "A"; letters[3, 2] = "U"; letters[3, 3] = "S"; letters[3, 4] = "E";
        letters[4, 0] = ""; letters[4, 1] = ""; letters[4, 2] = "P"; letters[4, 3] = ""; letters[4, 4] = "";
        return letters;
    }
    public string[,] B12()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = "T"; letters[0, 2] = ""; letters[0, 3] = ""; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = "W"; letters[1, 2] = ""; letters[1, 3] = ""; letters[1, 4] = "";
        letters[2, 0] = "S"; letters[2, 1] = "I"; letters[2, 2] = "G"; letters[2, 3] = "H"; letters[2, 4] = "";
        letters[3, 0] = ""; letters[3, 1] = "S"; letters[3, 2] = ""; letters[3, 3] = ""; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = "T"; letters[4, 2] = ""; letters[4, 3] = ""; letters[4, 4] = "";
        return letters;
    }
    public string[,] B13()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = ""; letters[0, 2] = "S"; letters[0, 3] = ""; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = ""; letters[1, 2] = "W"; letters[1, 3] = ""; letters[1, 4] = "";
        letters[2, 0] = ""; letters[2, 1] = ""; letters[2, 2] = "I"; letters[2, 3] = ""; letters[2, 4] = "";
        letters[3, 0] = ""; letters[3, 1] = ""; letters[3, 2] = "N"; letters[3, 3] = ""; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = "A"; letters[4, 2] = "G"; letters[4, 3] = "E"; letters[4, 4] = "";
        return letters;
    }
    public string[,] B14()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = ""; letters[0, 2] = ""; letters[0, 3] = ""; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = "G"; letters[1, 2] = "R"; letters[1, 3] = "I"; letters[1, 4] = "M";
        letters[2, 0] = ""; letters[2, 1] = ""; letters[2, 2] = "A"; letters[2, 3] = ""; letters[2, 4] = "";
        letters[3, 0] = ""; letters[3, 1] = ""; letters[3, 2] = "N"; letters[3, 3] = ""; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = "A"; letters[4, 2] = "G"; letters[4, 3] = "O"; letters[4, 4] = "";
        return letters;
    }

    public string[,] B15()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = ""; letters[0, 2] = "W"; letters[0, 3] = ""; letters[0, 4] = "";
        letters[1, 0] = "F"; letters[1, 1] = "L"; letters[1, 2] = "I"; letters[1, 3] = "C"; letters[1, 4] = "K";
        letters[2, 0] = ""; letters[2, 1] = ""; letters[2, 2] = "S"; letters[2, 3] = ""; letters[2, 4] = "";
        letters[3, 0] = ""; letters[3, 1] = ""; letters[3, 2] = "E"; letters[3, 3] = ""; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = ""; letters[4, 2] = ""; letters[4, 3] = ""; letters[4, 4] = "";
        return letters;
    }

    public string[,] B16()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = "D"; letters[0, 2] = ""; letters[0, 3] = ""; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = "E"; letters[1, 2] = ""; letters[1, 3] = ""; letters[1, 4] = "";
        letters[2, 0] = ""; letters[2, 1] = "W"; letters[2, 2] = "E"; letters[2, 3] = "T"; letters[2, 4] = "";
        letters[3, 0] = ""; letters[3, 1] = ""; letters[3, 2] = ""; letters[3, 3] = "A"; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = ""; letters[4, 2] = ""; letters[4, 3] = "N"; letters[4, 4] = "";
        return letters;
    }

    public string[,] B17()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = ""; letters[0, 2] = ""; letters[0, 3] = ""; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = "P"; letters[1, 2] = "A"; letters[1, 3] = "N"; letters[1, 4] = "";
        letters[2, 0] = ""; letters[2, 1] = "I"; letters[2, 2] = ""; letters[2, 3] = "A"; letters[2, 4] = "";
        letters[3, 0] = ""; letters[3, 1] = "L"; letters[3, 2] = ""; letters[3, 3] = "I"; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = "L"; letters[4, 2] = ""; letters[4, 3] = "L"; letters[4, 4] = "";
        return letters;
    }

    public string[,] B18()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = "S"; letters[0, 2] = ""; letters[0, 3] = "A"; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = "E"; letters[1, 2] = "L"; letters[1, 3] = "M"; letters[1, 4] = "";
        letters[2, 0] = ""; letters[2, 1] = "A"; letters[2, 2] = ""; letters[2, 3] = "I"; letters[2, 4] = "";
        letters[3, 0] = ""; letters[3, 1] = "M"; letters[3, 2] = ""; letters[3, 3] = "D"; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = ""; letters[4, 2] = ""; letters[4, 3] = ""; letters[4, 4] = "";
        return letters;
    }

    public string[,] B19()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = "D"; letters[0, 2] = ""; letters[0, 3] = ""; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = "U"; letters[1, 2] = ""; letters[1, 3] = "B"; letters[1, 4] = "";
        letters[2, 0] = ""; letters[2, 1] = "S"; letters[2, 2] = "L"; letters[2, 3] = "Y"; letters[2, 4] = "";
        letters[3, 0] = ""; letters[3, 1] = "T"; letters[3, 2] = ""; letters[3, 3] = "E"; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = "Y"; letters[4, 2] = ""; letters[4, 3] = ""; letters[4, 4] = "";
        return letters;
    }

    public string[,] B20()
    {
        string[,] letters = new string[6, 6];
        letters[0, 0] = ""; letters[0, 1] = ""; letters[0, 2] = ""; letters[0, 3] = "A"; letters[0, 4] = "";
        letters[1, 0] = ""; letters[1, 1] = "A"; letters[1, 2] = ""; letters[1, 3] = "B"; letters[1, 4] = "";
        letters[2, 0] = ""; letters[2, 1] = "G"; letters[2, 2] = "U"; letters[2, 3] = "Y"; letters[2, 4] = "";
        letters[3, 0] = ""; letters[3, 1] = "E"; letters[3, 2] = ""; letters[3, 3] = "S"; letters[3, 4] = "";
        letters[4, 0] = ""; letters[4, 1] = ""; letters[4, 2] = ""; letters[4, 3] = "S"; letters[4, 4] = "";
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
