using Microsoft.Extensions.Logging;
using ScheduleAppContracts.BindingModels;
using ScheduleAppContracts.BusinessLogicContracts;
using ScheduleAppContracts.SearchModels;
using ScheduleAppContracts.StoragesContracts;
using ScheduleAppContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppBusinessLogic.BusinessLogics
{
    public class TeacherLogic : ITeacherLogic
    {
        private readonly ILogger _logger;
        private readonly ITeacherStorage _teacherStorage;

        public TeacherLogic(ILogger<TeacherLogic> logger, ITeacherStorage teacherStorage)
        {
            _logger = logger;
            _teacherStorage = teacherStorage;
        }

        public List<TeacherViewModel>? ReadList(TeacherSearchModel? model)
        {
            _logger.LogInformation("ReadList. TeacherName:{TeacherName}. Id:{Id}", model?.TeacherName, model?.Id);
            var list = model == null ? _teacherStorage.GetFullList() : _teacherStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        public TeacherViewModel? ReadElement(TeacherSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. TeacherName:{TeacherName}. Id:{Id}", model.TeacherName, model.Id);
            var element = _teacherStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }

        public bool Create(TeacherBindingModel model)
        {
            CheckModel(model);
            if (_teacherStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public bool Update(TeacherBindingModel model)
        {
            CheckModel(model);
            if (_teacherStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }

        public bool Delete(TeacherBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_teacherStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }

        private void CheckModel(TeacherBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.TeacherName))
            {
                throw new ArgumentNullException("Нет имени преподавателя", nameof(model.TeacherName));
            }
            _logger.LogInformation("Teacher. TeacherName:{TeacherName}. Id:{Id}", model.TeacherName, model.Id);
            var element = _teacherStorage.GetElement(new TeacherSearchModel
            {
                TeacherName = model.TeacherName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Преподаватель с таким именем уже есть");
            }
        }
    }
}
