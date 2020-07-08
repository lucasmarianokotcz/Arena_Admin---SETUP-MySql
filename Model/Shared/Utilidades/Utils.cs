using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Model.Shared.Utilidades
{
    public static class Utils
    {
        public static string GetEnumDescription<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() as DescriptionAttribute;

                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }

            return string.Empty;
        }

        public static void BindComboBoxWithEnumDescription<T>(ComboBox comboBox)
        {
            comboBox.DisplayMember = "Description";
            comboBox.ValueMember = "Value";

            comboBox.Items.AddRange(Enum.GetValues(typeof(T))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToArray());
        }

        public static void Test<T>(this ComboBox comboBox)
        {
            var list = Enum.GetValues(typeof(T))
        .Cast<T>()
        .Select(value => new
        {
            Description = (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute)?.Description ?? value.ToString(),
            Value = value
        })
        .OrderBy(item => item.Value.ToString())
        .ToList();

            comboBox.DataSource = list;
            comboBox.DisplayMember = "Description";
            comboBox.ValueMember = "Value";
        }
    }
}
