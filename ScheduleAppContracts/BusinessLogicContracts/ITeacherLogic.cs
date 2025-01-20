﻿using ScheduleAppContracts.BindingModels;
using ScheduleAppContracts.SearchModels;
using ScheduleAppContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppContracts.BusinessLogicContracts
{
    public interface ITeacherLogic
    {
        List<TeacherViewModel>? ReadList(TeacherSearchModel? model);

        TeacherViewModel? ReadElement(TeacherSearchModel model);

        bool Create(TeacherBindingModel model);

        bool Update(TeacherBindingModel model);

        bool Delete(TeacherBindingModel model);
    }
}
