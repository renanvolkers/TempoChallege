using System.Reflection;

namespace Tempo.Common.Setup.Util.Extension
{
    public static class EnumExtensions
    {
        /// <summary>
        /// It is used in Enum's dataanotation to facilitate the use of description
        /// </summary>
        public static string GetInfo(this Enum element)
        {
            FieldInfo elementInfo = element.GetType().GetField(element.ToString())!;

            var attributes = (DescriptionAttribute[])elementInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                if (attributes[0].Description != null)
                    return attributes[0].Description;
                else
                    return "Sem descrição";    
            }
            else
                return element.ToString();
        }
    }
}
