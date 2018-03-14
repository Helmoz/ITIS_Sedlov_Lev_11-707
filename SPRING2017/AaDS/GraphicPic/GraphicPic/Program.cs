using System;

namespace GraphicPic
{
    class Program
    {
        static void Main()
        {
            var picture = new GraphicPic("input");

            picture.Show();

            picture.Insert(new Figure(1, 1, 1, 5, 5, 333333));

            picture.Show();

            var newPicture = picture.CommonWith(new Figure(1, 0, 3, 3, 0, 111111));
            newPicture.Show();

            newPicture.Delete(1);
            newPicture.Show();

            var secondPicture = newPicture.HasSquareBiggerThan(10);

            secondPicture.Show();

        }
    }
}
