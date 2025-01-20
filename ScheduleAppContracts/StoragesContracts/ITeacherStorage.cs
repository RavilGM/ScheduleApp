﻿using ScheduleAppContracts.BindingModels;
using ScheduleAppContracts.SearchModels;
using ScheduleAppContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppContracts.StoragesContracts
{
    public interface ITeacherStorage
    {
        List<TeacherViewModel> GetFullList();

        List<TeacherViewModel> GetFilteredList(TeacherSearchModel model);

        TeacherViewModel? GetElement(TeacherSearchModel model);

        TeacherViewModel? Insert(TeacherBindingModel model);

        TeacherViewModel? Update(TeacherBindingModel model);

        TeacherViewModel? Delete(TeacherBindingModel model);
    }
}
