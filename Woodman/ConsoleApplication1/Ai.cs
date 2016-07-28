using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication1
{
    public class Ai
    {
        public List<List<int>> edges;
        public Inhabitant Inhabitant;
        public Forest forest;

        public Ai(Inhabitant inh, Forest forest)
        {
            Inhabitant = inh;
            edges = new List<List<int>>();
            for (int i = 0; i <= Inhabitant.Location.Y; i++)
                edges.Add(new List<int>());
            this.forest = forest;
        }

        public static List<CommandMove> directions = new List<CommandMove>()
        {
            new Up(),
            new Right(),
            new Down(),
            new Left()
        };

        public bool FindWay()
        {
            DFS(Inhabitant.Location, forest.Target);
            return come;
        }

        public Stack<CommandMove> route = new Stack<CommandMove>();
        public bool come = false;
        public void DFS(Vector start, Vector finish)
        {
            WeightMap(start);
            edges[start.Y][start.X] = 1;
            Vector cell;
            CommandMove currentDirection;
            foreach (var direction in directions)
            {
                cell = NextCell(direction);
                if (edges[cell.Y][cell.X] == 0 && !come)
                {
                    if (!forest.MoveInhabitant(Inhabitant, direction))
                    {
                        edges[cell.Y][cell.X] = 1;
                        continue;
                    }
                    route.Push(direction);
                    if (cell.Equals(finish))
                        come = true;
                    DFS(cell, finish);
                    if (come)
                        return;
                    currentDirection = route.Pop();
                    forest.MoveInhabitant(Inhabitant, FindReverseDirection(currentDirection));
                }
            }
        }

        private CommandMove FindReverseDirection(CommandMove command)
        {
            var c = command.Direction();
            var reverseDirection = c.X != 0
                ? (c.X == 1 ? new Vector(-1, 0) : new Vector(1, 0))
                : (c.Y == 1 ? new Vector(0, -1) : new Vector(0, 1));
            if (reverseDirection.Equals(new Up().Direction()))
                return new Up();
            if (reverseDirection.Equals(new Down().Direction()))
                return new Down();
            if (reverseDirection.Equals(new Right().Direction()))
                return new Right();
            return new Left();
        }

        public Vector NextCell(CommandMove direction)
        {
            Vector cell = Inhabitant.Location.Add(direction.Direction());
            WeightMap(cell);
            return cell;
        }
        private void WeightMap(Vector cell)
        {
            if (edges.Count <= cell.Y)
            {
                edges.Add(new List<int>(Inhabitant.Location.X));
            }
            while (edges[cell.Y].Count <= cell.X)
            {
                edges[cell.Y].Add(0);
            }
        }
    }
}
