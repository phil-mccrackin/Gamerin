using System;
using System.Collections.Generic;

namespace Gamerin
{
    public class TetrisBagGenerator
    {
        public IDictionary<int, string> newBagPieces = new Dictionary<int, string>();
        string[] newPieceList = new string[]{"i", "l", "j", "s", "z", "t", "o"};
        public string newNextPiece;
        Random RNG = new Random();
        public TetrisBagGenerator(IDictionary<int, string> bagPieces)
        {
            foreach(KeyValuePair<int, string> kvp in bagPieces)
            {
                newBagPieces.Add(kvp.Key, kvp.Value);
            }
        }

        public void GenerateFirstBag()
        {
            switch(RNG.Next(1, 7))
            {
                case 1:
                    newNextPiece = "i";
                    newPieceList[0] = "empty";
                    break;
                case 2:
                    newNextPiece = "l";
                    newPieceList[1] = "empty";
                    break;
                case 3:
                    newNextPiece = "j";
                    newPieceList[2] = "empty";
                    break;
                case 4:
                    newNextPiece = "s";
                    newPieceList[3] = "empty";
                    break;
                case 5:
                    newNextPiece = "z";
                    newPieceList[4] = "empty";
                    break;
                case 6:
                    newNextPiece = "t";
                    newPieceList[5] = "empty";
                    break;
                case 7:
                    newNextPiece = "o";
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
                                newBagPieces.Add(i, "i");
                                newPieceList[0] = "empty";
                                resultFound = true;
                                break;
                            case 2:
                                newBagPieces.Add(i, "l");
                                newPieceList[1] = "empty";
                                resultFound = true;
                                break;
                            case 3:
                                newBagPieces.Add(i, "j");
                                newPieceList[2] = "empty";
                                resultFound = true;
                                break;
                            case 4:
                                newBagPieces.Add(i, "s");
                                newPieceList[3] = "empty";
                                resultFound = true;
                                break;
                            case 5:
                                newBagPieces.Add(i, "z");
                                newPieceList[4] = "empty";
                                resultFound = true;
                                break;
                            case 6:
                                newBagPieces.Add(i, "t");
                                newPieceList[5] = "empty";
                                resultFound = true;
                                break;
                            case 7:
                                newBagPieces.Add(i, "o");
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
        }

        public void GenerateAnotherBag()
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
                                newBagPieces.Add(newBagPieces.Count + i, "i");
                                newPieceList[0] = "empty";
                                resultFound = true;
                                break;
                            case 2:
                                newBagPieces.Add(newBagPieces.Count + i, "l");
                                newPieceList[1] = "empty";
                                resultFound = true;
                                break;
                            case 3:
                                newBagPieces.Add(newBagPieces.Count + i, "j");
                                newPieceList[2] = "empty";
                                resultFound = true;
                                break;
                            case 4:
                                newBagPieces.Add(newBagPieces.Count + i, "s");
                                newPieceList[3] = "empty";
                                resultFound = true;
                                break;
                            case 5:
                                newBagPieces.Add(newBagPieces.Count + i, "z");
                                newPieceList[4] = "empty";
                                resultFound = true;
                                break;
                            case 6:
                                newBagPieces.Add(newBagPieces.Count + i, "t");
                                newPieceList[5] = "empty";
                                resultFound = true;
                                break;
                            case 7:
                                newBagPieces.Add(newBagPieces.Count + i, "o");
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
        }
    }
}