﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _435
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int maxCount = 0;
            int repaintingNumber = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                int currentCount = 0;
                for (int j = i; j < sequence.Length; j++)
                {
                    if (sequence[i] == sequence[j])
                    {
                        currentCount++;
                    }
                }
                if (currentCount > maxCount)
                {
                    repaintingNumber = sequence[i];
                    maxCount = currentCount;
                }
            }
            Console.WriteLine(maxCount + " " + repaintingNumber);
        }
    }
}
