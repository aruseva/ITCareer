﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _616
{
    class Program
    {
        //Автор: Цветилин Цветилов
        // 616 = Arrays in Matrix
        
/*
4
9
*--*---*-
*--*---*-
*--*---*-
*---*-*--
*/
        public static int row = int.Parse(Console.ReadLine());
        public static int col = int.Parse(Console.ReadLine());
        public static string[] table = new string[row];
        public static List<Region> regions = new List<Region>();
        public static void Draw()
        {
            for (int i = 0; i < row; i++)
            {
                table[i] = Console.ReadLine();
            }
        }
        public static void FindStartingPoints()
        {
            for (int i = 0; i < row; i++)
            {
                for (int y = 0; y < col; y++)
                {
                    if (table[i][y] == '-')
                    {
                        if (y == 0 && i == 0) regions.Add(new Region(y, i));
                        else if (y == 0) { if (table[i - 1][y] == '*') regions.Add(new Region(y, i)); }
                        else if (i == 0) { if (table[i][y - 1] == '*') regions.Add(new Region(y, i)); }
                        else if (table[i - 1][y] == '*' && table[i][y - 1] == '*') regions.Add(new Region(y, i));
                    }
                }
            }
        }

        public static void Print()
        {
            foreach (var item in regions)
            {
                Console.WriteLine(item.X + " " + item.Y + " " + item.Area);
            }
        }
        static void Main(string[] args)
        {
            Draw();
            FindStartingPoints();
            for (int ind = 0; ind < regions.Count; ind++)
            {
                int startX = regions[ind].X;
                int startY = regions[ind].Y;
                Counter = 0;
                Check(startX, startY);
                regions[ind].Area = Counter;
            }
            regions = regions.Where(x => x.Area != 0).OrderByDescending(x => x.Area).ToList();
            Print();
        }
        public static int Counter = 0;
        public static void Check(int startX, int startY)
        {
            if (IsInBounds(startX, startY))
                if (table[startY][startX] != '*')
                {
                    Mark(startX, startY);
                    Check(startX, startY + 1);
                    Check(startX + 1, startY);
                    Check(startX, startY - 1);
                    Check(startX - 1, startY);
                }
        }
        public static bool IsInBounds(int x, int y)
        {
            if (x < 0 || y >= row || y < 0 || x >= col) return false;
            return true;
        }
        public static void Mark(int x, int y)
        {
            var temp = table[y].ToCharArray();
            temp[x] = '*';
            table[y] = string.Join("", temp);
            Counter++;
        }
    }
    public class Region
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Area { get; set; }
        public Region(int x, int y, int area = 0)
        {
            X = x;
            Y = y;
            Area = area;
        }
    }
}

//Нерекурсивен начин, неработещ за криви стени с отклонение > 1
/*public static void Check()
{
    for (int ind = 0; ind < regions.Count; ind++)
    {
        int startX = regions[ind].X;
        int startY = regions[ind].Y;
        int area = 0;
        //bool first = true;
        for (; true; startY++)
        {

            // TODO: Проверка за стени с разминаване на елемените >=1
            //     *----*         **----*----*
            //     *--*-*         *-*--*-----*
            //     *-**-*         *-----*----*
            //     ******         ************
            //      A=9           A1=12   A2=13

            while (startX > 0 && startY != 0)
            {
                if (table[startY][startX - 1] == '-') startX--;
                //else if(!first && table[startY-1][startX ] == '*'&& table[startY][startX] == '-'){startX--;}
                else if (startX - 2 >= 0)
                { if ((table[startY][startX - 1] == '*' && table[startY - 1][startX - 1] == '-' && table[startY - 1][startX] == '-' && table[startY - 1][startX - 2] == '-')) startX--; else break; }
                else break;
            }
            //first = false;
            for (; true; startX++)
            {
                if (startX == col) break;
                if (table[startY][startX] == '-')
                {
                    var temp = table[startY].ToCharArray();
                    temp[startX] = '*';
                    table[startY] = string.Join("", temp);
                    area++;
                }
                else break;
            }
            if (startY + 1 == row) break;
        }
        regions[ind].Area = area;
    }
}*/
