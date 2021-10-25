using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{
    private int[,] levelMapArray = {
                                    {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
                                    {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
                                    {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
                                    {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
                                    {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
                                    {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
                                    {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
                                    {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
                                    {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
                                    {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
                                    {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
                                    {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
                                    {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
                                    {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
                                    {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
                                    };
    public Tilemap levelMap;
    public AnimatedTile outsideCorner;
    public AnimatedTile outsideWall;
    public AnimatedTile insideCorner;
    public AnimatedTile insideWall;
    public AnimatedTile standardPellet;
    public AnimatedTile powerPellet;
    public AnimatedTile tJunction;
    


    //Place all tiles first, then check when and how to rotate

    public void PlaceOutsideCorner(int row, int col, int mapWidth, int mapHeight)
    {
        levelMap.SetTile(new Vector3Int(col - mapWidth, mapHeight - row, 0), outsideCorner); // left top
        levelMap.SetTile(new Vector3Int(mapWidth - 1 - col, mapHeight - row, 0), outsideCorner); // right top
        levelMap.SetTile(new Vector3Int(mapWidth - 1 - col, row - (mapHeight - 2), 0), outsideCorner); // right bottom
        levelMap.SetTile(new Vector3Int(col - mapWidth, row - (mapHeight - 2), 0), outsideCorner); // left bottm
        // check downwards
        if (row + 1 < mapHeight && levelMapArray[row + 1, col] == 2)
        {
            // check leftside 
            if (col - 1 >= 0 && levelMapArray[row, col - 1] == 2)
            {
                Matrix4x4 matrixLeftTop = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 270f), Vector3.one);
                levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, mapHeight - row, 0), matrixLeftTop);
                Matrix4x4 matrixRightBottom = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(180f, 0f, 0f), Vector3.one);
                levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, row - (mapHeight - 2), 0), matrixRightBottom);
                Matrix4x4 matrixLeftBottom = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 180f), Vector3.one);
                levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, row - (mapHeight - 2), 0), matrixLeftBottom);
            }
            // check rightside
            if (col + 1 < mapWidth && levelMapArray[row, col + 1] == 2)
            {
                Matrix4x4 matrixRightTop = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 180f, 0f), Vector3.one);
                levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, mapHeight - row, 0), matrixRightTop);
                Matrix4x4 matrixRightBottom = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 180f), Vector3.one);
                levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, row - (mapHeight - 2), 0), matrixRightBottom);
                Matrix4x4 matrixLeftBottom = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(180f, 0f, 0f), Vector3.one);
                levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, row - (mapHeight - 2), 0), matrixLeftBottom);
            }
        }
        // check upwards
        if (row - 1 >= 0 && levelMapArray[row - 1, col] == 2)
        {
            // check leftside
            if (col - 1 >= 0 && levelMapArray[row, col - 1] == 2)
            {
                Matrix4x4 matrixLeftTop = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 180f), Vector3.one);
                levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, mapHeight - row, 0), matrixLeftTop);
                Matrix4x4 matrixRightTop = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 90f), Vector3.one);
                levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, mapHeight - row, 0), matrixRightTop);
                Matrix4x4 matrixLeftBottom = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 180f, 0f), Vector3.one);
                levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, row - (mapHeight - 2), 0), matrixLeftBottom);
            }
            // check rightside
            if (col + 1 < mapWidth && levelMapArray[row, col + 1] == 2)
            {
                Matrix4x4 matrixLeftTop = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 90f), Vector3.one);
                levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, mapHeight - row, 0), matrixLeftTop);
                Matrix4x4 matrixRightTop = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 180f), Vector3.one);
                levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, mapHeight - row, 0), matrixRightTop);
                Matrix4x4 matrixRightBottom = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 180f, 0f), Vector3.one);
                levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, row - (mapHeight - 2), 0), matrixRightBottom);
            }
        }
    }

    public void PlaceOutsideWall(int row, int col, int mapWidth, int mapHeight)
    {
        levelMap.SetTile(new Vector3Int(col - mapWidth, mapHeight - row, 0), outsideWall);
        levelMap.SetTile(new Vector3Int(mapWidth - 1 - col, mapHeight - row, 0), outsideWall);
        levelMap.SetTile(new Vector3Int(mapWidth - 1 - col, row - (mapHeight - 2), 0), outsideWall);
        levelMap.SetTile(new Vector3Int(col - mapWidth, row - (mapHeight - 2), 0), outsideWall);
        // if vertical
        if ((row - 1 >= 0 && levelMapArray[row - 1, col] == 2) || (row + 1 < mapHeight && levelMapArray[row + 1, col] == 2))
        {
            Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 90f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, mapHeight - row, 0), matrix);
            levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, mapHeight - row, 0), matrix);
            levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, row - (mapHeight - 2), 0), matrix);
            levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, row - (mapHeight - 2), 0), matrix);
        }
    }

    public void PlaceInsideCorner(int row, int col, int mapWidth, int mapHeight)
    {
        levelMap.SetTile(new Vector3Int(col - mapWidth, mapHeight - row, 0), insideCorner);
        levelMap.SetTile(new Vector3Int(mapWidth - 1 - col, mapHeight - row, 0), insideCorner);
        levelMap.SetTile(new Vector3Int(mapWidth - 1 - col, row - (mapHeight - 2), 0), insideCorner);
        levelMap.SetTile(new Vector3Int(col - mapWidth, row - (mapHeight - 2), 0), insideCorner);
        // left & down                        4
        // 4 3   3 3   4 3   3   4 4 3 4    4 3   3 3
        //   4     4     3   4       4        4     3
        //                                    4
        if (((row + 1 < mapHeight && levelMapArray[row + 1, col] == 4) && (col - 1 >= 0 && levelMapArray[row, col - 1] == 4) &&
             (col + 1 < mapWidth && levelMapArray[row, col + 1] != 4)) ||

            ((row + 1 < mapHeight && levelMapArray[row + 1, col] == 4) && (col - 1 >= 0 && levelMapArray[row, col - 1] == 3) &&
             (col + 1 < mapWidth && levelMapArray[row, col + 1] != 4)) ||

            ((row + 1 < mapHeight && levelMapArray[row + 1, col] == 3) && (col - 1 >= 0 && levelMapArray[row, col - 1] == 4) &&
             (col + 1 < mapWidth && levelMapArray[row, col + 1] != 4)) ||

            ((row + 1 < mapHeight && levelMapArray[row + 1, col] == 4) && (col + 1 < mapWidth && levelMapArray[row, col + 1] != 4) &&
             (col - 1 < 0)) ||

            ((row + 1 < mapHeight && levelMapArray[row + 1, col] == 4) && (col - 1 >= 0 && levelMapArray[row, col - 1] == 4) &&
             (col - 2 >= 0 && levelMapArray[row, col - 2] == 4) &&
             (col + 1 < mapWidth && levelMapArray[row, col + 1] == 4)) ||

            ((row + 1 < mapHeight && levelMapArray[row + 1, col] == 4) && (row + 2 < mapHeight && levelMapArray[row + 2, col] == 4) &&
             (col - 1 >= 0 && levelMapArray[row, col - 1] == 4) &&
             (row - 1 >= 0 && levelMapArray[row - 1, col] == 4)) ||

            ((row + 1 < mapHeight && levelMapArray[row + 1, col] == 3) && (col - 1 >= 0 && levelMapArray[row, col - 1] == 3))
            )
        {
            Matrix4x4 matrixLeftTop = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 270f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, mapHeight - row, 0), matrixLeftTop);
            Matrix4x4 matrixRightBottom = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(180f, 0f, 0f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, row - (mapHeight - 2), 0), matrixRightBottom);
            Matrix4x4 matrixLeftBottom = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 180f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, row - (mapHeight - 2), 0), matrixLeftBottom);
        }

        //                                  4
        // left & up                        4
        //   4     4     3   4      4     4 3     3 
        // 4 3   3 3   4 3   3  4 4 3 4     4   3 3
        else if (((row - 1 >= 0 && levelMapArray[row - 1, col] == 4) && (col - 1 >= 0 && levelMapArray[row, col - 1] == 4) &&
             (col + 1 < mapWidth && levelMapArray[row, col + 1] != 4)) ||

            ((row - 1 >= 0 && levelMapArray[row - 1, col] == 4) && (col - 1 >= 0 && levelMapArray[row, col - 1] == 3) &&
             (col + 1 < mapWidth && levelMapArray[row, col + 1] != 4)) ||

            ((row - 1 >= 0 && levelMapArray[row - 1, col] == 3) && (col - 1 >= 0 && levelMapArray[row, col - 1] == 4) &&
             (col + 1 < mapWidth && levelMapArray[row, col + 1] != 4)) ||

            ((row - 1 >= 0 && levelMapArray[row - 1, col] == 4) && (col + 1 < mapWidth && levelMapArray[row, col + 1] != 4) &&
             (col - 1 < 0)) ||

            ((row - 1 >= 0 && levelMapArray[row - 1, col] == 4) && (col - 1 >= 0 && levelMapArray[row, col - 1] == 4) &&
             (col - 2 >= 0 && levelMapArray[row, col - 2] == 4) && (col + 1 < mapWidth && levelMapArray[row, col + 1] == 4)) ||

            ((row - 1 >= 0 && levelMapArray[row - 1, col] == 4) && (col - 1 >= 0 && levelMapArray[row, col - 1] == 4) &&
             (row + 1 < mapHeight && levelMapArray[row + 1, col] == 4) && (row - 2 >= 0 && levelMapArray[row - 2, col] == 4)) ||

            ((row - 1 >= 0 && levelMapArray[row - 1, col] == 3) && (col - 1 >= 0 && levelMapArray[row, col - 1] == 3))
            )
        {
            Matrix4x4 matrixLeftTop = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 180f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, mapHeight - row, 0), matrixLeftTop);
            Matrix4x4 matrixRightTop = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(180f, 0f, 0f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, mapHeight - row, 0), matrixRightTop);
            Matrix4x4 matrixLeftBottom = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 180f, 0f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, row - (mapHeight - 2), 0), matrixLeftBottom);
        }

        //                                   4
        // right & up                        4
        // 4     4     3      4      4       3 4    3
        // 3 4   3 3   3 4    3    4 3 4 4   4      3 3
        else if (((row - 1 >= 0 && levelMapArray[row - 1, col] == 4) && (col + 1 < mapWidth && levelMapArray[row, col + 1] == 4) &&
             (col - 1 >= 0 && levelMapArray[row, col - 1] != 4)) ||

            ((row - 1 >= 0 && levelMapArray[row - 1, col] == 4) && (col + 1 < mapWidth && levelMapArray[row, col + 1] == 3) &&
             (col - 1 >= 0 && levelMapArray[row, col - 1] != 4)) ||

            ((row - 1 >= 0 && levelMapArray[row - 1, col] == 3) && (col + 1 < mapWidth && levelMapArray[row, col + 1] == 4) &&
             (col - 1 >= 0 && levelMapArray[row, col - 1] != 4)) ||

            ((row - 1 >= 0 && levelMapArray[row - 1, col] == 4) && (col - 1 >= 0 && levelMapArray[row, col - 1] != 4) &&
             (col + 1 == mapWidth)) ||

            ((row - 1 >= 0 && levelMapArray[row - 1, col] == 4) && (col + 1 < mapWidth && levelMapArray[row, col + 1] == 4) &&
            (col + 2 < mapWidth && levelMapArray[row, col + 2] == 4) && (col - 1 >= 0 && levelMapArray[row, col - 1] == 4)) ||

            ((row - 1 >= 0 && levelMapArray[row - 1, col] == 4) && (col + 1 < mapWidth && levelMapArray[row, col + 1] == 4) &&
             (row + 1 < mapHeight && levelMapArray[row + 1, col] == 4) && (row - 2 >= 0 && levelMapArray[row - 2, col] == 4)) ||

            ((row - 1 >= 0 && levelMapArray[row - 1, col] == 3) && (col + 1 < mapWidth && levelMapArray[row, col + 1] == 3))
            )
        {
            Matrix4x4 matrixLeftTop = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 90f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, mapHeight - row, 0), matrixLeftTop);
            Matrix4x4 matrixRightTop = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 180f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, mapHeight - row, 0), matrixRightTop);
            Matrix4x4 matrixRightBottom = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 180f, 0f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, row - (mapHeight - 2), 0), matrixRightBottom);
        }
        else
        {
            Matrix4x4 matrixRightTop = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 180f, 0f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, mapHeight - row, 0), matrixRightTop);
            Matrix4x4 matrixRightBottom = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 180f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, row - (mapHeight - 2), 0), matrixRightBottom);
            Matrix4x4 matrixLeftBottom = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(180f, 0f, 0f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, row - (mapHeight - 2), 0), matrixLeftBottom);
        }
    }

    public void PlaceInsideWall(int row, int col, int mapWidth, int mapHeight)
    {
        levelMap.SetTile(new Vector3Int(col - mapWidth, mapHeight - row, 0), insideWall);
        levelMap.SetTile(new Vector3Int(mapWidth - 1 - col, mapHeight - row, 0), insideWall);
        levelMap.SetTile(new Vector3Int(mapWidth - 1 - col, row - (mapHeight - 2), 0), insideWall);
        levelMap.SetTile(new Vector3Int(col - mapWidth, row - (mapHeight - 2), 0), insideWall);
        // if vertical
        // 3   3   3   X   4   4   4   X   7   4
        // 4   4   4   4   4   4   4   4   4   4
        // 3   X   4   4   4   X   3   3   4   7
        if (((row - 1 >= 0 && levelMapArray[row - 1, col] == 3) && (row + 1 < mapHeight && levelMapArray[row + 1, col] == 3)) ||
            ((row - 1 >= 0 && levelMapArray[row - 1, col] == 3) && (row + 1 == mapHeight)) ||
            ((row - 1 >= 0 && levelMapArray[row - 1, col] == 3) && (row + 1 < mapHeight && levelMapArray[row + 1, col] == 4)) ||
            ((row - 1 == 0) && (row + 1 < mapHeight && levelMapArray[row + 1, col] == 4)) ||
            ((row - 1 >= 0 && levelMapArray[row - 1, col] == 4) && (row + 1 < mapHeight && levelMapArray[row + 1, col] == 4)) ||
            ((row - 1 >= 0 && levelMapArray[row - 1, col] == 4) && (row + 1 == mapHeight)) ||
            ((row - 1 >= 0 && levelMapArray[row - 1, col] == 4) && (row + 1 < mapHeight && levelMapArray[row + 1, col] == 3)) ||
            ((row - 1 == 0) && (row + 1 < mapHeight && levelMapArray[row + 1, col] == 3)) ||
            ((row - 1 >= 0 && levelMapArray[row - 1, col] == 7) && (row + 1 < mapHeight && levelMapArray[row + 1, col] == 4)) ||
            ((row - 1 >= 0 && levelMapArray[row - 1, col] == 4) && (row + 1 < mapHeight && levelMapArray[row + 1, col] == 7))
           )
        {
            Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 90f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, mapHeight - row, 0), matrix);
            levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, mapHeight - row, 0), matrix);
            levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, row - (mapHeight - 2), 0), matrix);
            levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, row - (mapHeight - 2), 0), matrix);
        }
    }

    public void PlaceTJuntion(int row, int col, int mapWidth, int mapHeight)
    {
        //                   4   4
        //  2  7   7  2   2  7   7  2
        //     4   4
        levelMap.SetTile(new Vector3Int(col - mapWidth, mapHeight - row, 0), tJunction);
        levelMap.SetTile(new Vector3Int(mapWidth - 1 - col, mapHeight - row, 0), tJunction); // right top
        levelMap.SetTile(new Vector3Int(mapWidth - 1 - col, row - (mapHeight - 2), 0), tJunction); // right bottom
        levelMap.SetTile(new Vector3Int(col - mapWidth, row - (mapHeight - 2), 0), tJunction); // left bottom
        if ((row + 1 < mapHeight && levelMapArray[row + 1, col] == 4) && (col - 1 >= 0 && levelMapArray[row, col - 1] == 2))
        {
            Matrix4x4 matrixRightTop = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 180f, 0f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, mapHeight - row, 0), matrixRightTop);
            Matrix4x4 matrixRightBottom = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 180f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, row - (mapHeight - 2), 0), matrixRightBottom);
            Matrix4x4 matrixLeftBottom = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(180f, 0f, 0f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, row - (mapHeight - 2), 0), matrixLeftBottom);
        }
        if ((row + 1 < mapHeight && levelMapArray[row + 1, col] == 4) && (col + 1 < mapWidth && levelMapArray[row, col - 1] == 2))
        {
            Matrix4x4 matrixLeftTop = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 180f, 0f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, mapHeight - row, 0), matrixLeftTop);
            Matrix4x4 matrixRightBottom = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(180f, 0f, 0f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, row - (mapHeight - 2), 0), matrixRightBottom);
            Matrix4x4 matrixLeftBottom = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 180f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, row - (mapHeight - 2), 0), matrixLeftBottom);
        }
        if ((row - 1 >= 0 && levelMapArray[row - 1, col] == 4) && (col - 1 >= 0 && levelMapArray[row, col - 1] == 2))
        {
            Matrix4x4 matrixLeftTop = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(180f, 0f, 0f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, mapHeight - row, 0), matrixLeftTop);
            Matrix4x4 matrixRightTop = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 180f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, mapHeight - row, 0), matrixRightTop);
            Matrix4x4 matrixRightBottom = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 180f, 0f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, row - (mapHeight - 2), 0), matrixRightBottom);
            
        }
        if ((row - 1 >= 0 && levelMapArray[row - 1, col] == 4) && (col + 1 < mapWidth && levelMapArray[row, col + 1] == 2))
        {
            Matrix4x4 matrixLeftTop = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 180f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, mapHeight - row, 0), matrixLeftTop);
            Matrix4x4 matrixRightTop = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(180f, 0f, 0f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(mapWidth - 1 - col, mapHeight - row, 0), matrixRightTop);
            Matrix4x4 matrixLeftBottom = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 180f, 0f), Vector3.one);
            levelMap.SetTransformMatrix(new Vector3Int(col - mapWidth, row - (mapHeight - 2), 0), matrixLeftBottom);
        }
       
    }

    // Start is called before the first frame update
    void Start()
    {
        int levelMapArrayHeight = levelMapArray.GetLength(0); // mapHeight
        int levelMapArrayWidth = levelMapArray.GetLength(1);  // mapWidth
        levelMap.ClearAllTiles();
        for (int i = 0; i < levelMapArray.GetLength(0); i++)
        {
            for (int j = 0; j < levelMapArray.GetLength(1); j++)
            {
                switch (levelMapArray[i, j])
                {
                    case 0: break;
                    case 1: PlaceOutsideCorner(i, j, levelMapArrayWidth, levelMapArrayHeight); break;
                    case 2: PlaceOutsideWall(i, j, levelMapArrayWidth, levelMapArrayHeight); break;
                    case 3: PlaceInsideCorner(i, j, levelMapArrayWidth, levelMapArrayHeight); break;
                    case 4: PlaceInsideWall(i, j, levelMapArrayWidth, levelMapArrayHeight); break;
                    case 5:
                        levelMap.SetTile(new Vector3Int(j - levelMapArrayWidth, levelMapArrayHeight - i, 0), standardPellet);
                        levelMap.SetTile(new Vector3Int(levelMapArrayWidth - 1 - j, levelMapArrayHeight - i, 0), standardPellet);
                        levelMap.SetTile(new Vector3Int(levelMapArrayWidth - 1 - j, i - (levelMapArrayHeight - 2), 0), standardPellet);
                        levelMap.SetTile(new Vector3Int(j - levelMapArrayWidth, i - (levelMapArrayHeight - 2), 0), standardPellet);
                        break;
                    case 6:
                        levelMap.SetTile(new Vector3Int(j - levelMapArrayWidth, levelMapArrayHeight - i, 0), powerPellet);
                        levelMap.SetTile(new Vector3Int(levelMapArrayWidth - 1 - j, levelMapArrayHeight - i, 0), powerPellet);
                        levelMap.SetTile(new Vector3Int(levelMapArrayWidth - 1 - j, i - (levelMapArrayHeight - 2), 0), powerPellet);
                        levelMap.SetTile(new Vector3Int(j - levelMapArrayWidth, i - (levelMapArrayHeight - 2), 0), powerPellet);
                        break;
                    case 7:
                        PlaceTJuntion(i, j, levelMapArrayWidth, levelMapArrayHeight);
                        break;
                }
            }
        }


        string fileName = "Levelmap01";
        GameObject lmGrid = GameObject.Find("Grid");
        if (lmGrid)
        {
            string filePath = "Assets/" + fileName + ".prefab";
            PrefabUtility.SaveAsPrefabAsset(lmGrid, filePath);
        }

        
    }

    // Update is called once per frame
    void Update()
    {

    }
}