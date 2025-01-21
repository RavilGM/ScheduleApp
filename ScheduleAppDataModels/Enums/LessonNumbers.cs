using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppDataModels.Enums
{
    public enum LessonNumbers
    {
        Неназначено,
        [Description("Первая пара")]
        Первая_Пара,
        [Description("Вторая пара")]
        Вторая_Пара,
        [Description("Третья пара")]
        Третья_Пара,
        [Description("Четвертая пара")]
        Четвертая_Пара,
        [Description("Пятая пара")]
        Пятая_Пара,
        [Description("Шетсая пара")]
        Шестая_Пара,
        [Description("Седьмая пара")]
        Седьмая_Пара
        
    }
}
