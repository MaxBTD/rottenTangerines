namespace rottenTangerines
{
    internal class Program
    {
        static int rotCheck(string[] box, int rows, int cols)
        {
            int hourglassCount = 0;
            while (box.Contains("1"))
            {
                string[] compare = new string[box.Length];
                box.CopyTo(compare, 0);
                for (int i = 0; i < box.Length; i++)
                {
                    /* 
                        l - left
                        r - right
                        t - top
                        b - bottom

                        m - middle
                    */
                    string whatSpot = "";
                    switch ((i+1) % cols)
                    {
                        case 1:
                            whatSpot += "l";
                            break;
                        case 0:
                            whatSpot += "r";
                            break;
                        default:
                            whatSpot += "m";
                            break;
                    }
                    if ((i + 1) <= rows)
                        whatSpot += "t";
                    else if ((i + 1) > (rows * (cols - 1)))
                        whatSpot += "b";
                    else
                        whatSpot += "m";

                    if (box[i] == "1" || box[i] == "2")
                    {
                        switch (whatSpot)
                        {
                            case "lt":
                                if (box[i + 1] == "0" && box[i + rows] == "0")
                                    return -1;
                                if (compare[i] == "2")
                                {
                                    if (compare[i + 1] == "1")
                                        box[i + 1] = "2";
                                    if (compare[i + rows] == "1")
                                        box[i + rows] = "2";
                                }
                                break;
                            case "rt":
                                if (box[i - 1] == "0" && box[i + rows] == "0")
                                    return -1;
                                if (box[i] == "2")
                                {
                                    if (compare[i - 1] == "1")
                                        box[i - 1] = "2";
                                    if (compare[i + rows] == "1")
                                        box[i + rows] = "2";
                                }
                                break;
                            case "lb":
                                if (box[i + 1] == "0" && box[i - rows] == "0")
                                    return -1;
                                if (compare[i] == "2")
                                {
                                    if (compare[i + 1] == "1")
                                        box[i + 1] = "2";
                                    if (compare[i - rows] == "1")
                                        box[i - rows] = "2";
                                }
                                break;
                            case "rb":
                                if (box[i - 1] == "0" && box[i - rows] == "0")
                                    return -1;
                                if (compare[i] == "2")
                                {
                                    if (compare[i - 1] == "1")
                                        box[i - 1] = "2";
                                    if (compare[i - rows] == "1")
                                        box[i - rows] = "2";
                                }
                                break;
                            case "mt":
                                if (box[i + 1] == "0" && box[i + rows] == "0" && box[i - 1] == "0")
                                    return -1;
                                if (box[i] == "2")
                                {
                                    if (box[i + 1] == "1")
                                        box[i + 1] = "2";
                                    if (box[i + rows] == "1")
                                        box[i + rows] = "2";
                                    if (box[i - 1] == "1")
                                        box[i - 1] = "2";
                                }
                                break;
                            case "mb":
                                if (box[i + 1] == "0" && box[i - rows] == "0" && box[i - 1] == "0")
                                    return -1;
                                if (compare[i] == "2")
                                {
                                    if (compare[i + 1] == "1")
                                        box[i + 1] = "2";
                                    if (compare[i - rows] == "1")
                                        box[i - rows] = "2";
                                    if (compare[i - 1] == "1")
                                        box[i - 1] = "2";
                                }
                                break;
                            case "lm":
                                if (box[i + 1] == "0" && box[i + rows] == "0" && box[i - rows] == "0")
                                    return -1;
                                if (compare[i] == "2")
                                {
                                    if (compare[i + 1] == "1")
                                        box[i + 1] = "2";
                                    if (compare[i + rows] == "1")
                                        box[i + rows] = "2";
                                    if (compare[i - rows] == "1")
                                        box[i - rows] = "2";
                                }
                                break;
                            case "rm":
                                if (box[i - 1] == "0" && box[i + rows] == "0" && box[i - rows] == "0")
                                    return -1;
                                if (compare[i] == "2")
                                {
                                    if (compare[i - 1] == "1")
                                        box[i - 1] = "2";
                                    if (compare[i + rows] == "1")
                                        box[i + rows] = "2";
                                    if (compare[i - rows] == "1")
                                        box[i - rows] = "2";
                                }
                                break;
                            default:
                                if (box[i + 1] == "0" && box[i + rows] == "0" && box[i - rows] == "0" && box[i - 1] == "0")
                                    return -1;
                                if (compare[i] == "2")
                                {
                                    if (compare[i + 1] == "1")
                                        box[i + 1] = "2";
                                    if (compare[i + rows] == "1")
                                        box[i + rows] = "2";
                                    if (compare[i - 1] == "1")
                                        box[i - 1] = "2";
                                    if (compare[i - rows] == "1")
                                        box[i - rows] = "2";
                                }
                                break;
                        }
                    }
                }
                hourglassCount++;
            }

            return hourglassCount + 1;
        }

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            input = Console.ReadLine().Split(' ');

            Console.WriteLine(rotCheck(input, n, m));
        }
    }
}
