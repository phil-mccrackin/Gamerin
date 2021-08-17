using System;
using System.Collections.Generic;

namespace Gamerin
{
    public class TetrisBagGenerator
    {
        string[] newPieceList = new string[]{"i", "l", "j", "s", "z", "t", "o"};
        public string bagNextPiece;
        Random RNG = new Random();

        public List<string> GenerateFirstBag(List<string> newBagPieces)
        {
            switch(RNG.Next(1, 7))
            {
                case 1:
                    bagNextPiece = "i";
                    newPieceList[0] = "empty";
                    break;
                case 2:
                    bagNextPiece = "l";
                    newPieceList[1] = "empty";
                    break;
                case 3:
                    bagNextPiece = "j";
                    newPieceList[2] = "empty";
                    break;
                case 4:
                    bagNextPiece = "s";
                    newPieceList[3] = "empty";
                    break;
                case 5:
                    bagNextPiece = "z";
                    newPieceList[4] = "empty";
                    break;
                case 6:
                    bagNextPiece = "t";
                    newPieceList[5] = "empty";
                    break;
                case 7:
                    bagNextPiece = "o";
                    newPieceList[7] = "empty";
                    break;
            }
            bool resultFound = false;
            for(int i = 0; i < 6; i++)
            {
                while(resultFound == false)
                {
                    int randomResult = RNG.Next(1, 8);
                    if(newPieceList[randomResult - 1] != "empty")
                    {
                        switch(randomResult)
                        {
                            case 1:
                                newBagPieces.Add("i");
                                newPieceList[0] = "empty";
                                resultFound = true;
                                break;
                            case 2:
                                newBagPieces.Add("l");
                                newPieceList[1] = "empty";
                                resultFound = true;
                                break;
                            case 3:
                                newBagPieces.Add("j");
                                newPieceList[2] = "empty";
                                resultFound = true;
                                break;
                            case 4:
                                newBagPieces.Add("s");
                                newPieceList[3] = "empty";
                                resultFound = true;
                                break;
                            case 5:
                                newBagPieces.Add("z");
                                newPieceList[4] = "empty";
                                resultFound = true;
                                break;
                            case 6:
                                newBagPieces.Add("t");
                                newPieceList[5] = "empty";
                                resultFound = true;
                                break;
                            case 7:
                                newBagPieces.Add("o");
                                newPieceList[6] = "empty";
                                resultFound = true;
                                break;
                        }
                    }
                }
                resultFound = false;
            }
            newPieceList[0] = "i";
            newPieceList[1] = "l";
            newPieceList[2] = "j";
            newPieceList[3] = "s";
            newPieceList[4] = "z";
            newPieceList[5] = "t";
            newPieceList[6] = "o";

            return newBagPieces;
        }

        public List<string> GenerateAnotherBag(List<string> newBagPieces)
        {
            for(int i = 0; i < 7; i++)
            {
                bool resultFound = false;
                while(resultFound == false)
                {
                    int randomResult = RNG.Next(1, 8);
                    if(newPieceList[randomResult - 1] != "empty")
                    {
                        switch(randomResult)
                        {
                            case 1:
                                newBagPieces.Add("i");
                                newPieceList[0] = "empty";
                                resultFound = true;
                                break;
                            case 2:
                                newBagPieces.Add("l");
                                newPieceList[1] = "empty";
                                resultFound = true;
                                break;
                            case 3:
                                newBagPieces.Add("j");
                                newPieceList[2] = "empty";
                                resultFound = true;
                                break;
                            case 4:
                                newBagPieces.Add("s");
                                newPieceList[3] = "empty";
                                resultFound = true;
                                break;
                            case 5:
                                newBagPieces.Add("z");
                                newPieceList[4] = "empty";
                                resultFound = true;
                                break;
                            case 6:
                                newBagPieces.Add("t");
                                newPieceList[5] = "empty";
                                resultFound = true;
                                break;
                            case 7:
                                newBagPieces.Add("o");
                                newPieceList[6] = "empty";
                                resultFound = true;
                                break;
                        }
                    }
                }
                resultFound = false;
            }
            newPieceList[0] = "i";
            newPieceList[1] = "l";
            newPieceList[2] = "j";
            newPieceList[3] = "s";
            newPieceList[4] = "z";
            newPieceList[5] = "t";
            newPieceList[6] = "o";

            return newBagPieces;
        }
    }
}