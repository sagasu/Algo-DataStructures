﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.AOC2023;

[TestClass]
public class Day23
{
	[TestMethod]
	public void Test()
	{
		// I did it in python
		//https://github.com/sagasu/python-algorithms/tree/master/aoc2023
	}

	private string data = """
	                        #.###########################################################################################################################################
	                        #.#...###...#.......#.....#.....###.....###...#...#.....###...#.............#.......#...#...#...#.....#...#####.....#...###.....#...#####...#
	                        #.#.#.###.#.#.#####.#.###.#.###.###.###.###.#.#.#.#.###.###.#.#.###########.#.#####.#.#.#.#.#.#.#.###.#.#.#####.###.#.#.###.###.#.#.#####.#.#
	                        #.#.#.....#...#.....#.#...#...#...#...#.###.#.#.#.#...#.###.#.#.....#.......#...#...#.#.#.#.#.#.#...#.#.#...###.#...#.#...#...#...#.###...#.#
	                        #.#.###########.#####.#.#####.###.###.#.###.#.#.#.###.#.###.#.#####.#.#########.#.###.#.#.#.#.#.###.#.#.###.###.#.###.###.###.#####.###.###.#
	                        #.#.#.......#...#...#.#.#...#.#...#...#...#.#...#...#.#...#.#.#####.#.#...>.>.#.#.###.#.#.#.#.#.###.#.#...#.....#...#.#...###.....#...#...#.#
	                        #.#.#.#####.#.###.#.#.#.#.#.#.#.###.#####.#.#######.#.###.#.#.#####.#.#.###v#.#.#.###.#.#.#.#.#.###.#.###.#########.#.#.#########.###.###.#.#
	                        #.#.#.....#...###.#...#...#.#.#...#.....#.#...#.....#.#...#.#.###...#.#.#...#...#...#.#...#.#.#.#...#.>.>.#.........#.#.###...###.#...###.#.#
	                        #.#.#####.#######.#########.#.###.#####.#.###.#.#####.#.###.#.###.###.#.#.#########.#.#####.#.#.#.#####v###.#########.#.###.#.###.#.#####.#.#
	                        #...#.....###...#.........#.#.#...#.....#.#...#.#...#.#...#.#.>.>.###...#.#...#...#.#...#...#.#.#.#####...#...###...#.#...#.#.#...#.#...#.#.#
	                        #####.#######.#.#########.#.#.#.###.#####.#.###.#.#.#.###.#.###v#########.#.#.#.#.#.###.#.###.#.#.#######.###.###.#.#.###.#.#.#.###.#.#.#.#.#
	                        #...#.#.....#.#.#...#...#.#.#.#.###.....#.#.#...#.#.#...#.#...#.###.....#.#.#.#.#.#...#.#.#...#.#...#...#...#...#.#.#.#...#.#.#...#.#.#.#.#.#
	                        #.#.#.#.###.#.#.#.#.#.#.#.#.#.#.#######.#.#.#.###.#.###.#.###.#.###.###.#.#.#.#.#.###.#.#.#.###.###.#.#.###.###.#.#.#.#.###.#.###.#.#.#.#.#.#
	                        #.#...#...#.#.#.#.#.#.#...#...#...>.>.#.#.#.#...#.#...#.#.#...#...#.#...#...#...#...#...#.#.###.#...#.#.#...###.#.#.#.#.#...#...#.#...#...#.#
	                        #.#######.#.#.#.#.#.#.#############v#.#.#.#.###.#.###.#.#.#.#####.#.#.#############.#####.#.###.#.###.#.#.#####.#.#.#.#.#.#####.#.#########.#
	                        #.#...#...#...#.#.#.#.#.......#.....#.#.#...###.#.###.#.#.#.#...#...#...#.......#...###...#...#.#.#...#.#.....#...#.#.#.#.....#.#.###.....#.#
	                        #.#.#v#.#######.#.#.#.#.#####.#.#####.#.#######.#.###.#.#.#.#.#.#######.#.#####.#.#####.#####.#.#.#.###.#####.#####.#.#.#####.#.#.###.###.#.#
	                        #...#.>.#...#...#.#...#...#...#.....#.#.......#.#...#...#...#.#.#...#...#.....#.#.....#...#...#...#...#.......#...#...#.......#.#.#...###...#
	                        #####v###.#.#.###.#######.#.#######.#.#######.#.###.#########.#.#.#.#.#######.#.#####.###.#.#########.#########.#.#############.#.#.#########
	                        #...#.....#.#...#.###...#.#.#...#...#...#.....#.#...###.......#.#.#.#...#####.#.#.....#...#.....#.....#.........#.........#...#...#.........#
	                        #.#.#######.###.#.###.#.#.#.#.#.#.#####.#.#####.#.#####.#######.#.#.###.#####.#.#.#####.#######.#.#####.#################.#.#.#############.#
	                        #.#.........###...#...#...#...#...#...#.#.....#.#.....#.......#...#.....#.....#...#...#.....#...#.......#.....#...........#.#.#.............#
	                        #.#################.###############.#.#.#####.#.#####.#######.###########.#########.#.#####.#.###########.###.#.###########.#.#.#############
	                        #.................#.#...#...#.......#.#.......#...#...#.......#.....#...#...........#.....#.#...#.......#...#.#.#...###...#.#.#.............#
	                        #################.#.#.#.#.#.#.#######.###########.#.###.#######.###.#.#.#################.#.###.#.#####.###.#.#.#.#.###.#.#.#.#############.#
	                        #...#.............#...#.#.#.#.#.......#...#.....#...###.........#...#.#.........#.....#...#.....#.#...#.....#...#.#...#.#.#.#.#.........#...#
	                        #.#.#.#################.#.#.#.#.#######.#.#.###.#################.###.#########.#.###.#.#########.#.#.###########.###.#.#.#.#.#.#######.#.###
	                        #.#.#...........#...###.#.#...#.......#.#...#...#.....#...###...#...#...#.....#...###...###.....#...#...#.....###...#.#.#.#.#.#.......#.#.###
	                        #.#.###########.#.#.###.#.###########.#.#####.###.###.#.#.###.#.###.###.#.###.#############.###.#######.#.###.#####.#.#.#.#.#.#######v#.#.###
	                        #.#.###.........#.#...#...#.........#...#.....###...#...#.....#.....###.#.###.....#...#...#.#...#.....#...#...#.....#.#.#.#.#...#...>.#.#...#
	                        #.#.###.#########.###.#####.#######.#####.#########.###################.#.#######.#.#.#.#.#.#.###.###.#####.###.#####.#.#.#.###.#.###v#.###.#
	                        #.#.....#...#.....#...#...#.......#.......#...###...#...#.............#...###.....#.#.#.#.#.#.#...#...###...###.....#.#.#...###...#...#.....#
	                        #.#######.#.#.#####.###.#.#######.#########.#.###.###.#.#.###########.#######.#####.#.#.#.#.#.#.###.#####.#########.#.#.###########.#########
	                        #.........#...#...#.#...#.#...###...#...#...#...#.....#...###.........#.......#...#.#...#.#.#.#...#.#...#...###.....#.#.#.....#.....###...###
	                        ###############.#.#.#.###.#.#.#####.#.#.#.#####.#############.#########.#######.#.#.#####.#.#.###.#.#.#.###v###.#####.#.#.###.#.#######.#.###
	                        ###...#...#.....#...#...#.#.#.......#.#.#.#.....#...#...#...#.....#...#.........#.#.#.....#.#...#.#.#.#...>.>.#.....#.#.#...#.#.........#...#
	                        ###.#.#.#.#.###########.#.#.#########.#.#.#.#####.#.#.#.#.#.#####.#.#.###########.#.#.#####.###.#.#.#.#####v#.#####.#.#.###.#.#############.#
	                        #...#...#...###...#...#.#.#.#.....###.#.#.#.#...#.#.#.#.#.#...#...#.#...#.........#.#.#...#...#.#.#...###...#.#...#.#.#.###.#...............#
	                        #.#############.#.#.#.#.#.#.#.###.###.#.#.#.#.#.#.#.#.#.#.###.#.###.###.#.#########.#.#.#.###.#.#.#######.###.#.#.#.#.#.###.#################
	                        #...#...###.....#.#.#.#.#.#...#...#...#.#.#.#.#.#.#.#.#.#...#.#...#.#...#.....#...#.#.#.#.#...#.#.#.......###.#.#.#.#...#...#...#...........#
	                        ###.#.#v###.#####.#.#.#.#.#####.###.###.#.#.#.#.#.#.#.#.###.#.###v#.#.#######.#.#.#.#.#.#.#.###.#.#.#########.#.#.#.#####.###.#.#.#########.#
	                        ###...#.>.#...#...#.#.#.#.#...#...#...#.#.#.#.#.#.#.#.#...#.#...>.>.#...#...#.#.#.#.#...#.#.###...#.........#.#.#.#.....#...#.#.#.#.........#
	                        #######v#.###.#.###.#.#.#.#.#.###v###.#.#.#.#.#.#.#.#.###.#.#####v#####.#.#.#v#.#.#.#####.#.###############.#.#.#.#####.###.#.#.#.#.#########
	                        #.......#.....#.#...#...#.#.#.#.>.>...#.#.#.#.#.#.#.#...#.#.#.....#...#.#.#.>.>.#...#.....#...###...#.......#...#.#.....###...#.#.#.###.....#
	                        #.#############.#.#######.#.#.#.#v#####.#.#.#.#.#.#.###.#.#.#.#####.#.#.#.###v#######.#######.###.#.#.###########.#.###########.#.#.###.###.#
	                        #.....#...#...#.#.#.......#.#.#.#...###...#...#.#.#.#...#...#.......#.#.#...#...#...#.........#...#...#...#...###...#####...###...#.....#...#
	                        #####.#.#.#.#.#.#.#.#######.#.#.###.###########.#.#.#.###############.#.###.###.#.#.###########.#######.#.#.#.###########.#.#############.###
	                        #...#...#...#.#.#.#...#...#.#.#.###...#...#.....#.#.#...#.............#...#.###...#.#...###...#.........#...#.....#...#...#.....#.........###
	                        #.#.#########.#.#.###.#.#.#.#.#.#####.#.#.#.#####.#.###.#.###############.#.#######.#.#.###.#.###################.#.#.#.#######.#.###########
	                        #.#...........#.#.###...#...#...#...#...#.#.......#...#.#.....#...#######.#.#.......#.#.#...#.....#...#...........#.#.#...#.....#...#####...#
	                        #.#############.#.###############.#.#####.###########.#.#####.#.#.#######.#.#.#######.#.#.#######.#.#.#.###########.#.###.#.#######.#####.#.#
	                        #.#...........#...#.....#.....#...#...#...#.....#...#...#...#...#.......#...#.....###.#.#.#.......#.#.#...#...#.....#.#...#...#...#.....#.#.#
	                        #.#.#########.#####.###.#.###.#.#####.#v###.###.#.#.#####.#.###########.#########.###.#.#.#.#######.#.###v#.#.#.#####.#.#####.#.#.#####.#.#.#
	                        #...#.........#...#...#.#...#.#.....#.>.>.#.#...#.#.#.....#.#...........#...#...#.#...#.#.#.#...#...#.#.>.>.#.#...#...#.....#.#.#.#.....#.#.#
	                        #####.#########.#.###.#.###.#.#####.###v#.#.#.###.#.#.#####.#.###########.#.#.#.#v#.###.#.#.#.#.#.###.#.#v###.###.#.#######.#.#.#.#v#####.#.#
	                        #.....#.........#...#.#.###.#.#...#...#.#...#...#.#.#...#...#.......###...#.#.#.>.>.#...#.#...#.#...#.#.#...#...#.#.#...#...#.#.#.>.#...#.#.#
	                        #.#####.###########.#.#.###.#.#.#.###.#.#######.#.#.###.#.#########.###.###.#.###v###.###.#####.###.#.#.###.###.#.#.#.#.#.###.#.###v#.#.#.#.#
	                        #.....#.#...........#.#...#.#.#.#.###.#.....#...#.#.#...#...#.....#...#...#.#.###...#...#...#...#...#...#...###.#.#.#.#.#.#...#...#...#...#.#
	                        #####.#.#.###########.###.#.#.#.#.###.#####.#.###.#.#.#####.#.###.###.###.#.#.#####.###.###.#.###.#######.#####.#.#.#.#.#.#.#####.#########.#
	                        #.....#.#...#...#...#.#...#.#.#.#.....#.....#...#.#.#.....#.#.#...#...#...#.#.#.....###.#...#...#.#.......#...#...#...#.#.#.#...#.###...#...#
	                        #.#####.###.#.#.#.#.#.#.###.#.#.#######.#######.#.#.#####.#.#.#.###v###.###.#.#.#######.#.#####.#.#.#######.#.#########.#.#.#.#.#.###.#.#.###
	                        #.#...#...#.#.#...#.#.#.#...#...###...#...#.....#.#...#...#.#.#.#.>.>.#...#...#...#...#.#.....#.#.#.........#.........#.#.#.#.#.#.#...#...###
	                        #.#.#.###.#.#.#####.#.#.#.#########.#.###.#.#####.###.#.###.#.#.#.#v#.###.#######.#.#.#.#####.#.#.###################.#.#.#.#.#.#.#.#########
	                        #...#...#.#...###...#.#...#####...#.#.#...#.....#.#...#...#...#...#.#.#...###...#...#.#.......#.#.#...................#.#.#...#...#.........#
	                        #######.#.#######v###.#########.#.#.#.#.#######.#.#.#####.#########.#.#.#####.#.#####.#########.#.#.###################.#.#################.#
	                        #.......#.#.....#.>.#...###.....#...#...###.....#.#.......#.......#.#...#.....#.......#...#...#...#...................#.#.#.................#
	                        #.#######.#.###.#v#.###.###.###############.#####.#########.#####.#.#####.#############.#.#.#.#######################.#.#.#.#################
	                        #.......#.#.#...#.#...#...#...........#...#.......###...###...#...#.....#.#.......#...#.#...#.......###...............#...#.............#...#
	                        #######.#.#.#.###.###.###.###########.#.#.###########.#.#####.#.#######.#.#.#####.#.#.#.###########.###.###############################.#.#.#
	                        #...###...#.#.#...#...#...###.........#.#...#.......#.#.#.....#.......#.#.#.#.....#.#.#.#...........#...#.............#.........#.......#.#.#
	                        #.#.#######.#.#.###.###.#####.#########.###.#.#####.#.#.#.###########.#.#.#.#.#####.#.#.#.###########.###.###########.#.#######.#.#######.#.#
	                        #.#...#...#.#.#...#.....#...#.....#...#.#...#.....#...#.#.....#.....#.#.#.#.#.#...#.#...#.#.....#...#...#.#...........#.......#...#.....#.#.#
	                        #.###.#.#.#.#.###.#######.#.#####.#.#.#.#.#######.#####.#####.#.###.#.#.#.#.#.#.#.#.#####.#.###.#.#.###.#.#.#################.#####.###.#.#.#
	                        #...#...#...#...#.....###.#.......#.#.#.#.#...###.#.....#...#...###.#...#...#...#...#.....#.#...#.#...#...#.......###...#.....#.....###...#.#
	                        ###.###########.#####.###.#########.#.#.#.#.#.###.#.#####.#.#######v#################.#####.#.###.###.###########.###.#.#.#####.###########.#
	                        ###.#...#.....#.#...#.#...#.....###.#.#.#.#.#...#.#...#...#.#...#.>.>.#...#...#.......#.....#...#.#...#.....#...#...#.#.#.......#...#.......#
	                        ###.#.#.#.###.#.#.#.#.#.###.###.###.#.#.#.#.###.#.###.#.###.#.#.#.#v#.#.#.#.#.#.#######.#######.#.#.###.###.#.#.###.#.#.#########.#.#.#######
	                        ###...#.#.###.#...#...#.....#...#...#...#...#...#...#.#.#...#.#...#.#.#.#.#.#.#.........#.......#.#.###...#...#.....#.#.#...#...#.#.#.......#
	                        #######.#.###v###############.###.###########.#####.#.#.#.###.#####.#.#.#.#.#.###########.#######.#.#####.###########.#.#.#.#.#.#.#.#######.#
	                        ###...#...###.>.#...#.......#...#.#...#...###.#...#.#...#...#.###...#.#.#...#...#...#.....#...#...#.....#.........#...#.#.#.#.#.#.#...#.....#
	                        ###.#.#######v#.#.#.#.#####.###.#.#.#.#.#.###.#.#.#.#######.#.###.###.#.#######.#.#.#.#####.#.#.#######.#########.#.###.#.#.#.#.#.###.#.#####
	                        ###.#.#...#...#.#.#.#.#.....###.#...#...#...#.#.#.#.....#...#.#...###...#.......#.#.#.#...#.#.#...#.....#...#.....#.#...#.#.#.#.#.#...#...###
	                        ###.#.#.#.#.###.#.#.#.#.#######v###########.#.#.#.#####.#.###.#.#########.#######.#.#.#.#.#.#.###.#.#####.#.#v#####.#.###.#.#.#.#.#.#####v###
	                        #...#...#.#...#.#.#.#.#...#...>.>.........#.#...#.#.....#.....#.......###...#...#.#.#...#.#.#...#.#.#.....#.>.>...#.#.#...#.#.#.#.#.#...>.###
	                        #.#######.###.#.#.#.#.###.#.###v#########.#.#####.#.#################.#####.#.#.#.#.#####.#.###.#.#.#.#######v###.#.#.#.###.#.#.#.#.#.###v###
	                        #.......#.....#...#.#...#.#...#.........#.#.....#...#...#...###.....#...#...#.#.#.#.#...#.#...#...#.#.#.......#...#.#...#...#.#...#.#.#...###
	                        #######.###########.###.#.###.#########.#.#####.#####.#.#.#.###.###.###.#.###.#.#.#.#.#.#v###.#####.#.#.#######.###.#####.###.#####.#.#.#####
	                        ###...#.........#...#...#.....###.......#.#...#.#.....#...#.#...###.#...#...#.#.#.#...#.>.>.#...#...#.#...#...#...#.....#.#...#...#.#.#.....#
	                        ###.#.#########.#.###.###########.#######.#.#.#.#.#########.#.#####.#.#####.#.#.#.#######v#.###.#.###.###.#.#.###.#####.#.#.###.#.#.#.#####.#
	                        #...#.#...#.....#.....#####.......#######...#.#.#.........#...#...#...#...#...#...#...###.#...#.#.#...###...#...#.......#...#...#...#.#.....#
	                        #.###.#.#.#.###############.#################.#.#########.#####.#.#####.#.#########.#.###.###.#.#.#.###########.#############.#######.#.#####
	                        #...#...#...#.......#.......#...............#.#.#.........#.....#...#...#.......#...#...#...#.#.#.#.#.....#.....#.....#.....#.........#.....#
	                        ###.#########.#####.#.#######.#############.#.#.#.#########.#######.#.#########.#.#####.###.#.#.#.#.#.###.#.#####.###.#.###.###############.#
	                        #...#.........#.....#.......#.#.....#...#...#...#.........#.#.......#...#.....#.#...#...#...#.#.#.#.#...#.#.......#...#...#...........###...#
	                        #.###.#########.###########.#.#.###.#.#.#.###############.#.#.#########.#.###.#.###.#.###.###.#.#.#.###.#.#########.#####.###########.###.###
	                        #...#.#.........#####.......#.#...#...#.#...#...........#...#.#.....#...#.#...#.....#...#.###...#...###.#...........#####...........#...#.###
	                        ###.#.#.#############.#######.###.#####.###.#.#########.#####.#.###.#.###.#.###########.#.#############.###########################.###.#.###
	                        ###.#.#.#...#.......#.......#...#.....#...#.#.........#.#...#...#...#.....#...........#...#...#...#.....#.........#...###...###.....#...#...#
	                        ###.#.#.#.#v#.#####.#######.###.#####.###.#.#########.#.#.#.#####.###################.#####.#.#.#.#.#####.#######.#.#.###.#.###.#####.#####.#
	                        ###...#...#.>.#...#...#...#.....#...#...#...###.......#...#.....#...#...###...........###...#...#.#.....#.#.......#.#.#...#...#...###.....#.#
	                        ###########v###.#.###.#.#.#######.#.###.#######.###############.###.#.#.###.#############.#######.#####.#.#.#######.#.#.#####.###.#######.#.#
	                        #...........#...#.....#.#.###.....#...#...#...#...#.....#.....#...#.#.#...#...#.....#.....#.......#####...#...#...#.#.#.....#...#.....#...#.#
	                        #.###########.#########.#.###.#######.###.#.#.###.#.###.#.###.###.#.#.###.###v#.###.#.#####.#################.#.#.#.#.#####.###.#####.#.###.#
	                        #...........#.#...#.....#...#.......#.#...#.#.###...#...#.###...#...#...#.#.>.>.#...#...#...###...###...#...#...#...#.#...#...#.#.....#.....#
	                        ###########.#.#.#.#.#######.#######.#.#.###.#.#######.###.#####.#######.#.#.#v###.#####.#.#####.#.###.#.#.#.#########.#.#.###.#.#.###########
	                        #...#.......#.#.#.#...#.....#.......#...#...#.#...#...#...#.....#.....#.#.#.#.###.....#.#.....#.#...#.#.#.#.#.........#.#.#...#.#...........#
	                        #.#.#.#######.#.#.###.#.#####.###########.###.#.#.#.###.###.#####.###.#.#.#.#.#######.#.#####.#.###.#.#.#.#.#.#########.#.#.###.###########.#
	                        #.#.#.......#...#...#.#.....#.........#...#...#.#.#.....###.....#...#.#.#.#.#.#.....#...#.....#.#...#.#.#.#.#.#.....#...#...###.....#.....#.#
	                        #.#.#######.#######.#.#####.#########.#.###.###.#.#############.###.#.#.#.#.#.#.###.#####.#####.#.###.#.#.#.#v#.###.#.#############.#.###.#.#
	                        #.#.........#...#...#.#.....#...#.....#...#.....#.#.......#.....#...#.#.#.#.#.#.###.....#.#...#.#...#.#.#.#.>.>.#...#.............#.#...#.#.#
	                        #.###########.#.#.###.#.#####.#.#v#######.#######.#.#####.#.#####.###.#.#.#.#.#.#######.#.#.#.#.###.#.#.#.###v###.###############.#.###.#.#.#
	                        #...........#.#.#...#.#...#...#.>.>...###.....#...#...#...#...#...#...#.#.#.#...#####...#.#.#.#...#.#.#.#.###.###.#...#...#.....#.#.#...#...#
	                        ###########.#.#.###.#.###.#.#####v###.#######.#.#####.#.#####v#.###.###.#.#.#########.###.#.#.###.#.#.#.#.###.###.#.#.#.#.#v###.#.#.#.#######
	                        #####...###...#.#...#...#...#.....###...#...#.#.......#.....>.>.###...#.#.#...#...#...###...#.#...#.#.#...#...#...#.#.#.#.>.###...#...###...#
	                        #####.#.#######.#.#####.#####.#########.#.#.#.###############v#######.#.#.###.#.#.#.#########.#.###.#.#####.###.###.#.#.###v#############.#.#
	                        #.....#.........#...#...#...#.....#...#.#.#...###...#.......#.#.....#...#.....#.#...#...###...#.###...###...###.....#.#.###.......#...#...#.#
	                        #.#################.#.###.#.#####.#.#.#.#.#######.#.#.#####.#.#.###.###########.#####.#.###.###.#########.###########.#.#########.#.#.#.###.#
	                        #.#.............###.#.###.#.....#...#.#...###...#.#.#.....#...#...#.....#...#...#.....#...#.....#...#...#...###.....#...#.........#.#.#.#...#
	                        #.#.###########.###.#.###.#####.#####.#######.#.#.#.#####.#######.#####.#.#.#.###.#######.#######.#.#.#.###.###.###.#####.#########.#.#.#.###
	                        #...#.....#...#...#...#...#.....#...#.......#.#.#.#...###.....###.#.....#.#.#.....#.....#.....#...#...#...#.....#...#...#.......#...#...#...#
	                        #####.###.#.#.###.#####.###.#####.#.#######.#.#.#.###.#######.###.#.#####.#.#######.###.#####.#.#########.#######.###.#.#######.#.#########.#
	                        #...#...#.#.#...#...###.#...#...#.#.###.....#.#.#...#.#.......#...#.#...#.#.....###...#.......#.........#.....#...###.#.........#.#...#.....#
	                        #.#.###.#.#.###.###.###.#.###.#.#.#.###v#####.#.###.#.#v#######.###.#.#.#.#####.#####.#################.#####.#.#####.###########.#.#.#.#####
	                        #.#.###.#...#...#...#...#...#.#.#.#.#.>.>...#.#.#...#.>.>...#...#...#.#.#.#.....#...#.....#.....#...###.....#.#.....#...#.....###.#.#...#####
	                        #.#.###.#####.###.###.#####.#.#.#.#.#.#####.#.#.#.#########.#.###.###.#.#.#.#####.#.#####.#.###.#.#.#######.#.#####.###.#.###.###.#.#########
	                        #.#.....#...#.....###...###.#.#.#.#.#...#...#.#.#.###...#...#.###...#.#.#.#.#...#.#.......#.#...#.#...#.....#.......###.#.###.....#...#...###
	                        #.#######.#.###########.###.#.#.#.#.###.#.###.#.#.###.#.#.###.#####.#.#.#.#.#.#.#.#########.#.###.###.#.###############.#.###########.#.#.###
	                        #.#.....#.#.#.....#...#...#.#.#.#.#...#.#.#...#.#...#.#.#...#.....#...#...#.#.#.#.....#...#.#.###.#...#.....#...#.....#...#.........#...#...#
	                        #.#.###.#.#.#.###.#.#.###.#.#.#.#.###.#.#.#.###.###.#.#.###.#####.#########.#.#.#####.#.#.#.#.###.#.#######v#.#.#.###.#####.#######.#######.#
	                        #.#.###...#...#...#.#.#...#.#.#.#...#.#.#.#.###...#.#.#.....#...#...#.......#.#.#...#...#.#.#...#.#...#...>.>.#...#...#.....#...###.........#
	                        #.#.###########.###.#.#.###.#.#.###.#.#.#.#.#####.#.#.#######.#.###.#.#######.#.#.#.#####v#.###.#.###.#.###########.###.#####.#.#############
	                        #...###.......#...#.#.#...#...#.#...#...#...#.....#.#...#...#.#.#...#.......#.#.#.#.#...>.>.###.#.#...#...#.........###.#...#.#.........#...#
	                        #######.#####.###.#.#.###.#####.#.###########.#####.###.#.#.#.#.#.#########.#.#.#.#.#.#########.#.#.#####.#.###########.#.#.#.#########.#.#.#
	                        #.......#...#.....#.#.#...#.....#...........#.....#.#...#.#.#.#.#...#.......#.#.#.#.#.....#.....#.#...#...#.......#...#...#...#.........#.#.#
	                        #.#######.#.#######.#.#.###.###############.#####.#.#.###.#.#.#.###.#.#######.#.#.#.#####.#.#####.###.#.#########.#.#.#########.#########.#.#
	                        #.#.......#.#.....#.#.#...#.#...#.....#...#.###...#.#...#.#.#.#...#.#...#...#.#...#.#.....#.....#.#...#.#.........#.#.###...###.......#...#.#
	                        #.#.#######.#.###.#.#.###.#.#.#.#.###.#.#.#.###.###.###.#.#.#.###.#.###.#.#.#.#####.#.#########.#.#.###.#.#########.#.###.#.#########v#.###.#
	                        #.#.#.......#...#.#.#...#.#.#.#.#.###.#.#.#...#.#...#...#.#.#...#.#.###.#.#.#.....#.#.....#.....#.#...#.#...#...#...#.#...#...#...#.>.#...#.#
	                        #.#.#.#########.#.#.###.#.#.#.#.#.###.#.#.###.#.#.###.###.#.###.#.#.###.#.#.#####.#.#####.#.#####.###.#.###.#.#.#.###.#.#####.#.#.#.#v###.#.#
	                        #...#...........#...###...#...#...###...#.....#...###.....#.....#...###...#.......#.......#.......###...###...#...###...#####...#...#.....#.#
	                        ###########################################################################################################################################.#
	                      """;
}