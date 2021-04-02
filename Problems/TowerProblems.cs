using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingProblems
{
    public class TowerProblems
    {
        /// <summary>
        /// The skyline of a city is composed of several buildings of various widths and heights,
        /// possibly overlapping one another when viewed from a distance.
        /// We can represent the buildings using an array of (left, right, height) tuples,
        /// which tell us where on an imaginary x-axis a building begins and ends, and how tall it is.
        /// The skyline itself can be described by a list of (x, height) tuples,
        /// giving the locations at which the height visible to a distant observer changes, and each new height.
        ///
        /// suppose the input consists of the buildings [(0, 15, 3), (4, 11, 5), (19, 23, 4)]. In aggregate, these buildings would create a skyline that looks like the one below.
        ///         ______  
        ///        |      |        ___
        ///     ___|      |___    |   | 
        ///    |   |   B  |   |   | C |
        ///    | A |      | A |   |   |
        ///    |   |      |   |   |   |
        ///    ------------------------
        ///    As a result, your function should return [(0, 3), (4, 5), (11, 3), (15, 0), (19, 4), (23, 0)]
        /// </summary>
        public TowerProblems()
        {
            List<Tuple<int, int, int>> towerCoordinates = new List<Tuple<int, int, int>>();
            towerCoordinates.Add(new Tuple<int, int, int>(0, 15, 3));
            towerCoordinates.Add(new Tuple<int, int, int>(4, 11, 5));
            towerCoordinates.Add(new Tuple<int, int, int>(19, 23, 4));
            SolveProblem(towerCoordinates);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="towerCoordinates">tuple types are
        /// 1st - left
        /// 2nd - right
        /// 3rd - height
        /// </param>
        public void SolveProblem(List<Tuple<int, int, int>> towerCoordinates)
        {
            ///tuple types
            ///1st - x co-ordinate
            ///2nd - height
            List<Tuple<int, int>> skylineCoordinates = new List<Tuple<int, int>>();
            int minleft = towerCoordinates.First().Item1;
            int maxright = towerCoordinates.Last().Item2;
            for (int i = minleft; i <= maxright; i++)
            {
                //If `i` is on left or in between right then take max height wchich comes
                //If `i` is on right then take minimum of found co-ordinates if only one co-ordinate found then take 0
                //when to add in skylineCoordinates;
                // 1. When it is empty or when last co-ordinate's height does not match with current co-ordinate's height
                Tuple<int, int> tupleData = new Tuple<int, int>(i, ReturnHeight(towerCoordinates, i));
                if (skylineCoordinates.Count == 0 || skylineCoordinates.Last().Item2 != tupleData.Item2)
                {
                    skylineCoordinates.Add(tupleData);
                }
            }
        }

        private int ReturnHeight(List<Tuple<int, int, int>> towerCoordinates, int xCoordinate)
        {
            List<Tuple<int, int, int>> sortedCoordinates = (from tco in towerCoordinates
                                                            where tco.Item1 == xCoordinate || (tco.Item2 > xCoordinate && tco.Item1 <= xCoordinate)
                                                            select tco).ToList();
            if (sortedCoordinates?.Count > 0)
            {
                return sortedCoordinates.Max(x => x.Item3);
            }
            else
            {
                sortedCoordinates = (from tco in towerCoordinates
                                     where tco.Item2 == xCoordinate
                                     select tco).ToList();
                if (sortedCoordinates?.Count > 1)
                {
                    return sortedCoordinates.Min(x => x.Item3);
                }
            }
            return 0;
        }
    }
}
