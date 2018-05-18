using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicPic
{
    class GraphicPic
    {
        public SinglyLinkedList ListOfFigures = new SinglyLinkedList();

        public GraphicPic(string filename)
        {
            var lines = File.ReadAllLines($"{filename}.txt");
            foreach (var line in lines)
            {
                var splited = line.Split(' ');
                var intSplited = splited.Select(int.Parse).ToArray();
                ListOfFigures.Add(new Figure(intSplited));
            }
        }

        public GraphicPic()
        {

        }

        public void Insert(Figure figure)
        {
            foreach (var item in ListOfFigures)
                if (item.Data.Similar(figure))
                {
                    item.Data = figure;
                    return;
                }
            ListOfFigures.Add(figure);
        }

        public void Delete(int type)
        {
            var current = ListOfFigures.Head;
            while (current != null)
            {
                if ((int)current.Data.Type == type)
                    ListOfFigures.Remove(current.Data);
                current = current.Next;
            }
        }

        public GraphicPic HasSquareBiggerThan(double square)
        {
            var result = new GraphicPic();
            foreach (var item in ListOfFigures)
            {
                if(item.Data.Square > square)
                    result.ListOfFigures.Add(item.Data);
            }

            return result;
        }

        public GraphicPic CommonWith(Figure rectangle)
        {
            var result = new GraphicPic();
            foreach (var item in ListOfFigures)
            {
                if (item.Data.AreIntersected(rectangle))
                    result.ListOfFigures.Add(item.Data);
            }

            return result;
        }

        public void Show()
        {
            foreach (var item in ListOfFigures)
            {
                Console.WriteLine(item.Data);
            }

            Console.WriteLine();
            
        }
        

    }
}
