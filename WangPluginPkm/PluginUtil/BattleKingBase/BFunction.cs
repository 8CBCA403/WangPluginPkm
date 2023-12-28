namespace WangPluginPkm.PluginUtil.BattleKingBase
{
    public class BFuction
    {
        public static string GetString(string longString, string startMarker, string endMarker)
        {
            int startIndex = longString.IndexOf(startMarker);
            int endIndex = longString.IndexOf(endMarker);
            string extractedString = "";
            if (startIndex != -1 && endIndex != -1)
            {
                startIndex += startMarker.Length;
                extractedString = longString.Substring(startIndex, endIndex - startIndex);

            }
            int lastSlashIndex = extractedString.LastIndexOf('/');
            if (lastSlashIndex != -1)
            {
                int secondLastSlashIndex = extractedString.LastIndexOf('/', lastSlashIndex - 1);
                if (secondLastSlashIndex != -1)
                {
                    string extracted = extractedString.Substring(secondLastSlashIndex + 1, lastSlashIndex - secondLastSlashIndex - 1);
                    return extracted;
                }
                else return "";
            }
            else return "";
        }

        public static string DeleStringEnd(string originalString, string substring)
        {
            int index = originalString.IndexOf(substring);

            if (index >= 0)
            {
                string result = originalString.Replace(originalString.Substring(index), "");

                return result;
            }
            else
            {
                return "";
            }

        }
        public static string DeleStringStart(string originalString, string substring)
        {
            int startIndex = originalString.IndexOf(substring);
            string result = originalString.Substring(startIndex + substring.Length);
            return result;
        }
    }
}
