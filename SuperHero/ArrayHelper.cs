namespace SuperHero
{
    public static class ArrayHelper
    {

        public static T[] Append<T>(this T[] array, T item)
        {
            List<T> list = new List<T>(array);
            list.Add(item);

            return list.ToArray();
        }


        public static T[] Remove<T>(this T[] array, int position)
        {
            List<T> list = new List<T>(array);
            list.RemoveAt(position);

            return list.ToArray();
        }

    }
}
