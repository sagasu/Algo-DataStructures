﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.AOC2022
{
    [TestClass]
    public class Day8
    {
        [TestMethod]
        public void Test1()
        {
            var data = realData;
            var visible = data.GetLength(0)*2+ data.GetLength(1)*2-4;
            for (int i = 1; i < data.GetLength(0)-1; i++)
            {
                for (int j = 1; j < data.GetLength(1)-1; j++)
                {
                    var length = data[i, j];
                    if (IsVisible(length,data,i,j,-1,0) ||
                        IsVisible(length, data, i, j, +1, 0)||
                        IsVisible(length, data, i, j, 0, -1)||
                        IsVisible(length, data, i, j, 0, +1)) visible += 1;
                }
            }

            Assert.AreEqual(1787, visible);
        }

        private bool IsVisible(int treeLength, int[,] data, int i, int j, int iModifier, int jModifier)
        {
            if (iModifier > 0 && iModifier + i >= data.GetLength(0)) return true;
            if (iModifier < 0 && iModifier + i < 0) return true;
            if (jModifier > 0 && jModifier + j >= data.GetLength(1)) return true;
            if (jModifier < 0 && jModifier + j < 0) return true;

            if (treeLength > data[i + iModifier, j + jModifier])
                return IsVisible(treeLength, data, i, j,
                    iModifier > 0 ? iModifier + 1 : iModifier < 0 ? iModifier - 1 : 0,
                    jModifier > 0 ? jModifier + 1 : jModifier < 0 ? jModifier - 1 : 0);
            return false;
        }
        
        private int Sum(int treeLength, int[,] data, int i, int j, int iModifier, int jModifier)
        {
            if (iModifier > 0 && iModifier + i >= data.GetLength(0)) return 0;
            if (iModifier < 0 && iModifier + i < 0) return 0;
            if (jModifier > 0 && jModifier + j >= data.GetLength(1)) return 0;
            if (jModifier < 0 && jModifier + j < 0) return 0;

            if (treeLength > data[i + iModifier, j + jModifier])
                return Sum(treeLength, data, i, j,
                    iModifier > 0 ? iModifier + 1 : iModifier < 0 ? iModifier - 1 : 0,
                    jModifier > 0 ? jModifier + 1 : jModifier < 0 ? jModifier - 1 : 0) + 1;
            return 1;
        }

        private int max = 0;
        [TestMethod]
        public void Test2()
        {
            var data = realData;
            for (int i = 1; i < data.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < data.GetLength(1) - 1; j++)
                {
                    var length = data[i, j];
                    
                    max = Math.Max(max, Sum(length, data, i, j, -1, 0) *
                        Sum(length, data, i, j, +1, 0) *
                        Sum(length, data, i, j, 0, -1) *
                        Sum(length, data, i, j, 0, +1));
                }
            }

            Assert.AreEqual(440640, max);
        }

        private int[,] testData = new[,]
        {
            {3,0,3,7,3},
            {2,5,5,1,2},
            {6,5,3,3,2},
            {3,3,5,4,9},
            {3,5,3,9,0}
        };
        private int[,] realData = new[,]
        {
            {0,1,1,1,1,2,2,2,0,2,2,0,3,2,3,2,3,3,3,3,2,2,3,1,3,4,3,0,1,4,1,4,1,1,3,1,1,4,0,1,1,2,4,2,1,2,1,1,4,1,3,3,5,5,2,3,4,3,3,4,0,2,4,4,1,4,2,4,2,1,3,3,3,0,3,3,1,2,2,1,0,3,1,3,0,2,3,0,0,0,0,2,1,2,2,0,1,0,2},
{2,2,1,0,0,2,1,0,3,1,1,2,2,3,3,2,0,1,2,3,4,2,0,2,0,0,3,4,2,1,1,3,4,0,4,3,0,2,4,1,5,3,5,1,5,4,4,3,3,3,2,4,1,5,4,5,1,1,4,2,1,5,1,1,4,1,3,2,3,1,1,4,3,2,1,3,0,1,4,3,4,3,3,3,0,3,3,2,1,0,0,2,2,2,2,1,0,2,2},
{2,0,1,2,0,0,0,0,3,3,1,1,1,3,3,3,3,1,4,4,1,2,1,4,4,0,3,1,3,1,0,4,1,3,1,2,5,5,1,4,2,3,5,2,2,3,3,2,4,2,2,5,3,1,5,2,4,2,3,2,5,3,3,5,1,3,0,3,3,2,3,3,4,3,4,4,2,0,2,0,3,4,2,1,0,2,3,1,1,0,3,2,3,2,2,1,0,2,2},
{1,2,1,1,2,1,2,1,3,1,3,1,0,1,0,1,3,1,2,0,1,0,0,2,4,1,3,2,3,2,2,2,4,4,4,4,3,3,4,1,3,3,2,1,3,3,2,2,2,5,1,4,4,3,1,5,3,1,4,5,2,2,2,3,2,1,5,5,2,0,4,4,2,3,2,1,1,3,0,1,1,2,1,4,2,1,2,1,1,0,1,0,2,1,0,2,2,1,1},
{2,1,2,1,1,3,3,0,3,3,3,1,0,2,1,3,1,4,3,2,1,1,1,1,1,4,0,1,1,1,5,2,2,4,5,4,5,5,5,1,3,5,5,4,4,3,1,4,2,3,5,4,5,2,2,3,4,2,2,4,5,4,5,1,4,2,5,4,1,3,3,0,2,2,3,3,2,2,2,2,2,2,3,4,2,1,1,0,3,1,3,0,0,1,2,0,2,2,0},
{0,1,0,2,1,2,0,3,1,2,2,3,2,0,1,2,4,4,1,1,2,2,0,0,4,0,1,3,3,5,2,5,3,2,2,1,2,2,5,2,5,5,2,5,5,3,2,2,5,5,3,1,3,3,2,1,1,3,2,3,5,1,3,1,1,3,4,2,2,1,4,3,5,2,2,3,2,3,4,2,0,0,1,1,2,2,3,3,2,1,1,3,3,1,1,3,1,0,1},
{0,1,1,0,2,0,3,1,2,3,0,1,0,1,3,0,4,0,3,4,4,1,1,4,3,3,3,3,3,4,4,4,2,1,4,4,5,1,4,4,5,5,5,1,2,5,5,2,2,2,1,4,1,5,1,2,3,2,5,5,1,2,4,5,2,4,5,3,1,1,5,1,5,5,4,1,0,4,2,2,4,2,0,0,4,4,3,1,1,2,2,1,1,2,1,0,0,3,1},
{2,1,2,1,0,3,3,0,1,3,2,0,2,3,1,3,3,2,4,4,1,1,4,4,2,1,4,3,5,5,4,2,2,4,5,1,1,4,5,1,4,3,5,2,1,3,4,5,2,5,5,3,2,6,5,4,4,4,5,1,4,3,1,5,4,4,2,1,4,4,3,2,1,2,1,5,5,0,1,1,2,0,3,0,1,0,1,1,2,2,3,0,2,3,0,3,0,2,1},
{2,2,0,2,3,2,1,2,2,1,1,0,1,3,1,1,4,3,4,1,1,3,3,5,3,4,4,5,5,1,3,2,2,3,1,4,1,5,3,4,2,2,3,5,3,5,5,5,2,4,5,3,5,3,5,2,2,3,4,6,6,1,5,1,4,2,1,4,2,5,3,3,5,1,2,4,2,3,2,1,2,3,4,0,1,3,3,0,0,2,2,2,3,1,0,2,3,2,0},
{1,2,3,2,0,3,2,2,2,2,2,3,4,3,0,3,3,0,0,3,0,3,1,4,5,1,5,2,5,2,5,1,5,2,5,5,2,5,4,3,6,2,2,5,2,2,6,5,4,3,6,6,4,5,5,2,4,6,4,3,5,3,4,6,3,3,2,4,5,2,3,2,4,3,4,1,5,5,4,1,3,0,3,0,1,4,2,1,3,3,0,0,1,2,0,0,3,2,0},
{2,3,2,2,1,1,2,1,3,3,2,2,1,2,3,3,2,2,1,0,3,4,4,2,1,2,5,5,1,1,1,3,1,1,5,5,6,6,3,3,2,5,6,3,5,5,5,3,5,2,2,4,3,4,5,4,5,4,4,5,5,5,2,2,6,6,4,4,2,1,5,1,5,1,4,3,2,2,4,4,4,4,2,4,1,0,0,4,2,0,0,2,0,0,0,0,0,1,1},
{3,2,1,2,3,2,3,2,2,3,1,3,2,4,3,0,0,0,4,5,3,3,4,1,4,1,4,5,2,3,4,4,5,4,2,6,2,2,6,6,4,4,6,4,4,2,6,5,4,5,2,2,6,2,6,6,4,3,4,4,6,3,4,4,6,5,2,4,6,1,2,2,1,2,2,5,4,3,1,3,2,5,1,4,1,2,0,0,2,0,4,1,1,3,3,2,0,3,3},
{2,0,2,3,3,1,3,3,4,1,2,1,4,2,0,2,3,5,3,2,3,2,2,5,3,5,4,2,4,2,4,2,5,2,4,5,6,5,2,3,2,4,2,6,6,4,4,2,3,4,4,5,2,6,2,3,2,6,5,4,5,3,5,2,4,5,2,5,2,6,5,1,5,5,5,2,1,5,1,3,5,1,2,5,0,4,1,4,0,1,0,1,4,4,1,3,0,0,3},
{0,3,0,1,1,2,1,0,0,3,3,4,3,1,4,0,5,1,2,2,2,3,2,5,3,2,5,1,2,4,6,3,6,3,2,5,4,4,4,6,3,4,6,6,4,3,4,6,6,2,4,4,6,2,2,5,5,2,5,3,3,6,6,2,5,5,4,6,6,4,5,2,5,1,3,4,3,1,3,2,5,2,5,1,1,1,3,4,1,3,1,4,4,4,4,2,3,3,0},
{0,2,0,2,0,0,4,3,3,0,4,3,3,2,0,1,5,2,2,3,2,1,5,4,1,3,6,2,3,2,5,6,4,4,4,3,5,4,5,3,6,5,4,6,5,2,5,5,6,4,6,6,5,3,2,6,3,5,2,2,3,6,3,5,5,4,3,5,4,5,6,4,4,2,2,4,2,1,3,2,4,2,4,1,2,1,1,0,2,1,0,0,0,1,4,0,1,2,1},
{0,3,2,0,1,1,1,3,2,0,2,3,1,0,4,2,5,5,1,5,1,1,4,5,2,4,6,4,2,4,3,5,3,2,6,4,5,2,3,5,2,6,3,4,4,4,3,6,5,5,4,3,3,4,4,7,5,6,4,6,4,4,4,5,4,2,4,3,5,5,6,2,5,5,6,3,2,5,3,3,5,4,4,3,5,1,3,0,2,0,1,4,0,4,2,1,1,2,0},
{2,1,0,2,0,4,3,0,3,0,4,3,2,4,1,2,2,1,4,1,5,4,5,3,6,5,3,4,5,3,3,6,6,2,5,4,5,6,5,3,7,3,4,5,7,3,6,4,6,7,5,5,4,5,6,5,4,6,6,6,3,7,7,4,2,3,4,5,4,5,4,2,2,6,5,2,6,3,3,4,2,3,3,5,2,5,5,2,3,0,4,3,3,1,4,2,3,1,0},
{2,1,0,3,1,2,3,2,3,2,2,0,3,4,3,1,4,3,3,5,3,5,5,6,2,4,3,4,3,6,3,2,5,4,3,2,5,5,6,7,3,6,7,6,4,6,6,6,3,3,4,6,3,3,4,5,7,5,3,3,7,4,5,3,3,2,6,4,4,3,4,5,6,2,3,5,3,6,2,2,1,5,4,4,2,2,5,4,3,2,0,3,3,0,2,0,4,1,0},
{2,3,3,4,1,0,2,1,4,3,1,5,4,2,3,3,4,4,4,2,3,4,4,2,6,5,6,2,2,6,4,5,4,4,4,5,3,5,7,7,6,7,6,4,6,3,4,3,3,7,3,5,6,5,3,6,3,6,4,5,7,5,5,7,3,4,7,3,2,3,5,4,3,5,3,6,4,5,2,2,3,2,4,2,4,4,2,4,4,2,1,1,2,3,2,2,4,4,3},
{3,2,2,4,0,3,3,0,1,0,0,1,2,5,1,2,5,5,1,5,4,2,4,2,3,2,6,4,4,3,4,4,5,4,6,6,7,3,6,5,7,6,4,6,6,4,5,5,5,4,5,6,5,6,6,4,3,4,3,5,6,7,7,3,6,5,6,7,4,2,4,3,2,3,5,2,2,2,2,4,5,3,4,3,1,4,3,4,5,5,3,2,0,1,1,4,3,3,0},
{2,3,2,3,4,3,2,0,1,2,3,4,1,3,4,1,3,1,1,3,4,3,3,2,3,3,5,4,4,4,5,5,7,4,7,4,3,6,3,4,7,4,4,4,6,3,4,4,7,7,6,3,6,6,7,5,6,5,6,5,5,7,4,5,3,5,7,4,4,7,3,5,3,2,4,3,2,3,2,4,6,5,3,2,5,5,2,5,5,5,4,3,2,0,4,0,0,4,1},
{2,2,1,2,3,2,2,2,4,4,1,5,5,3,3,1,2,2,5,4,3,4,6,5,3,6,4,4,4,5,4,3,5,3,6,4,5,6,4,5,7,6,5,3,4,7,4,3,7,6,3,4,7,4,5,6,6,3,5,5,7,6,7,7,7,5,7,7,4,5,7,7,5,5,3,5,4,4,6,5,3,4,6,4,1,4,2,5,1,3,1,4,4,4,4,3,3,1,3},
{1,2,2,1,1,2,4,4,2,2,4,4,5,4,2,2,1,4,2,6,2,4,4,5,6,6,5,4,7,5,4,7,7,5,4,5,7,3,4,5,6,5,4,5,7,4,7,8,8,5,7,6,6,7,5,4,7,4,7,3,5,6,7,4,7,7,3,3,6,5,5,7,7,2,6,4,4,2,4,4,4,6,4,4,4,4,1,2,4,3,4,4,4,4,0,2,3,3,0},
{1,4,3,0,1,2,1,4,5,5,1,5,2,1,2,4,2,4,2,3,5,5,2,4,5,3,5,5,5,5,7,3,3,3,3,4,4,5,7,6,8,6,4,4,7,4,4,4,8,4,7,5,6,4,5,5,4,8,6,6,7,3,5,4,3,3,3,7,4,6,4,3,7,6,3,3,4,3,2,4,5,5,4,2,3,5,4,3,4,1,5,2,2,3,1,0,3,0,1},
{3,4,3,0,3,4,0,2,1,3,2,5,4,3,5,5,3,5,4,5,5,4,4,2,3,5,5,4,7,4,6,7,7,5,3,5,7,7,7,7,8,4,6,8,8,8,6,4,6,4,7,6,4,8,6,8,4,4,4,4,4,5,8,7,4,7,4,4,3,6,6,7,6,4,3,4,2,3,6,4,3,4,5,2,5,4,4,4,3,5,1,1,4,4,4,3,1,2,4},
{0,0,0,4,0,3,4,5,1,4,1,1,2,4,1,4,6,3,2,2,6,4,4,3,4,7,6,7,3,3,3,6,5,5,4,6,8,7,7,6,4,4,7,5,4,7,4,7,5,6,6,6,6,7,4,8,6,5,7,4,5,4,4,5,4,3,7,7,6,4,7,5,3,6,3,6,2,4,5,4,5,3,3,2,3,3,4,5,1,1,3,1,1,2,1,4,3,0,3},
{0,1,3,0,0,2,2,4,2,5,2,5,5,5,6,3,5,2,6,2,6,4,3,3,6,3,6,4,5,5,3,7,7,3,8,4,7,6,6,8,5,5,8,7,6,7,5,6,6,8,5,8,8,5,8,5,4,8,4,8,8,7,5,5,6,8,4,7,4,3,7,3,4,3,7,6,7,5,5,3,2,4,3,3,6,3,5,2,1,2,3,2,1,1,1,1,3,2,2},
{1,0,1,0,1,0,1,4,2,2,5,2,1,2,3,3,4,6,2,3,5,4,3,7,4,6,7,4,7,6,5,4,6,6,8,5,8,4,6,8,8,5,8,6,6,8,6,5,5,6,7,4,8,7,8,5,6,7,5,5,6,8,4,7,4,4,5,4,4,6,7,5,5,7,5,6,3,3,2,2,3,2,6,4,2,2,5,5,4,5,2,2,3,5,4,2,2,2,2},
{3,4,2,0,0,2,3,1,3,4,3,4,1,3,6,6,3,5,6,5,6,2,4,4,3,5,6,6,4,6,4,6,8,5,7,6,6,6,4,5,6,5,5,8,6,7,5,6,4,4,7,5,5,5,6,6,4,5,8,5,4,7,8,6,6,5,5,5,6,4,6,3,3,5,4,5,5,5,5,4,6,6,4,3,5,5,6,6,2,2,5,2,5,5,2,5,0,0,2},
{3,0,4,2,1,1,4,2,2,3,3,5,3,4,2,3,5,5,3,2,3,7,5,5,6,3,4,4,5,4,7,5,7,4,8,4,6,8,5,5,6,8,7,8,5,6,6,8,9,9,5,6,8,6,8,5,6,5,7,7,7,5,4,5,7,7,8,4,4,7,7,7,6,3,4,7,5,6,4,7,2,3,6,2,3,6,6,6,3,3,3,2,4,3,1,4,4,1,2},
{2,3,1,1,3,3,2,4,4,5,5,3,2,5,6,6,2,3,6,4,7,3,3,6,6,4,6,6,6,6,8,6,4,7,5,6,7,8,7,4,4,5,8,7,7,6,7,5,5,8,5,5,9,7,6,8,6,5,9,4,8,8,6,6,6,7,6,4,7,4,6,4,3,5,4,5,3,3,6,5,7,5,5,4,5,5,4,3,5,3,3,3,2,1,1,2,5,2,4},
{1,2,0,3,4,4,3,2,1,2,1,5,6,5,2,6,2,2,2,2,7,4,4,5,6,6,4,6,5,8,8,5,6,6,5,8,7,8,7,5,8,5,8,8,9,8,8,9,6,5,9,5,6,7,9,6,9,6,5,6,7,8,5,8,5,5,8,7,4,7,7,7,7,5,5,4,7,3,7,6,4,5,5,6,2,6,4,2,4,4,4,4,3,1,5,2,2,4,2},
{4,4,0,4,2,3,2,1,4,3,1,3,6,3,2,5,2,6,3,7,6,4,3,4,5,6,3,6,5,8,6,5,7,4,8,5,7,4,9,7,9,8,8,5,7,5,8,8,5,5,6,5,7,6,7,7,6,7,7,6,8,5,8,5,8,7,6,4,8,4,7,8,4,6,6,4,6,4,6,6,3,5,6,4,6,6,3,3,3,6,3,2,5,4,2,5,3,3,1},
{0,1,1,2,5,4,3,3,1,3,1,6,2,5,3,6,5,3,6,7,4,5,7,4,3,4,6,4,5,6,8,7,4,6,4,7,6,6,7,8,8,8,8,6,6,5,5,9,7,7,9,6,5,8,6,8,6,7,6,5,6,5,6,7,6,8,7,6,5,5,7,8,8,6,5,5,5,4,6,7,4,3,5,2,3,3,3,2,2,5,5,4,4,2,2,1,3,2,3},
{0,2,3,4,1,3,1,4,4,5,2,4,3,6,4,6,4,5,6,3,5,6,7,5,7,3,6,6,7,7,5,8,6,6,6,6,9,5,6,8,8,5,6,8,9,7,9,8,8,8,6,5,9,8,5,9,5,7,9,9,5,7,5,6,5,6,8,7,4,7,6,4,8,6,5,3,7,3,5,3,5,6,4,4,3,3,2,4,6,6,5,1,1,3,3,1,3,4,1},
{1,2,2,2,5,4,4,1,4,3,5,5,2,2,5,3,2,3,6,6,4,7,5,5,3,6,5,5,6,8,7,5,8,5,8,9,5,7,7,6,7,9,6,8,6,8,8,7,7,9,9,7,9,5,7,5,9,8,9,6,7,7,9,8,8,7,5,4,5,5,7,6,7,7,7,4,5,4,5,4,4,3,7,5,2,6,5,4,6,6,4,4,3,4,4,3,2,3,5},
{4,1,2,4,2,1,4,5,2,5,6,3,2,5,3,4,4,5,5,3,7,4,6,7,3,4,7,6,5,8,7,7,7,8,7,9,7,8,5,7,5,9,5,6,7,9,6,8,9,6,6,9,6,7,5,7,5,5,5,8,9,5,5,8,6,8,8,5,4,6,4,6,5,7,8,8,7,3,5,7,5,3,5,7,5,6,5,2,3,6,5,1,1,1,2,2,5,2,1},
{0,1,5,2,2,1,3,1,4,6,6,4,5,6,4,2,3,6,6,4,5,5,4,3,6,6,8,7,6,6,6,7,5,7,9,8,5,6,7,9,9,9,7,8,8,8,7,9,7,9,6,6,6,6,8,6,9,6,9,9,6,5,7,8,8,5,9,8,5,8,7,4,5,4,7,8,4,5,7,7,3,5,6,6,4,6,4,6,2,5,3,6,1,2,1,2,1,2,5},
{2,1,3,2,5,5,1,1,2,6,2,4,4,4,5,6,5,3,7,4,4,6,3,4,7,5,5,4,6,7,7,6,6,5,9,5,8,8,6,5,7,7,8,6,9,9,8,9,8,9,6,9,6,7,9,6,7,7,9,6,5,9,9,6,8,5,6,9,5,6,7,5,8,8,8,7,6,3,3,5,5,4,5,5,3,6,3,3,5,2,5,6,1,5,3,1,4,5,5},
{0,5,1,1,1,5,2,5,5,5,2,4,4,4,3,2,6,4,7,6,4,4,3,5,6,6,8,4,4,8,5,7,6,9,7,6,6,6,7,7,7,6,6,6,9,9,7,8,6,6,8,9,9,8,8,6,6,6,6,9,9,8,7,9,9,7,5,8,8,8,8,7,5,6,4,4,4,4,6,7,3,7,7,6,5,2,5,6,3,6,5,5,5,2,5,2,5,2,2},
{3,1,5,3,4,4,4,3,2,5,5,5,3,4,4,6,6,4,6,3,3,5,5,5,4,8,5,5,5,4,4,6,9,9,8,8,6,7,8,8,7,8,9,9,9,8,9,7,6,8,7,9,7,7,7,9,7,7,8,6,8,8,9,7,8,7,9,7,8,5,4,5,8,5,8,7,8,4,4,3,6,3,4,6,5,6,6,5,3,6,6,6,2,5,4,3,4,3,2},
{3,4,2,3,3,4,5,3,2,4,4,2,2,5,6,6,5,5,7,6,5,4,3,6,7,8,7,5,5,6,7,8,9,9,5,7,5,6,5,6,8,6,7,8,9,7,8,8,8,9,6,8,9,9,9,8,7,6,8,9,6,7,8,7,9,7,5,7,9,8,8,7,8,6,7,7,7,8,4,4,3,4,3,5,5,5,2,4,5,4,2,2,3,2,3,4,5,1,4},
{0,4,4,2,2,2,2,2,6,3,5,3,4,2,5,7,5,4,4,7,4,3,4,6,6,8,5,4,7,4,5,7,5,6,5,7,7,5,8,6,7,8,9,6,6,6,9,7,9,9,8,8,6,9,8,8,8,6,7,9,7,7,6,8,6,8,5,6,8,5,6,7,6,7,8,5,8,4,4,6,4,3,4,3,6,4,3,4,4,6,5,4,3,1,4,2,3,1,5},
{1,4,4,5,1,2,2,4,6,6,5,4,5,3,2,4,6,4,3,4,3,3,4,7,6,4,5,7,6,6,5,6,5,7,8,9,8,9,8,6,9,8,7,8,9,7,8,8,9,9,7,9,6,8,6,7,9,6,8,7,9,8,9,7,5,8,8,6,9,9,7,4,5,7,4,4,6,6,6,3,6,6,6,7,6,6,5,3,2,3,2,5,3,2,1,3,3,2,1},
{1,5,4,4,1,5,2,5,5,6,2,4,5,6,6,6,3,6,6,5,4,3,8,8,8,5,8,6,6,8,7,5,8,6,6,5,6,8,9,9,7,8,9,9,6,8,9,7,9,7,9,7,9,8,7,8,8,8,7,8,6,9,9,7,6,7,9,7,6,5,9,8,4,5,5,4,4,6,4,7,4,7,6,5,4,3,5,3,2,4,4,5,6,1,1,3,3,4,2},
{2,2,2,3,3,3,5,1,3,5,5,5,2,4,5,3,4,6,4,6,7,3,7,4,6,6,6,6,5,5,8,8,5,6,5,7,5,7,7,9,9,8,6,6,7,7,9,8,7,9,7,8,8,8,9,7,8,9,9,8,8,6,8,8,6,6,9,5,7,7,9,7,6,6,5,8,5,8,7,6,5,3,7,7,4,6,5,2,3,4,2,5,6,1,3,3,2,3,1},
{3,4,5,5,5,1,4,4,4,5,3,6,6,4,5,6,3,4,5,7,6,7,8,8,8,8,7,6,7,8,7,6,8,5,5,6,6,8,7,7,6,6,6,6,7,8,9,8,9,8,9,7,7,7,9,7,9,9,9,9,9,7,6,7,7,7,8,6,6,9,5,6,6,6,5,8,5,5,4,7,6,5,7,4,5,5,4,5,6,5,6,4,5,4,2,4,3,1,5},
{2,1,4,4,2,5,3,5,4,3,3,2,3,3,5,6,3,4,3,3,6,4,4,4,5,5,6,7,4,5,8,7,6,6,5,9,8,6,7,6,8,8,8,6,8,7,8,7,7,9,8,7,9,8,8,7,9,8,9,8,7,6,8,9,9,6,7,8,5,6,5,5,5,7,5,6,8,6,8,4,6,5,6,7,5,4,2,4,4,2,5,5,4,3,5,3,2,3,4},
{4,1,1,1,5,1,5,2,6,3,6,5,5,2,6,4,3,5,7,6,3,6,5,4,7,6,6,7,4,5,6,9,5,7,6,9,9,8,9,9,9,7,7,8,7,8,7,7,8,9,9,9,9,9,7,7,7,6,7,7,7,9,6,9,7,5,7,6,8,6,6,5,5,7,8,8,5,5,4,3,3,3,5,3,5,3,7,4,2,5,3,6,4,3,2,4,4,3,5},
{5,2,2,5,3,5,5,2,2,3,3,4,2,6,6,7,5,3,7,6,7,6,4,5,6,5,5,5,7,8,7,8,7,7,5,9,9,9,9,7,9,7,9,7,7,7,9,9,9,7,8,8,9,7,8,7,7,9,6,7,8,6,9,6,9,9,7,8,7,6,8,6,6,7,8,5,5,5,7,3,3,4,4,6,7,6,3,6,3,3,3,4,5,2,3,5,2,4,2},
{4,3,4,5,5,4,5,5,6,2,3,4,4,6,4,7,5,6,7,5,6,6,4,6,5,6,6,5,7,7,6,8,5,8,5,6,6,9,8,8,6,7,8,8,8,7,9,8,7,7,9,9,8,9,8,9,7,8,8,8,7,6,8,8,8,6,7,5,6,6,6,6,8,4,8,4,5,5,5,6,5,4,7,4,7,7,3,2,5,5,4,3,6,4,3,1,3,5,3},
{4,4,2,4,4,5,3,4,3,5,2,6,3,3,5,5,7,7,4,6,5,5,5,4,6,7,5,6,6,5,5,5,9,8,8,6,8,9,7,8,8,7,7,7,8,7,7,7,9,8,7,8,8,8,7,7,8,9,6,8,8,7,7,9,8,5,9,9,7,6,6,7,6,6,8,7,7,8,5,7,3,6,7,7,7,6,7,5,6,6,5,4,3,4,3,1,4,3,4},
{2,1,1,4,5,1,5,5,2,6,2,6,3,3,3,6,3,4,3,6,3,4,6,5,7,6,8,5,6,7,8,5,8,6,8,5,9,7,8,8,9,9,7,6,7,7,7,8,8,8,8,7,9,7,7,8,7,7,6,9,8,8,9,9,9,7,8,8,6,6,9,6,6,4,8,4,8,8,4,5,3,3,7,4,4,5,7,3,3,5,4,2,6,3,2,4,3,3,1},
{3,5,2,3,2,1,2,4,5,6,6,5,4,3,5,4,7,3,4,5,7,5,4,6,8,6,7,4,5,7,5,7,9,5,6,6,6,8,8,9,8,7,9,8,8,8,9,8,9,9,9,7,8,8,9,7,7,9,6,8,6,7,6,8,7,5,9,5,8,8,7,5,7,5,6,7,8,6,8,5,6,5,5,7,3,3,4,6,2,3,6,6,5,6,1,3,5,5,4},
{1,3,4,2,5,1,5,3,4,2,5,4,3,4,6,3,6,4,3,7,3,7,4,6,8,6,8,4,4,7,9,5,7,6,6,7,5,7,8,6,8,8,8,9,7,8,8,7,8,8,8,9,7,7,7,9,9,9,9,8,9,7,7,7,6,7,8,6,8,7,5,8,7,5,4,6,7,4,6,4,3,6,3,6,7,3,4,3,5,4,4,5,5,3,3,4,5,3,3},
{2,4,5,2,4,5,4,2,3,4,4,5,5,4,4,5,5,7,3,7,3,6,6,7,4,4,5,6,7,5,7,5,5,5,8,7,8,9,7,7,6,6,6,7,7,9,8,7,7,9,9,8,7,9,9,7,7,6,8,8,6,9,6,6,6,5,9,8,9,9,8,6,8,4,6,4,4,8,8,7,3,4,7,7,3,6,4,2,6,2,6,2,5,2,3,4,4,5,4},
{1,4,5,2,2,4,3,2,4,3,4,4,2,4,6,7,7,6,3,4,3,7,5,5,7,5,4,7,8,5,9,9,5,7,6,8,7,8,9,7,8,6,8,8,8,6,9,9,7,8,7,7,8,8,7,6,6,8,8,6,7,6,7,6,7,7,9,6,5,6,9,7,4,6,7,4,7,7,5,5,3,6,5,6,7,6,6,5,4,4,2,4,6,5,1,3,2,5,4},
{3,2,4,1,4,5,2,1,3,3,2,5,5,6,3,5,4,3,6,4,4,6,5,7,7,8,5,4,5,4,8,6,5,6,7,7,7,7,7,8,7,6,7,8,8,8,6,9,7,7,8,8,6,8,7,9,7,6,6,8,7,8,7,6,7,6,6,9,5,5,5,5,6,6,8,4,7,6,3,4,3,5,7,4,6,7,5,4,6,3,4,3,5,3,5,4,2,5,1},
{4,1,3,4,4,5,2,1,5,4,6,3,6,5,3,5,5,7,6,6,3,6,4,6,7,8,5,8,5,7,9,8,9,6,8,5,9,5,6,6,8,6,9,6,6,6,7,8,6,7,8,6,9,8,8,8,9,7,7,8,8,9,7,7,6,6,8,9,5,8,9,8,5,4,4,6,6,4,3,5,6,6,7,3,7,3,4,2,4,2,2,3,4,2,5,4,1,2,4},
{0,3,4,3,5,1,5,3,5,5,5,3,3,4,2,5,4,4,6,5,5,6,7,4,7,5,6,8,6,5,6,9,8,8,7,5,8,9,7,8,8,8,7,8,7,8,9,7,6,8,8,7,6,8,7,8,9,6,9,8,7,9,9,6,5,6,9,5,8,6,6,6,5,6,7,8,5,6,6,5,3,3,5,3,4,4,4,6,4,4,5,4,4,5,4,4,4,2,1},
{1,3,3,4,3,1,5,5,5,2,2,6,3,5,3,3,3,6,6,6,4,7,3,4,6,5,8,7,8,4,7,8,8,7,5,9,7,6,9,7,9,9,6,9,6,8,8,9,7,9,9,6,8,6,6,7,8,8,8,6,8,5,6,9,6,6,5,6,8,6,7,5,6,4,7,8,7,6,7,5,5,6,6,3,3,3,6,3,6,4,6,6,5,3,1,4,3,2,2},
{3,5,2,5,3,3,3,3,4,6,3,5,4,5,4,5,4,6,7,4,3,5,4,5,6,7,5,4,7,5,5,6,5,9,7,8,7,5,5,6,7,7,9,9,8,6,7,6,8,8,9,8,7,6,8,7,9,8,6,8,5,6,6,8,6,8,8,7,5,5,7,4,4,5,7,7,4,7,6,4,4,3,3,3,6,2,5,4,6,6,2,2,4,4,4,5,2,2,5},
{3,5,5,3,5,1,2,2,2,5,5,4,2,5,3,3,3,7,3,5,7,5,4,3,4,5,4,7,5,6,6,7,5,8,7,6,9,8,9,6,6,7,6,8,6,8,6,7,7,7,7,7,7,7,8,8,8,9,7,9,5,7,5,6,7,8,9,6,7,4,5,7,8,8,6,6,8,6,7,6,6,6,4,3,3,2,2,4,2,6,6,2,5,2,5,5,1,2,5},
{3,0,1,4,2,4,4,3,1,2,5,6,3,5,5,6,5,4,5,7,3,4,5,4,7,4,8,7,7,6,5,5,6,9,8,5,9,8,9,9,8,6,5,6,9,8,8,8,6,8,8,8,9,8,7,8,8,8,5,6,5,9,7,6,9,6,5,7,5,4,8,8,8,6,4,8,5,6,7,5,4,5,6,7,3,5,5,3,5,2,2,4,1,1,1,5,3,2,1},
{3,3,4,3,2,1,3,5,1,3,4,3,5,3,4,4,6,7,4,3,6,5,5,3,5,8,4,5,8,5,4,4,5,7,5,8,8,7,5,6,6,9,9,7,7,6,7,8,7,9,7,6,6,6,5,7,8,6,7,7,5,7,5,5,7,8,6,5,5,8,7,7,4,7,5,4,7,7,5,3,6,4,4,3,4,2,4,5,4,4,5,2,1,4,5,4,2,2,4},
{0,1,3,5,4,4,2,3,5,4,6,4,3,3,5,3,3,6,4,7,6,6,3,3,4,7,7,7,7,4,4,7,7,4,7,6,6,8,6,8,6,6,5,5,9,8,5,5,6,8,7,8,7,6,6,6,5,9,6,9,6,7,9,6,6,5,7,6,4,8,5,4,6,6,7,4,6,7,3,7,3,4,5,5,3,3,5,3,6,6,3,1,5,2,4,3,2,3,3},
{1,1,2,1,5,1,4,5,1,5,3,5,6,5,3,4,6,4,3,3,4,7,4,5,3,6,6,7,7,4,7,5,4,8,4,7,7,7,8,7,5,8,8,5,9,6,9,8,6,7,9,7,5,5,7,6,8,6,9,7,8,5,8,9,9,7,8,7,8,4,8,6,7,5,8,7,5,7,5,4,6,3,4,3,3,2,2,2,2,5,2,5,5,5,1,2,5,1,4},
{4,4,3,5,4,5,4,1,1,3,3,5,3,5,4,4,4,5,5,4,4,6,7,3,3,3,5,7,6,5,6,8,4,5,7,4,7,8,9,5,8,9,6,7,7,9,7,8,9,8,9,7,5,7,7,8,7,6,6,7,7,7,8,6,8,8,4,7,6,7,8,7,4,7,7,6,6,4,3,6,4,4,4,5,3,3,6,6,6,2,1,1,5,5,3,1,2,2,1},
{4,4,3,2,4,4,5,4,4,1,4,5,4,4,5,2,6,6,2,4,7,7,3,4,6,6,4,5,4,6,7,6,8,4,6,4,6,5,8,6,6,9,7,9,6,7,7,5,8,5,9,6,6,8,8,9,7,5,6,5,6,5,8,6,5,8,4,6,8,8,5,7,6,5,3,3,7,7,6,5,5,4,3,6,4,3,3,3,6,6,4,1,4,1,3,5,3,1,3},
{0,1,0,2,5,2,5,3,4,4,2,3,2,5,6,3,3,4,4,4,6,6,6,7,5,7,3,4,7,6,4,5,7,5,7,5,4,8,7,5,9,6,7,7,6,8,9,5,8,8,5,7,5,5,5,8,6,6,6,7,8,8,4,4,6,6,6,5,4,8,8,8,4,6,3,5,3,4,6,5,5,5,5,6,5,4,4,2,4,3,1,3,5,4,2,1,4,1,4},
{0,1,4,4,4,2,5,5,1,4,1,1,3,4,4,3,2,2,4,6,6,6,5,3,4,5,4,7,5,7,8,4,8,4,7,7,5,8,4,4,7,6,8,8,6,8,9,9,9,6,7,6,8,6,7,8,7,6,6,5,7,8,6,6,4,7,7,7,4,4,5,7,4,6,5,7,5,6,3,5,6,4,5,2,5,3,6,3,2,4,5,3,5,4,3,5,1,2,3},
{3,3,4,4,2,2,3,3,5,2,5,1,3,3,4,2,4,4,5,3,3,5,7,4,5,6,5,4,6,5,4,8,6,8,7,8,4,8,5,4,4,6,6,6,5,5,6,9,6,5,9,9,7,6,6,9,6,4,7,4,6,5,4,8,4,4,4,8,8,6,5,4,6,5,4,6,6,4,4,4,6,4,3,4,2,2,2,5,4,1,4,5,5,1,4,5,1,1,3},
{4,2,2,0,4,2,2,2,2,1,1,4,5,4,4,6,4,5,6,5,3,6,4,6,6,3,7,6,7,3,3,5,7,4,4,6,4,4,6,7,6,7,6,5,7,6,8,6,7,8,4,4,5,5,4,6,6,8,5,5,6,7,4,8,8,4,7,5,8,5,5,5,5,5,5,6,5,5,7,2,5,5,6,3,3,2,2,3,4,5,4,4,3,2,1,4,3,1,1},
{4,0,2,1,0,1,3,5,1,3,3,3,3,4,2,2,6,5,5,4,5,5,5,3,6,4,3,3,7,4,4,4,7,4,8,7,5,7,8,8,7,6,4,8,7,7,5,6,6,8,6,7,5,5,5,6,7,7,7,8,8,5,5,4,5,7,5,6,4,6,6,3,6,4,4,7,4,4,5,5,6,3,2,5,3,3,5,1,1,3,2,5,2,2,1,4,4,1,3},
{0,2,0,4,0,1,4,3,2,4,5,2,5,2,5,4,6,5,4,6,2,3,4,2,6,7,5,6,3,4,5,7,6,7,6,8,7,6,5,5,5,8,4,7,5,7,6,8,5,4,6,7,4,7,4,5,8,4,4,4,6,5,7,4,6,5,7,3,6,7,7,7,4,3,5,7,5,6,5,2,4,5,3,5,4,2,3,1,5,1,5,3,4,5,4,0,4,3,3},
{2,4,3,4,0,0,2,4,1,4,2,1,4,2,2,3,6,5,2,3,6,3,2,4,3,4,3,4,3,3,5,3,7,6,5,5,6,4,6,7,6,5,6,5,6,6,8,6,8,6,8,4,5,7,7,4,4,8,8,8,8,7,6,8,8,7,6,4,5,4,6,6,6,4,4,3,5,3,5,5,2,5,2,2,5,6,1,4,4,3,4,5,2,1,1,0,1,3,1},
{0,0,3,1,0,3,1,3,5,1,2,1,3,5,1,2,5,6,2,2,2,6,2,4,2,3,7,4,4,4,3,6,4,3,3,6,5,7,7,7,4,4,6,5,6,8,8,5,5,5,5,6,6,8,4,7,6,4,8,4,4,5,8,5,3,4,5,6,4,5,5,7,5,4,6,5,2,3,4,5,4,4,3,5,6,5,1,4,3,1,3,5,2,1,3,4,3,4,1},
{4,4,2,2,0,1,1,4,4,1,3,2,3,5,2,1,5,2,4,4,2,4,2,3,5,5,4,6,3,4,3,4,7,5,4,5,5,3,7,7,5,6,8,8,8,4,5,7,7,7,4,5,6,4,7,8,8,4,4,6,8,6,5,5,5,7,3,3,3,6,3,3,7,5,3,2,4,6,3,6,2,5,2,2,5,3,3,1,2,1,3,2,2,1,2,4,2,2,1},
{0,4,2,3,0,4,4,0,5,5,2,2,5,4,1,2,3,4,5,2,6,2,6,5,6,2,4,6,7,5,4,6,3,5,3,7,3,4,3,6,3,7,5,7,7,7,5,4,4,8,4,5,7,5,6,6,4,3,4,3,3,5,7,6,3,6,7,6,6,4,6,7,7,6,5,4,5,4,6,2,5,4,2,1,4,5,5,1,2,5,2,5,2,4,2,1,1,3,0},
{3,1,4,1,1,0,0,3,1,5,5,1,5,4,5,4,5,4,2,5,5,5,2,3,6,4,5,5,3,5,7,5,6,3,7,7,6,7,3,4,3,4,6,7,7,5,6,4,5,7,4,6,5,7,7,6,4,6,7,3,6,7,6,7,6,6,5,3,5,5,5,6,6,2,4,2,4,2,3,3,4,5,4,5,5,4,2,3,2,3,2,3,4,0,4,4,3,4,3},
{0,4,1,0,1,2,3,3,2,3,3,3,3,2,5,3,4,5,1,6,5,4,3,2,6,3,4,3,6,4,5,7,6,4,7,5,7,5,5,7,4,4,5,5,5,3,3,4,5,6,4,6,5,4,6,4,4,3,3,3,7,4,4,3,5,3,5,6,3,6,4,4,4,6,4,4,2,3,5,2,3,3,1,2,3,1,2,4,1,1,4,0,3,4,4,4,1,2,1},
{1,2,4,3,0,2,1,2,1,1,3,1,2,5,3,1,3,4,5,4,3,6,4,6,5,2,2,6,3,3,3,3,3,3,3,3,5,7,6,3,7,3,7,7,5,4,6,5,5,5,5,6,7,6,7,7,3,7,4,7,3,5,3,6,7,4,4,5,3,6,3,3,5,4,5,3,3,2,6,5,3,3,5,5,4,1,1,2,1,3,1,1,4,3,0,0,4,0,3},
{3,0,2,4,1,1,4,2,2,2,1,2,3,5,2,1,3,5,2,1,4,2,2,5,6,4,5,6,5,2,5,3,6,6,6,7,3,5,7,5,3,3,3,5,7,6,6,7,6,3,5,6,5,4,3,7,7,7,6,6,4,3,6,7,5,7,3,5,2,4,2,5,4,3,5,3,6,2,5,3,4,1,5,3,5,2,2,5,3,2,3,4,0,2,4,3,1,2,0},
{2,0,3,2,0,2,2,2,3,2,4,1,3,3,4,3,1,2,1,2,2,4,1,4,4,4,3,4,2,5,2,5,4,5,3,4,4,3,5,3,4,7,4,3,4,5,7,6,5,6,7,6,7,3,5,6,7,6,3,5,5,3,7,4,6,4,3,2,2,5,3,4,3,6,2,4,3,5,1,4,5,1,1,4,2,1,5,3,2,2,4,2,2,0,0,4,2,0,1},
{1,1,0,3,4,2,1,4,0,4,4,1,0,3,4,1,1,2,5,3,1,1,4,3,6,6,6,2,5,4,3,4,2,2,6,4,3,4,4,4,3,5,3,4,6,6,6,7,6,6,4,6,7,7,4,5,4,7,5,7,3,3,6,3,5,4,3,6,3,4,5,5,6,2,2,3,5,2,2,3,2,1,2,5,2,5,1,1,3,3,3,1,0,2,3,1,3,0,3},
{3,0,0,3,0,4,3,4,3,3,1,4,3,2,4,2,2,1,5,3,2,4,3,2,4,4,5,6,6,3,4,4,3,5,6,3,5,6,2,3,6,6,3,5,7,3,4,6,4,4,3,3,7,4,7,3,4,4,7,2,2,4,6,5,2,5,5,6,6,4,3,5,2,6,5,2,3,2,5,2,4,1,4,2,5,1,2,2,2,2,0,3,4,1,1,1,1,3,3},
{2,0,2,2,3,3,1,1,2,2,1,2,1,2,0,5,1,5,1,3,1,2,5,2,2,3,5,2,6,2,3,4,6,5,4,4,2,6,6,6,6,5,6,5,3,6,6,4,5,5,4,6,3,6,5,6,5,4,2,4,4,2,4,2,3,5,2,3,4,4,3,3,2,2,6,2,4,1,3,2,4,5,4,5,1,3,2,2,4,0,2,3,2,4,1,0,0,0,1},
{3,3,2,3,1,3,1,1,1,2,2,4,2,1,1,0,4,3,4,1,4,5,4,3,2,1,2,3,3,6,3,5,6,2,6,5,2,4,4,5,2,5,5,5,5,5,3,5,2,4,5,6,6,4,2,4,2,3,5,5,4,2,6,6,6,4,3,2,5,2,2,5,3,5,4,1,2,2,3,3,2,1,2,5,2,3,3,0,0,4,0,4,1,2,3,1,3,1,3},
{2,1,2,2,0,2,2,4,2,3,2,3,1,4,1,2,0,5,3,1,4,2,3,5,5,5,1,1,4,5,5,3,3,4,5,5,6,6,3,6,3,2,6,5,3,4,2,4,3,5,3,3,6,4,4,2,6,4,2,6,2,6,5,4,2,5,6,3,6,3,2,4,1,1,1,5,1,3,1,5,4,3,5,2,1,4,2,3,2,2,1,3,3,2,3,3,0,2,1},
{2,2,2,0,0,1,2,2,3,1,0,2,0,2,1,2,3,1,2,5,3,5,2,5,5,4,3,2,2,3,5,2,2,6,5,3,6,5,6,6,5,6,5,3,3,6,2,6,6,4,6,5,4,6,3,2,3,2,6,5,6,4,3,6,3,6,3,3,2,2,2,1,1,1,4,1,2,5,5,3,5,2,3,0,3,4,2,0,1,1,1,3,2,0,2,3,0,0,3},
{1,3,1,3,2,1,0,0,2,0,4,2,1,0,2,0,2,1,3,0,3,5,5,1,1,4,3,2,2,1,3,5,2,2,5,5,2,6,3,6,4,6,4,3,2,5,2,5,6,5,3,2,2,2,5,3,6,3,6,4,4,2,6,3,6,6,2,5,5,2,2,5,4,1,2,1,1,3,3,3,4,1,0,3,1,0,2,4,3,3,0,3,0,1,2,0,1,2,0},
{1,2,3,0,1,3,2,3,2,1,1,3,4,4,3,1,1,3,0,0,4,3,3,3,5,1,3,5,4,1,1,4,1,4,3,3,4,4,6,5,6,3,5,6,5,4,5,3,4,2,3,3,5,3,6,3,2,2,2,6,2,4,6,3,4,2,5,3,2,5,2,2,2,5,3,5,1,1,5,4,3,2,2,3,0,2,4,3,3,0,2,2,0,1,2,3,2,3,2},
{0,2,0,1,0,0,0,0,1,1,2,2,0,0,4,0,1,3,0,2,1,2,1,4,1,4,4,1,3,2,2,1,4,5,2,5,1,4,1,3,3,3,3,4,4,4,5,2,2,2,5,2,5,5,6,3,3,2,2,6,3,5,1,3,3,1,5,2,3,2,5,4,4,2,3,5,3,5,2,4,2,2,1,0,0,4,2,1,3,4,1,1,0,0,2,1,3,1,3},
{0,0,0,0,3,2,3,1,2,3,3,0,4,3,1,0,2,2,2,3,4,1,1,2,3,1,3,5,2,1,1,1,3,2,2,5,3,3,2,2,5,5,2,3,5,1,6,5,6,4,4,2,2,6,4,4,5,1,3,1,1,2,5,4,4,1,5,1,2,1,4,2,1,1,4,3,2,0,0,4,2,4,3,0,3,1,0,2,2,1,1,1,1,2,1,0,3,2,3},
{2,2,2,1,3,1,3,2,0,2,1,3,2,1,2,3,2,2,0,0,0,3,4,1,0,1,3,5,3,2,1,1,3,5,1,5,5,1,2,4,2,5,4,2,2,4,2,2,5,3,1,5,4,5,4,1,2,3,1,1,1,3,5,5,2,2,2,2,5,3,1,3,5,5,3,3,3,0,2,4,1,4,0,3,0,3,4,2,3,3,0,0,1,0,2,1,2,0,1},
{1,0,2,2,3,2,0,3,2,3,3,2,1,1,1,0,1,2,0,3,0,0,3,1,4,3,3,3,2,5,4,5,5,2,4,2,5,4,3,4,1,5,3,5,3,3,2,5,3,5,4,3,2,5,4,1,1,4,3,4,1,5,5,3,5,1,2,2,3,1,1,4,4,0,3,0,2,4,2,1,4,0,0,3,4,2,4,0,3,0,0,2,3,1,2,1,1,0,1},
{0,0,1,0,2,3,1,2,0,2,3,0,0,0,1,1,4,1,4,0,1,1,4,3,2,1,0,1,3,4,4,3,2,5,4,5,4,5,1,3,4,3,5,4,2,4,1,4,4,3,2,4,3,2,4,4,4,5,3,4,4,2,2,1,3,5,4,5,4,1,1,1,4,1,1,0,1,0,3,3,4,0,0,1,3,2,3,2,0,0,2,3,0,0,2,2,0,2,2},
{0,2,0,2,1,0,0,2,3,3,2,2,2,1,0,0,1,4,2,4,3,4,0,1,2,4,0,1,3,4,3,1,4,5,4,1,2,3,5,2,5,1,5,1,3,2,1,5,5,1,5,3,4,2,4,3,2,3,4,5,4,3,3,2,3,2,3,1,2,0,0,1,0,4,0,2,2,2,2,3,2,1,0,1,2,2,3,2,0,3,3,3,0,2,2,1,2,2,0},
{0,2,2,0,1,0,2,2,0,3,3,2,3,2,3,2,3,2,0,2,4,4,0,2,3,4,0,3,4,3,4,4,1,3,2,1,2,2,5,4,4,5,4,5,3,3,2,5,1,5,1,5,4,4,2,1,1,2,3,5,5,2,1,3,4,3,4,3,2,3,0,3,1,2,4,0,1,2,1,0,1,0,2,0,0,1,1,2,2,0,0,0,0,3,0,1,2,2,2},
        };
       
    }


}
