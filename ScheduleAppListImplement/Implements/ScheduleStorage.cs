using ScheduleAppContracts.BindingModels;
using ScheduleAppContracts.SearchModels;
using ScheduleAppContracts.StoragesContracts;
using ScheduleAppContracts.ViewModels;
using ScheduleAppListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppListImplement.Implements
{
    public class ScheduleStorage : IScheduleStorage
    {
        private readonly DataListSingelton _source;

        public ScheduleStorage()
        {
            _source = DataListSingelton.GetInstance();
        }

        public List<ScheduleViewModel> GetFullList()
        {
            var result = new List<ScheduleViewModel>();
            foreach (var schedule in _source.Schedules)
            {
                result.Add(schedule.GetViewModel);
            }
            return result;
        }

        public List<ScheduleViewModel> GetFilteredList(ScheduleSearchModel model)
        {
            var result = new List<ScheduleViewModel>();
            if (model.Date == null && !model.Id.HasValue)
            {
                return result;
            }
            foreach (var schedule in _source.Schedules)
            {
                if ((model.Date.HasValue && schedule.Date.Date == model.Date.Value.Date) ||
                    (model.Id.HasValue && schedule.Id == model.Id))
                {
                    result.Add(schedule.GetViewModel);
                }
            }
            return result;
        }

        public ScheduleViewModel? GetElement(ScheduleSearchModel model)
        {
            if (model.Date == null && !model.Id.HasValue)
            {
                return null;
            }
            foreach (var schedule in _source.Schedules)
            {
                if ((model.Date.HasValue && schedule.Date.Date == model.Date.Value.Date) ||
                    (model.Id.HasValue && schedule.Id == model.Id))
                {
                    return schedule.GetViewModel;
                }
            }
            return null;
        }

        public ScheduleViewModel? Insert(ScheduleBindingModel model)
        {
            model.Id = 1;
            foreach (var schedule in _source.Schedules)
            {
                if (model.Id <= schedule.Id)
                {
                    model.Id = schedule.Id + 1;
                }
            }
            var newSchedule = Schedule.Create(model);
            if (newSchedule == null)
            {
                return null;
            }
            _source.Schedules.Add(newSchedule);
            return newSchedule.GetViewModel;
        }

        public ScheduleViewModel? Update(ScheduleBindingModel model)
        {
            foreach (var schedule in _source.Schedules)
            {
                if (schedule.Id == model.Id)
                {
                    schedule.Update(model);
                    return schedule.GetViewModel;
                }
            }
            return null;
        }

        public ScheduleViewModel? Delete(ScheduleBindingModel model)
        {
            for (int i = 0; i < _source.Schedules.Count; ++i)
            {
                if (_source.Schedules[i].Id == model.Id)
                {
                    var element = _source.Schedules[i];
                    _source.Schedules.RemoveAt(i);
                    return element.GetViewModel;
                }
            }
            return null;
        }
    }
}
