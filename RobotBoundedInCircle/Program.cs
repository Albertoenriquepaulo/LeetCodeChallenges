using System;
using System.Collections.Generic;

namespace RobotBoundedInCircle
{
    class Program
    {
        static void Main(string[] args)
        {
            string instructions = "GGGLGGLGGRGG";
            Solution sol = new Solution();
            bool result = sol.IsRobotBounded(instructions);
        }
    }

    public class Solution
    {
        public bool IsRobotBounded(string instructions)
        {
            Coordinate currentCoordinates = new Coordinate(0, 0);
            Movement movement = new Movement();
            movement.SetNext();
            int j = 0;
            while (j < 4)
            {
                for (int i = 0; i < instructions.Length; i++)
                {
                    string instruction = instructions[i].ToString();
                    if (instruction == "G")
                    {
                        Move(currentCoordinates, movement.Next);
                        movement.Current = movement.Next;
                    }
                    else
                    {
                        movement.Rotation = instruction;
                        movement.SetNext();
                        movement.Current = movement.Next;
                    }
                }
                if (currentCoordinates.X == 0 && currentCoordinates.Y == 0)
                {
                    j = 4;
                    return true;
                }
                j++;
            }
            if (currentCoordinates == new Coordinate(0, 0))
            {
                return true;
            }
            return false;
        }
        private void Move(Coordinate coordinate, string nextMovement)
        {
            switch (nextMovement)
            {
                case "up":
                    coordinate.AddOneToY();
                    break;
                case "down":
                    coordinate.SubstractOneToY();
                    break;
                case "left":
                    coordinate.SubstractOneToX();
                    break;
                case "right":
                    coordinate.AddOneToX();
                    break;
                default:
                    break;
            }
        }
    }

    class Movement
    {
        public string Current { get; set; }
        public string Rotation { get; set; }
        public string Next { get; set; }
        public void SetNext()
        {
            if (Current == null)
            {
                Next = "up";
                return;
            }
            if (Current == "up")
            {
                if (Rotation == "L")
                {
                    Next = "left";
                    return;
                }
                Next = "right";
            }
            else if (Current == "right")
            {
                if (Rotation == "L")
                {
                    Next = "up";
                    return;
                }
                Next = "down";
            }

            if (Current == "down")
            {
                if (Rotation == "L")
                {
                    Next = "right";
                    return;
                }
                Next = "left";
            }
            else if (Current == "left")
            {
                if (Rotation == "L")
                {
                    Next = "down";
                    return;
                }
                Next = "up";
            }
        }
    }

    class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Coordinate()
        {
        }

        public void AddOneToX()
        {
            X++;
        }
        public void SubstractOneToX()
        {
            X--;
        }
        public void AddOneToY()
        {
            Y++;
        }
        public void SubstractOneToY()
        {
            Y--;
        }

    }
}
