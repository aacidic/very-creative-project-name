﻿using System;
using System.Collections.Generic;

namespace very_creative_project_name
{
    class Properties : Map
    {
        public int[][] tileType = new int[44][];
        public List<Point> enemy = new List<Point>();

        /// <summary>
        /// tileType Broken down:
        /// Type 0 = Unwalkable space in map
        /// Type 1 = Walkable space in map
        /// Type 2 = Enemy spawn in room
        /// Type 3 = Interactable in room
        /// Type 4 = Floor exit
        /// </summary>

        //SetBase initialises the full array and sets all elements of tileType to 0 as the baseline
        public void SetBase()
        {
            for (int y = 0; y < tileType.Length; y++)
            {
                tileType[y] = new int[200];
                for (int x = 0; x < tileType[y].Length; x++)
                {
                    tileType[y][x] = 0;
                }
            }
        }

        //SetRoom sets all room positions by coordinates as tileType 1
        public void SetRoom(Room rect)
        {
            for (int y = rect.y; y < rect.y + rect.height; y++)
            {
                for (int x = rect.x; x < rect.x + rect.width; x++)
                {
                    tileType[y][x] = 1;
                }
            }
        }

        /// <summary>
        /// Sets any extra tile types by individual coordinates
        /// </summary>
        /// <param name="x">X position of tile</param>
        /// <param name="y">Y position of tile</param>
        /// <param name="tile">Tile type as int</param>
        public void SetExtra(int x, int y, int tile)
        {
            tileType[y][x] = tile;
        }
    }
}
