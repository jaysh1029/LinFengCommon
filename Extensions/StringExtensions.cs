using System.Text.RegularExpressions;

namespace LinFeng.Common.Extensions {
    /// <summary>
    ///     String类的扩展
    /// </summary>
    public static class StringExtensions {

        private static readonly Regex splitNameRegex;

        private static readonly Regex properWordRegex;

        private static readonly Regex identifierRegex;

        private static readonly Regex htmlIdentifierRegex;

        private static readonly Regex whiteSpace;

        private const string link = "<a href=\"{0}\">{1}</a>";

        private const string linkWithRel = "<a href=\"{0}\" rel=\"{1}\">{2}</a>";

        

        

        static StringExtensions() {

            splitNameRegex = new Regex("[\\W_]+");
            properWordRegex = new Regex("([A-Z][a-z]*)|([0-9]+)");
            identifierRegex = new Regex("[^\\p{Ll}\\p{Lu}\\p{Lt}\\p{Lo}\\p{Nd}\\p{Nl}\\p{Mn}\\p{Mc}\\p{Cf}\\p{Pc}\\p{Lm}]");
            htmlIdentifierRegex= new Regex("[^A-Za-z0-9-_:\\.]");
            whiteSpace = new Regex("\\s");
            


        }



        /// <summary>
        ///     <para>模拟Javascript中的substring函数</para>
        ///     <para>C#中的substring第二个参数是截取个数，javascript中的substring第二个参数是截取的末尾索引</para>
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <param name="startIndex">开始索引</param>
        /// <param name="endIndex">结尾索引</param>
        /// <returns></returns>
        public static string JsSubString(this string str, int startIndex, int endIndex) {
            var result = string.Empty;
            //若startIndex和endIndex 同时为负 或相等 或同时大于字符串长度则返回空
            if (startIndex == endIndex || startIndex < 0 && endIndex < 0 ||
                startIndex > str.Length && endIndex > str.Length) {
                return result;
            }

            //若start 大于 end  则交换他们的值
            if (startIndex > endIndex) {
                var temp = endIndex;
                startIndex = endIndex;
                endIndex = temp;
            }

            //若 start为负 则将start置零
            if (startIndex < 0) {
                startIndex = 0;
            }

            //如果截取的长度超过startIndex后的长度，则截取到末尾即可
            var subLen = endIndex - startIndex;
            if (subLen > str.Length - startIndex) {
                result = str.Substring(startIndex);
            }
            else {
                result = str.Substring(startIndex, subLen);
            }

            return result;
        }
    }
}